using System.Net.Http;

namespace QuickBooksSharp
{
    public class QuickBooksAPIResponse
    {
        internal HttpResponseMessage Response { get; private set; }

        internal QuickBooksException? Exception { get; private set; }

        public QuickBooksAPIResponse(HttpResponseMessage response, QuickBooksException? ex)
        {
            Response = response;
            Exception = ex;
        }
    }
}
