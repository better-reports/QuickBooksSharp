using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class SimpleRetryRunPolicy : IRunPolicy
    {
        public async Task<HttpResponseMessage> RunAsync(long? realmId, Func<Task<QuickBooksAPIResponse>> getResponseAsync)
        {
            while (true)
            {
                var r = await getResponseAsync();

                if (r.Exception?.IsRateLimit == true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    continue;
                }

                if (r.Exception != null)
                    throw r.Exception;

                return r.Response;
            }
        }
    }
}
