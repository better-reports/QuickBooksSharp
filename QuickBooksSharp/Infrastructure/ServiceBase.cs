using Flurl;

namespace QuickBooksSharp
{
    public abstract class ServiceBase
    {
        protected readonly QuickBooksHttpClient _client;

        protected readonly Url _serviceUrl;

        public ServiceBase(string accessToken, long realmId, bool useSandbox)
        {
            _client = new QuickBooksHttpClient(accessToken);
            _serviceUrl = QuickBooksUrl.Build(useSandbox, realmId);
        }
    }
}
