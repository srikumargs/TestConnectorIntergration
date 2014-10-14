using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TenantInfoContract")]
    public class TenantInfo : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TenantInfo class
        /// </summary>
        /// <param name="publicUri"></param>
        /// <param name="name"></param>
        public TenantInfo(Uri publicUri, String name)
        {
            PublicUri = publicUri;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the TenantInfo class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public TenantInfo(TenantInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            PublicUri = source.PublicUri;
            Name = source.Name;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TenantInfo));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "PublicUri", IsRequired = true, Order = 0)]
        public Uri PublicUri { get; protected set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 1)]
        public String Name { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}