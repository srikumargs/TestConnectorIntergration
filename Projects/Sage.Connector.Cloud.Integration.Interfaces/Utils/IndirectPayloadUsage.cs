
namespace Sage.Connector.Cloud.Integration.Interfaces.Utils
{
    public enum IndirectPayloadUsage
    {
        /// <summary>
        ///  No usage value (default value automatically initialized by runtime)
        /// </summary>
        None = 0,

        /// <summary>
        /// Member will be deferred to indirect payload if necessary (e.g., size constraints)
        /// </summary>
        Allowed,

        /// <summary>
        /// Member is always deferred to indirect payload
        /// </summary>
        Required
    }
}
