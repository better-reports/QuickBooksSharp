# QuickBooksSharp

.NET client for QuickBooks Online Accounting API

https://developer.intuit.com/app/developer/qbo/docs/develop

![Build](https://github.com/better-reports/QuickBooksSharp/actions/workflows/ci.yml/badge.svg)

https://www.nuget.org/packages/QuickBooksSharp/

`Install-Package QuickBooksSharp`

- TargetFramework = netstandard2.1
- The object model is generated via the XSD.
- Minor version is currently pinned to version 56

## OAuth authentication

### Generate URL to redirect user for approval of connection:
```csharp
var authService = new AuthenticationService();
var scopes = new[] { "com.intuit.quickbooks.accounting" };
string redirectUrl = "https://myapp.com/quickbooks/authresult";
string state = Guid.NewGuid().ToString();
string url = authService.GenerateAuthorizationPromptUrl(clientId, scopes, redirectUrl, state);
// Redirect the user to redirectUrl so that they can approve the connection
```

### Exchange code for token
```csharp
[HttpGet]
public async Task<IActionResult> AuthResult(string code, long realmId, string state)
{
    //validate state parameter
    var authService = new AuthenticationService();
    string clientId = //get from config
    string clientSecret = //get from config
    var result = await authService.GetOAuthTokenAsync(clientId, clientSecret, code, redirectUrl);
    //persit access token and refresh token
    ...
}
```

### Refresh token
```csharp
var authService = new AuthenticationService();
var result = await authService.RefreshOAuthTokenAsync(clientId, clientSecret, refreshToken);
//persit access token and refresh token
```

### Get User Info
```csharp
var authService = new AuthenticationService();
var userInfo = await authService.GetUserInfo(accessToken, useSandbox: true);
//persit access token and refresh token
```

## Instantiating the DataService
```csharp
var dataService = new DataService(accessToken, realmId, useSandbox: true);
```

## Creating / Updating entities
```csharp
var result = await dataService.PostAsync(new Customer
            {
                DisplayName = "Chandler Bing",
                Suffix = "Jr",
                Title = "Mr",
                MiddleName = "Muriel",
                FamilyName = "Bing",
                GivenName = "Chandler",
            });
//result.Response is of type Customer
var customer = result.Response;

//Sparse update some properties
result = await dataService.PostAsync(new Customer
            {
                Id = customer.Id,
                SyncToken = customer.SyncToken,
                GivenName = "Ross",
                sparse = true
            });

//Update all properties
customer = result.Response;
customer.FamilyName = "Geller";
customer.sparse = false;
result = await dataService.PostAsync(customer);
```

## Querying entities
```csharp
var result = await dataService.QueryAsync<Customer>("SELECT * FROM Customer")
//res.Response.Entities is of type Customer[]
var customers = res.Response.Entities;
```

## Querying reports
```csharp
var report = await dataService.GetReportAsync("ProfitAndLoss", new()
            {
                { "accounting_method", "Accrual" },
                { "date_macro", "Last Fiscal Year" }
            });
string reportName = report.Header.ReportName;
```

## Change Data Capture (CDC)
```csharp
var result = await dataService.GetCDCAsync(DateTimeOffset.UtcNow.AddDays(-10), "Customer,Invoice");
var queryResponses = result.Response.QueryResponse; //type QueryResponse[]
var customers = queryResponses[0].IntuitObjects.Cast<Customer>();
var invoices = queryResponses[1].IntuitObjects.Cast<Invoice>();
```

## Batch
```csharp
//Delete 30 bills in a batch
var bills = (await dataService.QueryAsync<Bill>("SELECT * FROM Bill MAXRESULTS 30")).Response.Entities;
var response = await dataService.BatchAsync(new IntuitBatchRequest
{
    BatchItemRequest = bills.Select(b => new BatchItemRequest
    {
        bId = Guid.NewGuid().ToString(),
        operation = OperationEnum.delete,
        Bill = new Bill
        {
            Id = b.Id,
            SyncToken = b.SyncToken
        }
    }).ToArray()
});

//Issue multiple queries in a batch
var response = await dataService.BatchAsync(new IntuitBatchRequest
{
    BatchItemRequest = new[]
    {
            new BatchItemRequest
            {
                bId = Guid.NewGuid().ToString(),
                Query = "SELECT * FROM Bill MAXRESULTS 30",
            },
            new BatchItemRequest
            {
                bId = Guid.NewGuid().ToString(),
                Query = "SELECT * FROM Invoice MAXRESULTS 30",
            }
    }
});
```

## Verifying webhooks
```csharp
[HttpPost]
[IgnoreAntiforgeryToken]
[AllowAnonymous]
public async Task<IActionResult> Webhook()
{
    string signature = Request.Headers["intuit-signature"].ToString();
    string webhookVerifierToken = //get from config
    string requestBodyJSON = await base.ReadBodyToEndAsync();
    if (!Helper.IsAuthenticWebhook(signature, webhookVerifierToken, requestBodyJSON))
        return BadRequest();
        //return HTTP error status

    //Process webhook
    WebhookEvent notification = JsonSerializer.Deserialize<WebhookEvent>(requestBodyJSON, QuickBooksHttpClient.JsonSerializerOptions);
}
```

## Download Invoice PDF
```csharp
    var invoiceId = "1023";
    var invoidePdfStream = await dataService.GetInvoicePDF(invoiceId);
```