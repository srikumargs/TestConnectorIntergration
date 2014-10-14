using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;

namespace Sage.Connector.Cloud.Integration.Proxy
{
    public class RawRequestServiceProxy : ClientBase<IRequestService>, IRequestService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RawRequestServiceProxy()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="behavior"></param>
        public RawRequestServiceProxy(string endpointConfigurationName, IEndpointBehavior behavior = null)
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
        public RawRequestServiceProxy(string endpointConfigurationName, string remoteAddress, IEndpointBehavior behavior = null)
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
        public RawRequestServiceProxy(string endpointConfigurationName, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
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
        public RawRequestServiceProxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(binding, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }

        #endregion


        #region IRequestService Members
        public Request[] GetRequests()
        { return base.Channel.GetRequests(); }
        #endregion
    }
}
