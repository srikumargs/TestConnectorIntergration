using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// A system filter report specification
    /// </summary>
    [KnownType(typeof(SingleValueSystemFilterParam))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SystemFilterParamContract")]
    public abstract class SystemFilterParam : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SystemFilterParam class 
        /// </summary>
        public SystemFilterParam()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SystemFilterParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SystemFilterParam(SystemFilterParam source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SystemFilterParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }

        }

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
