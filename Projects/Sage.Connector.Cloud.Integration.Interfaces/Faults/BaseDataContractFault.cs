using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    /// <summary>
    /// Serializable base class for faults
    /// </summary>
    [KnownType(typeof(ConnectivityFault))]
    [KnownType(typeof(IncompatibleClientFault))]
    [KnownType(typeof(InvalidResponseFault))]
    [KnownType(typeof(RetiredEndpointFault))]
    [KnownType(typeof(SerializationFault))]
    [KnownType(typeof(TenantConnectionDisabledFault))]
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "BaseDataContractFaultContract")]
    public abstract class BaseDataContractFault : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="message"></param>
        public BaseDataContractFault(String message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the BaseDataContractFault class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public BaseDataContractFault(BaseDataContractFault source, IEnumerable<PropertyTuple> propertyTuples)
        {
            Message = source.Message;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(BaseDataContractFault));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// The error message
        /// </summary>
        [DataMember(Name = "Message", IsRequired = true, Order = 0)]
        public String Message { get; protected set; }

        #endregion


        #region IExtensibleDataObject Members

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
        
        #endregion
    }
}
