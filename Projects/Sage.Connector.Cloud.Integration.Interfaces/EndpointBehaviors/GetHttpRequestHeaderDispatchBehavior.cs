using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Sage.Connector.Cloud.Integration.Interfaces.MessageInspectors;

namespace Sage.Connector.Cloud.Integration.Interfaces.EndpointBehaviors
{
    public class GetHttpRequestHeaderDispatchBehavior : IEndpointBehavior
    {
        #region Constructors

        /// <summary>
        /// Default constructor is private
        /// </summary>
        private GetHttpRequestHeaderDispatchBehavior() { }

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="getPremiseKeyMethod"></param>
        /// <param name="checkTenantDisabledMethod"></param>
        /// <param name="checkRetiredEndpointMethod"></param>
        /// <param name="checkIncompatibleClientMethod"></param>
        /// <param name="logger"></param>
        public GetHttpRequestHeaderDispatchBehavior(
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


        #region IEndpointBehavior Implementation
        
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        { }

        public void Validate(ServiceEndpoint endpoint)
        { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
                new GetHttpRequestHeaderDispatchInspector(
                    _getPremiseKeyMethod,
                    _checkTenantDisabledMethod,
                    _checkRetiredEndpointMethod,
                    _checkIncompatibleClientMethod,
                    _logger));
        }

        #endregion
    }
}
