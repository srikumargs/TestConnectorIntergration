using System;
using System.ServiceModel;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Faults;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    /// <summary>
    /// Provides services for retrieving an upload key
    /// </summary>
    [ServiceContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UploadSessionService")]
    public interface IUploadSessionService
    {
        /// <summary>
        /// Create session data, including a time-limited upload key, in order to upload data
        /// </summary>
        /// <remarks>
        /// Header must include TenantId and ConnectionKeyHash
        /// 
        /// If the shared access signature expires before the upload can be completed, then the premise software
        /// should request a new UploadSessionInfo ... but specify the _same_ premiseDocumentId the next time
        /// around.  The Cloud may use this information to decide/ whether to grant the session
        /// longer-than-normal time based on the fact that it has seen a prior failed attempt to upload this
        /// document already.
        /// </remarks>
        /// <param name="premiseDocumentId">An unique identifier that the premise software should associate
        /// with the logical document it is going to attempt to upload.
        /// </param>
        /// <param name="purposeDescription">A human-readable description of the intended content of this upload.
        /// This may be used to allow Tenant or Sage Cloud Administrators to gather information about upload usage.
        /// </param>
        /// <param name="expectedSizeInBytes">The expected size in bytes of the upload.  This may be used to allow
        /// the Cloud integration service to tune the expiration policy for the key it returns based upon the
        /// expected size.</param>
        /// <returns>The upload key</returns>
        [FaultContract(typeof(RetiredEndpointFault))]
        [FaultContract(typeof(ConnectivityFault))]
        [FaultContract(typeof(TenantConnectionDisabledFault))]
        [FaultContract(typeof(IncompatibleClientFault))]
        [FaultContract(typeof(SerializationFault))]
        [OperationContract(Name = "CreateUploadSession")]
        UploadSessionInfo CreateUploadSession(String premiseDocumentId, String purposeDescription, Int32 expectedSizeInBytes);
    }
}
