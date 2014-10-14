using System;
using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.WebAPI
{
    /// <summary>
    /// Tenant registration attributes
    /// </summary>
    [DataContract]
    public class TenantRegistration
    {
        [DataMember(Name="tenantid")]
        public String TenantId { get; set; }
        [DataMember(Name="tenantname")]
        public String TenantName { get; set; }
        [DataMember(Name="tenanturl")]
        public Uri TenantUrl { get; set; }
        [DataMember(Name="tenantclaim")]
        public String TenantClaim { get; set; }
        [DataMember(Name="tenantkey")]
        public String TenantKey { get; set; }
        [DataMember(Name="siteaddressbaseuri")]
        public Uri SiteAddressBaseUri { get; set; }
    }
}
