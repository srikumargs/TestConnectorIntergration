using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [KnownType(typeof(CurrencyReportParam))]
    [KnownType(typeof(DecimalReportParam))]
    [KnownType(typeof(PercentageReportParam))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "NumberReportParamContract")]
    public abstract class NumberReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NumberReportParam class 
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
        public NumberReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            Decimal? defaultValue, Int32? scale, Int32? precision, Decimal? minimumValue, Decimal? maximumValue, ReportParameterIntegerTypes integerType,
            Boolean? commaGrouping, Boolean? disallowZero, Boolean? showZeroAsBlank)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultValue = defaultValue;
            Scale = scale;
            Precision = precision;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            IntegerType = integerType;
            CommaGrouping = commaGrouping;
            DisallowZero = disallowZero;
            ShowZeroAsBlank = showZeroAsBlank;
        }

        /// <summary>
        /// Initializes a new instance of the NumberReportParam class 
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
        public NumberReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, 
            Decimal? defaultValue, Int32? scale, Int32? precision, Decimal? minimumValue, Decimal? maximumValue, ReportParameterIntegerTypes integerType,
            Boolean? commaGrouping, Boolean? disallowZero, Boolean? showZeroAsBlank)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultValue = defaultValue;
            Scale = scale;
            Precision = precision;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            IntegerType = integerType;
            CommaGrouping = commaGrouping;
            DisallowZero = disallowZero;
            ShowZeroAsBlank = showZeroAsBlank;
        }

        /// <summary>
        /// Initializes a new instance of the NumberReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public NumberReportParam(NumberReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultValue = source.DefaultValue;
            Scale = source.Scale;
            Precision = source.Precision;
            MinimumValue = source.MinimumValue;
            MaximumValue = source.MaximumValue;
            IntegerType = source.IntegerType;
            CommaGrouping = source.CommaGrouping;
            DisallowZero = source.DisallowZero;
            ShowZeroAsBlank = source.ShowZeroAsBlank;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(NumberReportParam));
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
        public Decimal? DefaultValue { get; protected set; }

        /// <summary>
        /// Scale
        /// </summary>
        [DataMember(Name = "Scale", IsRequired = true, Order = 1)]
        public Int32? Scale { get; protected set; }

        /// <summary>
        /// Precision
        /// </summary>
        [DataMember(Name = "Precision", IsRequired = true, Order = 2)]
        public Int32? Precision { get; protected set; }

        /// <summary>
        /// Minimum range
        /// </summary>
        [DataMember(Name = "MinimumValue", IsRequired = true, Order = 3)]
        public Decimal? MinimumValue { get; protected set; }

        /// <summary>
        /// Maximum range
        /// </summary>
        [DataMember(Name = "MaximumValue", IsRequired = true, Order = 4)]
        public Decimal? MaximumValue { get; protected set; }

        /// <summary>
        /// Positive/negative/both
        /// </summary>
        [DataMember(Name = "IntegerType", IsRequired = true, Order = 5)]
        public ReportParameterIntegerTypes IntegerType { get; set; }

        /// <summary>
        /// Whether to group digits together for larger numbers (e.g. 1,000,000)
        /// </summary>
        [DataMember(Name = "CommaGrouping", IsRequired = true, Order = 6)]
        public Boolean? CommaGrouping { get; set; }

        /// <summary>
        /// Whether zero is an allowable value
        /// </summary>
        [DataMember(Name = "DisallowZero", IsRequired = true, Order = 7)]
        public Boolean? DisallowZero { get; set; }

        /// <summary>
        /// Whether to show zero values as blank
        /// </summary>
        [DataMember(Name = "ShowZeroAsBlank", IsRequired = true, Order = 8)]
        public Boolean? ShowZeroAsBlank { get; set; }
        
        #endregion
    }
}
