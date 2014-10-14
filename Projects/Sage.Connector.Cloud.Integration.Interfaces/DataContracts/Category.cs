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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "CategoryContract")]
    public class Category : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the Category class
        /// </summary>
        /// <param name="jobUniqueIdentifier"></param>
        /// <param name="subJobUniqueIdentifier"> </param>
        /// <param name="costCodeUniqueIdentifier"> </param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        public Category(String jobUniqueIdentifier, String subJobUniqueIdentifier, String costCodeUniqueIdentifier, String uniqueIdentifier, String name, String description, String type, String status)
        {
            JobUniqueIdentifier = jobUniqueIdentifier;
            SubJobUniqueIdentifier = subJobUniqueIdentifier;
            CostCodeUniqueIdentifier = costCodeUniqueIdentifier;
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
            Type = type;
            Status = status;
        }

        /// <summary>
        ///  Initializes a new instance of the Category class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public Category(Category source, IEnumerable<PropertyTuple> propertyTuples)
        {
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            SubJobUniqueIdentifier = source.SubJobUniqueIdentifier;
            CostCodeUniqueIdentifier = source.CostCodeUniqueIdentifier;
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            Type = source.Type;
            Status = source.Status;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Category));
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
        [DataMember(Name = "CostCodeUniqueIdentifier", IsRequired = true, Order = 2)]
        public string CostCodeUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 3)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Name", Order = 4)]
        public string Name { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Description", Order = 5)]
        public string Description { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Type", Order = 6)]
        public string Type { get; protected set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Status", Order = 7)]
        public string Status { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
