using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector.Cloud.Integration.MockServiceLibrary
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any, Namespace = ServiceConstants.V1_SERVICE_NAMESPACE)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UploadSessionService : IUploadSessionService
    {
        public UploadSessionInfo CreateUploadSession(String premiseDocumentId, String purposeDescription, Int32 expectedSizeInBytes)
        {
            throw new NotImplementedException();
        }
    }
}
