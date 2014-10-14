using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;

namespace Sage.Connector.Cloud.Integration.Proxy
{
    public class RawResponseServiceProxy : ClientBase<IResponseService>, IResponseService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RawResponseServiceProxy()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="behavior"></param>
        public RawResponseServiceProxy(string endpointConfigurationName, IEndpointBehavior behavior = null)
            : base(endpointConfigurationName)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="remoteAddress"></param>
        /// <param name="behavior"></param>
        public RawResponseServiceProxy(string endpointConfigurationName, string remoteAddress, IEndpointBehavior behavior = null)
            : base(endpointConfigurationName, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="remoteAddress"></param>
        /// <param name="behavior"></param>
        public RawResponseServiceProxy(string endpointConfigurationName, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(endpointConfigurationName, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="remoteAddress"></param>
        /// <param name="behavior"></param>
        public RawResponseServiceProxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(binding, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }
        #endregion


        #region IResponseService Members
        public void PutResponses(Response[] responses)
        { base.Channel.PutResponses(responses); }
        #endregion
    }
}
