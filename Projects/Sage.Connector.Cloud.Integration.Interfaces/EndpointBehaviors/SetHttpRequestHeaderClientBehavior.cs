using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.MessageInspectors;

namespace Sage.Connector.Cloud.Integration.Interfaces.EndpointBehaviors
{
    public class SetHttpRequestHeaderClientBehavior : IEndpointBehavior
    {
        #region Constructors

        /// <summary>
        /// Default constructor is private
        /// </summary>
        private SetHttpRequestHeaderClientBehavior() { }

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="premiseKey"></param>
        /// <param name="premiseAgent"></param>
        /// <param name="logger"></param>
        public SetHttpRequestHeaderClientBehavior(
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
        private readonly PremiseAgent _premiseAgent;
        private readonly MessageLogger _logger;

        #endregion


        #region IEndpointBehavior Implementation
        
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        { 
            clientRuntime.MessageInspectors.Add(
                new SetHttpRequestHeaderClientInspector(_tenantId, _premiseKey, _premiseAgent, _logger)); 
        }

        public void Validate(ServiceEndpoint endpoint)
        { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        { }

        #endregion
    }
}
