using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector.Cloud.Integration.Proxy
{
    public class RawUploadSessionServiceProxy : ClientBase<IUploadSessionService>, IUploadSessionService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RawUploadSessionServiceProxy()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="behavior"></param>
        public RawUploadSessionServiceProxy(string endpointConfigurationName, IEndpointBehavior behavior = null)
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
        public RawUploadSessionServiceProxy(string endpointConfigurationName, string remoteAddress, IEndpointBehavior behavior = null)
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
        public RawUploadSessionServiceProxy(string endpointConfigurationName, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
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
        public RawUploadSessionServiceProxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(binding, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }
        #endregion


        #region IUploadSessionService Members
        public UploadSessionInfo CreateUploadSession(String premiseDocumentId, String purposeDescription, Int32 expectedSizeInBytes)
        { return base.Channel.CreateUploadSession(premiseDocumentId, purposeDescription, expectedSizeInBytes); }
        #endregion
    }
}
