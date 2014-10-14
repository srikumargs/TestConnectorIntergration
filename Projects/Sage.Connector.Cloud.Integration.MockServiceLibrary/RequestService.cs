using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;

namespace Sage.Connector.Cloud.Integration.MockServiceLibrary
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any, Namespace = ServiceConstants.V1_SERVICE_NAMESPACE)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RequestService : IRequestService
    {
        public Request[] GetRequests()
        {
            throw new NotImplementedException();
        }
    }
}
