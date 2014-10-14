using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Report parameter integer types
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ReportParameterIntegerTypesContract")]
    public enum ReportParameterIntegerTypes
    {
        /// <summary>
        /// No ReportParameterIntegerTypes (default value automatically initialized by runtime)
        /// </summary>
        [EnumMember]
        None = 0,

        /// <summary>
        /// Both
        /// </summary>
        [EnumMember]
        Both,
        
        /// <summary>
        /// Positive Only
        /// </summary>
        [EnumMember]
        PositiveOnly,

        /// <summary>
        /// Negative Only
        /// </summary>
        [EnumMember]
        NegativeOnly,
    }
}
