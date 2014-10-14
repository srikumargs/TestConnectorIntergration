using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "StringReportParamContract")]
    public class StringReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the StringReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="length"></param>
        public StringReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType, String defaultValue, Int32 length)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
            Length = length;
        }

        /// <summary>
        /// Initializes a new instance of the StringReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        /// <param name="length"></param>
        public StringReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, String defaultValue, Int32 length)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
            Length = length;
        }

        /// <summary>
        /// Initializes a new instance of the StringReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public StringReportParam(StringReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultValue = source.DefaultValue;
            Length = source.Length;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(StringReportParam));
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
        public String DefaultValue { get; protected set; }

        /// <summary>
        /// Length
        /// </summary>
        [DataMember(Name = "Length", IsRequired = true, Order = 1)]
        public Int32 Length { get; protected set; }

        #endregion
    }
}
