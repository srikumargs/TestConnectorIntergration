using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Error information to pass to caller chain
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ErrorInformationContract")]
    public class ErrorInformation : IExtensibleDataObject
    {
        /// <summary>
        /// Construct ErrorInformation
        /// </summary>
        /// <param name="rawErrorMessage"></param>
        /// <param name="userFacingErrorMessage"></param>
        public ErrorInformation(string rawErrorMessage, String userFacingErrorMessage)
        {
            if (String.IsNullOrEmpty(rawErrorMessage))
                throw new ArgumentException(_argumentExceptionMessage, "rawErrorMessage");

            RawErrorMessage = rawErrorMessage;

            UserFacingErrorMessage = userFacingErrorMessage ?? string.Empty;
        }

        /// <summary>
        /// Construct ErrorInformation - will populate the UserFacingMessage value with the empty string
        /// </summary>
        /// <param name="rawErrorMessage"></param>
        public ErrorInformation(String rawErrorMessage)
        {
            if (String.IsNullOrEmpty(rawErrorMessage))
                throw new ArgumentException(_argumentExceptionMessage, "rawErrorMessage");

            RawErrorMessage = rawErrorMessage;
            UserFacingErrorMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the ErrorInformation class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ErrorInformation(ErrorInformation source, IEnumerable<PropertyTuple> propertyTuples)
        {
            RawErrorMessage = source.RawErrorMessage;
            UserFacingErrorMessage = source.UserFacingErrorMessage;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ErrorInformation));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        /// <summary>
        /// Raw Error message for a developer.
        /// This should always be none empty.
        /// This maybe the same as the UserFaceingErrorMessage.
        /// </summary>

        [DataMember(Name = "RawErrorMessage", IsRequired = true, Order = 0)]
        public String RawErrorMessage { get; private set; }

        /// <summary>
        /// End user presentable version of an error message.
        /// This may will be empty or populated.
        /// </summary>
        [DataMember(Name = "UserFacingErrorMessage", IsRequired = true, Order = 1)]
        public String UserFacingErrorMessage { get; private set; }

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        private static readonly string _argumentExceptionMessage = "String argument can not be null or empty.";
    }
}
