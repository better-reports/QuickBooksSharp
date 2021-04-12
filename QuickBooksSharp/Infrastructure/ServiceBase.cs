using System;

namespace QuickBooksSharp
{
    public class ServiceBase
    {
        protected readonly QuickBooksHttpClient _client;

        protected readonly Uri _serviceUri;

        public ServiceBase(string accessToken, string endpointPath, bool useSandbox)
        {
            _client = new QuickBooksHttpClient(accessToken);
            string serviceBaseUrl = useSandbox ? "https://sandbox-quickbooks.api.intuit.com" : "https://quickbooks.api.intuit.com";
            _serviceUri = new Uri($"{serviceBaseUrl}/{endpointPath}");
        }
    }
}
