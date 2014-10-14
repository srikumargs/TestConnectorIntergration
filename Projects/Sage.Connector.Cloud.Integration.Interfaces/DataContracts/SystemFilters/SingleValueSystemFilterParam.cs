using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Specification of a report that supports a single report parameter
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SingleValueSystemFilterParamContract")]
    public class SingleValueSystemFilterParam : SystemFilterParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SingleValueSystemFilterParam class 
        /// </summary>
        public SingleValueSystemFilterParam(ReportParam singleFilterParam)
            : base()
        {
            SingleFilterParam = singleFilterParam;
        }

        /// <summary>
        /// Initializes a new instance of the SingleValueSystemFilterParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SingleValueSystemFilterParam(SingleValueSystemFilterParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            SingleFilterParam = source.SingleFilterParam;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SingleValueSystemFilterParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// SingleFilterParam
        /// </summary>
        [DataMember(Name = "SingleFilterParam", IsRequired = true, Order = 0)]
        public ReportParam SingleFilterParam { get; protected set; }

        #endregion
    }
}
