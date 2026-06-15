using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XPoster.Tests.Integration;

/// <summary>
/// Integration tests verifying that the Polly standard resilience pipeline wired
/// for the <c>Instagram</c> named <see cref="System.Net.Http.HttpClient" /> behaves
/// correctly in a real <see cref="IServiceProvider" /> context.
/// </summary>
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

        // minimumThroughput: 2 — allows the breaker to open after just 2 failures
        // within the sampling window, making the test deterministic without requiring
        // hundreds of requests (which is the production-appropriate default of 100).
        var provider = BuildProviderWithHandler(
            "Instagram",
            handler,
            maxRetryAttempts:    0,   // no retries: each PostAsync = exactly 1 request to handler
            breakDurationSeconds: 3600,
            minimumThroughput:   2);
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient("Instagram");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        Exception? circuitBreakerException = null;
        for (var i = 0; i < 10; i++)
        {
            try
            {
                // Recreate StringContent on every iteration: HttpContent is single-use
                // and gets disposed after the first send. Reusing the same instance
                // causes the request to fail before reaching Polly.
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
        var provider = BuildProviderWithHandler(
            "Instagram",
            handler,
            attemptTimeoutSeconds: 1);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Instagram");
        client.BaseAddress = new Uri("https://graph.facebook.com");
        client.Timeout = TimeSpan.FromSeconds(30);

        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                "/v18.0/me/media",
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }
}
