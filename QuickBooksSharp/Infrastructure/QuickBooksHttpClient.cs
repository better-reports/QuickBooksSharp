using Flurl;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class QuickBooksHttpClient : IQuickBooksHttpClient
    {
        private readonly string? _accessToken;
        private readonly long? _realmId;
        private IRunPolicy _runPolicy;

        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip
        });


        public readonly static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            Converters =
            {
                //new JsonStringEnumConverter(),

                //using community package to fix https://github.com/dotnet/runtime/issues/31081
                //can revert to out of the box converter once fix (.net 6?)
                new JsonStringEnumMemberConverter()
            }
        };

        static QuickBooksHttpClient()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(nameof(QuickBooksSharp), typeof(QuickBooksHttpClient).Assembly.GetName().Version!.ToString()));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("(github.com/better-reports/QuickBooksSharp)"));
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public QuickBooksHttpClient(string? accessToken, long? realmId, IRunPolicy runPolicy)
        {
            _accessToken = accessToken;
            _realmId = realmId;
            _runPolicy = runPolicy;
        }

        public async Task<TResponse> GetAsync<TResponse>(Url url)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Get, url);
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<TResponse> PostAsync<TResponse>(Url url, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, JsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<TResponse> SendAsync<TResponse>(Func<HttpRequestMessage> makeRequest)
        {
            var response = await this.SendAsync(makeRequest);
            return (await response.Content.ReadFromJsonAsync<TResponse>(JsonSerializerOptions))!;
        }

        public async Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage> makeRequest)
        {
            var response = await this._runPolicy.RunAsync(_realmId, async () =>
            {
                using (var request = makeRequest())
                {
                    if (_accessToken != null)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                    var response = await _httpClient.SendAsync(request);
                    var ex = response.IsSuccessStatusCode ? null : new QuickBooksException(request, response, await response.Content.ReadAsStringAsync());

                    if (ex?.IsRateLimit == true)
                        RunPolicy.NotifyRateLimt(new RateLimitEvent(_realmId, request.RequestUri));

                    return new QuickBooksAPIResponse(response, ex);
                }
            });

            return response;
        }
    }
}
