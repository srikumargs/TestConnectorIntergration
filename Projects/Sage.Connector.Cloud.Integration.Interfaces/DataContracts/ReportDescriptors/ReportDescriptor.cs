using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// Description of a report
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "ReportDescriptorContract")]
    public class ReportDescriptor : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ReportDescriptor class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="applicationName"></param>
        /// <param name="menuPath"></param>
        /// <param name="path"></param>
        /// <param name="reportParams"></param>
        /// <param name="systemFilterParams"></param>
        public ReportDescriptor(
            String uniqueIdentifier, 
            String name,
            String description, 
            String category,
            String applicationName,
            String menuPath,
            String path,
            IEnumerable<ReportParam> reportParams,
            IEnumerable<SystemFilterParam> systemFilterParams
            )
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            Description = description;
            Category = category;
            ApplicationName = applicationName;
            MenuPath = menuPath;
            Path = path;
            ReportParams = reportParams.ToArray();
            SystemFilterParams = systemFilterParams.ToArray();
        }

        /// <summary>
        /// Constructor - transient failure
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="indeterminateResultMessage"></param>
        public ReportDescriptor(
            String uniqueIdentifier,
            String name,
            ErrorInformation indeterminateResultMessage
            )
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
            IsIndeterminateResult = true;
            IndeterminateResultMessage = indeterminateResultMessage;
        }

        /// <summary>
        /// Initializes a new instance of the ReportDescriptor class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public ReportDescriptor(ReportDescriptor source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            Category = source.Category;
            ApplicationName = source.ApplicationName;
            MenuPath = source.MenuPath;
            Path = source.Path;
            ReportParams = source.ReportParams; 
            SystemFilterParams = source.SystemFilterParams;
            ExtensionData = source.ExtensionData;
            IsIndeterminateResult = source.IsIndeterminateResult;
            IndeterminateResultMessage = source.IndeterminateResultMessage;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(ReportDescriptor));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties

        /// <summary>
        /// UniqueIdentifier - This is a string from the client what can be used to uniquely
        /// identify this report.
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public String UniqueIdentifier { get; protected set; }
        
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "Name", IsRequired = true, Order = 1)]
        public String Name { get; protected set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember(Name = "Description", IsRequired = true, Order = 2)]
        public String Description { get; protected set; }

        /// <summary>
        /// Category
        /// </summary>
        [DataMember(Name = "Category", IsRequired = true, Order = 3)]
        public String Category { get; protected set; }
        
        /// <summary>
        /// ApplicationName
        /// </summary>
        [DataMember(Name = "ApplicationName", IsRequired = true, Order = 4)]
        public String ApplicationName { get; protected set; }

        /// <summary>
        /// MenuPath
        /// </summary>
        [DataMember(Name = "MenuPath", IsRequired = true, Order = 5)]
        public String MenuPath { get; protected set; }

        /// <summary>
        /// Path
        /// Not necessarily tied to a real file system
        /// </summary>
        [DataMember(Name = "Path", IsRequired = true, Order = 6)]
        public String Path { get; protected set; }

        /// <summary>
        /// Parameters
        /// </summary>
        [DataMember(Name = "ReportParams", IsRequired = true, Order = 7)]
        public ReportParam[] ReportParams { get; protected set; }

        /// <summary>
        /// System Filters
        /// </summary>
        [DataMember(Name = "SystemFilterParams", IsRequired = true, Order = 8)]
        public SystemFilterParam[] SystemFilterParams { get; protected set; }

        /// <summary>
        /// Is Indeterminate Result
        /// </summary>
        [DataMember(Name = "IsIndeterminateResult", IsRequired = true, Order = 9)]
        public Boolean IsIndeterminateResult { get; set; }

        /// <summary>
        /// Indeterminate Result Message - reason for the indeterminate result
        /// </summary>
        [DataMember(Name = "IndeterminateResultMessage", IsRequired = true, Order = 10)]
        public ErrorInformation IndeterminateResultMessage { get; set; }


        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}