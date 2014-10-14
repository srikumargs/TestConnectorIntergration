using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SingleSelectReportParamContract")]
    public class SingleSelectReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SingleSelectReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultSelectionValue"></param>
        /// <param name="availableSelectionValues"></param>
        /// <param name="isCustomValueAllowed"></param>
        public SingleSelectReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata, EntityTypeTag entityType,
            String defaultSelectionValue, IEnumerable<KeyName> availableSelectionValues, Boolean isCustomValueAllowed)
            : base(name, displayText, isRequired, premiseMetadata, entityType)
        {
            DefaultSelectionValue = defaultSelectionValue;
            AvailableSelectionValues = availableSelectionValues.ToArray();
            IsCustomValueAllowed = isCustomValueAllowed;
        }

        /// <summary>
        /// Initializes a new instance of the SingleSelectReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isRequired"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="defaultSelectionValue"></param>
        /// <param name="availableSelectionValues"></param>
        /// <param name="isCustomValueAllowed"></param>
        public SingleSelectReportParam(String name, String displayText, Boolean isRequired, String premiseMetadata,
            String defaultSelectionValue, IEnumerable<KeyName> availableSelectionValues, Boolean isCustomValueAllowed)
            : base(name, displayText, isRequired, premiseMetadata)
        {
            DefaultSelectionValue = defaultSelectionValue;
            AvailableSelectionValues = availableSelectionValues.ToArray();
            IsCustomValueAllowed = isCustomValueAllowed;
        }

        /// <summary>
        /// Initializes a new instance of the CurrencyReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SingleSelectReportParam(SingleSelectReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultSelectionValue = source.DefaultSelectionValue;
            AvailableSelectionValues = source.AvailableSelectionValues;
            IsCustomValueAllowed = source.IsCustomValueAllowed;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SingleSelectReportParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        /// <summary>
        /// Values 'pre-selected'
        /// </summary>
        [DataMember(Name = "DefaultSelectionValue", IsRequired = true, Order = 0)]
        public String DefaultSelectionValue { get; protected set; }

        /// <summary>
        /// Possible values
        /// </summary>
        [DataMember(Name = "AvailableSelectionValues", IsRequired = true, Order = 1)]
        public KeyName[] AvailableSelectionValues { get; protected set; }

        /// <summary>
        /// Can select value outside defined values
        /// </summary>
        [DataMember(Name = "IsCustomValueAllowed", IsRequired = true, Order = 2)]
        public Boolean IsCustomValueAllowed { get; protected set; }


        #endregion
    }
}
