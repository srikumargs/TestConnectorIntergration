using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides services for retrieving requests
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "RequestService")]
    public interface IRequestService
    {
        /// <summary>
        /// Gets requests
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// </remarks>
        /// <returns>The requests for this Tenant</returns>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "GetRequests")]
        Request[] GetRequests();
    }
}
