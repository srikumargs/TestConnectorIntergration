using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DateMonthDayReportParamContract")]
    public class DateMonthDayReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="defaultCurrent"></param>
        public DateMonthDayReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            DateTime? defaultValue, DateTime? minimumValue, DateTime? maximumValue, Boolean? defaultCurrent)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            DefaultCurrent = defaultCurrent;
        }

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="defaultCurrent"></param>
        public DateMonthDayReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata,
            DateTime? defaultValue, DateTime? minimumValue, DateTime? maximumValue, Boolean? defaultCurrent)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            DefaultCurrent = defaultCurrent;
        }

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public DateMonthDayReportParam(DateMonthDayReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            DefaultValue = source.DefaultValue;
            MinimumValue = source.MinimumValue;
            MaximumValue = source.MaximumValue;
            DefaultCurrent = source.DefaultCurrent;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(DateMonthDayReportParam));
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
        public DateTime? DefaultValue { get; protected set; }

        /// <summary>
        /// Minimum range
        /// </summary>
        [DataMember(Name = "MinimumValue", IsRequired = true, Order = 1)]
        public DateTime? MinimumValue { get; protected set; }

        /// <summary>
        /// Maximum range
        /// </summary>
        [DataMember(Name = "MaximumValue", IsRequired = true, Order = 2)]
        public DateTime? MaximumValue { get; protected set; }

        /// <summary>
        /// Whether to default to the user's system date/time when report is requested
        /// </summary>
        [DataMember(Name = "DefaultCurrent", IsRequired = true, Order = 3)]
        public Boolean? DefaultCurrent { get; protected set; }

        #endregion
    }
}
