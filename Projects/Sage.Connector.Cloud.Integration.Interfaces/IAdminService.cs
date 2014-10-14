using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides administrative services
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "AdminService")]
    public interface IAdminService
    {
        /// <summary>
        /// Gets the specified TenantInfo
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// </remarks>
        /// <returns>The TenantInfo for this tenant</returns>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "GetTenantInfo")]
        TenantInfo GetTenantInfo();

        /// <summary>
        /// Gets the specified ConfigParams
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// </remarks>
        /// <returns>The ConfigParams for this tenant</returns>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "GetConfigParams")]
        ConfigParams GetConfigParams();
    }
}
