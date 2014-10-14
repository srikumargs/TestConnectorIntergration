using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Headers;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.MessageInspectors
{
    public class SetHttpRequestHeaderClientInspector : IClientMessageInspector
    {
        #region Constructors

        /// <summary>
        /// Default constructor is private
        /// </summary>
        private SetHttpRequestHeaderClientInspector() { }

        /// <summary>
        /// Fully-speciied constructor
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="premiseKey"></param>
        /// <param name="premiseAgent"></param>
        /// <param name="logger"></param>
        public SetHttpRequestHeaderClientInspector(
            String tenantId, string premiseKey, PremiseAgent premiseAgent, MessageLogger logger)
        {
            _tenantId = tenantId;
            _premiseKey = premiseKey;
            _premiseAgent = premiseAgent;
            _logger = logger;
        }

        #endregion


        #region Private Members

        private readonly String _tenantId;
        private readonly string _premiseKey;
        private readonly MessageLogger _logger;
        private readonly PremiseAgent _premiseAgent;

        #endregion


        #region IClientMessageInspector Implementation

        public object BeforeSendRequest(
            ref System.ServiceModel.Channels.Message request, 
            System.ServiceModel.IClientChannel channel)
        {
            // Log the request before it goes out
            if (_logger != null)
            {
                // Only log if the system variable SAGE_CONNECTOR_LOG_REQUEST_RESPONSE is set to 1
                String logRequestResponse = Environment.GetEnvironmentVariable("SAGE_CONNECTOR_LOG_REQUEST_RESPONSE", EnvironmentVariableTarget.Machine);
                Boolean bLogRequestResponse = (!String.IsNullOrEmpty(logRequestResponse) && logRequestResponse == "1");
                if (bLogRequestResponse)
                    _logger(request.ToString());
            }

            HttpRequestMessageProperty httpRequest;
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            }
            else
            {
                httpRequest = new HttpRequestMessageProperty();
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequest);
            }

            // Get the request body
            string requestBody = MessageInspectorHelper.GetRequestBody(request);

            // Create the message hash
            var messageHashManager = new MessageHashManager(_premiseKey);
            var messageHash = messageHashManager.ComputeMessageHash(requestBody);

            // Get the serialized version of the premise agent
            string serializedPremiseAgent = SerializationHelper.Serialize<PremiseAgent>(_premiseAgent);

            // Add the header values
            httpRequest.Headers.Add(
                HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.TenantId], _tenantId);
            httpRequest.Headers.Add(
                HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.MessageHash], messageHash);
            httpRequest.Headers.Add(
                HeaderCommon.ServiceHeaderKeys[ServiceHeaderKeyTypes.PremiseAgent], serializedPremiseAgent);

            // Log all the http header values
            if (_logger != null)
            {
                for (int headerIndex = 0; headerIndex < httpRequest.Headers.Count; ++headerIndex)
                {
                    _logger(String.Format("Set Http request header '{0}' value '{1}'", 
                        httpRequest.Headers.GetKey(headerIndex),
                        httpRequest.Headers[headerIndex]));
                }
            }

            // Return null since we are required to return an object 
            // In this IClientMessageInspector method
            return null;
        }

        public void AfterReceiveReply(
            ref System.ServiceModel.Channels.Message reply, 
            object correlationState)
        { }

        #endregion
    }
}
