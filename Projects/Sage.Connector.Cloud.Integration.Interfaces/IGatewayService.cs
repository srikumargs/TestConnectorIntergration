using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;


namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides the gateway to all services
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "GatewayService")]
    public interface IGatewayService
    {
        /// <summary>
        /// Gets the ServiceInfos of the various services
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// </remarks>
        /// <returns></returns>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "GetSiteServiceInfo")]
        SiteServiceInfo GetSiteServiceInfo();
    }
}
