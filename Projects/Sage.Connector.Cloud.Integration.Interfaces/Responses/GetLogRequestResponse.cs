using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "GetLogRequestResponseContract")]
    public class GetLogRequestResponse : Response
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GetActivityLogsRequestResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="uploadId"></param>
        public GetLogRequestResponse(Guid requestId, Guid id, DateTime createdTimestampUtc, String uploadId)
            : base(requestId, id, createdTimestampUtc)
        {
            UploadId = uploadId;
        }

        /// <summary>
        /// Initializes a new instance of the GetActivityLogsRequestResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public GetLogRequestResponse(GetLogRequestResponse source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            UploadId = source.UploadId;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(GetLogRequestResponse));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "LogUploadId", IsRequired = true, Order = 0)]
        public String UploadId { get; protected set; }
        #endregion
    }
}