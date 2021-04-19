using Flurl;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public class QuickBooksHttpClient
    {
        public static HttpClient HttpClient { get; set; } = new HttpClient();

        public static RateLimitBreachBehavior RateLimitBreachBehavior { get; set; } = RateLimitBreachBehavior.Throw;

        private readonly string? _accessToken;

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public QuickBooksHttpClient(string? accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<TResponse> GetAsync<TResponse>(Url url)
        {
            Func<HttpRequestMessage> makeRequest = () =>
            {
                var r = new HttpRequestMessage(HttpMethod.Get, url);
                r.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return r;
            };
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<TResponse> PostAsync<TResponse>(Url url, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, _jsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<HttpResponseMessage> PostAsync(Url url, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, _jsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(makeRequest);
        }

        public async Task<HttpResponseMessage> PutAsync(Url url, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, _jsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(makeRequest);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Url url)
        {
            Func<HttpRequestMessage> request = () => new HttpRequestMessage(HttpMethod.Delete, url);
            return await this.SendAsync(request);
        }

        public async Task<TResponse> SendAsync<TResponse>(Func<HttpRequestMessage> makeRequest)
        {
            var response = await this.SendAsync(makeRequest);
            return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
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

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var exception = new QuickBooksException(response, await response.Content.ReadAsStringAsync());
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
