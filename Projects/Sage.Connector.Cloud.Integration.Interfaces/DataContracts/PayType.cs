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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PayTypeContract")]
    public class PayType : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the PayType class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="categoryUniqueIdentifier"></param>
        public PayType(String uniqueIdentifier, String name, String description, String categoryUniqueIdentifier)
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
            CategoryUniqueIdentifier = categoryUniqueIdentifier;
        }

        /// <summary>
        ///  Initializes a new instance of the PayType class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public PayType(PayType source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            CategoryUniqueIdentifier = source.CategoryUniqueIdentifier;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PayType));
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

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CategoryUniqueIdentifier", Order = 3)]
        public string CategoryUniqueIdentifier { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
