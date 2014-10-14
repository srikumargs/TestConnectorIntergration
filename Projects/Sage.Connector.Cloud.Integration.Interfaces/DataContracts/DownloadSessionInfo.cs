using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DownloadSessionInfoContract")]
    public class DownloadSessionInfo : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of DownloadSessionInfo with all values specified
        /// </summary>
        /// <param name="downloadSessionKey"></param>
        /// <param name="downloadDestinationName"></param>
        /// <param name="downloadContainerUri"></param>
        /// <param name="downloadDirectoryPath"></param>
        /// <param name="downloadSizeInBytes"></param>
        public DownloadSessionInfo(
            string downloadSessionKey,
            string downloadDestinationName,
            Uri downloadContainerUri,
            string downloadDirectoryPath,
            Int32 downloadSizeInBytes)
        {
            DownloadSessionKey = downloadSessionKey;
            DownloadDestinationName = downloadDestinationName;
            DownloadContainerUri = downloadContainerUri;
            DownloadDirectoryPath = downloadDirectoryPath;
            DownloadSizeInBytes = downloadSizeInBytes;
        }

        /// <summary>
        /// Initializes a new instance of the UploadSessionInfo class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public DownloadSessionInfo(DownloadSessionInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            // Copy over values from the source
            DownloadSessionKey = source.DownloadSessionKey;
            DownloadDestinationName = source.DownloadDestinationName;
            DownloadContainerUri = source.DownloadContainerUri;
            DownloadDirectoryPath = source.DownloadDirectoryPath;
            DownloadSizeInBytes = source.DownloadSizeInBytes;
            ExtensionData = source.ExtensionData;

            // Edit properties from the tuple collection
            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(UploadSessionInfo));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// The key used to identify an upload session
        /// </summary>
        [DataMember(Name = "DownloadSessionKey", IsRequired = true, Order = 0)]
        public string DownloadSessionKey { get; protected set; }

        /// <summary>
        /// The name of the destination for this upload
        /// This is how both the client and service identify the upload
        /// </summary>
        [DataMember(Name = "DownloadDestinationName", IsRequired = true, Order = 1)]
        public string DownloadDestinationName { get; protected set; }

        /// <summary>
        /// The Uri of the container for the tenant
        /// Which is where this new blob will be going
        /// </summary>
        [DataMember(Name = "DownloadContainerUri", IsRequired = true, Order = 2)]
        public Uri DownloadContainerUri { get; protected set; }

        /// <summary>
        /// The directory path, if any, for the resulting blob
        /// </summary>
        [DataMember(Name = "DownloadDirectoryPath", IsRequired = true, Order = 3)]
        public string DownloadDirectoryPath { get; protected set; }

        /// <summary>
        /// The download file size in bytes
        /// </summary>
        [DataMember(Name = "DownloadSizeInBytes", IsRequired = true, Order = 4)]
        public Int32 DownloadSizeInBytes { get; protected set; }

        #endregion


        #region IExtensibleDataObject Members

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}