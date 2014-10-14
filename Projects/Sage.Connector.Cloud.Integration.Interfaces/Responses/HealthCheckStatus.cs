using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    /// <summary>
    /// Different states of health possible
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "HealthCheckStatusContract")]
    public enum HealthCheckStatus
    {
        /// No status (default value automatically initialized by runtime)
        [EnumMember]
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Passed,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Failed
    }
}
