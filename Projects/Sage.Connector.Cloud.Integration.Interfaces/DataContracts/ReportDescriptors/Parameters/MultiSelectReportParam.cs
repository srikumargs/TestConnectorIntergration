using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "MultiSelectReportParamContract")]
    public class MultiSelectReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MultiSelectReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        /// <param name="defaultSelectionValues"></param>
        /// <param name="availableSelectionValues"></param>
        /// <param name="minimumSelections"></param>
        /// <param name="maximumSelections"></param>
        /// <param name="isCustomValueAllowed"></param>
        public MultiSelectReportParam(String name, String displayText, String premiseMetadata, EntityTypeTag entityType,
            IEnumerable<String> defaultSelectionValues, IEnumerable<KeyName> availableSelectionValues, Int32? minimumSelections, Int32? maximumSelections, Boolean isCustomValueAllowed)
            : base(name, displayText, false, premiseMetadata, entityType)
        {
            StringList list = (defaultSelectionValues == null ? new StringList() : new StringList(defaultSelectionValues));
            DefaultSelectionValues = list;
            AvailableSelectionValues = availableSelectionValues.ToArray();
            MinimumSelectionCount = minimumSelections;
            MaximumSelectionCount = maximumSelections;
            IsCustomValueAllowed = isCustomValueAllowed;
        }

        /// <summary>
        /// Initializes a new instance of the MultiSelectReportParam class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="isCustomValueAllowed"></param>
        /// <param name="defaultSelectionValues"></param>
        /// <param name="availableSelectionValues"></param>
        /// <param name="minimumSelections"></param>
        /// <param name="maximumSelections"></param>
        /// <param name="premiseMetadata"></param>
        public MultiSelectReportParam(String name, String displayText, String premiseMetadata,
            IEnumerable<String> defaultSelectionValues, IEnumerable<KeyName> availableSelectionValues, Int32? minimumSelections, Int32? maximumSelections, Boolean isCustomValueAllowed)
            : base(name, displayText, false, premiseMetadata)
        {
            StringList list 
                = (defaultSelectionValues == null ? new StringList() : new StringList(defaultSelectionValues));
            DefaultSelectionValues = list;
            AvailableSelectionValues = availableSelectionValues.ToArray();
            MinimumSelectionCount = minimumSelections;
            MaximumSelectionCount = maximumSelections;
            IsCustomValueAllowed = isCustomValueAllowed;
        }

        /// <summary>
        /// Initializes a new instance of the CurrencyReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public MultiSelectReportParam(MultiSelectReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            DefaultSelectionValues = source.DefaultSelectionValues;
            AvailableSelectionValues = source.AvailableSelectionValues;
            MinimumSelectionCount = source.MinimumSelectionCount;
            MaximumSelectionCount = source.MaximumSelectionCount;
            IsCustomValueAllowed = source.IsCustomValueAllowed;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(MultiSelectReportParam));
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
        [DataMember(Name = "DefaultSelectionValues", IsRequired = true, Order = 0)]
        public StringList DefaultSelectionValues { get; protected set; }

        /// <summary>
        /// Available selection values
        /// </summary>
        [DataMember(Name = "AvailableSelectionValues", IsRequired = true, Order = 1)]
        public KeyName[] AvailableSelectionValues { get; protected set; }

        /// <summary>
        /// The minimum required selection; null if no prescribed minimum number of selections
        /// </summary>
        /// <remarks>
        /// This property should be used instead of the base class's IsRequired property
        /// </remarks>
        [DataMember(Name = "MinimumSelectionCount", IsRequired = true, Order = 2)]
        public Int32? MinimumSelectionCount { get; protected set; }

        /// <summary>
        /// The maximum allowed selection; null if no prescribed maximum number of selections
        /// </summary>
        [DataMember(Name = "MaximumSelectionCount", IsRequired = true, Order = 3)]
        public Int32? MaximumSelectionCount { get; protected set; }

        /// <summary>
        /// Can select value outside defined values
        /// </summary>
        [DataMember(Name = "IsCustomValueAllowed", IsRequired = true, Order = 4)]
        public Boolean IsCustomValueAllowed { get; protected set; }

        #endregion
    }
}
