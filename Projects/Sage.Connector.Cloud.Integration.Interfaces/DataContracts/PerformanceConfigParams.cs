using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PerformanceConfigParamsContract")]
    public class PerformanceConfigParams : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        // Initializes a new instance of the ConfigParams class
        /// </summary>
        /// <param name="maxResponseBatchCount"></param>
        /// <param name="largeResponseSizeThreshold"></param>
        /// <param name="minGetRequestsInterval"></param>
        /// <param name="maxGetRequestsInterval"></param>
        public PerformanceConfigParams(
            UInt32 maxResponseBatchCount,
            UInt32 largeResponseSizeThreshold,
            TimeSpan minGetRequestsInterval,
            TimeSpan maxGetRequestsInterval)
        {
            MaxResponseBatchCount = maxResponseBatchCount;
            LargeResponseSizeThreshold = largeResponseSizeThreshold;
            MinGetRequestsInterval = minGetRequestsInterval;
            MaxGetRequestsInterval = maxGetRequestsInterval;
        }

        /// <summary>
        /// Initializes a new instance of the ConfigParams class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public PerformanceConfigParams(PerformanceConfigParams source, IEnumerable<PropertyTuple> propertyTuples)
        {
            MaxResponseBatchCount = source.MaxResponseBatchCount;
            LargeResponseSizeThreshold = source.LargeResponseSizeThreshold;
            MinGetRequestsInterval = source.MinGetRequestsInterval;
            MaxGetRequestsInterval = source.MaxGetRequestsInterval;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PerformanceConfigParams));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion
        [DataMember(Name = "MaxResponseBatchCount", IsRequired = true, Order = 0)]
        public UInt32 MaxResponseBatchCount { get; protected set; }

        [DataMember(Name = "LargeResponseSizeThreshold", IsRequired = true, Order = 1)] 
        public UInt32 LargeResponseSizeThreshold { get; protected set; }

        [DataMember(Name = "MinGetRequestsInterval", IsRequired = true, Order = 2)]
        public TimeSpan MinGetRequestsInterval { get; protected set; }

        [DataMember(Name = "MaxGetRequestsInterval", IsRequired = true, Order = 3)]
        public TimeSpan MaxGetRequestsInterval { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
