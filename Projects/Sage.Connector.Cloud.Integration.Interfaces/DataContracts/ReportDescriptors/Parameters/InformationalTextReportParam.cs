using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "InformationalTextReportParamContract")]
    public class InformationalTextReportParam : ReportParam
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the InformationalTextReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="premiseMetadata"></param>
        /// <param name="entityType"></param>
        public InformationalTextReportParam(String name, String displayText, String premiseMetadata, EntityTypeTag entityType)
            : base(name, displayText, false, premiseMetadata, entityType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InformationalTextReportParam class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        /// <param name="premiseMetadata"></param>
        public InformationalTextReportParam(String name, String displayText, String premiseMetadata)
            : base(name, displayText, false, premiseMetadata)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InformationalTextReportParam class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public InformationalTextReportParam(InformationalTextReportParam source, IEnumerable<PropertyTuple> propertyTuples)
            : base(source, propertyTuples)
        {
            // add assignments for properties belonging to this class, e.g.,
            // Property1 = source.Property1;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(InformationalTextReportParam));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion
    }
}
