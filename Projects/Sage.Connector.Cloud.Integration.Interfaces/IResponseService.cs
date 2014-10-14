using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides services for sending responses
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ResponseService")]
    public interface IResponseService
    {
        /// <summary>
        /// Puts responses 
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// </remarks>
        /// <param name="responses">The responses for this Tenant</param>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(InvalidResponseFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "PutResponses")]
        void PutResponses(Response[] responses);
    }
}
