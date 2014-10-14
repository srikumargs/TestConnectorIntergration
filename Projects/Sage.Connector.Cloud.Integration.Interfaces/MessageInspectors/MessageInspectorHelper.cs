using System;

namespace Sage.Connector.Cloud.Integration.Interfaces.MessageInspectors
{
    /// <summary>
    /// Delegate to write out messages to a custom logger
    /// Used by both the header getter and setter
    /// </summary>
    /// <param name="message"> </param>
    /// <returns></returns>
    public delegate void MessageLogger(string message);

    internal static class MessageInspectorHelper
    {
        private static readonly string BodyStartTag = "<s:Body>";
        private static readonly string BodyEndTag = "</s:Body>";

        /// <summary>
        /// Get the string version of the request's body
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetRequestBody(System.ServiceModel.Channels.Message message)
        {
            // Default to string empty if the expected body tags are not found
            string result = string.Empty;

            // Just use string parsing
            string fullXmlString = message.ToString();
            int startIndex = fullXmlString.IndexOf(BodyStartTag);
            if (startIndex > 0)
            {
                int endIndex = fullXmlString.IndexOf(BodyEndTag, startIndex);
                if (endIndex > 0)
                {
                    // Get the substring including both starting and ending body tags
                    result = fullXmlString.Substring(startIndex, endIndex - startIndex + BodyEndTag.Length);
                }
            }

            return result;
        }

        /// <summary>
        /// Single place to provide the method we want to use for 
        /// Converting a byte array to a string.  Can be done in different ways.
        /// </summary>
        /// <param name="inputBytes"></param>
        /// <returns></returns>
        public static string GetBytesFromString(byte[] inputBytes)
        {
            return Convert.ToBase64String(inputBytes);
        }

        /// <summary>
        /// Single place to provide the method we want to use for
        /// Converting a string to a byte array.  Can be done in different ways.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] GetStringFromBytes(string inputString)
        {
            return Convert.FromBase64String(inputString);
        }
    }
}
