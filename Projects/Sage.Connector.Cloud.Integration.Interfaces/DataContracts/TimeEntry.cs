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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TimeEntryContract")]
    public class TimeEntry : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the TimeEntry class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="employeeUniqueIdentifier"></param>
        /// <param name="periodEndDate"></param>
        /// <param name="jobUniqueIdentifier"></param>
        /// <param name="subJobUniqueIdentifier"></param>
        /// <param name="costCodeUniqueIdentifier"></param>
        /// <param name="categoryUniqueIdentifier"></param>
        /// <param name="certified"></param>
        /// <param name="certificationUniqueIdentifier"></param>
        /// <param name="payTypeUniqueIdentifier"></param>
        /// <param name="workDate"></param>
        /// <param name="hours"></param>
        /// <param name="workStart"></param>
        /// <param name="workEnd"></param>
        /// <param name="units"></param>
        /// <param name="unitCost"></param>
        /// <param name="amount"></param>
        /// <param name="notes"></param>
        public TimeEntry(
            String uniqueIdentifier,
            String employeeUniqueIdentifier,
            DateTime periodEndDate,
            String jobUniqueIdentifier,
            String subJobUniqueIdentifier,
            String costCodeUniqueIdentifier,
            String categoryUniqueIdentifier,
            Boolean certified,
            String certificationUniqueIdentifier,
            String payTypeUniqueIdentifier,
            DateTime workDate,
            Decimal? hours,
            DateTime? workStart,
            DateTime? workEnd,
            Decimal? units,
            Decimal? unitCost,
            Decimal? amount,
            IEnumerable<Note> notes )
        {
            UniqueIdentifier = uniqueIdentifier;
            EmployeeUniqueIdentifier = employeeUniqueIdentifier;
            PeriodEndDate = periodEndDate;
            JobUniqueIdentifier = jobUniqueIdentifier;
            SubJobUniqueIdentifier = subJobUniqueIdentifier;
            CostCodeUniqueIdentifier = costCodeUniqueIdentifier;
            CategoryUniqueIdentifier = categoryUniqueIdentifier;
            Certified = certified;
            CertificationUniqueIdentifier = certificationUniqueIdentifier;
            PayTypeUniqueIdentifier = payTypeUniqueIdentifier;
            WorkDate = workDate;
            Hours = hours;
            WorkStart = workStart;
            WorkEnd = workEnd;
            Units = units;
            UnitCost = unitCost;
            Amount = amount;
            Notes = notes;
        }

        /// <summary>
        ///  Initializes a new instance of the TimeEntry class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public TimeEntry(TimeEntry source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            EmployeeUniqueIdentifier = source.EmployeeUniqueIdentifier;
            PeriodEndDate = source.PeriodEndDate;
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            SubJobUniqueIdentifier = source.SubJobUniqueIdentifier;
            CostCodeUniqueIdentifier = source.CostCodeUniqueIdentifier;
            CategoryUniqueIdentifier = source.CategoryUniqueIdentifier;
            Certified = source.Certified;
            CertificationUniqueIdentifier = source.CertificationUniqueIdentifier;
            PayTypeUniqueIdentifier = source.PayTypeUniqueIdentifier;
            WorkDate = source.WorkDate;
            Hours = source.Hours;
            WorkStart = source.WorkStart;
            WorkEnd = source.WorkEnd;
            Units = source.Units;
            UnitCost = source.UnitCost;
            Amount = source.Amount;
            Notes = source.Notes;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TimeEntry));
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
        [DataMember(Name = "JobUniqueIdentifier", Order = 3)]
        public string JobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SubJobUniqueIdentifier", Order = 4)]
        public string SubJobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CostCodeUniqueIdentifier", Order = 5)]
        public string CostCodeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CategoryUniqueIdentifier", Order = 6)]
        public string CategoryUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Certified", Order = 7)]
        public Boolean Certified { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CertificationUniqueIdentifier", Order = 8)]
        public string CertificationUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PayTypeUniqueIdentifier", Order = 9)]
        public string PayTypeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "WorkDate", Order = 10)]
        public DateTime WorkDate { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Hours", Order = 11)]
        public Decimal? Hours { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "WorkStart", Order = 12)]
        public DateTime? WorkStart { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "WorkEnd", Order = 13)]
        public DateTime? WorkEnd { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Units", Order = 14)]
        public Decimal? Units { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UnitCost", Order = 15)]
        public Decimal? UnitCost { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Amount", Order = 16)]
        public Decimal? Amount { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Notes", Order = 17)]
        public IEnumerable<Note> Notes { get; protected set; } 

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}

