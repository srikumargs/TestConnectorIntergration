using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Requests
{
    /// <summary>
    /// Request for the Connector to re-query the GatewayService & AdminService for the ServiceInfo's
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UpdateSiteServiceInfoRequestContract")]
    public class UpdateSiteServiceInfoRequest : Request
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UpdateServiceInfoRequest class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTimestampUtc"></param>
        /// <param name="retryCount"></param>
        /// <param name="priority"></param>
        /// <param name="requestingUser"></param>
        /// <param name="siteAddressBaseUri"></param>
        public UpdateSiteServiceInfoRequest(Guid id, DateTime createdTimestampUtc, UInt32 retryCount, UInt32 priority, String requestingUser, Uri siteAddressBaseUri)
            : base(id, createdTimestampUtc, retryCount, priority, requestingUser, null, null)
        {
            SiteAddressBaseUri = siteAddressBaseUri;
        }

        /// <summary>
        /// Initializes a new instance of the UpdateServiceInfoRequest class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public UpdateSiteServiceInfoRequest(UpdateSiteServiceInfoRequest source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            SiteAddressBaseUri = source.SiteAddressBaseUri;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(UpdateSiteServiceInfoRequest));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "SiteAddressBaseUri", IsRequired = true, Order = 0)]
        public Uri SiteAddressBaseUri { get; protected set; }
        #endregion
    }
}