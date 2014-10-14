using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;
using Sage.Connector.Cloud.Integration.Interfaces.WebAPI;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UpdateConfigParamsRequestContract")]
    public class UpdateConfigParamsRequest : Request
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UpdateConfigParamsRequest class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="configParams"> </param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        public UpdateConfigParamsRequest(Guid id, DateTime createdTimestampUtc, Configuration configParams, UInt32 retryCount, UInt32 priority, String requestingUser)
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        {
            ConfigParams = configParams;
        }

        /// <summary>
        /// Initializes a new instance of the UpdateConfigParamsRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public UpdateConfigParamsRequest(UpdateConfigParamsRequest source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            ConfigParams = source.ConfigParams;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(UpdateConfigParamsRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "ConfigParams", IsRequired = true, Order = 0)]
        public Configuration ConfigParams { get; protected set; }
        #endregion
    }
}