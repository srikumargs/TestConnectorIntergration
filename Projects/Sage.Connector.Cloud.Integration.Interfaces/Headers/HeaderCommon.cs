using System.Collections.Generic;

namespace Sage.Connector.Cloud.Integration.Interfaces.Headers
{
    /// <summary>
    /// Enumeration of the keys types that the service expects
    /// </summary>
    public enum ServiceHeaderKeyTypes
    {
        MessageHash,
        TenantId,
        PremiseAgent,
        ConnectorId,
        CNonce
    }

    /// <summary>
    /// Class to store common header data needed by the client and server
    /// </summary>
    public static class HeaderCommon
    {
        /// <summary>
        /// Private dictionary to hold the actual type to string mapping
        /// </summary>
        private static Dictionary<ServiceHeaderKeyTypes, string> ServiceHeaderKeyTypesMap =
            new Dictionary<ServiceHeaderKeyTypes, string>()
            {
                {ServiceHeaderKeyTypes.MessageHash, "MessageHash"},
                {ServiceHeaderKeyTypes.TenantId, "TenantId"},
                {ServiceHeaderKeyTypes.PremiseAgent, "PremiseAgent"},
                {ServiceHeaderKeyTypes.ConnectorId, "ConnectorId"},
                {ServiceHeaderKeyTypes.CNonce, "CNonce"}
            };

        /// <summary>
        /// Public accessor for the key type to string map
        /// </summary>
        public static Dictionary<ServiceHeaderKeyTypes, string> ServiceHeaderKeys
        {
            get
            {
                return ServiceHeaderKeyTypesMap;
            }
        }
    }
}
