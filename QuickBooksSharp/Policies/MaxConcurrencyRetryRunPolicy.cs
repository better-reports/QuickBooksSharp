using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class MaxConcurrencyRetryRunPolicy : IRunPolicy
    {
        //QBO API allows up to 10 concurrent requests
        //https://developer.intuit.com/app/developer/qbo/docs/learn/rest-api-features#limits-and-throttles
        private const int MAX_CONCURRENT_REQUESTS = 10;

        private ConcurrentDictionary<long, SemaphoreSlim> _realmIdToConcurrentRequestsCount = new ConcurrentDictionary<long, SemaphoreSlim>();

        public async Task<HttpResponseMessage> RunAsync(long? realmId, Func<Task<QuickBooksAPIResponse>> getResponseAsync)
        {
            while (true)
            {
                SemaphoreSlim? sem = null;

                if (realmId != null)
                {
                    sem = _realmIdToConcurrentRequestsCount.GetOrAdd(realmId.Value, _ => new SemaphoreSlim(MAX_CONCURRENT_REQUESTS));
                    await sem.WaitAsync();
                }

                try
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
                finally
                {
                    sem?.Release();
                }
            }
        }
    }
}
