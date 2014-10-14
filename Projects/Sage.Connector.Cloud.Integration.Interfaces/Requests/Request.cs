using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// KnownTypes are required each time the Request object hierarchy is expanded.  This is 
    /// needed for polymorphic serialization support with the DataContractSerializer
    /// </remarks>
    [KnownType(typeof(DomainMediationRequest))]
    [KnownType(typeof(ConnectorRegistrationRequest))]
    [KnownType(typeof(GetLogRequest))]
    [KnownType(typeof(GetMetricsRequest))]
    [KnownType(typeof(HealthCheckRequest))]
    [KnownType(typeof(LoopBackRequest))]
    [KnownType(typeof(UpdateConfigParamsRequest))]
    [KnownType(typeof(UpdateSiteServiceInfoRequest))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "RequestContract")]
    public class Request : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Request class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority">The request priority.</param>
        /// <param name="requestingUser"></param>
        /// <param name="projectName"></param>
        /// <param name="requestSummary"> </param>
        public Request(Guid id, DateTime createdTimestampUtc, UInt32 retryCount, UInt32 priority, String requestingUser, String projectName, String requestSummary)
        {
            Id = id;
            CreatedTimestampUtc = createdTimestampUtc;
            RetryCount = retryCount;
            Priority = priority;
            RequestingUser = requestingUser;
            ProjectName = projectName;
            RequestSummary = requestSummary;
        }

        /// <summary>
        /// Initializes a new instance of the Request class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public Request(Request source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Id = source.Id;
            CreatedTimestampUtc = source.CreatedTimestampUtc;
            RetryCount = source.RetryCount;
            RequestingUser = source.RequestingUser;
            ExtensionData = source.ExtensionData;
            ProjectName = source.ProjectName;
            RequestSummary = source.RequestSummary;
            Priority = source.Priority;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Request));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "Id", IsRequired = true, Order = 0)]
        public Guid Id { get; protected set; }

        [DataMember(Name = "CreatedTimestampUtc", IsRequired = true, Order = 1)]
        public DateTime CreatedTimestampUtc { get; protected set; }

        /// <summary>
        /// The number of retries this request has gone through
        /// </summary>
        [DataMember(Name = "RetryCount", IsRequired = true, Order = 2)]
        public UInt32 RetryCount { get; protected set; }

        [DataMember(Name = "RequestingUser", IsRequired = true, Order = 3)]
        public String RequestingUser { get; protected set; }

        /// <summary>
        /// User facing cloud project name associated with the request
        /// </summary>
        [DataMember(Name = "ProjectName", IsRequired = true, Order = 4)]
        public String ProjectName { get; protected set; }

        /// <summary>
        /// User Facing request summary
        /// </summary>
        [DataMember(Name = "RequestSummary", IsRequired = true, Order = 5)]
        public String RequestSummary { get; protected set; }

        /// <summary>
        /// Identifier to retrieve the 'full' message
        /// </summary>
        [DataMember(Name = "IndirectPayloadDownloadId", IsRequired = true, Order = 6)]
        public String IndirectPayloadDownloadId { get; protected set; }

        /// <summary>
        /// Identifier to retrieve the 'full' message
        /// </summary>
        [DataMember(Name = "Priority", IsRequired = true, Order = 7)]
        public UInt32 Priority { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion


        #region "Overrides"
        /// <summary>
        /// To String (Debug)
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        { return String.Format("{0}", this.Id); }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="target">Item to compare</param>
        /// <returns>Equality</returns>
        public override Boolean Equals(Object target)
        {
            Boolean result = false;

            Request targetAsRequest = (target as Request);
            if (targetAsRequest != null)
            {
                result = targetAsRequest.Id.Equals(this.Id);
            }

            return result;
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>HashCode</returns>
        public override Int32 GetHashCode()
        { return this.Id.GetHashCode(); }
        #endregion
    }
}