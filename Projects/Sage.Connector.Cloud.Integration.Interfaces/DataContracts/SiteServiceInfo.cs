using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SiteServiceInfoContract")]
    public class SiteServiceInfo : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ServiceInfo class
        /// </summary>
        /// <param name="currentInterfaceVersion"> </param>
        /// <param name="currentProductVersion"> </param>
        /// <param name="currentProductUpgradeInfo"> </param>
        /// <param name="siteAddressBaseUri"></param>
        /// <param name="serviceInfos"> </param>
        public SiteServiceInfo(String currentInterfaceVersion, String currentProductVersion, UpgradeInfo currentProductUpgradeInfo, Uri siteAddressBaseUri, IEnumerable<ServiceInfo> serviceInfos)
        {
            CurrentInterfaceVersion = currentInterfaceVersion;
            CurrentConnectorProductVersion = currentProductVersion;
            CurrentConnectorProductUpgradeInfo = currentProductUpgradeInfo;
            SiteAddressBaseUri = siteAddressBaseUri;
            ServiceInfos = serviceInfos.ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the ServiceInfo class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SiteServiceInfo(SiteServiceInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            CurrentInterfaceVersion = source.CurrentInterfaceVersion;
            CurrentConnectorProductVersion = source.CurrentConnectorProductVersion;
            CurrentConnectorProductUpgradeInfo = source.CurrentConnectorProductUpgradeInfo;
            SiteAddressBaseUri = source.SiteAddressBaseUri;
            ServiceInfos = source.ServiceInfos; 
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SiteServiceInfo));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        /// <summary>
        /// A string representation of the AssemblyFileVersion of the current supported Sage.Connector.Cloud.Integration.Interfaces.dll
        /// </summary>
        [DataMember(Name = "CurrentInterfaceVersion", IsRequired = true, Order = 0)]
        public String CurrentInterfaceVersion { get; protected set; }

        /// <summary>
        /// A string representation of the current product version of the Connector
        /// </summary>
        [DataMember(Name = "CurrentConnectorProductVersion", IsRequired = true, Order = 1)]
        public String CurrentConnectorProductVersion { get; protected set; }

        [DataMember(Name = "CurrentConnectorProductUpgradeInfo", IsRequired = true, Order = 2)]
        public UpgradeInfo CurrentConnectorProductUpgradeInfo { get; protected set; }

        [DataMember(Name = "SiteAddressBaseUri", IsRequired = true, Order = 3)]
        public Uri SiteAddressBaseUri { get; protected set; }

        [DataMember(Name = "ServiceInfos", IsRequired = true, Order = 4)]
        public ServiceInfo[] ServiceInfos { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}
