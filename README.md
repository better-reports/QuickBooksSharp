# QuickBooksSharp

.NET client for QuickBooks Online Accounting API

https://developer.intuit.com/app/developer/qbo/docs/develop

![Build](https://github.com/better-reports/QuickBooksSharp/workflows/Build/badge.svg)

`Install-Package QuickBooksSharp`

### Implemented operations

Not all endpoints are fully implemented yet.

PRs are welcome!

| Endpoint                     | Operation                         | Implemented? |
| ---------------------------- | --------------------------------- | ------------ |
| Authentication			   | *                                 | Yes          |
| Account					   | *                                 | No           |
| Customer					   | *                                 | No           |


### Authenticating and calling the API

All services must be given an access token which can be fetched via the `AuthenticationService`.

###### OAuth authentication

```
var authService = new AuthenticationService();
string redirectUrl = authService.GenerateAuthorizationPromptUrl(clientId, redirectUrl, state);
// Redirect the user to redirectUrl so that they can approve the connection
...
...
// Then exchange the code on the redirected url for a token
var token = await _service.GetOAuthTokenAsync(clientId, clientSecret, "ENTER_CODE_HERE", "ENTER_REDIRECT_URL_HERE");
... 
...
TODO
```

### Global settings

#### Custom `HttpClient`

You may set a custom `HttpClient`: 

`QuickBooksHttpClient.HttpClient = myHttpClient;`

#### Rate limit breach behaviour

By default, a `QuickBooksException` is thrown when you breach your rate limit.

Alternatively, you can opt-in for QuickBooksSharp to automatically retry after 1 minute:

`QuickBooksHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;`

### Verifying webhooks

TODO