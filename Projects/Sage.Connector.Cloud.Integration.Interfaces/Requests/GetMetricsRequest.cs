using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "GetMetricsRequestContract")]
    public class GetMetricsRequest : Request
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GetMetricsRequest class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        public GetMetricsRequest(Guid id, DateTime createdTimestampUtc, UInt32 retryCount, UInt32 priority, String requestingUser)
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the GetMetricsRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public GetMetricsRequest(GetMetricsRequest source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            // Property1 = source.Property1;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(GetMetricsRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        #endregion
    }
}