using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "MultiSelectReportParamValueContract")]
    public class MultiSelectReportParamValue : ReportParamValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MultiSelectReportParamValue class
        /// </summary>
        public MultiSelectReportParamValue(String name, String premiseMetadata, EntityTypeTag entityType, IEnumerable<String> values)
            : base(name, premiseMetadata, entityType)
        {
            Values = (values == null ? new StringList() : new StringList(values));
        }

        /// <summary>
        /// Initializes a new instance of the MultiSelectReportParamValue class
        /// </summary>
        public MultiSelectReportParamValue(String name, String premiseMetadata, IEnumerable<String> values)
            : base(name, premiseMetadata)
        {
            Values = (values == null ? new StringList() : new StringList(values));
        }

        /// <summary>
        /// Initializes a new instance of the MultiSelectReportParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        public MultiSelectReportParamValue(MultiSelectReportParamValue source, IEnumerable<PropertyTuple> propertyTuples) : base(source, propertyTuples)
        {
            Values = source.Values;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(MultiSelectReportParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "Values", IsRequired = true, Order = 0)]
        public StringList Values { get; protected set; }

        #endregion
    }
}
