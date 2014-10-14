using System;

namespace Sage.Connector.Cloud.Integration.Interfaces.Utils
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IndirectPayloadAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the IndirectPayloadAttribute class
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="defaultValue"></param>
        public IndirectPayloadAttribute(IndirectPayloadUsage usage, Object defaultValue)
        {
            Usage = usage;
            DefaultValue = defaultValue;
        }

        public IndirectPayloadUsage Usage { get; private set; }

        public Object DefaultValue { get; private set; }
    }
}
