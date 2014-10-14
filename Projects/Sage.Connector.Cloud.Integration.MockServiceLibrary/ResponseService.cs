using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;

namespace Sage.Connector.Cloud.Integration.MockServiceLibrary
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any, Namespace = ServiceConstants.V1_SERVICE_NAMESPACE)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ResponseService : IResponseService
    {
        public void PutResponses(Response[] responses)
        {
            throw new NotImplementedException();
        }
    }
}
