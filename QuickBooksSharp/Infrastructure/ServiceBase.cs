using Flurl;

namespace QuickBooksSharp
{
    public abstract class ServiceBase
    {
        protected readonly QuickBooksHttpClient _client;

        protected readonly Url _serviceUrl;

        public const int MinorVersion = 56;

        public ServiceBase(string accessToken, long realmId, bool useSandbox)
        {
            _client = new QuickBooksHttpClient(accessToken);
            string serviceBaseUrl = useSandbox ? "https://sandbox-quickbooks.api.intuit.com" : "https://quickbooks.api.intuit.com";

            _serviceUrl = new Url($"{serviceBaseUrl}/v3/company/{realmId}")
                                .SetQueryParam("minorversion", MinorVersion);
        }
    }
}
