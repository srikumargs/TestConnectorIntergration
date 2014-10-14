using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Sage.Connector
{
    internal static class JsonSerialization
    {
        /// <summary>
        /// Serialize an object using the DataContractJsonSerializer
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string JsonSerialize(object item)
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(item.GetType());
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Deserialize a string into an object using the DataContractJsonSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(String item)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(item)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Deserialize a string into an object using the DataContractJsonSerializer
        /// </summary>
        /// <param name="t"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static object JsonDeserialize(Type t, String item)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(item)))
            {
                var serializer = new DataContractJsonSerializer(t);
                return serializer.ReadObject(ms);
            }
        }
    }
}
