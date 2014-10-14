using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Responses
{
    /// <summary>
    /// Response to request for the Connector to re-query the GatewayService & AdminService for the ServiceInfo's
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UpdateSiteServiceInfoRequestResponseContract")]
    public class UpdateSiteServiceInfoRequestResponse : Response
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UpdateServiceInfoRequestResponse class
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        public UpdateSiteServiceInfoRequestResponse(
            Guid requestId,
            Guid id,
            DateTime createdTimestampUtc)
            : base(requestId, id, createdTimestampUtc)
        { }

        /// <summary>
        /// Initializes a new instance of the UpdateServiceInfoRequestResponse class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public UpdateSiteServiceInfoRequestResponse(UpdateSiteServiceInfoRequestResponse source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            // Property1 = source.Property1;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(UpdateSiteServiceInfoRequestResponse));
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
