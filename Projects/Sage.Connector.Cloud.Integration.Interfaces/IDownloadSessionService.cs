using System;
using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides services for retrieving an download location
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DownloadSessionService")]
    public interface IDownloadSessionService
    {
        /// <summary>
        /// Create session data, including a time-limited download key, in order to download data
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// 
        /// If the shared access signature expires before the download can be completed, then the premise software
        /// should request a new DownloadSessionInfo ... but specify the _same_ cloudDocumentId the next time
        /// around.  The Cloud may use this information to decide/ whether to grant the session
        /// longer-than-normal time based on the fact that it has seen a prior failed attempt to download this
        /// document already.
        /// </remarks>
        /// <param name="cloudDocumentId">An unique identifier that the cloud would associate
        /// with the logical document that could be downloaded.
        /// </param>
        /// <returns>The download key</returns>
        [FaultContract(typeof (RetiredEndpointFault))]
        [FaultContract(typeof (ConnectivityFault))]
        [FaultContract(typeof (TenantConnectionDisabledFault))]
        [FaultContract(typeof (IncompatibleClientFault))]
        [FaultContract(typeof (SerializationFault))]
        [OperationContract(Name = "CreateDownloadSession")]
        DownloadSessionInfo CreateDownloadSession(String cloudDocumentId);
    }
}
