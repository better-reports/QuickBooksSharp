﻿using Flurl;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly QuickBooksHttpClient _client = new QuickBooksHttpClient(null, null, new NoRetryRunPolicy());

        //TODO: retrieve the endpoints URLs dynamically
        //See https://developer.intuit.com/app/developer/qbo/docs/develop/authentication-and-authorization/oauth-openid-discovery-doc

        private const string TOKEN_ENDPOINT_URL = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";
        private const string REVOKE_TOKEN_ENDPOINT_URL = "https://developer.api.intuit.com/v2/oauth2/tokens/revoke";
        private const string USER_INFO_ENDPOINT_URL = "https://accounts.platform.intuit.com/v1/openid_connect/userinfo";
        private const string USER_INFO_ENDPOINT_SANDBOX_URL = "https://sandbox-accounts.platform.intuit.com/v1/openid_connect/userinfo";

        public string GenerateAuthorizationPromptUrl(string clientId, IEnumerable<string> scopes, string redirectUrl, string state)
        {
            return new Url("https://appcenter.intuit.com/connect/oauth2")
                        .SetQueryParam("client_id", clientId)
                        .SetQueryParam("scope", string.Join(" ", scopes))
                        .SetQueryParam("redirect_uri", redirectUrl)
                        .SetQueryParam("response_type", "code")
                        .SetQueryParam("state", state)
                        .ToString();
        }

        public async Task<UserInfo> GetUserInfo(string accessToken, bool useSandbox)
        {
            return await new QuickBooksHttpClient(accessToken, null, RunPolicy.DefaultRunPolicy).GetAsync<UserInfo>(useSandbox ? USER_INFO_ENDPOINT_SANDBOX_URL : USER_INFO_ENDPOINT_URL);
        }

        public async Task<TokenResponse> GetOAuthTokenAsync(string clientId, string clientSecret, string code, string redirectUrl)
        {
            return await _client.SendAsync<TokenResponse>(() =>
            {
                var request = new HttpRequestMessage(HttpMethod.Post, TOKEN_ENDPOINT_URL)
                {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                    Content = new FormUrlEncodedContent(new Dictionary<string, string?>
                                {
                                    { "code", code },
                                    { "redirect_uri", redirectUrl },
                                    { "grant_type", "authorization_code" },
                                })
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                };
                this.AddAuthenticationHeader(request, clientId, clientSecret);
                return request;
            });
        }

        /// <summary>
        /// When refreshed, the previous access token is invalidated immediately
        /// </summary>
        /// <returns></returns>
        public async Task<TokenResponse> RefreshOAuthTokenAsync(string clientId, string clientSecret, string refreshToken)
        {
            return await _client.SendAsync<TokenResponse>(() =>
            {
                var request = new HttpRequestMessage(HttpMethod.Post, TOKEN_ENDPOINT_URL)
                {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                                {
                                    { "refresh_token", refreshToken },
                                    { "grant_type", "refresh_token" },
                                })
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                };
                this.AddAuthenticationHeader(request, clientId, clientSecret);
                return request;
            });
        }

        public async Task RevokeOAuthTokenAsync(string clientId, string clientSecret, string tokenOrRefreshToken)
        {
            await _client.SendAsync(() =>
            {
                var request = new HttpRequestMessage(HttpMethod.Post, REVOKE_TOKEN_ENDPOINT_URL)
                {
                    Content = new StringContent(JsonSerializer.Serialize(new { token = tokenOrRefreshToken }), Encoding.UTF8, "application/json")
                };
                this.AddAuthenticationHeader(request, clientId, clientSecret);
                return request;
            });
        }

        private void AddAuthenticationHeader(HttpRequestMessage request, string clientId, string clientSecret)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
        }
    }
}
