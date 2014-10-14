using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector.Cloud.Integration.MockServiceLibrary
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any, Namespace = ServiceConstants.V1_SERVICE_NAMESPACE)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AdminService : IAdminService
    {
        public TenantInfo GetTenantInfo()
        {
            return new TenantInfo(new Uri("http://someuri.com"), "somename");
        }

        public ConfigParams GetConfigParams()
        {
            throw new NotImplementedException();
        }


        public ServiceInfo GetRequestServiceInfo()
        {
            throw new NotImplementedException();
        }

        public ServiceInfo GetResponseServiceInfo()
        {
            throw new NotImplementedException();
        }

        public ServiceInfo GetUploadSessionServiceInfo()
        {
            throw new NotImplementedException();
        }
    }
}
