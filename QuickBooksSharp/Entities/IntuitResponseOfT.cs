using QuickBooksSharp.Entities;
using System;

namespace QuickBooksSharp
{
    public class IntuitResponse<TResponse> where TResponse : class
    {
        /// <summary>
        /// Indication that a request was processed, but with possible exceptional circumstances (i.e. ignored unsupported fields) that the client may want to be aware of
        /// </summary>
        public Warnings? Warnings { get; set; }

        /// <summary>
        /// RequestId associated with the request
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Time at which request started processing in the server
        /// </summary>
        public DateTimeOffset? Time { get; set; }

        /// <summary>
        /// HTTP codes result of the operation<
        /// </summary>
        public string? Status { get; set; }

        public Fault? Fault { get; set; }

        public TResponse? Response { get; set; }
    }
}
