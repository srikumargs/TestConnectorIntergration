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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "EquipmentCostContract")]
    public class EquipmentCost : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the EquipmentCost class
        /// </summary>
        public EquipmentCost(
            String uniqueIdentifier,
            String employeeUniqueIdentifier,
            DateTime periodEndDate,
            String equipmentUniqueIdentifier,
            String equipmentCostCodeUniqueIdentifier,
            String description,
            DateTime date,
            Decimal amount,
            String jobUniqueIdentifier,
            String subJobUniqueIdentifier,
            String costCodeUniqueIdentifier,
            String categoryUniqueIdentifier,
            IEnumerable<Note> notes )
        {
            UniqueIdentifier = uniqueIdentifier;
            EmployeeUniqueIdentifier = employeeUniqueIdentifier;
            PeriodEndDate = periodEndDate;
            EquipmentUniqueIdentifier = equipmentUniqueIdentifier;
            EquipmentCostCodeUniqueIdentifier = equipmentCostCodeUniqueIdentifier;
            Date = date;
            Amount = amount;
            Description = description;
            JobUniqueIdentifier = jobUniqueIdentifier;
            SubJobUniqueIdentifier = subJobUniqueIdentifier;
            CostCodeUniqueIdentifier = costCodeUniqueIdentifier;
            CategoryUniqueIdentifier = categoryUniqueIdentifier;
            Notes = notes;
        }

        /// <summary>
        ///  Initializes a new instance of the EquipmentCost class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public EquipmentCost(EquipmentCost source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            EmployeeUniqueIdentifier = source.EmployeeUniqueIdentifier;
            PeriodEndDate = source.PeriodEndDate;
            EquipmentUniqueIdentifier = source.EquipmentUniqueIdentifier;
            EquipmentCostCodeUniqueIdentifier = source.EquipmentCostCodeUniqueIdentifier;
            Date = source.Date;
            Amount = source.Amount;
            Description = source.Description;
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            SubJobUniqueIdentifier = source.SubJobUniqueIdentifier;
            CostCodeUniqueIdentifier = source.CostCodeUniqueIdentifier;
            CategoryUniqueIdentifier = source.CategoryUniqueIdentifier;
            Notes = source.Notes;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(EquipmentCost));
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
        [DataMember(Name = "EmployeeUniqueIdentifier", IsRequired = true, Order = 1)]
        public string EmployeeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PeriodEndDate", IsRequired = true, Order = 2)]
        public DateTime PeriodEndDate { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "EquipmentUniqueIdentifier", IsRequired = true, Order = 3)]
        public string EquipmentUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "EquipmentCostCodeUniqueIdentifier", Order = 4)]
        public string EquipmentCostCodeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Date", IsRequired = true, Order = 5)]
        public DateTime Date { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Amount", IsRequired = true, Order = 6)]
        public Decimal Amount { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Description", Order = 7)]
        public string Description { get; protected set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "JobUniqueIdentifier", Order = 8)]
        public string JobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SubJobUniqueIdentifier", Order = 9)]
        public string SubJobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CostCodeUniqueIdentifier", Order = 10)]
        public string CostCodeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CategoryUniqueIdentifier", Order = 11)]
        public string CategoryUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Notes", Order = 12)]
        public IEnumerable<Note> Notes  { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}

