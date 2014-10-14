using System;
using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    /// <summary>
    /// Fault for serialization issues.
    /// Convert to this type when we hit the internal exception NetDispatcherFaultException
    /// In a custom service IErrorHandler, for example
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SerializationFaultContract")]
    public class SerializationFault : BaseDataContractFault
    {
        #region Constructors
        
        /// <summary>
        /// Fully-specified constructor
        /// Note: no mutable constructor as there are no properties in this derived type
        /// </summary>
        /// <param name="message"></param>
        public SerializationFault(String message)
            : base(message)
        {
        }

        #endregion
    }
}
