using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Proxy.Utils
{
    public static class ResponseHelper
    {
        #region Public Methods

        /// <summary>
        /// Prepares a response object using the LargeResponseSizeThreshold policy of the cloud
        /// </summary>
        /// <remarks>
        /// Response objects that exceed the LargeResponseSizeThreshold policy of the cloud should upload the complete
        /// response to the cloud and then replace the properties which have an IndirectPayload attribute with
        /// a default value.  The original response is then populated with the IndirectPayloadUploadId.
        /// 
        /// The cloud will process any Response with a IndirectPayloadUploadId as a placeholder response, and then go
        /// out to its upload storage for the real Response.
        /// </remarks>
        /// <param name="original"></param>
        /// <param name="largeResponseSizeThreshold"></param>
        /// <param name="GetIndirectPayloadIdFunction">A function callback which returns the payload ID that should be populated</param>
        /// <param name="finalResult">The resulting shrunk response message</param>
        /// <returns>True if resulting response is smaller than the threshold</returns>
        public static bool PrepareResponse(Response original, UInt32 largeResponseSizeThreshold, Func<Response, String> GetIndirectPayloadIdFunction, out Response finalResult)
        {
            // Init result
            finalResult = null;

            IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute;
            var propertiesWithRequiredIndirectPayloadAttribute = GetPropertiesWithRequiredIndirectPayloadAttribute(original, out propertyInfosWithIndirectPayloadAttribute);

            String responseAsString = GetResponseAsString(original);
            if ((propertiesWithRequiredIndirectPayloadAttribute.Count() == 0) && 
                (responseAsString.Length <= largeResponseSizeThreshold))
            {
                // There no properties marked with IndirectPayloadUsage.Required and the response size is under the
                // largeResponseSizeThreshold.
                finalResult = original;
                return true;
            }
            else
            {
                // There are 1 or more properties marked with IndirectPayloadUsage.Required or the response size is over
                // the largeResponseSizeThreshold.
                List<PropertyTuple> propertyTuples = new List<PropertyTuple>();

                // Use the provided method to get the indirect payload Id from the original response
                // This method should also handle any uploading, etc. that is needed behind the scenes
                String indirectPayloadId = GetIndirectPayloadIdFunction(original);

                // We want to create a new response with the indirectPayloadUploadId property replaced with 
                // The pointer to the real payload.  Use the mutate constructor for this, which all responses have.
                // Note: we're guaranteed to have the indirect payload upload Id property, since it's in the base
                // Response class
                propertyTuples.AddRange(GetPropertyTuplesForAlteredResponse(propertyInfosWithIndirectPayloadAttribute));
                propertyTuples.Add(new PropertyTuple(original.PropertyInfo(x => x.IndirectPayloadUploadId), indirectPayloadId));
                finalResult = CreateAlteredResponse(original, propertyTuples);

                // Check that the result is now less than the threshold
                string resultAsString = GetResponseAsString(finalResult);
                return (resultAsString.Length > largeResponseSizeThreshold)
                    ? false
                    : true;
            }
        }

        /// <summary>
        /// Get the string version of a response object
        /// Mainly for use by this helper, but also useful in unit testing
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static String GetResponseAsString(Response response)
        {
            var dcs = new DataContractSerializer(typeof(Response));

            using (var stringWriter = new StringWriter())
            {
                using (var textWriter = new XmlTextWriter(stringWriter))
                {
                    dcs.WriteObject(textWriter, response);
                    textWriter.Flush();
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Call the mutable constructor for the given response and provide the list
        /// Of properties to change
        /// </summary>
        /// <param name="original"></param>
        /// <param name="propertyTuples"></param>
        /// <returns></returns>
        public static Response CreateAlteredResponse(Response original, List<PropertyTuple> propertyTuples)
        {
            Type type = original.GetType();
            var constructors = type.GetConstructors();
            var copyWithMutateConstructor = constructors.Where(x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "propertyTuples").Single();
            if (copyWithMutateConstructor == null)
            {
                // Derived class did not provide a mutate constructor
                throw new ArgumentException(string.Format("No mutate constructor found for derived type '{0}'", type.Name));

            }
            return (Response)copyWithMutateConstructor.Invoke(new Object[] { original, propertyTuples });
        }

        #endregion


        #region Private Methods
        
        private static IEnumerable<PropertyTuple> GetPropertyTuplesForAlteredResponse(IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute)
        {
            List<PropertyTuple> result = new List<PropertyTuple>();

            IndirectPayloadUsage usageArg;
            Object defaultValueArg;
            foreach (var propertyInfo in propertyInfosWithIndirectPayloadAttribute)
            {
                GetIndirectPayloadData(propertyInfo, out usageArg, out defaultValueArg);

                if (usageArg == IndirectPayloadUsage.Allowed || usageArg == IndirectPayloadUsage.Required)
                {
                    result.Add(new PropertyTuple(propertyInfo, defaultValueArg));
                }
            }

            return result;
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithIndirectPayloadAttribute(Response subject)
        {
            Type responseType = subject.GetType();
            Type indirecPayloadAttributeType = typeof(IndirectPayloadAttribute);
            var propertyInfos = responseType.GetProperties();
            return (propertyInfos.Where(x => (x.GetCustomAttributes(indirecPayloadAttributeType, true).Length > 0)));
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithRequiredIndirectPayloadAttribute(Response subject, out IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();

            propertyInfosWithIndirectPayloadAttribute = GetPropertiesWithIndirectPayloadAttribute(subject);
            Type indirecPayloadAttributeType = typeof(IndirectPayloadAttribute);
            IndirectPayloadUsage usageArg;
            Object defaultValueArg;
            foreach (var propertyInfo in propertyInfosWithIndirectPayloadAttribute)
            {
                GetIndirectPayloadData(propertyInfo, out usageArg, out defaultValueArg);

                if (usageArg == IndirectPayloadUsage.Required)
                {
                    result.Add(propertyInfo);
                }
            }

            return result;
        }

        private static void GetIndirectPayloadData(PropertyInfo propertyInfo, out IndirectPayloadUsage usageArg, out Object defaultValueArg)
        {
            Type indirecPayloadAttributeType = typeof(IndirectPayloadAttribute);

            var data = propertyInfo.GetCustomAttributesData().Where(x => x.ToString().Contains(indirecPayloadAttributeType.FullName)).Single();
            usageArg = (IndirectPayloadUsage)data.ConstructorArguments[0].Value;
            defaultValueArg = data.ConstructorArguments[1].Value;
        }

        #endregion
    }
}
