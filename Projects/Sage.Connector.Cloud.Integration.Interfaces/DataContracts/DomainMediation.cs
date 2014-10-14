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
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "DomainMediationContract")]
    public class DomainMediation : IExtensibleDataObject
    {

        /// <summary>
        /// Initializes a new instance of the DomainMediation class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="domainFeatureRequest">Domain feature request name or id</param>
        /// <param name="payload">feature request payload</param>
        /// <param name="payloadType">feature request payload type (e.g. json)</param>
        public DomainMediation(String uniqueIdentifier, String domainFeatureRequest, String payload, String payloadType) 
        {
            UniqueIdentifier = uniqueIdentifier;
            DomainFeatureRequest = domainFeatureRequest;
            Payload = payload;
            PayloadType = payloadType;
        }

        /// <summary>
        ///  Initializes a new instance of the DomainMediation class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public DomainMediation(DomainMediation source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            DomainFeatureRequest = source.DomainFeatureRequest;
            Payload = source.Payload;
            PayloadType = source.PayloadType;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(DomainMediation));

            foreach (var tuple in myPropertyTuples)
            {
                var propInfo = tuple.Item1;

                if (propInfo.PropertyType.IsAssignableFrom(typeof(StringList)))
                {
                    var list = (StringList)propInfo.GetValue(this);

                    if (list != null) list.Add(tuple.Item2.ToString());
                }
                else
                {
                    tuple.Item1.SetValue(this, tuple.Item2, null);
                }
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
        [DataMember(Name = "DomainFeatureRequest", Order = 3)]
        public string DomainFeatureRequest { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Payload", Order = 4)]
        public string Payload { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PayloadType", Order = 5)]
        public string PayloadType { get; protected set; }

        #endregion

        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}

