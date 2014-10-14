using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TimeOfDayReportParamValueContract")]
    public class TimeOfDayReportParamValue : ReportParamValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParamValue class; expresses the time as a TimeSpan duration
        /// since 00:00 (midnight)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="value"></param>
        public TimeOfDayReportParamValue(String name, String premiseMetadata, EntityTypeTag entityType, TimeSpan? value)
            : base(name, premiseMetadata, entityType)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParamValue class; expresses the time as a TimeSpan duration
        /// since 00:00 (midnight)
        /// </summary>
        public TimeOfDayReportParamValue(String name, String premiseMetadata, TimeSpan? value)
            : base(name, premiseMetadata)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimeOfDayReportParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        public TimeOfDayReportParamValue(TimeOfDayReportParamValue source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Value = source.Value;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TimeOfDayReportParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        /// <summary>
        /// The time of day as a TimeSpan duration since 00:00 (midnight)
        /// </summary>
        [DataMember(Name = "Value", IsRequired = true, Order = 0)]
        public TimeSpan? Value { get; protected set; }

        #endregion
    }
}
