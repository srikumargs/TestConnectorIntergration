using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "KeyNameContract")]
    public class KeyName : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the KeyName class
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        public KeyName(String key, String name)
        {
            Key = key;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the KeyName class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public KeyName(KeyName source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Key = source.Key;
            Name = source.Name;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(KeyName));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// Key
        /// </summary>
        [DataMember(Name = "Key", IsRequired = true, Order = 0)]
        public String Key { get; protected set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "Name", IsRequired = true, Order = 1)]
        public String Name { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion    
    }
}
