using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Proxy.Utils
{
    public static class RequestHelper
    {
        #region Public Methods

        /// <summary>
        /// Prepares a request object using the LargeRequestSizeThreshold policy of the cloud
        /// </summary>
        /// <remarks>
        /// Request objects that exceed the LargeRequestSizeThreshold policy of the cloud should upload the complete
        /// request to the blob and then replace the properties which have an IndirectPayload attribute with
        /// a default value.  The original request is then populated with the IndirectPayloadDownloadId.
        /// 
        /// The cloud will process any Request with a IndirectPayloadDownloadId as a placeholder request, and then go
        /// out to its download storage for the real Request.
        /// </remarks>
        /// <param name="original"></param>
        /// <param name="largeRequestSizeThreshold"></param>
        /// <param name="GetIndirectPayloadIdFunction">A function callback which returns the payload ID that should be populated</param>
        /// <param name="finalResult">The resulting shrunk request message</param>
        /// <returns>True if resulting request is smaller than the threshold</returns>
        public static bool PrepareRequest(Request original, UInt32 largeRequestSizeThreshold, Func<Request, String> GetIndirectPayloadIdFunction, out Request finalResult)
        {
            // Init result
            finalResult = null;

            IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute;
            var propertiesWithRequiredIndirectPayloadAttribute = GetPropertiesWithRequiredIndirectPayloadAttribute(original, out propertyInfosWithIndirectPayloadAttribute);

            String requestAsString = GetRequestAsString(original);
            if ((propertiesWithRequiredIndirectPayloadAttribute.Count() == 0) &&
                (requestAsString.Length <= largeRequestSizeThreshold))
            {
                // There no properties marked with IndirectPayloadUsage.Required and the request size is under the
                // largeRequestSizeThreshold.
                finalResult = original;
                return true;
            }
            else
            {
                // There are 1 or more properties marked with IndirectPayloadUsage.Required or the request size is over
                // the largeRequestSizeThreshold.
                List<PropertyTuple> propertyTuples = new List<PropertyTuple>();

                // Use the provided method to get the indirect payload Id from the original request
                // This method should also handle any uploading, etc. that is needed behind the scenes
                String indirectPayloadId = GetIndirectPayloadIdFunction(original);

                // We want to create a new request with the indirectPayloadDownloadId property replaced with 
                // The pointer to the real payload.  Use the mutate constructor for this, which all requests have.
                // Note: we're guaranteed to have the indirect payload upload Id property, since it's in the base
                // Request class
                propertyTuples.AddRange(GetPropertyTuplesForAlteredRequest(propertyInfosWithIndirectPayloadAttribute));
                propertyTuples.Add(new PropertyTuple(original.PropertyInfo(x => x.IndirectPayloadDownloadId), indirectPayloadId));
                finalResult = CreateAlteredRequest(original, propertyTuples);

                // Check that the result is now less than the threshold
                string resultAsString = GetRequestAsString(finalResult);
                return (resultAsString.Length > largeRequestSizeThreshold)
                    ? false
                    : true;
            }
        }

        /// <summary>
        /// Get the string version of a request object
        /// Mainly for use by this helper, but also useful in unit testing
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static String GetRequestAsString(Request request)
        {
            var dcs = new DataContractSerializer(typeof(Request));

            using (var stringWriter = new StringWriter())
            {
                using (var textWriter = new XmlTextWriter(stringWriter))
                {
                    dcs.WriteObject(textWriter, request);
                    textWriter.Flush();
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Call the mutable constructor for the given request and provide the list
        /// Of properties to change
        /// </summary>
        /// <param name="original"></param>
        /// <param name="propertyTuples"></param>
        /// <returns></returns>
        public static Request CreateAlteredRequest(Request original, List<PropertyTuple> propertyTuples)
        {
            Type type = original.GetType();
            var constructors = type.GetConstructors();
            var copyWithMutateConstructor = constructors.Where(x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "propertyTuples").Single();
            if (copyWithMutateConstructor == null)
            {
                // Derived class did not provide a mutate constructor
                throw new ArgumentException(string.Format("No mutate constructor found for derived type '{0}'", type.Name));

            }
            return (Request)copyWithMutateConstructor.Invoke(new Object[] { original, propertyTuples });
        }

        #endregion


        #region Private Methods
        
        private static IEnumerable<PropertyTuple> GetPropertyTuplesForAlteredRequest(IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute)
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

        private static IEnumerable<PropertyInfo> GetPropertiesWithIndirectPayloadAttribute(Request subject)
        {
            Type requestType = subject.GetType();
            Type indirecPayloadAttributeType = typeof(IndirectPayloadAttribute);
            var propertyInfos = requestType.GetProperties();
            return (propertyInfos.Where(x => (x.GetCustomAttributes(indirecPayloadAttributeType, true).Length > 0)));
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithRequiredIndirectPayloadAttribute(Request subject, out IEnumerable<PropertyInfo> propertyInfosWithIndirectPayloadAttribute)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();

            propertyInfosWithIndirectPayloadAttribute = GetPropertiesWithIndirectPayloadAttribute(subject);
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
