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
        public static RateLimitBreachBehavior RateLimitBreachBehavior { get; set; } = RateLimitBreachBehavior.Throw;

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

        private readonly string? _accessToken;

        static QuickBooksHttpClient()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(nameof(QuickBooksSharp), typeof(QuickBooksHttpClient).Assembly.GetName().Version!.ToString()));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("(github.com/better-reports/QuickBooksSharp)"));
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public QuickBooksHttpClient(string? accessToken)
        {
            _accessToken = accessToken;
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
            //we use a request factory to make a new request when a retry is needed
            //that is because request message cannot be reused
            bool isFirstTry = true;

        send:
            using (var request = makeRequest())
            {
                if (_accessToken != null)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var exception = new QuickBooksException(request, response, await response.Content.ReadAsStringAsync());
                    if (isFirstTry && RateLimitBreachBehavior == RateLimitBreachBehavior.WaitAndRetryOnce && exception.IsRateLimit)
                    {
                        isFirstTry = false;
                        await Task.Delay(TimeSpan.FromMinutes(1));
                        goto send;
                    }
                    throw exception;
                }

                return response;
            }
        }
    }
}
