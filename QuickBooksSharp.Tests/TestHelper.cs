using System;

namespace QuickBooksSharp.Tests
{
    public class TestHelper
    {
        /// <summary>
        /// Used to run AuthenticationService tests
        /// </summary>
        public static string ClientId = GetEnvVar("QUICKBOOKS_SHARP_CLIENT_ID");

        public static string ClientSecret = GetEnvVar("QUICKBOOKS_SHARP_CLIENT_SECRET");

        public static string RedirectUri = GetEnvVar("QUICKBOOKS_SHARP_OAUTH_REDIRECT_URI");



        /// <summary>
        /// Used to run other tests
        /// </summary>
        public static string RefreshToken = GetEnvVar("QUICKBOOKS_SHARP_REFRESH_TOKEN");

        public static long RealmId = long.Parse(GetEnvVar("QUICKBOOKS_SHARP_REALMID"));

        private static string GetEnvVar(string name) => Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User) ?? Environment.GetEnvironmentVariable(name);
    }
}
