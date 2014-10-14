using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ErrorResponseActionContract")]
    public enum ErrorResponseAction
    {
        /// <summary>
        /// No kind (default value automatically initialized by runtime)
        /// </summary>
        [EnumMember]
        None = 0,

        [EnumMember]
        Retry,

        [EnumMember]
        Fail,

        [EnumMember]
        Cancel
    }
}
