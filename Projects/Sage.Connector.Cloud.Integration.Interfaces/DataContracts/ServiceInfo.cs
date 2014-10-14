using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ServiceInfoContract")]
    public class ServiceInfo : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ServiceInfo class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uri"></param>
        /// <param name="serviceNamespace"></param>
        public ServiceInfo(String name, Uri uri, String serviceNamespace)
        {
            Name = name;
            Uri = uri;
            ServiceNamespace = serviceNamespace;
        }

        /// <summary>
        /// Initializes a new instance of the ServiceInfo class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ServiceInfo(ServiceInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Name = source.Name;
            Uri = source.Uri;
            ServiceNamespace = source.ServiceNamespace;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ServiceInfo));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        /// <summary>
        /// The name identifier of the service
        /// </summary>
        /// <remarks>
        /// Refer to Sage.Connector.Cloud.Integration.Interfaces.ServiceConstants for the service name values. 
        /// This mechanism is purposefully loosely coupled so that new services and versions can be 
        /// brought up without any impact to the IGatewayService, SiteServiceInfo or ServiceInfo contracts.
        /// </remarks>
        [DataMember(Name = "Name", IsRequired = true, Order = 0)]
        public String Name { get; protected set; }

        [DataMember(Name = "Uri", IsRequired = true, Order = 1)]
        public Uri Uri { get; protected set; }

        [DataMember(Name = "ServiceNamespace", IsRequired = true, Order = 2)]
        public String ServiceNamespace { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}