using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ConfigParamsContract")]
    public class ConfigParams : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ConfigParams class
        /// </summary>
        /// <param name="normalPerformanceConfigParams"></param>
        /// <param name="peakPerformanceConfigParams"></param>
        /// <param name="peakHoursStartTimeOfDayUtc"></param>
        /// <param name="peakHoursDuration"></param>
        /// <param name="communicationBlackoutStartTimeOfDayUtc"></param>
        /// <param name="communicationBlackoutDuration"></param>
        /// <param name="suggestedMaxConnectorUptimeDuration"></param>
        /// <param name="minCommunicationFailureRetryInterval"></param>
        /// <param name="maxCommunicationFailureRetryInterval"></param>
        /// <param name="maxBlobSize"></param>
        public ConfigParams(
            PerformanceConfigParams normalPerformanceConfigParams,
            PerformanceConfigParams peakPerformanceConfigParams,
            TimeSpan? peakHoursStartTimeOfDayUtc,
            TimeSpan? peakHoursDuration,
            TimeSpan? communicationBlackoutStartTimeOfDayUtc,
            TimeSpan? communicationBlackoutDuration,
            TimeSpan? suggestedMaxConnectorUptimeDuration,
            TimeSpan minCommunicationFailureRetryInterval,
            TimeSpan maxCommunicationFailureRetryInterval,
            long maxBlobSize = 16 * 1024 * 1000)
        {
            NormalPerformanceConfigParams = normalPerformanceConfigParams;
            PeakPerformanceConfigParams = peakPerformanceConfigParams;
            PeakHoursStartTimeOfDayUtc = peakHoursStartTimeOfDayUtc;
            PeakHoursDuration = peakHoursDuration;
            CommunicationBlackoutStartTimeOfDayUtc = communicationBlackoutStartTimeOfDayUtc;
            CommunicationBlackoutDuration = communicationBlackoutDuration;
            SuggestedMaxConnectorUptimeDuration = suggestedMaxConnectorUptimeDuration;
            MinCommunicationFailureRetryInterval = minCommunicationFailureRetryInterval;
            MaxCommunicationFailureRetryInterval = maxCommunicationFailureRetryInterval;
            MaxBlobSize = maxBlobSize;
        }

        /// <summary>
        /// Initializes a new instance of the ConfigParams class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ConfigParams(ConfigParams source, IEnumerable<PropertyTuple> propertyTuples)
        {
            NormalPerformanceConfigParams = source.NormalPerformanceConfigParams;
            PeakPerformanceConfigParams = source.PeakPerformanceConfigParams;
            PeakHoursStartTimeOfDayUtc = source.PeakHoursStartTimeOfDayUtc;
            PeakHoursDuration = source.PeakHoursDuration;
            CommunicationBlackoutStartTimeOfDayUtc = source.CommunicationBlackoutStartTimeOfDayUtc;
            CommunicationBlackoutDuration = source.CommunicationBlackoutDuration;
            SuggestedMaxConnectorUptimeDuration = source.SuggestedMaxConnectorUptimeDuration;
            MinCommunicationFailureRetryInterval = source.MinCommunicationFailureRetryInterval;
            MaxCommunicationFailureRetryInterval = source.MaxCommunicationFailureRetryInterval;
            MaxBlobSize = source.MaxBlobSize;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ConfigParams));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion

        #region Public properties
        [DataMember(Name = "NormalPerformanceConfigParams", IsRequired = true, Order = 0)]
        public PerformanceConfigParams NormalPerformanceConfigParams { get; protected set; }

        [DataMember(Name = "PeakPerformanceConfigParams", IsRequired = true, Order = 1)]
        public PerformanceConfigParams PeakPerformanceConfigParams { get; protected set; }

        [DataMember(Name = "PeakHoursStartTimeOfDayUtc", IsRequired = true, Order = 2)]
        public TimeSpan? PeakHoursStartTimeOfDayUtc { get; protected set; }

        [DataMember(Name = "PeakHoursDuration", IsRequired = true, Order = 3)]
        public TimeSpan? PeakHoursDuration { get; protected set; }

        [DataMember(Name = "CommunicationBlackoutStartTimeOfDayUtc", IsRequired = true, Order = 4)]
        public TimeSpan? CommunicationBlackoutStartTimeOfDayUtc { get; protected set; }

        [DataMember(Name = "CommunicationBlackoutDuration", IsRequired = true, Order = 5)]
        public TimeSpan? CommunicationBlackoutDuration { get; protected set; }

        [DataMember(Name = "SuggestedMaxConnectorUptimeDuration", IsRequired = true, Order = 6)]
        public TimeSpan? SuggestedMaxConnectorUptimeDuration { get; protected set; }

        [DataMember(Name = "MinCommunicationFailureRetryInterval", IsRequired = true, Order = 7)]
        public TimeSpan MinCommunicationFailureRetryInterval { get; protected set; }

        [DataMember(Name = "MaxCommunicationFailureRetryInterval", IsRequired = true, Order = 8)]
        public TimeSpan MaxCommunicationFailureRetryInterval { get; protected set; }

        [DataMember(Name = "MaxBlobSize", IsRequired = true, Order = 9)]
        public long MaxBlobSize { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}
