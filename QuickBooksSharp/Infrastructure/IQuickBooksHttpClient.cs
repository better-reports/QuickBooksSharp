using Flurl;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    public interface IQuickBooksHttpClient
    {
        Task<TResponse> GetAsync<TResponse>(Url url);
        Task<TResponse> PostAsync<TResponse>(Url url, object content);
        Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage> makeRequest);
        Task<TResponse> SendAsync<TResponse>(Func<HttpRequestMessage> makeRequest);
    }
}