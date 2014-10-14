﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DateMonthDayReportParamValueContract")]
    public class DateMonthDayReportParamValue : ReportParamValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParamValue class
        /// </summary>
        public DateMonthDayReportParamValue(String name, String premiseMetadata, EntityTypeTag entityType, DateTime? value)
            : base(name, premiseMetadata, entityType)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParamValue class
        /// </summary>
        public DateMonthDayReportParamValue(String name, String premiseMetadata, DateTime? value)
            : base(name, premiseMetadata)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the DateMonthDayReportParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        public DateMonthDayReportParamValue(DateMonthDayReportParamValue source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Value = source.Value;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(DateMonthDayReportParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "Value", IsRequired = true, Order = 0)]
        public DateTime? Value { get; protected set; }

        #endregion
    }
}
