using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DomainMediationContract")]
    public class DomainMediationRequestResponse : Response
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DomainMediationRequestResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="domainMediationEntry"></param>
        public DomainMediationRequestResponse(
            Guid requestId,
            Guid id,
            DateTime createdTimestampUtc,
            DomainMediation domainMediationEntry
           )
            : base(requestId, id, createdTimestampUtc)
        {
            DomainMediationEntry = domainMediationEntry;
        }

        /// <summary>
        /// Initializes a new instance of the PostTimeEntryRequestResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public DomainMediationRequestResponse(DomainMediationRequestResponse source, IEnumerable<PropertyTuple> propertyTuples) : base(source, propertyTuples)
        {
            var tupleList = propertyTuples.ToList();

            var tuples = tupleList.Where(x => x.Item1.DeclaringType == typeof(DomainMediation));
            
            if (tuples.Any())
            {
                DomainMediationEntry = new DomainMediation(source.DomainMediationEntry, tuples); 
            }
            else
            {
                DomainMediationEntry = source.DomainMediationEntry;
            }

            var myPropertyTuples = tupleList.Where(x => x.Item1.DeclaringType == typeof(DomainMediationRequestResponse));

            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// Posted DomainMediation
        /// </summary>
        [IndirectPayload(IndirectPayloadUsage.Allowed, null)]
        [DataMember(Name = "DomainMediationEntry", IsRequired = true, Order = 0)]
        public DomainMediation DomainMediationEntry { get; protected set; }

        #endregion
    }
}