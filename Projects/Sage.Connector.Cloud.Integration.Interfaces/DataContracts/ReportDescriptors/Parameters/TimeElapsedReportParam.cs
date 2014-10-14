using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TimeElapsedReportParamContract")]
    public class TimeElapsedReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        public TimeElapsedReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            TimeSpan? defaultValue, TimeSpan? minimumValue, TimeSpan? maximumValue)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        public TimeElapsedReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata,
            TimeSpan? defaultValue, TimeSpan? minimumValue, TimeSpan? maximumValue)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public TimeElapsedReportParam(TimeElapsedReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultValue = source.DefaultValue;
            MinimumValue = source.MinimumValue;
            MaximumValue = source.MaximumValue;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TimeElapsedReportParam));
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
        /// Minimum range
        /// </summary>
        [DataMember(Name = "MinimumValue", IsRequired = true, Order = 1)]
        public TimeSpan? MinimumValue { get; protected set; }

        /// <summary>
        /// Maximum range
        /// </summary>
        [DataMember(Name = "MaximumValue", IsRequired = true, Order = 2)]
        public TimeSpan? MaximumValue { get; protected set; }

        #endregion
    }
}
