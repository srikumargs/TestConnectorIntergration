using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "GetMetricsRequestResponseContract")]
    public class GetMetricsRequestResponse : Response
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GetMetricsRequestResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="lastGetMetricsRequestResponseId"> </param>
        /// <param name="lastMetricsRequestResponseCreatedTimestampUtc"> </param>
        /// <param name="attemptedGetRequestsCalls"> </param>
        /// <param name="failedGetRequestsCalls"> </param>
        /// <param name="attemptedPutResponsesCalls"> </param>
        /// <param name="failedPutResponsesCalls"> </param>
        /// <param name="requestsReceived"> </param>
        /// <param name="responsesSent"> </param>
        public GetMetricsRequestResponse(
            Guid requestId,
            Guid id,
            DateTime createdTimestampUtc,
            Guid lastGetMetricsRequestResponseId,
            DateTime lastMetricsRequestResponseCreatedTimestampUtc,
            UInt32 attemptedGetRequestsCalls,
            UInt32 failedGetRequestsCalls,
            UInt32 attemptedPutResponsesCalls,
            UInt32 failedPutResponsesCalls,
            UInt32 requestsReceived,
            UInt32 responsesSent)
            : base(requestId, id, createdTimestampUtc)
        {
            LastGetMetricsRequestResponseId = lastGetMetricsRequestResponseId;
            LastMetricsRequestResponseCreatedTimestampUtc = lastMetricsRequestResponseCreatedTimestampUtc;
            AttemptedGetRequestsCalls = attemptedGetRequestsCalls;
            FailedGetRequestsCalls = failedGetRequestsCalls;
            AttemptedPutResponsesCalls = attemptedPutResponsesCalls;
            FailedPutResponsesCalls = failedPutResponsesCalls;
            RequestsReceived = requestsReceived;
            ResponsesSent = responsesSent;
        }

        /// <summary>
        /// Initializes a new instance of the GetMetricsRequestResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public GetMetricsRequestResponse(GetMetricsRequestResponse source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            LastGetMetricsRequestResponseId = source.LastGetMetricsRequestResponseId;
            LastMetricsRequestResponseCreatedTimestampUtc = source.LastMetricsRequestResponseCreatedTimestampUtc;
            AttemptedGetRequestsCalls = source.AttemptedGetRequestsCalls;
            FailedGetRequestsCalls = source.FailedGetRequestsCalls;
            AttemptedPutResponsesCalls = source.AttemptedPutResponsesCalls;
            FailedPutResponsesCalls = source.FailedPutResponsesCalls;
            RequestsReceived = source.RequestsReceived;
            ResponsesSent = source.ResponsesSent;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(GetMetricsRequestResponse));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        /// <summary>
        /// The response ID of the last successfully transmitted GetMetricsRequestResponse
        /// </summary>
        /// <remarks>
        /// Helps Cloud correlate the period for which these counts and averages apply to
        /// </remarks>
        [DataMember(Name = "LastGetMetricsRequestResponseId", IsRequired = true, Order = 0)]
        public Guid LastGetMetricsRequestResponseId { get; protected set; }

        /// <summary>
        /// The UTC timestamp of the last successfully transmitted GetMetricsRequestResponse
        /// </summary>
        /// <remarks>
        /// Helps Cloud correlate the period for which these counts and averages apply to
        /// </remarks>
        [DataMember(Name = "LastMetricsRequestResponseCreatedTimestampUtc", IsRequired = true, Order = 1)]
        public DateTime LastMetricsRequestResponseCreatedTimestampUtc { get; protected set; }

        /// <summary>
        /// A count of the attempted number of GetRequests() calls made since the last successfully transmitted
        /// GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "AttemptedGetRequestsCalls", IsRequired = true, Order = 2)]
        public UInt32 AttemptedGetRequestsCalls { get; protected set; }

        /// <summary>
        /// A count of the failed number of GetRequests() calls made since the last successfully transmitted
        /// GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "FailedGetRequestsCalls", IsRequired = true, Order = 3)]
        public UInt32 FailedGetRequestsCalls { get; protected set; }

        /// <summary>
        /// A count of the attempted number of PutResponses() calls made since the last successfully transmitted
        /// GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "AttemptedPutResponsesCalls", IsRequired = true, Order = 4)]
        public UInt32 AttemptedPutResponsesCalls { get; protected set; }

        /// <summary>
        /// A count of the failed number of PutResponses() calls made since the last successfully transmitted
        /// GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "FailedPutResponsesCalls", IsRequired = true, Order = 5)]
        public UInt32 FailedPutResponsesCalls { get; protected set; }

        /// <summary>
        /// A count of the total number of requests received since the last successfully transmitted GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "RequestsReceived", IsRequired = true, Order = 6)]
        public UInt32 RequestsReceived { get; protected set; }

        /// <summary>
        /// A count of the total number of responses sent since the last successfully transmitted GetMetricsRequestResponse
        /// </summary>
        [DataMember(Name = "ResponsesSent", IsRequired = true, Order = 7)]
        public UInt32 ResponsesSent { get; protected set; }

        [DataMember(Name = "CpuProfileData", IsRequired = true, Order = 8)]
        public CpuProfileData[] CpuProfileData { get; protected set; }

        [DataMember(Name = "OSVersion", IsRequired = true, Order = 9)]
        public String OSVersion { get; protected set; }

        [DataMember(Name = "OSVersionString", IsRequired = true, Order = 10)]
        public String OSVersionString { get; protected set; }

        [DataMember(Name = "TotalPhysicalMemoryInMB", IsRequired = true, Order = 11)]
        public Int64 TotalPhysicalMemoryInMB { get; protected set; }

        [DataMember(Name = "TotalPageFileMemoryInMB", IsRequired = true, Order = 12)]
        public Int64 TotalPageFileMemoryInMB { get; protected set; }

        [DataMember(Name = "TotalVirtualMemoryInMB", IsRequired = true, Order = 13)]
        public Int64 TotalVirtualMemoryInMB { get; protected set; }

        // TODO: The exact types and names of the following additional metrics still TBD:
        //ConnectorDiskCapacity: the size of the disk being used by Connector
        //ConnectorDiskFreeSpace: the available space on the disk being used by the Connector
        //CpuUtilizationFactor: the average CPU utilization since last successful GetMetrics
        //MemoryUtilizationFactor: the average memory utilization since last successful GetMetrics
        //DiskUtilizationFactor: the average disk utilization since last successful GetMetrics
        //RequestProcessingLoad: the average number of skyfire requests that were processed in parallel since last successful GetMetrics
        //PeakRequestProcessingLoad: the maximum number of skyfire requests that were processed in parallel since last successful GetMetrics
        //ConnectorRestartCount: the number of time the Connector was restarted since last successful GetMetrics
        //ConnectorUptime: the uptime of the Connector service (i.e., how long since last restart)
        //ConnectorDBSize: the size of the Connector's DB
        //ConnectorDocumentRepositorySize: the amount of space occupied by this tenant's Document manager repository (in Connector)
        //ConnectorInboxQueueAge:  average amount of time requests spent in the Connector's Inbox queue
        //ConnectorOutboxQueueAge: average amount of time requests spent in the Connector's Outbox queue
        //ConnectorBinderQueueAge: average amount of time requests spent in the Connector's Binder queue (i.e., the "being processed" queue)
        //ConnectorInboxQueueSize:  average number of requests in the Connector's Inbox queue
        //ConnectorOutboxQueueSize: average number of requests in the Connector's Outbox queue
        //ConnectorBinderQueueSize: average number of requests in the Connector's Binder queue (i.e., the "being processed" queue)

        // TODO: do we need generic name value pairs so client can push up new data bits to cloud without requiring cloud contract update?
        // Should we have optionaly name value pairs? Depends in the end on how values get used. NV pairs that are required is not in line with current approach

        #endregion
    }
}