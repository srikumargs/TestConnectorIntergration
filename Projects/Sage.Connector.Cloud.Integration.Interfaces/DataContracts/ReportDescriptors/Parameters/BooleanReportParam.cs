using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "BooleanReportParamContract")]
    public class BooleanReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BooleanReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        public BooleanReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType, Boolean? defaultValue)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the BooleanReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        public BooleanReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, Boolean? defaultValue)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the BooleanReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public BooleanReportParam(BooleanReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultValue = source.DefaultValue;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(BooleanReportParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// Default Value
        /// </summary>
        [DataMember(Name = "DefaultValue", IsRequired = true, Order = 0)]
        public Boolean? DefaultValue { get; protected set; }

        #endregion
    }
}
