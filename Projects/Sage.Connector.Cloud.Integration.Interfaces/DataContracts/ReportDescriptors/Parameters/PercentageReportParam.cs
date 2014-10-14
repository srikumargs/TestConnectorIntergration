using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PercentageReportParam")]
    public class PercentageReportParam : NumberReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PercentageReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="scale"></param>
        /// <param name="precision"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="integerType"></param>
        /// <param name="commaGrouping"></param>
        /// <param name="disallowZero"></param>
        /// <param name="showZeroAsBlank"></param>
        public PercentageReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            Decimal? defaultValue, Int32? scale, Int32? precision, Decimal? minimumValue, Decimal? maximumValue, ReportParameterIntegerTypes integerType,
            Boolean? commaGrouping, Boolean? disallowZero, Boolean? showZeroAsBlank)
            : base(name, displayText, isRequired, premiseMetadata, entityType,
                defaultValue, scale, precision, minimumValue, maximumValue, integerType,
                commaGrouping, disallowZero, showZeroAsBlank)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PercentageReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultValue"></param>
        /// <param name="scale"></param>
        /// <param name="precision"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="integerType"></param>
        /// <param name="commaGrouping"></param>
        /// <param name="disallowZero"></param>
        /// <param name="showZeroAsBlank"></param>
        public PercentageReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata,
            Decimal? defaultValue, Int32? scale, Int32? precision, Decimal? minimumValue, Decimal? maximumValue, ReportParameterIntegerTypes integerType,
            Boolean? commaGrouping, Boolean? disallowZero, Boolean? showZeroAsBlank)
            : base(name, displayText, isRequired, premiseMetadata,
                defaultValue, scale, precision, minimumValue, maximumValue, integerType,
                commaGrouping, disallowZero, showZeroAsBlank)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PercentageReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public PercentageReportParam(PercentageReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            // Property1 = source.Property1;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PercentageReportParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion
    }
}
