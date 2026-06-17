using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XPoster.Tests.Integration;

[Trait("Category", "Integration")]
public sealed class InstagramResiliencePipelineTests : PollyIntegrationTestBase
{
    [Fact]
    public async Task Polly_Instagram_RetriesOn429_AndEventuallySucceeds()
    {
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"17841400008460056\"}"));

        var provider = BuildProviderWithHandler("Instagram", handler);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Instagram");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        var response = await client.PostAsync(
            "/v18.0/me/media",
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()
    {
        var handler = BuildSequenceHandler(
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"),
            (HttpStatusCode.InternalServerError, "{}"));

        var provider = BuildProviderWithHandler(
            "Instagram",
            handler,
            maxRetryAttempts:    1,
            retryEnabled:        false,
            breakDurationSeconds: 3600,
            minimumThroughput:   2);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Instagram");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        Exception? circuitBreakerException = null;
        for (var i = 0; i < 10; i++)
        {
            try
            {
                await client.PostAsync(
                    "/v18.0/me/media",
                    new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));
            }
            catch (Exception ex)
            {
                circuitBreakerException = ex;
                break;
            }
        }

        Assert.NotNull(circuitBreakerException);
    }

    [Fact]
    public async Task Polly_Instagram_AttemptTimeout_CancelsSlowRequest()
    {
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler("Instagram", handler, attemptTimeoutSeconds: 1);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Instagram");
        client.BaseAddress = new Uri("https://graph.facebook.com");
        client.Timeout = TimeSpan.FromSeconds(30);

        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                "/v18.0/me/media",
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }
}
