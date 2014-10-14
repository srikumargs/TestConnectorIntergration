using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;
using Sage.Connector.Cloud.Integration.Interfaces.Headers;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.MessageInspectors
{
    /// <summary>
    /// Delegate to get the corresponding premise key for the tenant
    /// This method will vary based on service implementation
    /// </summary>
    /// <param name="tenantId"></param>
    /// <returns></returns>
    public delegate string GetPremiseKeyMethod(Guid tenantId);

    /// <summary>
    /// Delegate to check whether the current tenant is disabled
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="premiseAgent"></param>
    /// <param name="message"></param>
    /// <param name="action"></param>
    /// <returns>true if tenant disabled</returns>
    public delegate bool CheckTenantDisabled(Guid tenantId, PremiseAgent premiseAgent, ref String message, out TenantConnectionDisabledAction action);

    /// <summary>
    /// Delegate to check whether the current endpoint is "retired" or not
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="premiseAgent"></param>
    /// <param name="endpointUri"> </param>
    /// <param name="message"></param>
    /// <param name="newSiteAddressBaseUri"> </param>
    /// <returns>true if endpoint retired</returns>
    public delegate bool CheckRetiredEndpoint(Guid tenantId, PremiseAgent premiseAgent, Uri endpointUri, ref String message, out Uri newSiteAddressBaseUri);

    /// <summary>
    /// Delegate to check whether the current client is compatible with our system
    /// Based on the client's current premise agent info
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="premiseAgent"></param>
    /// <param name="message"></param>
    /// <param name="MiniumInterfaceVersion"></param>
    /// <param name="MiniumConnectorProductVersion"></param>
    /// <param name="CurrentConnectorProductUpgradeInfo"></param>
    /// <returns>true if version incompatible</returns>
    public delegate bool CheckIncompatibleClient(
        Guid tenantId,
        PremiseAgent premiseAgent, 
        ref String message,
        out String MiniumInterfaceVersion, 
        out String MiniumConnectorProductVersion, 
        out UpgradeInfo CurrentConnectorProductUpgradeInfo);

    /// <summary>
    /// Message inspector designed to handle tenant/premise authentication for 
    /// All incoming requests, so that each service method does not have to do it
    /// </summary>
    public class GetHttpRequestHeaderDispatchInspector : IDispatchMessageInspector
    {
        #region Constructors

        /// <summary>
        /// Default constructor is private
        /// </summary>
        private GetHttpRequestHeaderDispatchInspector() { }

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="getPremiseKeyMethod"></param>
        /// <param name="checkTenantDisabledMethod"></param>
        /// <param name="checkRetiredEndpointMethod"></param>
        /// <param name="checkIncompatibleClientMethod"></param>
        /// <param name="logger"></param>
        public GetHttpRequestHeaderDispatchInspector(
            GetPremiseKeyMethod getPremiseKeyMethod, 
            CheckTenantDisabled checkTenantDisabledMethod,
            CheckRetiredEndpoint checkRetiredEndpointMethod,
            CheckIncompatibleClient checkIncompatibleClientMethod,
            MessageLogger logger)
        {
            _getPremiseKeyMethod = getPremiseKeyMethod;
            _checkTenantDisabledMethod = checkTenantDisabledMethod;
            _checkRetiredEndpointMethod = checkRetiredEndpointMethod;
            _checkIncompatibleClientMethod = checkIncompatibleClientMethod;
            _logger = logger;
        }

        #endregion


        #region Private Members

        private readonly GetPremiseKeyMethod _getPremiseKeyMethod;
        private readonly CheckTenantDisabled _checkTenantDisabledMethod;
        private readonly CheckRetiredEndpoint _checkRetiredEndpointMethod;
        private readonly CheckIncompatibleClient _checkIncompatibleClientMethod;
        private readonly MessageLogger _logger;

        #endregion


        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(
            ref System.ServiceModel.Channels.Message request, 
            System.ServiceModel.IClientChannel channel, 
            System.ServiceModel.InstanceContext instanceContext)
        {
            // Log the request as it comes in
            if (_logger != null)
            {
                _logger(request.ToString());
            }

            // Store the authentication result
            // Will only be set if authentication fails
            HttpStatusCode? authenticationState = null;

            // If we use the corresponding client message inspector
            // Then we should be guaranteed that the http request message property exists
            if (request == null || !request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                authenticationState = HttpStatusCode.BadRequest;
            }
            else
            {
                // Get the current endpoint
                Uri endpointUri = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.To;

                // Get the http request property
                HttpRequestMessageProperty httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

                // Get the existing headers
                string headerMessageHash = httpRequest.Headers[HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.MessageHash]];
                string headerTenantId = httpRequest.Headers[HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.TenantId]];
                string premiseAgentString = httpRequest.Headers[HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.PremiseAgent]];

                // If any expected headers are missing, then do not proceed
                if (string.IsNullOrEmpty(headerMessageHash) || 
                    string.IsNullOrEmpty(headerTenantId) ||
                    string.IsNullOrEmpty(premiseAgentString))
                {
                    authenticationState = HttpStatusCode.BadRequest;
                }
                else
                {
                    // Get the guid version of the tenant
                    Guid tenantGuid;
                    Guid.TryParse(headerTenantId, out tenantGuid);
                    if (tenantGuid == null)
                    {
                        authenticationState = HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        // Get the request body
                        string requestBody = MessageInspectorHelper.GetRequestBody(request);
                        if (string.IsNullOrEmpty(requestBody))
                        {
                            authenticationState = HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            // Parse the premise agent object
                            PremiseAgent premiseAgent = null;
                            try
                            {
                                premiseAgent = SerializationHelper.Deserialize<PremiseAgent>(premiseAgentString);
                                if (premiseAgent == null)
                                {
                                    // Empty premise agent is a bad request
                                    authenticationState = HttpStatusCode.BadRequest;
                                }
                            }
                            catch
                            {
                                // Premise agent parse error is a bad request
                                authenticationState = HttpStatusCode.BadRequest;
                            }

                            if (authenticationState == null)
                            {
                                // All relevant info obtained/parsed from the header
                                // Now perform all relevant checks on that data to ensure the incoming message is valid
                                ValidateMessage(tenantGuid, premiseAgent, endpointUri);

                                // All checks passed
                                // Now call the authenticate method
                                authenticationState = AuthenticateMessage(tenantGuid, headerMessageHash, requestBody);
                            }
                        }
                    }
                }
            }

            // If the authentication state is set due to an error
            // Then throw the expected ConnectivityFault
            if (authenticationState != null)
            {
                // Now return the connectivity fault
                ConnectivityFault cf = new ConnectivityFault((HttpStatusCode)authenticationState, CONNECTIVITY_FAULT_MESSAGE);
                throw new FaultException<ConnectivityFault>(cf);
            }

            // Return null in case of success
            // Since we are required to return an object in this IDispatchMessageInspector method
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        { }

        public void ValidateMessage(
            Guid tenantGuid,
            PremiseAgent premiseAgent,
            Uri endpointUri
            )
        {
            // Check that the endpoint has not been retired
            Uri newSiteAddressBaseUri;
            String message = RETIRED_ENDPOINT_FAULT_MESSAGE;
            if (_checkRetiredEndpointMethod(tenantGuid, premiseAgent, endpointUri, ref message, out newSiteAddressBaseUri))
            {
                // Endpoint has been retired
                RetiredEndpointFault repf =
                    new RetiredEndpointFault(message, newSiteAddressBaseUri);
                throw new FaultException<RetiredEndpointFault>(repf);
            }

            // Check that the tenant is valid
            TenantConnectionDisabledAction tenantDisabledAction;
            message = TENANT_CONNECTION_DISABLED_FAULT_MESSAGE;
            if (_checkTenantDisabledMethod(tenantGuid, premiseAgent, ref message, out tenantDisabledAction))
            {
                // Tenant has been disabled
                TenantConnectionDisabledFault tcdf =
                    new TenantConnectionDisabledFault(tenantDisabledAction, message);
                throw new FaultException<TenantConnectionDisabledFault>(tcdf);
            }

            // Check that the client is compatible
            String minumumInterfaceVersion;
            String minimumProductVersion;
            UpgradeInfo currentUpgradeInfo;
            message = INCOMPATIBLE_CLIENT_FAULT_MESSAGE;
            if (_checkIncompatibleClientMethod(tenantGuid, premiseAgent,
                ref message, out minumumInterfaceVersion, out minimumProductVersion, out currentUpgradeInfo))
            {
                // Client version is incompatible
                IncompatibleClientFault icf =
                    new IncompatibleClientFault(
                        message,
                        minumumInterfaceVersion,
                        minimumProductVersion,
                        currentUpgradeInfo);
                throw new FaultException<IncompatibleClientFault>(icf);
            }

        }

        public HttpStatusCode? AuthenticateMessage(
            Guid headerTenantId, 
            string headerMessageHash, 
            string requestBody)
        {
            // Use the passed in delegate to obtain the correct premise key 
            // For the tenant ID in the message header
            string premiseKey = _getPremiseKeyMethod(headerTenantId);

            // No premise key could be found
            // Indicating the tenant ID is bad, or has not had a premise
            // Key generated for it yet
            if (string.IsNullOrEmpty(premiseKey))
            {
                return HttpStatusCode.BadRequest;
            }

            // Create the message hash from the request body
            var messageHashManager = new MessageHashManager(premiseKey);
            var messageHash = messageHashManager.ComputeMessageHash(requestBody);

            // Compare the hashed message just created with the one in the header
            // If the same key was used and the original messages were the same, 
            // Then the two should be equal
            if (!headerMessageHash.Equals(messageHash))
            {
                return HttpStatusCode.Forbidden;
            }

            // Everything passed
            return null;
        }

        #endregion


        #region Private Members

        /// <summary>
        /// The string to use for connectivity faults encountered on the server
        /// </summary>
        private static readonly string CONNECTIVITY_FAULT_MESSAGE = "Connectivity could not be established";

        /// <summary>
        /// The string to use for tenant connection disabled faults encountered
        /// </summary>
        private static readonly string TENANT_CONNECTION_DISABLED_FAULT_MESSAGE = "Tenant connection has been disabled";

        /// <summary>
        /// The string to use for retired endpoint faults encountered
        /// </summary>
        private static readonly string RETIRED_ENDPOINT_FAULT_MESSAGE = "Endpoint has been retired";

        /// <summary>
        /// The string to use for incompatible client faults encountered
        /// </summary>
        private static readonly string INCOMPATIBLE_CLIENT_FAULT_MESSAGE = "Client version is incompatible";

        #endregion
    }
}
