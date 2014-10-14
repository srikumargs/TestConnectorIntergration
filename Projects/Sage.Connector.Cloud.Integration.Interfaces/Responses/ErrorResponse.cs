using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ErrorResponseContract")]
    public class ErrorResponse : Response
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ErrorResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="messages"></param>
        /// <param name="errorResponseAction"></param>
        /// <param name="suggestedRetryInterval"></param>
        public ErrorResponse(
            Guid requestId, 
            Guid id,
            DateTime createdTimestampUtc, 
            IEnumerable<ErrorInformation> messages, 
            ErrorResponseAction errorResponseAction,
            TimeSpan? suggestedRetryInterval)
            : base(requestId, id, createdTimestampUtc)
        {
            Messages = messages.ToArray();
            SuggestedRetryInterval = suggestedRetryInterval;
            ErrorResponseAction = errorResponseAction;
        }

        /// <summary>
        /// Initializes a new instance of the ErrorResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ErrorResponse(ErrorResponse source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Messages = source.Messages; 
            SuggestedRetryInterval = source.SuggestedRetryInterval;
            ErrorResponseAction = source.ErrorResponseAction;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ErrorResponse));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "Messages", IsRequired = true, Order = 0)]
        public ErrorInformation[] Messages { get; protected set; }

        /// <summary>
        /// Suggested Retry Interval. Null indicates no retry.
        /// </summary>
        [DataMember(Name = "SuggestedRetryInterval", IsRequired = true, Order = 1)]
        public TimeSpan? SuggestedRetryInterval { get; protected set; }

        /// <summary>
        /// The action to take for this error
        /// </summary>
        [DataMember(Name = "ErrorResponseAction", IsRequired = true, Order = 2)]
        public ErrorResponseAction ErrorResponseAction { get; protected set; }

        #endregion
    }
}