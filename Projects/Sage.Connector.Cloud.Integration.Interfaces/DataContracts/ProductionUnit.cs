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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ProductionUnitContract")]
    public class ProductionUnit : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the ProductionUnit class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="jobUniqueIdentifier"></param>
        /// <param name="subJobUniqueIdentifier"></param>
        /// <param name="costCodeUniqueIdentifier"></param>
        /// <param name="reportDate"></param>
        /// <param name="reportUnit"></param>
        /// <param name="notes"></param>
        public ProductionUnit(
            String uniqueIdentifier,
            String jobUniqueIdentifier,
            String subJobUniqueIdentifier,
            String costCodeUniqueIdentifier,
            DateTime reportDate,
            Decimal reportUnit,
            IEnumerable<Note> notes )
        {
            UniqueIdentifier = uniqueIdentifier;
            JobUniqueIdentifier = jobUniqueIdentifier;
            SubJobUniqueIdentifier = subJobUniqueIdentifier;
            CostCodeUniqueIdentifier = costCodeUniqueIdentifier;
            ReportDate = reportDate;
            ReportUnit = reportUnit;
            Notes = notes;
        }

        /// <summary>
        ///  Initializes a new instance of the ProductionUnit class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public ProductionUnit(ProductionUnit source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            SubJobUniqueIdentifier = source.SubJobUniqueIdentifier;
            CostCodeUniqueIdentifier = source.CostCodeUniqueIdentifier;
            ReportDate = source.ReportDate;
            ReportUnit = source.ReportUnit;
            Notes = source.Notes;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ProductionUnit));
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
        [DataMember(Name = "JobUniqueIdentifier", IsRequired = true, Order = 1)]
        public string JobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SubJobUniqueIdentifier", Order = 2)]
        public string SubJobUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CostCodeUniqueIdentifier", IsRequired = true, Order = 3)]
        public string CostCodeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ReportDate", IsRequired = true, Order = 4)]
        public DateTime ReportDate { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ReportUnit", IsRequired = true, Order = 5)]
        public Decimal ReportUnit { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Notes", IsRequired = true, Order = 6)]
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

