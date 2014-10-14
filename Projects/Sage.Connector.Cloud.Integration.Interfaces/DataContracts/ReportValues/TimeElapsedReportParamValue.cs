using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TimeElapsedReportParamValueContract")]
    public class TimeElapsedReportParamValue : ReportParamValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParamValue class
        /// </summary>
        public TimeElapsedReportParamValue(String name, String premiseMetadata, EntityTypeTag entityType, TimeSpan? value)
            : base(name, premiseMetadata, entityType)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParamValue class
        /// </summary>
        public TimeElapsedReportParamValue(String name, String premiseMetadata, TimeSpan? value)
            : base(name, premiseMetadata)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the TimeElapsedReportParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        public TimeElapsedReportParamValue(TimeElapsedReportParamValue source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Value = source.Value;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TimeElapsedReportParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "Value", IsRequired = true, Order = 0)]
        public TimeSpan? Value { get; protected set; }

        #endregion
    }
}
