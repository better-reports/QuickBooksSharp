using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Create the authorization request your app will send to the Intuit OAuth 2.0 Server. 
        /// Request parameters should identify your app and include the required scopes.
        /// https://developer.intuit.com/app/developer/qbo/docs/develop/authentication-and-authorization/oauth-2.0#authorization-request
        /// </summary>
        /// <param name="clientId">Identifies the app making the request.</param>
        /// <param name="scopes">Lists the scopes your app uses. The list is space-delimited. 
        /// Enter one or more scopes.The scope value defines the apps’ access and type of data it can utilize.This information appears on the authorization page when end-users connect to your app.
        /// Tip: We recommend apps request scopes incrementally based on your feature requirements, rather than every scope up front.</param>
        /// <param name="redirectUrl">Determines where the Intuit OAuth 2.0 Server redirects users after they grant permission to your app.
        /// The redirect value must match the URI you listed in Step 6 exactly.That includes the casing, http scheme, and trailing “/.”</param>
        /// <param name="state"> Defines the state between your authorization request and the Intuit OAuth 2.0 Server response.
        /// The purpose of the state field is to validate if the client (i.e.your app) gets back what was sent in the original request.Thus, the state is maintained from send to response.
        /// You can enter any string value to maintain the state. The server should return the exact name:value pair you sent in the original request.
        /// Tip: We strongly recommend you include an anti-forgery token for the state and confirm it in the response This prevents cross-site request forgery.Learn more about CSRF.</param>
        /// <returns>Url for authorization request</returns>
        string GenerateAuthorizationPromptUrl(string clientId, IEnumerable<string> scopes, string redirectUrl, string state);
        /// <summary>
        /// At this point, your app is waiting for a response from the Intuit OAuth 2.0 Server. If users approve access, the Intuit OAuth 2.0 Server sends a response to the redirect URI you specified.
        /// </summary>
        /// <param name="clientId">The client id of your QuickBooks application making the request</param>
        /// <param name="clientSecret">The client secret of your QuickBooks application</param>
        /// <param name="code">The authorization code sent by the Intuit OAuth 2.0 Server. Max length: 512 characters</param>
        /// <param name="redirectUrl">Determines where the Intuit OAuth 2.0 Server redirects users after they grant permission to your app.
        /// The redirect value must match the URI you listed in Step 6 exactly.That includes the casing, http scheme, and trailing “/.”</param>
        /// <returns></returns>
        Task<TokenResponse> GetOAuthTokenAsync(string clientId, string clientSecret, string code, string redirectUrl);
        /// <summary>
        /// Obtains User information
        /// </summary>
        /// <param name="accessToken">The token used to access our API. Max length: 4096 characters.</param>
        /// <param name="useSandbox">Determines if Sandbox environment is used</param>
        /// <returns></returns>
        Task<UserInfo> GetUserInfo(string accessToken, bool useSandbox);
        /// <summary>
        /// Access tokens eventually expire. Use refresh tokens to “refresh” expired access tokens. You can refresh access tokens without prompting users for permission.
        /// </summary>
        /// <param name="clientId">The client id of your QuickBooks application making the request</param>
        /// <param name="clientSecret">The client secret of your QuickBooks application</param>
        /// <param name="refreshToken">The last refresh token obtained from either <see cref="GetOAuthTokenAsync"/> or <see cref="RefreshOAuthTokenAsync"/></param>
        /// <returns></returns>
        Task<TokenResponse> RefreshOAuthTokenAsync(string clientId, string clientSecret, string refreshToken);
        /// <summary>
        /// If users need to disconnect from your app, you need a way to automatically revoke access. You can use the sample code below as a model.
        /// </summary>
        /// <param name="clientId">The client id of your QuickBooks application making the request</param>
        /// <param name="clientSecret">The client secret of your QuickBooks application</param>
        /// <param name="tokenOrRefreshToken">The last access or refresh token obtained from either <see cref="GetOAuthTokenAsync"/> or <see cref="RefreshOAuthTokenAsync"/></param>
        /// <returns></returns>
        Task RevokeOAuthTokenAsync(string clientId, string clientSecret, string tokenOrRefreshToken);
    }
}