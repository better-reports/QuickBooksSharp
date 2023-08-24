using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public interface IRunPolicy
    {
        //we use a request factory to make a new request when a retry is needed
        //that is because request message cannot be reused
        Task<HttpResponseMessage> RunAsync(long? realmId, Func<Task<QuickBooksAPIResponse>> getResponseAsync);
    }
}
