using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Sage.Connector.Cloud.Integration.Interfaces.Utils
{
    /// <summary>
    /// Consolidate serialization code
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// Helper to serialize the given object
        /// For example, used to put the serialized premise agent into the header
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Serialize<T>(T item)
        {
            var dcs = new DataContractSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (var textWriter = new XmlTextWriter(stringWriter))
                {
                    dcs.WriteObject(textWriter, item);
                    textWriter.Flush();
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Deserialization helper for generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T Deserialize<T>(String item)
        {
            var dcs = new DataContractSerializer(typeof(T));

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(item)))
            {
                memoryStream.Position = 0;
                using (var reader = XmlDictionaryReader.CreateTextReader(memoryStream, new XmlDictionaryReaderQuotas()))
                {
                    return (T) dcs.ReadObject(reader, true);
                }
            }
        }
    }
}
