using System;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector
{
    /// <summary>
    /// Construction helper for interacting with the WebAPIMessage data contract
    /// </summary>
    public static class WebAPIMessageHelper
    {
        /// <summary>
        /// Converts a Response to a WebAPIMessage
        /// </summary>
        /// <param name="response"></param>
        /// <param name="premiseKey"></param>
        /// <returns></returns>
        public static WebAPIMessage ConvertResponseToWebAPIMessage(Response response, String premiseKey)
        {
            string bodyContent = JsonSerialization.JsonSerialize(response);
            return new WebAPIMessage()
            {
                Id = response.Id,
                BodyType = response.GetType().FullName,
                TimeStamp = response.CreatedTimestampUtc,
                Version = 1,
                Body = bodyContent,
                BodyHash = HashBody(bodyContent, premiseKey),
                UploadSessionInfo = null,
                CorrelationId = response.RequestId
            };
        }

        /// <summary>
        /// Converts a WebAPIMessage to a Response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="premiseKey"></param>
        /// <returns></returns>
        public static Response ConvertWebAPIMessageToResponse(WebAPIMessage message, String premiseKey)
        {
            if (!ValidateMessageHash(message, premiseKey))
                return null;
            Type responseType = Type.GetType(message.BodyType);
            return JsonSerialization.JsonDeserialize(responseType, message.Body) as Response;
        }

        /// <summary>
        /// Converts a Request to a WebAPIMessage
        /// </summary>
        /// <param name="request"></param>
        /// <param name="premiseKey"></param>
        /// <returns></returns>
        public static WebAPIMessage ConvertRequestToWebAPIMessage(Request request, String premiseKey)
        {
            var body = JsonSerialization.JsonSerialize(request);
            return new WebAPIMessage()
            {
                Id = request.Id,
                BodyType = request.GetType().FullName,
                TimeStamp = request.CreatedTimestampUtc,
                Version = 1,
                Body = body,
                BodyHash = new MessageHashManager(premiseKey).ComputeMessageHash(body),
                UploadSessionInfo = null,
                CorrelationId = Guid.Empty
            };   
            
        }

        /// <summary>
        /// Converts a WebAPIMessage to a Request
        /// </summary>
        /// <param name="message"></param>
        /// <param name="premiseKey"></param>
        /// <returns></returns>
        public static Request ConvertWebAPIMessageToRequest(WebAPIMessage message, String premiseKey)
        {
            if (!ValidateMessageHash(message, premiseKey))
                return null;
            Type requestType = Type.GetType(message.BodyType);
            return JsonSerialization.JsonDeserialize(requestType, message.Body) as Request;
        }


        private static String HashBody(String body, String premiseKey)
        {
            if (String.IsNullOrEmpty(body) || String.IsNullOrEmpty(premiseKey))
                return String.Empty;

            var msh = new MessageHashManager(premiseKey);
            return msh.ComputeMessageHash(body);
        }

        private static Boolean ValidateMessageHash(WebAPIMessage message, String premiseKey)
        {
            if (String.IsNullOrEmpty(message.Body))
                return true;

            var computedHash = new MessageHashManager(premiseKey).ComputeMessageHash(message.Body);
            return (computedHash == message.BodyHash);
        }
    }
}
