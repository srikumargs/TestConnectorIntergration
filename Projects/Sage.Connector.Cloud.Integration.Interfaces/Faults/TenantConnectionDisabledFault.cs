using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TenantConnectionDisabledActionContract")]
    public enum TenantConnectionDisabledAction
    {
        /// No kind (default value automatically initialized by runtime)
        [EnumMember]
        None = 0,

        [EnumMember]
        DisableOnly,

        [EnumMember]
        Delete
    }

    /// <summary>
    /// General fault when there is an a valid tenant, credentials, and URI's
    /// are used ... but the tenant site has been disabled (e.g., due to administrative action).
    /// Could occur because a site has been disabled by Sage due to lack of payment.
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "TenantConnectionDisabledFaultContract")]
    public class TenantConnectionDisabledFault : BaseDataContractFault
    {   
        #region Constructors
         
        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="action"> </param>
        /// <param name="message"></param>
        public TenantConnectionDisabledFault(TenantConnectionDisabledAction action, String message)
            : base(message)
        {
            Action = action;
        }

        /// <summary>
        /// Initializes a new instance of the ConnectivityFault class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public TenantConnectionDisabledFault(TenantConnectionDisabledFault source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            Action = source.Action;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(TenantConnectionDisabledFault));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
 
        #endregion


        #region Public properties
        [DataMember(Name = "Action", IsRequired = true, Order = 0)]
        public TenantConnectionDisabledAction Action { get; protected set; }
        #endregion
    }
}
