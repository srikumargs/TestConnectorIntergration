using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// A tag representing a 'job' entity
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "JobEntityTypeTagContract")]
    public class JobEntityTypeTag : EntityTypeTag
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the JobEntityTypeTag class
        /// </summary>
        public JobEntityTypeTag() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the JobEntityTypeTag class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public JobEntityTypeTag(JobEntityTypeTag source, IEnumerable<PropertyTuple> propertyTuples)
            : base (source, propertyTuples)
        {
            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(JobEntityTypeTag));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion
    }
}