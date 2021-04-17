using System;

namespace QuickBooksSharp.Tests
{
    public class TestHelper
    {
        /// <summary>
        /// Used to run AuthenticationService tests
        /// </summary>
        public static string ClientId = Environment.GetEnvironmentVariable("QUICKBOOKS_SHARP_CLIENT_ID", EnvironmentVariableTarget.User);

        public static string ClientSecret = Environment.GetEnvironmentVariable("QUICKBOOKS_SHARP_CLIENT_SECRET", EnvironmentVariableTarget.User);

        public static string RedirectUri = Environment.GetEnvironmentVariable("QUICKBOOKS_SHARP_OAUTH_REDIRECT_URI", EnvironmentVariableTarget.User);



        /// <summary>
        /// Used to run other tests
        /// </summary>
        public static string RefreshToken = Environment.GetEnvironmentVariable("QUICKBOOKS_SHARP_REFRESH_TOKEN", EnvironmentVariableTarget.User);

        public static long RealmId = long.Parse(Environment.GetEnvironmentVariable("QUICKBOOKS_SHARP_REALMID", EnvironmentVariableTarget.User));
    }
}
