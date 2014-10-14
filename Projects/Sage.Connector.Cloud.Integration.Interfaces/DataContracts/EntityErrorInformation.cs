using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Error information to pass to caller chain
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "EntityErrorInformationOfType{0}")]
    public class EntityErrorInformation<TEntity> : IExtensibleDataObject
    {
        /// <summary>
        /// Construct ErrorInformation
        /// </summary>
        /// <param name="errorInfo"></param>
        /// <param name="errorEntity"></param>
        public EntityErrorInformation(ErrorInformation errorInfo, TEntity errorEntity)
        {
            ErrorInfo = errorInfo;
            ErrorEntity = errorEntity;
        }

        /// <summary>
        /// Initializes a new instance of the ErrorInformation class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public EntityErrorInformation(EntityErrorInformation<TEntity> source, IEnumerable<PropertyTuple> propertyTuples)
        {
            ErrorInfo = source.ErrorInfo;
            ErrorEntity = source.ErrorEntity;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(EntityErrorInformation<TEntity>));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        /// <summary>
        /// Raw Error message for a developer.
        /// This should always be none empty.
        /// This maybe the same as the UserFaceingErrorMessage.
        /// </summary>

        [DataMember(Name = "ErrorInfo", IsRequired = true, Order = 0)]
        public ErrorInformation ErrorInfo { get; private set; }

        /// <summary>
        /// End user presentable version of an error message.
        /// This may will be empty or populated.
        /// </summary>
        [DataMember(Name = "ErrorEntity", IsRequired = true, Order = 1)]
        public TEntity ErrorEntity { get; private set; }

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
