using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector.Cloud.Integration.Proxy
{
    public class RawDownloadSessionServiceProxy : ClientBase<IDownloadSessionService>, IDownloadSessionService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RawDownloadSessionServiceProxy()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="behavior"></param>
        public RawDownloadSessionServiceProxy(string endpointConfigurationName, IEndpointBehavior behavior = null)
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
        public RawDownloadSessionServiceProxy(string endpointConfigurationName, string remoteAddress, IEndpointBehavior behavior = null)
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
        public RawDownloadSessionServiceProxy(string endpointConfigurationName, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
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
        public RawDownloadSessionServiceProxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(binding, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }
        #endregion


        #region IDownloadSessionService Members
        public DownloadSessionInfo CreateDownloadSession(string cloudDocumentId)
        {
            return base.Channel.CreateDownloadSession(cloudDocumentId);
        }
        #endregion
    }
}
