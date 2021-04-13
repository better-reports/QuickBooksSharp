using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace QuickBooksSharp.Tests
{
    [TestClass]
    public class AuthenticationService_Tests
    {
        private AuthenticationService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new AuthenticationService();
        }

        [TestMethod]
        public void GenerateAuthorizationPromptUrl_Works()
        {
            string url = _service.GenerateAuthorizationPromptUrl(TestHelper.ClientId, new[] { "com.intuit.quickbooks.accounting" }, TestHelper.RedirectUri, Guid.NewGuid().ToString());
            Assert.IsNotNull(url);
        }

        [TestMethod]
        [Ignore("Requires manual input of code")]
        public async Task GetOAuthTokenAsync_Works()
        {
            var token = await _service.GetOAuthTokenAsync(TestHelper.ClientId, TestHelper.ClientSecret, "<ENTER_CODE>", TestHelper.RedirectUri);
            Assert.IsNotNull(token.access_token);
            Assert.IsNotNull(token.refresh_token);
            Assert.IsTrue(token.expires_in > TimeSpan.Zero);
            Assert.IsTrue(token.x_refresh_token_expires_in > TimeSpan.Zero);
        }


        [TestMethod]
        [Ignore("Requires manual input of refresh token")]
        public async Task RefreshOAuthTokenAsync_Works()
        {
            var token = await _service.RefreshOAuthTokenAsync(TestHelper.ClientId, TestHelper.ClientSecret, "<ENTER_REFRESH_TOKEN>");
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > TimeSpan.Zero);
            Assert.IsNotNull(token.refresh_token);
        }

        [TestMethod]
        [Ignore("Requires manual input of token")]
        public async Task RevokeOAuthTokenAsync_Works()
        {
            await _service.RevokeOAuthTokenAsync(TestHelper.ClientId, TestHelper.ClientSecret, "<ENTER_TOKEN_OR_REFRESH_TOKEN>");
        }
    }
}
