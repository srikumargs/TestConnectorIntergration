using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DomainMediationRequest")]
    public class DomainMediationRequest : Request
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DomainMediationRequest
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        /// <param name="domainMediationEntry"></param>
        public DomainMediationRequest(Guid id,
            DateTime createdTimestampUtc,
            UInt32 retryCount,
            UInt32 priority,
            String requestingUser,
            DomainMediation domainMediationEntry )
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        {
            DomainMediationEntry = domainMediationEntry;
        }

        /// <summary>
        /// Initializes a new instance of the PostTimeEntryRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public DomainMediationRequest(DomainMediationRequest source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            DomainMediationEntry = source.DomainMediationEntry;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(DomainMediationRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// Collection of time entries to post
        /// </summary>
        [DataMember(Name = "DomainMediationEntry", IsRequired = true, Order = 0)]
        [IndirectPayload(IndirectPayloadUsage.Allowed, null)]
        public DomainMediation DomainMediationEntry { get; protected set; }

        #endregion
    }
}
