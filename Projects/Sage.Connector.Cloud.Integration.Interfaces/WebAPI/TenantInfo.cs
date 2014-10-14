using System;
using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.WebAPI
{
    [DataContract]
    public class TenantInfo
    {
        [DataMember(Name = "tenantguid")]
        public Guid TenantGuid { get; set; }
        [DataMember(Name = "tenantname")]
        public String TenantName { get; set; }
        [DataMember(Name = "registeredconnectorid")]
        public String RegisteredConnectorId { get; set; }
        [DataMember(Name = "registeredcompany")]
        public String RegisteredCompany { get; set; }
    }
}
