using System;

namespace QuickBooksSharp
{
    public class ServiceBase
    {
        protected readonly QuickBooksHttpClient _client;

        protected readonly Uri _serviceUri;

        public const int MinorVersion = 56;

        public ServiceBase(string accessToken, long realmId, bool useSandbox, string pathAfterRealmId)
        {
            _client = new QuickBooksHttpClient(accessToken);
            string serviceBaseUrl = useSandbox ? "https://sandbox-quickbooks.api.intuit.com" : "https://quickbooks.api.intuit.com";

            _serviceUri = new Uri($"{serviceBaseUrl}/v3/company/{realmId}/{pathAfterRealmId}");

            //TODO use MinorVersion
        }
    }
}
