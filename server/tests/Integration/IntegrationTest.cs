using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FMBQ.Hub.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FMBQ.Hub.Tests
{
    /// <summary>
    /// Base class for integration tests. These tests will manage spinning up a
    /// test server automatically and building an appropriate HTTP client for
    /// reaching the app.
    /// </summary>
    public abstract class IntegrationTest : IClassFixture<WebApplicationFactory<FMBQ.Hub.Application>>
    {
        protected readonly HttpClient client;

        public IntegrationTest(WebApplicationFactory<FMBQ.Hub.Application> factory)
        {
            client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.Remove<IConnectionProvider>()
                        .AddSingleton<IConnectionProvider, TestConnectionProvider>();
                });
            }).CreateClient();
        }

        protected async Task<(HttpResponseMessage, R)> Get<R>(string url)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<R>();

            return (response, body);
        }

        protected async Task<(HttpResponseMessage, R)> Post<R>(string url, object requestBody)
        {
            var response = await client.PostAsync(url, JsonContent.Create(requestBody, requestBody.GetType()));
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<R>();

            return (response, body);
        }
    }
}
