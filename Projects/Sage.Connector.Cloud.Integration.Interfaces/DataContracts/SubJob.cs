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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SubJobContract")]
    public class SubJob : IExtensibleDataObject
    {

        /// <summary>
        ///  Initializes a new instance of the Subjob class
        /// </summary>
        /// <param name="jobUniqueIdentifier"></param>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        public SubJob(String jobUniqueIdentifier, String uniqueIdentifier, String name, String description, String status)
        {
            JobUniqueIdentifier = jobUniqueIdentifier;
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
            Status = status;
        }

        /// <summary>
        ///  Initializes a new instance of the Subjob class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public SubJob(SubJob source, IEnumerable<PropertyTuple> propertyTuples)
        {
            JobUniqueIdentifier = source.JobUniqueIdentifier;
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            Status = source.Status;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SubJob));
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
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 1)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Name", Order = 2)]
        public string Name { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Description", Order = 3)]
        public string Description { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Status", Order = 4)]
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
