using Flurl;

namespace QuickBooksSharp
{
    /// <summary>
    /// Creates the BaseUrl for QuickBooks Online API
    /// </summary>
    public static class QuickBooksUrl
    {
        public const string SandboxBaseUrl = "https://sandbox-quickbooks.api.intuit.com";
        public const string ProductionBaseUrl = "https://quickbooks.api.intuit.com";
        public const int MinorVersion = 56;

        /// <summary>
        /// Creates the <see cref="Url"/> using the <paramref name="useSandbox"/> and <paramref name="realmId"/> specified.
        /// </summary>
        /// <param name="useSandbox">Determines if the Sandbox or Production url will be used.</param>
        /// <param name="realmId">The realm ID is a unique ID value which identifies a specific QuickBooks Online company</param>
        /// <returns>
        /// Creates a <see cref="Url"/> instance with:
        /// <para>Sandbox: $"{<see cref="SandboxBaseUrl"/>}/v3/company/{<paramref name="realmId"/>}?minorversion=<see cref="MinorVersion"/>}"</para>
        /// <para>Production: $"{<see cref="ProductionBaseUrl"/>}/v3/company/{<paramref name="realmId"/>}?minorversion=<see cref="MinorVersion"/>}"</para>
        /// </returns>
        public static Url Build(bool useSandbox, long realmId)
        {
            var serviceBaseUrl = useSandbox ? SandboxBaseUrl : ProductionBaseUrl;

            return new Url($"{serviceBaseUrl}/v3/company/{realmId}")
                .SetQueryParam("minorversion", MinorVersion);
        }
    }
}
