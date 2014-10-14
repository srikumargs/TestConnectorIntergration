using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// A tag representing a 'vendor' entity
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "VendorEntityTypeTagContract")]
    public class VendorEntityTypeTag : EntityTypeTag
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the VendorEntityTypeTag class
        /// </summary>
        public VendorEntityTypeTag()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the VendorEntityTypeTag class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public VendorEntityTypeTag(VendorEntityTypeTag source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(VendorEntityTypeTag));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion
    }
}