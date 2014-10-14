using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PremiseAgentContract")]
    public class PremiseAgent : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="connectorFileVersion">The connector file version.</param>
        /// <param name="connectorProductCode">The connector product code.</param>
        /// <param name="connectorProductName">Name of the connector product.</param>
        /// <param name="connectorProductVersion">The connector product version.</param>
        /// <param name="backOfficeProductId">The back office product identifier.</param>
        /// <param name="backOfficeProductName">Name of the back office product.</param>
        /// <param name="backOfficeProductVersion">The back office product version.</param>
        /// <param name="backOfficeProductPluginFileVersion">The back office product plugin file version.</param>
        /// <param name="interfaceVersion">A String representation of the AssemblyFileVersion of the Sage.Connector.Cloud.Integration.Interfaces.dll being used</param>
        /// <param name="systemDateTimeUtc">The system date time UTC.</param>
        /// <param name="backOfficeCompanyName">Name of the back office company.</param>
        /// <param name="autoUpdateProductId">The automatic update product identifier.</param>
        /// <param name="autoUpdateProductVersion">The automatic update product version.</param>
        /// <param name="autoUpdateComponentBaseName">Name of the automatic update component base.</param>
        /// <param name="runAsUserIsRequired">The run as user is required.</param>
        /// <param name="platform">The platform.</param>
        public PremiseAgent(String connectorFileVersion, 
            String connectorProductCode,
            String connectorProductName,
            String connectorProductVersion,
            String backOfficeProductId,
            String backOfficeProductName,
            String backOfficeProductVersion,
            String backOfficeProductPluginFileVersion,
            String interfaceVersion,
            DateTime systemDateTimeUtc,
            String backOfficeCompanyName,
            String autoUpdateProductId,
            String autoUpdateProductVersion,
            String autoUpdateComponentBaseName,
            Boolean runAsUserIsRequired,
            String platform
            )
        {
            ConnectorFileVersion = connectorFileVersion;
            ConnectorProductCode = connectorProductCode;
            ConnectorProductName = connectorProductName;
            ConnectorProductVersion = connectorProductVersion;
            BackOfficeProductId = backOfficeProductId;
            BackOfficeProductName = backOfficeProductName;
            BackOfficeProductVersion = backOfficeProductVersion;
            BackOfficeProductPluginFileVersion = backOfficeProductPluginFileVersion;
            InterfaceVersion = interfaceVersion;
            SystemDateTimeUtc = systemDateTimeUtc;

            BackOfficeCompanyName = backOfficeCompanyName;
            AutoUpdateProductId = autoUpdateProductId;
            AutoUpdateProductVersion = autoUpdateProductVersion;
            AutoUpdateComponentBaseName = autoUpdateComponentBaseName;
            RunAsUserIsRequired = runAsUserIsRequired;
            Platform = platform;
        }

        /// <summary>
        /// Initializes a new instance of the PremiseAgent class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public PremiseAgent(PremiseAgent source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ConnectorFileVersion = source.ConnectorFileVersion;
            ConnectorProductCode = source.ConnectorProductCode;
            ConnectorProductName = source.ConnectorProductName;
            ConnectorProductVersion = source.ConnectorProductVersion;
            BackOfficeProductId = source.BackOfficeProductId;
            BackOfficeProductName = source.BackOfficeProductName;
            BackOfficeProductVersion = source.BackOfficeProductVersion;
            BackOfficeProductPluginFileVersion = source.BackOfficeProductPluginFileVersion;
            InterfaceVersion = source.InterfaceVersion;
            SystemDateTimeUtc = source.SystemDateTimeUtc;

            BackOfficeCompanyName = source.BackOfficeCompanyName;
            AutoUpdateProductId = source.AutoUpdateProductId;
            AutoUpdateProductVersion = source.AutoUpdateProductVersion;
            AutoUpdateComponentBaseName = source.AutoUpdateComponentBaseName;
            RunAsUserIsRequired = source.RunAsUserIsRequired;
            Platform = source.Platform;
            
            
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PremiseAgent));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        [DataMember(Name = "ConnectorFileVersion", IsRequired = true, Order = 0)]
        public String ConnectorFileVersion { get; protected set; }

        [DataMember(Name = "ConnectorProductCode", IsRequired = true, Order = 1)]
        public String ConnectorProductCode { get; protected set; }

        [DataMember(Name = "ConnectorProductName", IsRequired = true, Order = 2)]
        public String ConnectorProductName { get; protected set; }

        [DataMember(Name = "ConnectorProductVersion", IsRequired = true, Order = 3)]
        public String ConnectorProductVersion { get; protected set; }

        //this is he plugin id 
        [DataMember(Name = "BackOfficeProductId", IsRequired = true, Order = 4)]
        public String BackOfficeProductId { get; protected set; }

        [DataMember(Name = "BackOfficeProductName", IsRequired = true, Order = 5)]
        public String BackOfficeProductName { get; protected set; }

        [DataMember(Name = "BackOfficeProductVersion", IsRequired = true, Order = 6)]
        public String BackOfficeProductVersion { get; protected set; }

        [DataMember(Name = "BackOfficeProductPluginFileVersion", IsRequired = true, Order = 7)]
        public String BackOfficeProductPluginFileVersion { get; protected set; }

        //[Obsolete] ? maybe need this or an expansion of this later.
        [DataMember(Name = "InterfaceVersion", IsRequired = true, Order = 8)]
        public String InterfaceVersion { get; protected set; }

        [DataMember(Name = "SystemDateTimeUtc", IsRequired = true, Order = 9)]
        public DateTime SystemDateTimeUtc { get; protected set; }



        [DataMember(Name = "BackOfficeCompanyName", IsRequired = true, Order = 10)]
        public string BackOfficeCompanyName { get; protected set; }


        [DataMember(Name = "AutoUpdateProductId", IsRequired = true, Order = 11)]
        public string AutoUpdateProductId { get; protected set; }

        [DataMember(Name = "AutoUpdateProductVersion", IsRequired = true, Order = 12)]
        public string AutoUpdateProductVersion { get; protected set; }

        [DataMember(Name = "AutoUpdateComponentBaseName", IsRequired = true, Order = 13)]
        public string AutoUpdateComponentBaseName { get; protected set; }


        [DataMember(Name = "RunAsUserIsRequired", IsRequired = true, Order = 14)]
        public bool RunAsUserIsRequired { get; protected set; }

        [DataMember(Name = "Platform", IsRequired = true, Order = 15)]
        public string Platform { get; protected set; }


        #endregion


        #region IExtensionDataObject Members

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion


        #region Overridden Methods

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj">Item to compare</param>
        /// <returns>Equality</returns>
        public override bool Equals(object obj)
        {
            PremiseAgent pa = obj as PremiseAgent;
            if (pa == null) return false;

            return 
                (
                    (ConnectorFileVersion == pa.ConnectorFileVersion) &&
                    (ConnectorProductCode == pa.ConnectorProductCode) &&
                    (ConnectorProductName == pa.ConnectorProductName) &&
                    (ConnectorProductVersion == pa.ConnectorProductVersion) &&
                    (BackOfficeProductId == pa.BackOfficeProductId) &&
                    (BackOfficeProductName == pa.BackOfficeProductName) &&
                    (BackOfficeProductVersion == pa.BackOfficeProductVersion) &&
                    (BackOfficeProductPluginFileVersion == pa.BackOfficeProductPluginFileVersion) &&
                    (InterfaceVersion == pa.InterfaceVersion) &&

                    (BackOfficeCompanyName == pa.BackOfficeCompanyName) &&
                    (AutoUpdateProductId == pa.AutoUpdateProductId) &&
                    (AutoUpdateProductVersion == pa.AutoUpdateProductVersion) &&
                    (AutoUpdateComponentBaseName  == pa.AutoUpdateComponentBaseName) &&
                    (RunAsUserIsRequired == pa.RunAsUserIsRequired) &&
                    (Platform == pa.Platform) &&

                    (ExtensionData == pa.ExtensionData)
                );
        }

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int htoken = 0; base.GetHashCode();

            if (!string.IsNullOrEmpty(this.ConnectorFileVersion)) htoken = htoken ^ this.ConnectorFileVersion.GetHashCode();
            if (!string.IsNullOrEmpty(this.ConnectorProductCode)) htoken = htoken ^ this.ConnectorProductCode.GetHashCode();
            if (!string.IsNullOrEmpty(this.ConnectorProductName)) htoken = htoken ^ this.ConnectorProductName.GetHashCode();
            if (!string.IsNullOrEmpty(this.ConnectorProductVersion)) htoken = htoken ^ this.ConnectorProductVersion.GetHashCode();
            if (!string.IsNullOrEmpty(this.BackOfficeProductId)) htoken = htoken ^ this.BackOfficeProductId.GetHashCode();
            if (!string.IsNullOrEmpty(this.BackOfficeProductName)) htoken = htoken ^ this.BackOfficeProductName.GetHashCode();
            if (!string.IsNullOrEmpty(this.BackOfficeProductVersion)) htoken = htoken ^ this.BackOfficeProductVersion.GetHashCode();
            if (!string.IsNullOrEmpty(this.BackOfficeProductPluginFileVersion)) htoken = htoken ^ this.BackOfficeProductPluginFileVersion.GetHashCode();
            if (!string.IsNullOrEmpty(this.InterfaceVersion)) htoken = htoken ^ this.InterfaceVersion.GetHashCode();

            if (!string.IsNullOrEmpty(BackOfficeCompanyName)) htoken = htoken ^ this.BackOfficeCompanyName.GetHashCode();
            if (!string.IsNullOrEmpty(AutoUpdateProductId)) htoken = htoken ^ this.AutoUpdateProductId.GetHashCode();
            if (!string.IsNullOrEmpty(AutoUpdateProductVersion)) htoken = htoken ^ this.AutoUpdateProductVersion.GetHashCode();
            if (!string.IsNullOrEmpty(AutoUpdateComponentBaseName)) htoken = htoken ^ this.AutoUpdateComponentBaseName.GetHashCode();
            if (RunAsUserIsRequired) htoken = htoken ^ this.RunAsUserIsRequired.GetHashCode();
            if (!string.IsNullOrEmpty(Platform)) htoken = htoken ^ this.Platform.GetHashCode();

            if (!string.IsNullOrEmpty(this.InterfaceVersion)) htoken = htoken ^ this.InterfaceVersion.GetHashCode();
            if (!string.IsNullOrEmpty(this.ExtensionData.ToString())) htoken = htoken ^ this.ExtensionData.GetHashCode();

            return htoken;
        }
        #endregion
    }
}
