using System;
using System.Reflection;

namespace Sage.Connector.Cloud.Integration.Interfaces.Utils
{
    public sealed class PropertyTuple : Tuple<PropertyInfo, Object>
    {
        /// <summary>
        /// Initializes a new instance of the PropertyTuple class
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="value"></param>
        public PropertyTuple(PropertyInfo propertyInfo, Object value)
            : base(propertyInfo, value)
        { }
    }
}
