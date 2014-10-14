using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UpgradeInfoContract")]
    public class UpgradeInfo : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the UpgradeInfo class
        /// </summary>
        /// <param name="productVersion"></param>
        /// <param name="publicationDate"></param>
        /// <param name="interfaceVersion"></param>
        /// <param name="upgradeDescription"></param>
        /// <param name="upgradeLinkUri"></param>
        public UpgradeInfo(String productVersion, DateTime publicationDate, String interfaceVersion, String upgradeDescription, Uri upgradeLinkUri)
        {
            ProductVersion = productVersion;
            PublicationDate = publicationDate;
            InterfaceVersion = interfaceVersion;
            UpgradeDescription = upgradeDescription;
            UpgradeLinkUri = upgradeLinkUri;
        }

        /// <summary>
        /// Initializes a new instance of the UpgradeInfo class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public UpgradeInfo(UpgradeInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ProductVersion = source.ProductVersion;
            PublicationDate = source.PublicationDate;
            InterfaceVersion = source.InterfaceVersion;
            UpgradeDescription = source.UpgradeDescription;
            UpgradeLinkUri = source.UpgradeLinkUri;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(UpgradeInfo));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "ProductVersion", IsRequired = true, Order = 0)]
        public String ProductVersion { get; protected set; }

        [DataMember(Name = "PublicationDate", IsRequired = true, Order = 1)]
        public DateTime PublicationDate { get; protected set; }

        [DataMember(Name = "InterfaceVersion", IsRequired = true, Order = 2)]
        public String InterfaceVersion { get; protected set; }

        [DataMember(Name = "UpgradeDescription", IsRequired = true, Order = 3)]
        public String UpgradeDescription { get; protected set; }

        [DataMember(Name = "UpgradeLinkUri", IsRequired = true, Order = 4)]
        public Uri UpgradeLinkUri { get; protected set; }        

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}
