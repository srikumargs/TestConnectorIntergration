using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.Faults
{
    /// <summary>
    /// General fault when there is an issue connecting to the service
    /// For example, this covers a bad tenant or premise Id in a message.
    /// Note: If using the provided message inspectors, this fault should only
    /// Be thrown there, meaning the actual service implementation will not 
    /// Need to throw it.
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ConnectivityFaultContract")]
    public class ConnectivityFault : BaseDataContractFault
    {
        #region Constructors
        
        /// <summary>
        /// Fully-specified constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ConnectivityFault(HttpStatusCode statusCode, String message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the ConnectivityFault class from an existing instance 
        /// And a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ConnectivityFault(ConnectivityFault source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            StatusCode = source.StatusCode;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ConnectivityFault));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #endregion


        #region Public properties

        [DataMember(Name = "StatusCode", IsRequired = true, Order = 0)]
        public HttpStatusCode StatusCode { get; protected set; }

        #endregion
    }
}
