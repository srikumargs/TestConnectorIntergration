using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TimeOfDayReportParamContract")]
    public class TimeOfDayReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParam class; expresses the time as a TimeSpan duration
        /// since 00:00 (midnight)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="useCurrentTimeAsDefault"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        public TimeOfDayReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            TimeSpan? defaultValue, Boolean useCurrentTimeAsDefault, TimeSpan? minimumValue, TimeSpan? maximumValue)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
            UseCurrentTimeAsDefault = useCurrentTimeAsDefault;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParam class; expresses the time as a TimeSpan duration
        /// since 00:00 (midnight)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        /// <param name="useCurrentTimeAsDefault"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        public TimeOfDayReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata,
            TimeSpan? defaultValue, Boolean useCurrentTimeAsDefault, TimeSpan? minimumValue, TimeSpan? maximumValue)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
            UseCurrentTimeAsDefault = useCurrentTimeAsDefault;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public TimeOfDayReportParam(TimeOfDayReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultValue = source.DefaultValue;
            UseCurrentTimeAsDefault = source.UseCurrentTimeAsDefault;
            MinimumValue = source.MinimumValue;
            MaximumValue = source.MaximumValue;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TimeOfDayReportParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// Default value
        /// </summary>
        [DataMember(Name = "DefaultValue", IsRequired = true, Order = 0)]
        public TimeSpan? DefaultValue { get; protected set; }

        /// <summary>
        /// Whether the current time should be used as the default value (if true, causes DefaultValue to be ignored)
        /// </summary>
        [DataMember(Name = "UseCurrentTimeAsDefault", IsRequired = true, Order = 1)]
        public Boolean UseCurrentTimeAsDefault { get; protected set; }

        /// <summary>
        /// Minimum range
        /// </summary>
        [DataMember(Name = "MinimumValue", IsRequired = true, Order = 2)]
        public TimeSpan? MinimumValue { get; protected set; }

        /// <summary>
        /// Maximum range
        /// </summary>
        [DataMember(Name = "MaximumValue", IsRequired = true, Order = 3)]
        public TimeSpan? MaximumValue { get; protected set; }

        #endregion
    }
}
