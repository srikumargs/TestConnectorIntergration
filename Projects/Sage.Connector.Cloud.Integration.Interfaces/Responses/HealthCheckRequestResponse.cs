using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "HealthCheckRequestResponseContract")]
    public class HealthCheckRequestResponse : Response
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the HealthCheckRequestResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="userFacingMessages"></param>
        /// <param name="rawMessages"></param>
        /// <param name="status"></param>
        public HealthCheckRequestResponse(Guid requestId, Guid id, DateTime createdTimestampUtc, 
            HealthCheckStatus status,
            IEnumerable<String> userFacingMessages,
            IEnumerable<String> rawMessages)
            : base(requestId, id, createdTimestampUtc)
        {
            Status = status;

            StringList userFacingMessagesStringList;
            if (userFacingMessages == null)
                userFacingMessagesStringList = new StringList();
            else
                userFacingMessagesStringList = new StringList(userFacingMessages);
            UserFacingMessages = userFacingMessagesStringList;

            StringList rawMessagesStringList = (rawMessages == null ? new StringList() : new StringList(rawMessages));
            RawMessages = rawMessagesStringList;
        }

        /// <summary>
        /// Initializes a new instance of the HealthCheckRequestResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public HealthCheckRequestResponse(HealthCheckRequestResponse source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Status = source.Status;
            UserFacingMessages = source.UserFacingMessages;
            RawMessages = source.RawMessages;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(HealthCheckRequestResponse));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "Status", IsRequired = true, Order = 0)]
        public HealthCheckStatus Status { get; protected set; }

        [DataMember(Name = "UserFacingMessages", IsRequired = true, Order = 1)]
        public StringList UserFacingMessages { get; protected set; }

        [DataMember(Name = "RawMessages", IsRequired = true, Order = 2)]
        public StringList RawMessages { get; protected set; }

        #endregion
    }
}