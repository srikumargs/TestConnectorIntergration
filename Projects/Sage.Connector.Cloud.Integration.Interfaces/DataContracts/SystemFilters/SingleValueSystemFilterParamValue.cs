using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;


namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Specification of a report that supports a single report parameter value
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "SingleValueSystemFilterParamValueContract")]
    public class SingleValueSystemFilterParamValue : SystemFilterParamValue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SingleValueSystemFilterParamValue class 
        /// </summary>
        public SingleValueSystemFilterParamValue(ReportParamValue singleFilterParamValue)
            : base()
        {
            SingleFilterParamValue = singleFilterParamValue;
        }

        /// <summary>
        /// Initializes a new instance of the SingleValueSystemFilterParamValue class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public SingleValueSystemFilterParamValue(SingleValueSystemFilterParamValue source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            SingleFilterParamValue = source.SingleFilterParamValue;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(SingleValueSystemFilterParamValue));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// SingleFilterParamValue
        /// </summary>
        [DataMember(Name = "SingleFilterParamValue", IsRequired = true, Order = 0)]
        public ReportParamValue SingleFilterParamValue { get; protected set; }

        #endregion
    }
}
