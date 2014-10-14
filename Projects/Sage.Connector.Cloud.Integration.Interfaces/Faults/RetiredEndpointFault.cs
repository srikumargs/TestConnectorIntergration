using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "RetiredEndpointFaultContract")]
    public class RetiredEndpointFault : BaseDataContractFault
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RetiredEndpointFault class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="siteAddressBaseUri"></param>
        public RetiredEndpointFault(String message, Uri siteAddressBaseUri)
            : base(message)
        {
            SiteAddressBaseUri = siteAddressBaseUri;
        }

        /// <summary>
        /// Initializes a new instance of the RetiredEndpointFault class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public RetiredEndpointFault(RetiredEndpointFault source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            SiteAddressBaseUri = source.SiteAddressBaseUri;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(RetiredEndpointFault));
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