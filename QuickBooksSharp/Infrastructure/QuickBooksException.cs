using System;
using System.Net.Http;

namespace QuickBooksSharp
{
    public class QuickBooksException : Exception
    {
        public HttpResponseMessage Response { get; }

        public string ResponseContent { get; }

        /// <summary>
        /// HTTP 401
        /// </summary>
        public bool IsUnauthorized => (int)Response.StatusCode == 401;

        /// <summary>
        /// HTTP 403
        /// </summary>
        public bool IsForbidden => (int)Response.StatusCode == 403;

        /// <summary>
        /// HTTP 429
        /// </summary>
        public bool IsRateLimit => (int)Response.StatusCode == 429;

        public QuickBooksException(HttpResponseMessage response, string responseContent)
            : base($@"QuickBooks API call failed with code: {response.StatusCode}
Reason: {response.ReasonPhrase}
Content: {responseContent}")
        {
            this.Response = response;
            this.ResponseContent = responseContent;
        }
    }
}
