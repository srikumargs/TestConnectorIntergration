using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "VendorContract")]
    public class Vendor : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Vendor class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="companyContactIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="vendorType"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="mobile"></param>
        /// <param name="status"></param>
        public Vendor(
            String uniqueIdentifier, String companyContactIdentifier, String name, String description,
            String vendorType, String address1, String address2, String city, String state, String country, 
            String zip, String phone, String fax, String mobile, String status)
        {
            UniqueIdentifier = uniqueIdentifier;
            CompanyContactIdentifier = companyContactIdentifier;
            Name = name;
            Description = description;
            VendorType = vendorType;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Country = country;
            Zip = zip;
            Phone = phone;
            Fax = fax;
            Mobile = mobile;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the Vendor class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public Vendor(Vendor source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            CompanyContactIdentifier = source.CompanyContactIdentifier;
            Name = source.Name;
            Description = source.Description;
            VendorType = source.VendorType;
            Address1 = source.Address1;
            Address2 = source.Address2;
            City = source.City;
            State = source.State;
            Country = source.Country;
            Zip = source.Zip;
            Phone = source.Phone;
            Fax = source.Fax;
            Mobile = source.Mobile;
            Status = source.Status;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Vendor));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion    

        #region Public properties

        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public String UniqueIdentifier { get; protected set; }

        [DataMember(Name = "CompanyContactIdentifier", IsRequired = true, Order = 1)]
        public String CompanyContactIdentifier { get; protected set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 2)]
        public String Name { get; protected set; }

        [DataMember(Name = "Description", IsRequired = true, Order = 3)]
        public String Description { get; protected set; }

        [DataMember(Name = "VendorType", IsRequired = true, Order = 4)]
        public String VendorType { get; protected set; }

        [DataMember(Name = "Address1", IsRequired = true, Order = 5)]
        public String Address1 { get; protected set; }

        [DataMember(Name = "Address2", IsRequired = true, Order = 6)]
        public String Address2 { get; protected set; }

        [DataMember(Name = "City", IsRequired = true, Order = 7)]
        public String City { get; protected set; }

        [DataMember(Name = "State", IsRequired = true, Order = 8)]
        public String State { get; protected set; }

        [DataMember(Name = "Country", IsRequired = true, Order = 9)]
        public String Country { get; protected set; }

        [DataMember(Name = "Zip", IsRequired = true, Order = 10)]
        public String Zip { get; protected set; }

        [DataMember(Name = "Phone", IsRequired = true, Order = 11)]
        public String Phone { get; protected set; }

        [DataMember(Name = "Fax", IsRequired = true, Order = 12)]
        public String Fax { get; protected set; }

        [DataMember(Name = "Mobile", IsRequired = true, Order = 13)]
        public String Mobile { get; protected set; }

        [DataMember(Name = "Status", IsRequired = true, Order = 14)]
        public String Status { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
