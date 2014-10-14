using System;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;

namespace Sage.Connector
{
    /// <summary>
    /// A Sage message
    /// </summary>
    [DataContract]
    public class WebAPIMessage
    {
        /// <summary>
        /// Unique identifier for this message
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Message type identifier
        /// </summary>
        [DataMember(Name = "bodytype")]
        public String BodyType { get; set; }
        /// <summary>
        /// Date and time of request
        /// </summary>
        [DataMember(Name = "timestamp")]
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Version of the message
        /// </summary>
        [DataMember(Name = "version")]
        public int Version { get; set; }
        /// <summary>
        /// Serialized value of the cloud/back office entities
        /// </summary>
        [DataMember(Name = "body")]
        public String Body { get; set; }
        /// <summary>
        /// Computed hash of the body content
        /// </summary>
        [DataMember(Name = "bodyhash")]
        public String BodyHash { get; set; }
        /// <summary>
        /// Encapsulate information indicating the location of blob storage for large uploads
        /// </summary>
        [DataMember(Name="uploadsessioninfo")]
        public UploadSessionInfo UploadSessionInfo { get; set; }
        /// <summary>
        /// Identifier of the original message / request
        /// </summary>
        [DataMember(Name = "correlationid")]
        public Guid CorrelationId { get; set; }
    }
}
