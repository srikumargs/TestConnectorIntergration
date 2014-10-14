using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector.Cloud.Integration.Proxy
{
    public class RawAdminServiceProxy : ClientBase<IAdminService>, IAdminService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public RawAdminServiceProxy()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="behavior"></param>
        public RawAdminServiceProxy(string endpointConfigurationName, IEndpointBehavior behavior = null)
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
        public RawAdminServiceProxy(string endpointConfigurationName, string remoteAddress, IEndpointBehavior behavior = null)
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
        public RawAdminServiceProxy(string endpointConfigurationName, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
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
        public RawAdminServiceProxy(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress, IEndpointBehavior behavior = null)
            : base(binding, remoteAddress)
        {
            if (behavior != null)
            {
                Endpoint.Behaviors.Add(behavior);
            }
        }
        #endregion


        #region IAdminService Members
        public TenantInfo GetTenantInfo()
        { return base.Channel.GetTenantInfo(); }

        public ConfigParams GetConfigParams()
        { return base.Channel.GetConfigParams(); }
        #endregion
    }
}