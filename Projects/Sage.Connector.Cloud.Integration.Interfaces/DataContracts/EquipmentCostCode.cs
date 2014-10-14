using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "EquipmentCostCodeContract")]
    public class EquipmentCostCode : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the EquipmentCostCode class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public EquipmentCostCode(String uniqueIdentifier, String name, String description)
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
        }

        /// <summary>
        ///  Initializes a new instance of the EquipmentCostCode class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public EquipmentCostCode(EquipmentCostCode source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(EquipmentCostCode));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Description", Order = 2)]
        public string Description { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
