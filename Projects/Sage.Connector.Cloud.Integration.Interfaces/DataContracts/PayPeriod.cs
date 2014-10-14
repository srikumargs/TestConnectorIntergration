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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PayPeriodContract")]
    public class PayPeriod : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the PayPeriod class 
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="startPeriod"></param>
        /// <param name="endPeriod"></param>
        public PayPeriod(String uniqueIdentifier, DateTime? startPeriod, DateTime endPeriod)
        {
            UniqueIdentifier = uniqueIdentifier;
            StartPeriod = startPeriod;
            EndPeriod = endPeriod;
        }

        /// <summary>
        ///  Initializes a new instance of the PayPeriod class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public PayPeriod(PayPeriod source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            StartPeriod = source.StartPeriod;
            EndPeriod = source.EndPeriod;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PayPeriod));
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
        [DataMember(Name = "StartPeriod", Order = 1)]
        public DateTime? StartPeriod { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "EndPeriod", IsRequired = true, Order = 2)]
        public DateTime EndPeriod { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
