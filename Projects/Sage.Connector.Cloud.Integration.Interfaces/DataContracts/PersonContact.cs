using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "PersonContactContract")]
    public class PersonContact : IExtensibleDataObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PersonContact class 
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="companyUniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="phone"></param>
        /// <param name="extension"></param>
        /// <param name="fax"></param>
        /// <param name="mobile"></param>
        /// <param name="pager"></param>
        /// <param name="email"></param>
        /// <param name="webAddress"></param>
        /// <param name="status"> </param>
        public PersonContact(
            String uniqueIdentifier, String companyUniqueIdentifier,
            String name, String description,
            String phone, String extension, String fax, String mobile, String pager,
            String email, String webAddress, String status)
        {
            UniqueIdentifier = uniqueIdentifier;
            CompanyUniqueIdentifier = companyUniqueIdentifier;
            Name = name;
            Description = description;
            Phone = phone;
            Extension = extension;
            Fax = fax;
            Mobile = mobile;
            Pager = pager;
            Email = email;
            WebAddress = webAddress;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the PersonContact class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public PersonContact(PersonContact source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            CompanyUniqueIdentifier = source.CompanyUniqueIdentifier;
            Name = source.Name;
            Description = source.Description;
            Phone = source.Phone;
            Extension = source.Extension;
            Fax = source.Fax;
            Mobile = source.Mobile;
            Pager = source.Pager;
            Email = source.Email;
            WebAddress = source.WebAddress;
            Status = source.Status;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(PersonContact));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion    

        #region Public properties

        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public String UniqueIdentifier { get; protected set; }

        [DataMember(Name = "CompanyUniqueIdentifier", IsRequired = true, Order = 1)]
        public String CompanyUniqueIdentifier { get; protected set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 2)]
        public String Name { get; protected set; }

        [DataMember(Name = "Description", IsRequired = true, Order = 3)]
        public String Description { get; protected set; }

        [DataMember(Name = "Phone", IsRequired = true, Order = 4)]
        public String Phone { get; protected set; }

        [DataMember(Name = "Extension", IsRequired = true, Order = 5)]
        public String Extension { get; protected set; }

        [DataMember(Name = "Fax", IsRequired = true, Order = 6)]
        public String Fax { get; protected set; }

        [DataMember(Name = "Mobile", IsRequired = true, Order = 7)]
        public String Mobile { get; protected set; }

        [DataMember(Name = "Pager", IsRequired = true, Order = 8)]
        public String Pager { get; protected set; }

        [DataMember(Name = "Email", IsRequired = true, Order = 9)]
        public String Email { get; protected set; }

        [DataMember(Name = "WebAddress", IsRequired = true, Order = 10)]
        public String WebAddress { get; protected set; }

        [DataMember(Name = "Status", IsRequired = true, Order = 11)]
        public String Status { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
