using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// EntityTypeTag
    /// </summary>
    [KnownType(typeof(JobEntityTypeTag))]
    [KnownType(typeof(VendorEntityTypeTag))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "EntityTypeTagContract")]
    public class EntityTypeTag : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the EntityTypeTag class
        /// </summary>
        public EntityTypeTag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the EntityTypeTag class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public EntityTypeTag(EntityTypeTag source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(EntityTypeTag));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}

