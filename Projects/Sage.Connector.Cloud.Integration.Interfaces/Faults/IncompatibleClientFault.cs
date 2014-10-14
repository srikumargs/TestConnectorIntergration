using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    /// <summary>
    /// General fault when the connecting client is "down-rev'ed" (e.g., a known incompatible
    /// product version of the client or a client version that appears to currently be using
    /// a version of the interface DLL older than the minimum supported).
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "IncompatibleClientFaultContract")]
    public class IncompatibleClientFault : BaseDataContractFault
    {
        #region Constructors

        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="miniumInterfaceVersion"></param>
        /// <param name="miniumProductVersion"></param>
        /// <param name="currentProductUpgradeInfo"></param>
        public IncompatibleClientFault(String message, String miniumInterfaceVersion, String miniumProductVersion, UpgradeInfo currentProductUpgradeInfo)
            : base(message)
        {
            MiniumInterfaceVersion = miniumInterfaceVersion;
            MiniumConnectorProductVersion = miniumProductVersion;
            CurrentConnectorProductUpgradeInfo = currentProductUpgradeInfo;
        }

        /// <summary>
        /// Initializes a new instance of the ConnectivityFault class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public IncompatibleClientFault(IncompatibleClientFault source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            MiniumInterfaceVersion = source.MiniumInterfaceVersion;
            MiniumConnectorProductVersion = source.MiniumConnectorProductVersion;
            CurrentConnectorProductUpgradeInfo = source.CurrentConnectorProductUpgradeInfo;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(IncompatibleClientFault));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "MiniumInterfaceVersion", IsRequired = true, Order = 0)]
        public String MiniumInterfaceVersion { get; protected set; }

        [DataMember(Name = "MiniumConnectorProductVersion", IsRequired = true, Order = 1)]
        public String MiniumConnectorProductVersion { get; protected set; }

        [DataMember(Name = "CurrentConnectorProductUpgradeInfo", IsRequired = true, Order = 2)]
        public UpgradeInfo CurrentConnectorProductUpgradeInfo { get; protected set; }
        
        #endregion
    }
}
