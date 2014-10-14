using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// KnownTypes are required each time the ReportParam object hierarchy is expanded.  This is 
    /// needed for polymorphic serialization support with the DataContractSerializer
    /// </remarks>
    [KnownType(typeof(BooleanReportParamValue))]
    [KnownType(typeof(CurrencyReportParamValue))]
    [KnownType(typeof(DateMonthDayReportParamValue))]
    [KnownType(typeof(DateMonthYearReportParamValue))]
    [KnownType(typeof(DateReportParamValue))]
    [KnownType(typeof(DateTimeReportParamValue))]
    [KnownType(typeof(DecimalReportParamValue))]
    [KnownType(typeof(MultiSelectReportParamValue))]
    [KnownType(typeof(PercentageReportParamValue))]
    [KnownType(typeof(PhoneNumberReportParamValue))]
    [KnownType(typeof(SingleSelectReportParamValue))]
    [KnownType(typeof(SocialSecurityNumberReportParamValue))]
    [KnownType(typeof(StringReportParamValue))]
    [KnownType(typeof(TimeElapsedReportParamValue))]
    [KnownType(typeof(TimeOfDayReportParamValue))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ReportParamValueContract")]
    public class ReportParamValue : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ReportParamValue class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        public ReportParamValue(String name, String premiseMetadata, EntityTypeTag entityType)
        {
            Name = name;
            PremiseMetadata = premiseMetadata;
            EntityType = entityType;
        }

        /// <summary>
        /// Initializes a new instance of the ReportParamValue class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="premiseMetadata"> </param>
        public ReportParamValue(String name, String premiseMetadata)
        {
            Name = name;
            PremiseMetadata = premiseMetadata;
        }

        /// <summary>
        /// Initializes a new instance of the ReportParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ReportParamValue(ReportParamValue source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Name = source.Name;
            PremiseMetadata = source.PremiseMetadata;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ReportParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion

        #region Public properties

        /// <summary>
        /// Parameter Name
        /// </summary>
        [DataMember(Name = "Name", IsRequired = true, Order = 0)]
        public String Name { get; protected set; }

        /// <summary>
        /// Premise formatting information
        /// </summary>
        [DataMember(Name = "PremiseMetadata", IsRequired = true, Order = 1)]
        public String PremiseMetadata { get; protected set; }

        /// <summary>
        /// The entity type that this value represents
        /// </summary>
        [DataMember(Name = "EntityType", IsRequired = true, Order = 2)]
        public EntityTypeTag EntityType { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
