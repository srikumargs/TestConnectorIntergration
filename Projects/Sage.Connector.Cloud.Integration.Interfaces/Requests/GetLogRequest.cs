using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "GetLogRequestContract")]
    public class GetLogRequest : Request
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GetActivityLogsRequest class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        /// <param name="criteriaString"></param>
        public GetLogRequest(Guid id, DateTime createdTimestampUtc, UInt32 retryCount, UInt32 priority, String requestingUser, String criteriaString)
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        {
            CriteriaString = criteriaString;
        }

        /// <summary>
        /// Initializes a new instance of the GetActivityLogsRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public GetLogRequest(GetLogRequest source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            CriteriaString = source.CriteriaString;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(GetLogRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "CriteriaString", IsRequired = true, Order = 0)]
        public String CriteriaString { get; protected set; }

        #endregion
    }
}
