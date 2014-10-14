using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Specification for a system filter value
    /// </summary>
    [KnownType(typeof(SingleValueSystemFilterParamValue))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SystemFilterParamValueContract")]
    public abstract class SystemFilterParamValue : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SystemFilterParamValue class 
        /// </summary>
        public SystemFilterParamValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SystemFilterParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SystemFilterParamValue(SystemFilterParamValue source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SystemFilterParamValue));
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
