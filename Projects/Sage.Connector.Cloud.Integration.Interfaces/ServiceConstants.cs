using System;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    public static class ServiceConstants
    {
        public const String V1_SERVICE_NAMESPACE = "http://Sage.CRE.Cloud.com/2011/10";

        /// <summary>
        /// The value for the ServiceInfo Name of the GatewayService
        /// </summary>
        public const String V1_GATEWAY_SERVICE_INFO_NAME = "Gateway";

        /// <summary>
        /// The value for the ServiceInfo Name of the AdminService
        /// </summary>
        public const String V1_ADMIN_SERVICE_INFO_NAME = "Admin";

        /// <summary>
        /// The value for the ServiceInfo Name of the RequestService
        /// </summary>
        public const String V1_REQUEST_SERVICE_INFO_NAME = "Request";

        /// <summary>
        /// The value for the ServiceInfo Name of the ResponseService
        /// </summary>
        public const String V1_RESPONSE_SERVICE_INFO_NAME = "Response";

        /// <summary>
        /// The value for the ServiceInfo Name of the UploadSessionService
        /// </summary>
        public const String V1_UPLOAD_SESSION_SERVICE_INFO_NAME = "UploadSession";

        /// <summary>
        /// The value for the ServiceInfo Name of the DownloadSessionService
        /// </summary>
        public const String V1_DOWNLOAD_SESSION_SERVICE_INFO_NAME = "DownloadSession";

        /// <summary>
        /// The value for the ServiceInfo Name of the Request Waiting Notification Service
        /// </summary>
        public const String V2_REQUEST_WAITING_NOTIFICATION_SERVICE_INFO_NAME = "RequestWaitingNotification";

        /// <summary>
        /// The value for the Web API endpoint information service
        /// </summary>
        public const String V2_API_SERVICE_INFO_NAME = "ApiService";
    }
}