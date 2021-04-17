using System.Threading.Tasks;

namespace QuickBooksSharp.Tests
{
    public abstract class ServiceTestBase
    {
        protected async Task<string> GetAccessTokenAsync()
        {
            return (await new AuthenticationService().RefreshOAuthTokenAsync(TestHelper.ClientId, TestHelper.ClientSecret, TestHelper.RefreshToken)).access_token;
        }
    }
}
