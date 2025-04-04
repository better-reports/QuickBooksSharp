﻿using System;

namespace QuickBooksSharp.Tests
{
    /// <summary>
    /// https://developer.intuit.com/app/developer/playground makes it easy to generate values from the variables below
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// Used to run AuthenticationService tests
        /// </summary>
        public static string ClientId = GetEnvVar("QUICKBOOKS_SHARP_CLIENT_ID");

        public static string ClientSecret = GetEnvVar("QUICKBOOKS_SHARP_CLIENT_SECRET");

        public static string RedirectUri = GetEnvVar("QUICKBOOKS_SHARP_OAUTH_REDIRECT_URI");
        
        public static long RealmId = long.Parse(GetEnvVar("QUICKBOOKS_SHARP_REALMID"));

        public static string RefreshToken = GetEnvVar("QUICKBOOKS_SHARP_REFRESH_TOKEN");

        public static void PersistNewRefreshToken(string refreshToken) => Environment.SetEnvironmentVariable("QUICKBOOKS_SHARP_REFRESH_TOKEN", refreshToken, EnvironmentVariableTarget.User);

        private static string GetEnvVar(string name) => 
            Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User) 
                ?? Environment.GetEnvironmentVariable(name)
                ?? throw new Exception($"Environment {name} is not defined");

    }
}
