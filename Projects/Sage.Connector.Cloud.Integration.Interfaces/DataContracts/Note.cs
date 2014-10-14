using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "NoteContract")]
    public class Note : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the Note class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="referenceUniqueIdentifier"></param>
        /// <param name="user"></param>
        /// <param name="content"></param>
        /// <param name="noteDate"></param>
        public Note(String uniqueIdentifier, String referenceUniqueIdentifier, String user, String content, DateTime noteDate)
        {
            UniqueIdentifier = uniqueIdentifier;
            ReferenceUniqueIdentifier = referenceUniqueIdentifier;
            User = user;
            Content = content;
            NoteDate = noteDate;
        }

        /// <summary>
        ///  Initializes a new instance of the Note class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public Note(Note source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            ReferenceUniqueIdentifier = source.ReferenceUniqueIdentifier;
            User = source.User;
            Content = source.Content;
            NoteDate = source.NoteDate;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Note));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ReferenceUniqueIdentifier", IsRequired = true, Order = 1)]
        public string ReferenceUniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "User", IsRequired = true, Order = 2)]
        public string User { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Content", IsRequired = true, Order = 3)]
        public string Content { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "NoteDate", IsRequired = true, Order = 4)]
        public DateTime NoteDate { get; protected set; }

        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
