using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// KnownTypes are required each time the Response object hierarchy is expanded.  This is 
    /// needed for polymorphic serialization support with the DataContractSerializer
    /// </remarks>
    [KnownType(typeof(DomainMediationRequestResponse))]
    [KnownType(typeof(ErrorResponse))]
    [KnownType(typeof(GetLogRequestResponse))]
    [KnownType(typeof(GetMetricsRequestResponse))]
    [KnownType(typeof(HealthCheckRequestResponse))]
    [KnownType(typeof(LoopBackRequestResponse))]
    [KnownType(typeof(UpdateConfigParamsRequestResponse))]
    [KnownType(typeof(UpdateSiteServiceInfoRequestResponse))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ResponseContract")]
    public class Response : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Response class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        public Response(Guid requestId, Guid id, DateTime createdTimestampUtc)
        {
            RequestId = requestId;
            Id = id;
            CreatedTimestampUtc = createdTimestampUtc;
        }

        public Response(Guid requestId, Guid id, DateTime createdTimestampUtc, String indirectPayloadUploadId)
        {
            RequestId = requestId;
            Id = id;
            CreatedTimestampUtc = createdTimestampUtc;
            IndirectPayloadUploadId = indirectPayloadUploadId;
        }

        /// <summary>
        /// Initializes a new instance of the Response class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public Response(Response source, IEnumerable<PropertyTuple> propertyTuples)
        {
            RequestId = source.RequestId;
            Id = source.Id;
            CreatedTimestampUtc = source.CreatedTimestampUtc;
            IndirectPayloadUploadId = source.IndirectPayloadUploadId;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Response));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "RequestId", IsRequired = true, Order = 0)]
        public Guid RequestId { get; protected set; }

        [DataMember(Name = "Id", IsRequired = true, Order = 1)]
        public Guid Id { get; protected set; }

        [DataMember(Name = "CreatedTimestampUtc", IsRequired = true, Order = 2)]
        public DateTime CreatedTimestampUtc { get; protected set; }

        [DataMember(Name = "IndirectPayloadUploadId", IsRequired = true, Order = 3)]
        public String IndirectPayloadUploadId { get; protected set; }

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

            Response targetAsResponse = (target as Response);
            if (targetAsResponse != null)
            {
                result = targetAsResponse.Id.Equals(this.Id);
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