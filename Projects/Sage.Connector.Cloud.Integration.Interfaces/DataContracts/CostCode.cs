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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "CostCodeContract")]
    public class CostCode : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the CostCode class
        /// </summary>
        /// <param name="jobUniqueIdentifier"></param>
        /// <param name="subJobUniqueIdentifier"> </param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="group"></param>
        /// <param name="isLabor"></param>
        /// <param name="isMaterial"></param>
        /// <param name="isSubcontract"></param>
        /// <param name="isEquipment"></param>
        /// <param name="isOverhead"></param>
        /// <param name="isOther"></param>
        public CostCode(String jobUniqueIdentifier,
            String subJobUniqueIdentifier,
            String uniqueIdentifier,
            String name,
            String description,
            String status,
            Boolean group,
            Boolean isLabor,
            Boolean isMaterial,
            Boolean isSubcontract,
            Boolean isEquipment,
            Boolean isOverhead,
            Boolean isOther)
        {
            JobUniqueIdentifier = jobUniqueIdentifier;
            SubJobUniqueIdentifier = subJobUniqueIdentifier;
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
            Status = status;
            Group = group;
            IsLabor = isLabor;
            IsMaterial = isMaterial;
            IsSubcontract = isSubcontract;
            IsEquipment = isEquipment;
            IsOverhead = isOverhead;
            IsOther = isOther;
        }

        /// <summary>
        ///  Initializes a new instance of the CostCode class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public CostCode(CostCode source, IEnumerable<PropertyTuple> propertyTuples)
        {
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            SubJobUniqueIdentifier = source.SubJobUniqueIdentifier;
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            Status = source.Status;
            Group = source.Group;
            IsLabor = source.IsLabor;
            IsMaterial = source.IsMaterial;
            IsSubcontract = source.IsSubcontract;
            IsEquipment = source.IsEquipment;
            IsOverhead = source.IsOverhead;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(CostCode));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "JobUniqueIdentifier", IsRequired = true, Order = 0)]
        public string JobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SubJobUniqueIdentifier", IsRequired = true, Order = 1)]
        public string SubJobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 2)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Name", Order = 3)]
        public string Name { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Description", Order = 4)]
        public string Description { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Status", Order = 5)]
        public string Status { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Group", Order = 6)]
        public Boolean Group { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsLabor", Order = 7)]
        public Boolean IsLabor { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsMaterial", Order = 8)]
        public Boolean IsMaterial { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsSubcontract", Order = 9)]
        public Boolean IsSubcontract { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsEquipment", Order = 10)]
        public Boolean IsEquipment { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsOverhead", Order = 11)]
        public Boolean IsOverhead { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IsOther", Order = 12)]
        public Boolean IsOther { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
