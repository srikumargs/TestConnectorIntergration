using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "EmployeeContract")]
    public class Employee : IExtensibleDataObject
    {
        /// <summary>
        ///  Initializes a new instance of the Employee class
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <param name="sortAs"></param>
        /// <param name="suffix"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="title"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <param name="jobTitle"></param>
        /// <param name="department"></param>
        /// <param name="group"></param>
        /// <param name="active"></param>
        public Employee(String uniqueIdentifier,
            String sortAs,
            String suffix,
            String firstName,
            String middleName,
            String lastName,
            String title,
            String email,
            String phone,
            String mobile,
            String jobTitle,
            String department,
            String group,
            Boolean active)
        {
            UniqueIdentifier = uniqueIdentifier;
            SortAs = sortAs;
            Suffix = suffix;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Title = title;
            Email = email;
            Phone = phone;
            Mobile = mobile;
            JobTitle = jobTitle;
            Department = department;
            Group = group;
            Active = active;
        }

        /// <summary>
        ///  Initializes a new instance of the Employee class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"> </param>
        public Employee(Employee source, IEnumerable<PropertyTuple> propertyTuples)
        {
            UniqueIdentifier = source.UniqueIdentifier;
            SortAs = source.SortAs;
            Suffix = source.SortAs;
            FirstName = source.FirstName;
            MiddleName = source.MiddleName;
            LastName = source.LastName;
            Title = source.Title;
            Email = source.Email;
            Phone = source.Phone;
            Mobile = source.Mobile;
            JobTitle = source.JobTitle;
            Department = source.Department;
            Group = source.Group;
            Active = source.Active;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(Employee));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "UniqueIdentifier", IsRequired = true, Order = 0)]
        public string UniqueIdentifier { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SortAs", IsRequired = true, Order = 1)]
        public string SortAs { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Suffix", Order = 2)]
        public string Suffix { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "FirstName", Order = 3)]
        public string FirstName { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "MiddleName", Order = 4)]
        public string MiddleName { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "LastName", Order = 5)]
        public string LastName { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Title", Order = 6)]
        public string Title { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Email", Order = 7)]
        public string Email { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Phone", Order = 8)]
        public string Phone { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Mobile", Order = 9)]
        public string Mobile { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "JobTitle", Order = 10)]
        public string JobTitle { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Department", Order = 11)]
        public string Department { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Group", Order = 12)]
        public string Group { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Active", Order = 13)]
        public Boolean Active { get; protected set; }


        #endregion


        #region IExtensibleDataObject implementation

        /// <summary>
        /// To support forward-compatible data contracts
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}

