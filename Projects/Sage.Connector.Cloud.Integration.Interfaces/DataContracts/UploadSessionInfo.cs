using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "UploadSessionInfoContract")]
    public class UploadSessionInfo : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Default constructor for JSON serialization
        /// </summary>
        public UploadSessionInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of UploadSessionInfo with all values specified
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="destinationName"></param>
        /// <param name="containerUri"></param>
        /// <param name="directoryPath"></param>
        /// <param name="chunkSizeInBytes"></param>
        public UploadSessionInfo(
            string sessionKey, 
            string destinationName, 
            Uri containerUri,
            string directoryPath,
            Int32 chunkSizeInBytes)
        {
            SessionKey = sessionKey;
            DestinationName = destinationName;
            ContainerUri = containerUri;
            DirectoryPath = directoryPath;
            ChunkSizeInBytes = chunkSizeInBytes;
        }

        /// <summary>
        /// Initializes a new instance of the UploadSessionInfo class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public UploadSessionInfo(UploadSessionInfo source, IEnumerable<PropertyTuple> propertyTuples)
        {
            // Copy over values from the source
            SessionKey = source.SessionKey;
            DestinationName = source.DestinationName;
            ContainerUri = source.ContainerUri;
            DirectoryPath = source.DirectoryPath;
            ChunkSizeInBytes = source.ChunkSizeInBytes;
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
        [DataMember(Name = "SessionKey", IsRequired = true, Order = 0)]
        public string SessionKey { get; set; }

        /// <summary>
        /// The name of the destination for this upload
        /// This is how both the client and service identify the upload
        /// </summary>
        [DataMember(Name = "DestinationName", IsRequired = true, Order = 1)]
        public string DestinationName { get; set; }

        /// <summary>
        /// The Uri of the container for the tenant
        /// Which is where this new blob will be going
        /// </summary>
        [DataMember(Name = "ContainerUri", IsRequired = true, Order = 2)]
        public Uri ContainerUri { get; set; }

        /// <summary>
        /// The directory path, if any, for the resulting blob
        /// </summary>
        [DataMember(Name = "DirectoryPath", IsRequired = true, Order = 3)]
        public string DirectoryPath { get; set; }

        /// <summary>
        /// The size in bytes that uploads should be 'chunked'
        /// </summary>
        [DataMember(Name = "ChunkSizeInBytes", IsRequired = true, Order = 4)]
        public Int32 ChunkSizeInBytes { get; set; }


        #endregion


        #region IExtensibleDataObject Members

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
