using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class NoRetryRunPolicy : IRunPolicy
    {
        public async Task<HttpResponseMessage> RunAsync(long? realmId, Func<Task<QuickBooksAPIResponse>> getResponseAsync)
        {
            var r = await getResponseAsync();

            if (r.Exception != null) 
                throw r.Exception;

            return r.Response;
        }
    }
}
