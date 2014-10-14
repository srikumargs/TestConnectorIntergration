using System;
using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    /// <summary>
    /// General fault for an invalid response sent up to the cloud
    /// I.E. Connectivity has been established, but the response itself is invalid for
    /// Any number of reasons.  For example, there is no corresponding request.
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "InvalidResponseFaultContract")]
    public class InvalidResponseFault : BaseDataContractFault
    {

        #region Constructors
        
        /// <summary>
        /// Fully-specified constructor
        /// Note: no mutable constructor as there are no properties in this derived type
        /// </summary>
        /// <param name="message"></param>
        public InvalidResponseFault(String message)
            : base(message)
        {
        }

        #endregion
    }
}
