using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    /// <summary>
    /// A connector driven request to register a collaboration for the specified tenant
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ConnectorRegistrationRequestContract")]
    public class ConnectorRegistrationRequest : Request
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        /// <param name="backOfficeCompanyUniqueId"></param>
        /// <param name="connectorInstanceId"></param>
        public ConnectorRegistrationRequest(
            Guid id,
            DateTime createdTimestampUtc,
            UInt32 retryCount,
            UInt32 priority,
            String requestingUser,
            String backOfficeCompanyUniqueId,
            String connectorInstanceId)
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        {
            BackOfficeCompanyUniqueId = backOfficeCompanyUniqueId;
            ConnectorInstanceId = connectorInstanceId;
        }

        /// <summary>
        /// Initializes a new instance of the ConnectorRegistrationRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ConnectorRegistrationRequest(ConnectorRegistrationRequest source,
            IEnumerable<PropertyTuple> propertyTuples) :
            base(source, propertyTuples)
        {
            BackOfficeCompanyUniqueId = source.BackOfficeCompanyUniqueId;
            ConnectorInstanceId = source.ConnectorInstanceId;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ConnectorRegistrationRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        /// <summary>
        /// The unique identifier for the collaborating back office company
        /// </summary>
        [DataMember(Name = "BackOfficeCompanyUniqueId", IsRequired=true, Order = 0)]
        public String BackOfficeCompanyUniqueId { get; protected set; }

        /// <summary>
        /// The unique connector instance identifier
        /// </summary>
        [DataMember(Name = "ConnectorInstanceId", IsRequired=true, Order = 1)]
        public String ConnectorInstanceId { get; protected set; }
    }
}
