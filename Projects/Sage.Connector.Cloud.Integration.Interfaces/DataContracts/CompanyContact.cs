using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "CompanyContract")]
    public class CompanyContact : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the CompanyContact class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="trades"></param>
        /// <param name="businessEnterpriseTypes"></param>
        /// <param name="region"></param>
        /// <param name="location"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="address3"></param>
        /// <param name="address4"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="email"></param>
        /// <param name="webAddress"></param>
        /// <param name="status"></param>
        public CompanyContact(
            String uniqueIdentifier, String name, IEnumerable<String> trades,
            IEnumerable<String> businessEnterpriseTypes, String region, String location,
            String address1, String address2, String address3, String address4,
            String city, String state, String country, String zip,
            String phone, String fax, String email, String webAddress, String status)
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;

            StringList tradesStringList = (trades == null ? new StringList() : new StringList(trades));
            Trades = tradesStringList;

            StringList businessEnterpriseTypesStringList 
                = (businessEnterpriseTypes == null ? new StringList() : new StringList(businessEnterpriseTypes));
            BusinessEnterpriseTypes = businessEnterpriseTypesStringList;
            
            Region = region;
            Location = location;
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            Address4 = address4;
            City = city;
            State = state;
            Country = country;
            Zip = zip;
            Phone = phone;
            Fax = fax;
            Email = email;
            WebAddress = webAddress;
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the CompanyContact class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public CompanyContact(CompanyContact source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            Name = source.Name;
            Trades = source.Trades;
            BusinessEnterpriseTypes = source.BusinessEnterpriseTypes;
            Region = source.Region;
            Location = source.Location;
            Address1 = source.Address1;
            Address2 = source.Address2;
            Address3 = source.Address3;
            Address4 = source.Address4;
            City = source.City;
            State = source.State;
            Country = source.Country;
            Zip = source.Zip;
            Phone = source.Phone;
            Fax = source.Fax;
            Email = source.Email;
            WebAddress = source.WebAddress;
            Status = source.Status;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(CompanyContact));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion    

        #region Public properties

        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public String UniqueIdentifier { get; protected set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 1)]
        public String Name { get; protected set; }

        [DataMember(Name = "Trades", IsRequired = true, Order = 2)]
        public StringList Trades { get; protected set; }

        [DataMember(Name = "BusinessEnterpriseTypes", IsRequired = true, Order = 3)]
        public StringList BusinessEnterpriseTypes { get; protected set; }

        [DataMember(Name = "Region", IsRequired = true, Order = 4)]
        public String Region { get; protected set; }

        [DataMember(Name = "Location", IsRequired = true, Order = 5)]
        public String Location { get; protected set; }

        [DataMember(Name = "Address1", IsRequired = true, Order = 6)]
        public String Address1 { get; protected set; }

        [DataMember(Name = "Address2", IsRequired = true, Order = 7)]
        public String Address2 { get; protected set; }

        [DataMember(Name = "Address3", IsRequired = true, Order = 8)]
        public String Address3 { get; protected set; }

        [DataMember(Name = "Address4", IsRequired = true, Order = 9)]
        public String Address4 { get; protected set; }

        [DataMember(Name = "City", IsRequired = true, Order = 10)]
        public String City { get; protected set; }

        [DataMember(Name = "State", IsRequired = true, Order = 11)]
        public String State { get; protected set; }

        [DataMember(Name = "Country", IsRequired = true, Order = 12)]
        public String Country { get; protected set; }

        [DataMember(Name = "Zip", IsRequired = true, Order = 13)]
        public String Zip { get; protected set; }

        [DataMember(Name = "Phone", IsRequired = true, Order = 14)]
        public String Phone { get; protected set; }

        [DataMember(Name = "Fax", IsRequired = true, Order = 15)]
        public String Fax { get; protected set; }

        [DataMember(Name = "Email", IsRequired = true, Order = 16)]
        public String Email { get; protected set; }

        [DataMember(Name = "WebAddress", IsRequired = true, Order = 17)]
        public String WebAddress { get; protected set; }

        [DataMember(Name = "Status", IsRequired = true, Order = 18)]
        public String Status { get; protected set; }

        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
