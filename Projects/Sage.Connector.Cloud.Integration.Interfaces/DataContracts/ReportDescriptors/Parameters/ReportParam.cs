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
    [KnownType(typeof(BooleanReportParam))]
    [KnownType(typeof(CurrencyReportParam))]
    [KnownType(typeof(DateMonthDayReportParam))]
    [KnownType(typeof(DateMonthYearReportParam))]
    [KnownType(typeof(DateReportParam))]
    [KnownType(typeof(DateTimeReportParam))]
    [KnownType(typeof(DecimalReportParam))]
    [KnownType(typeof(InformationalTextReportParam))]
    [KnownType(typeof(MultiSelectReportParam))]
    [KnownType(typeof(NumberReportParam))]
    [KnownType(typeof(PercentageReportParam))]
    [KnownType(typeof(PhoneNumberReportParam))]
    [KnownType(typeof(SingleSelectReportParam))]
    [KnownType(typeof(SocialSecurityNumberReportParam))]
    [KnownType(typeof(StringReportParam))]
    [KnownType(typeof(TimeElapsedReportParam))]
    [KnownType(typeof(TimeOfDayReportParam))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ReportParamContract")]
    public class ReportParam : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        public ReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType)
        {
            Name = name;
            DisplayText = displayText;
            IsRequired = isRequired;
            PremiseMetadata = premiseMetadata;
            EntityType = entityType;
        }

        /// <summary>
        /// Initializes a new instance of the ReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        public ReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata)
        {
            Name = name;
            DisplayText = displayText;
            IsRequired = isRequired;
            PremiseMetadata = premiseMetadata;
        }

        /// <summary>
        /// Initializes a new instance of the ReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ReportParam(ReportParam source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Name = source.Name;
            DisplayText = source.DisplayText;
            IsRequired = source.IsRequired;
            PremiseMetadata = source.PremiseMetadata;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ReportParam));
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
        /// The Description of the Parameter
        /// </summary>
        [DataMember(Name = "DisplayText", IsRequired = true, Order = 1)]
        public string DisplayText { get; protected set; }

        /// <summary>
        /// Is this parameter a required field
        /// </summary>
        [DataMember(Name = "IsRequired", IsRequired = true, Order = 2)]
        public Boolean IsRequired { get; protected set; }

        /// <summary>
        /// Premise formatting information
        /// </summary>
        [DataMember(Name = "PremiseMetadata", IsRequired = true, Order = 3)]
        public String PremiseMetadata { get; protected set; }

        /// <summary>
        /// The entity type that this parameter represents
        /// </summary>
        [DataMember(Name = "EntityType", IsRequired = true, Order = 4)]
        public EntityTypeTag EntityType { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
