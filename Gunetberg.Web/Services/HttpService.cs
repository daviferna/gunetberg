using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gunetberg.Web.Services
{
    public abstract class HttpService
    {
        public HttpClientProvider _httpClientProvider;

        public HttpService(HttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var client = _httpClientProvider.HttpClient;
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return string.IsNullOrEmpty(responseBody)? default(T): JsonSerializer.Deserialize<T>(responseBody, options);

            }
            catch (HttpRequestException e)
            {
                return default(T);
            }
        }
    }
}
