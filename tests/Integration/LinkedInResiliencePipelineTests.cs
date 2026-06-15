using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace XPoster.Tests.Integration;

/// <summary>
/// Integration tests verifying that the Polly standard resilience pipeline wired
/// for the <c>LinkedIn</c> named <see cref="System.Net.Http.HttpClient" /> behaves
/// correctly in a real <see cref="IServiceProvider" /> context.
///
/// These tests exercise the full DelegatingHandler chain — Polly never participates
/// in unit tests that inject a <c>MockHttpMessageHandler</c> directly.
/// </summary>
public sealed class LinkedInResiliencePipelineTests : PollyIntegrationTestBase
{
    private System.Net.Http.HttpClient BuildClient(
        HttpMessageHandler handler,
        int attemptTimeoutSeconds = 30)
    {
        var provider = BuildProviderWithHandler(
            "LinkedIn",
            handler,
            attemptTimeoutSeconds: attemptTimeoutSeconds);
        return provider.GetRequiredService<IHttpClientFactory>().CreateClient("LinkedIn");
    }

    [Fact]
    public async Task Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()
    {
        // Arrange: two 429s followed by a 200
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"urn:li:ugcPost:1\"}"));

        var client = BuildClient(handler);
        client.BaseAddress = new Uri("https://api.linkedin.com");

        // Act
        var response = await client.PostAsync(
            "/v2/ugcPosts",
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        // Assert: Polly retried through the 429s and the final call succeeded
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()
    {
        // Arrange: return 500 for every call to trip the circuit breaker
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
            "LinkedIn",
            handler,
            maxRetryAttempts:   3,
            breakDurationSeconds: 3600 /* long break so the breaker stays open during the test */);
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

        // Act: exhaust the retry budget and failure threshold until the breaker opens
        Exception? circuitBreakerException = null;
        for (var i = 0; i < 10; i++)
        {
            try
            {
                await client.PostAsync("/v2/ugcPosts", content);
            }
            catch (Exception ex)
            {
                circuitBreakerException = ex;
                break;
            }
        }

        // Assert: eventually an exception is thrown once the circuit opens
        Assert.NotNull(circuitBreakerException);
    }

    [Fact]
    public async Task Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()
    {
        // Arrange: handler delays longer than the configured attempt timeout.
        // Use a very short timeout (1 s) so the test completes quickly.
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler(
            "LinkedIn",
            handler,
            attemptTimeoutSeconds: 1);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");
        client.Timeout = TimeSpan.FromSeconds(30);

        // Act & Assert: Polly's attempt timeout fires before the handler responds
        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                "/v2/ugcPosts",
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }

    [Fact]
    public async Task Polly_LinkedIn_OnRetry_LogEntryIsEmitted()
    {
        // Arrange: capture log entries emitted by Polly's OnRetry callback
        var logMessages = new List<string>();
        var services = new ServiceCollection();
        // AddProvider is an extension method from Microsoft.Extensions.Logging —
        // the using directive for that namespace is required.
        services.AddLogging(b => b.AddProvider(new CaptureLoggerProvider(logMessages)));

        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"ok\"}"));

        // AddStandardResilienceHandler and ConfigurePrimaryHttpMessageHandler must
        // be called on separate variables — see PollyIntegrationTestBase for rationale.
        var httpClientBuilder = services.AddHttpClient("LinkedIn");
        httpClientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.MaxRetryAttempts          = 3;
            options.Retry.Delay                    = TimeSpan.FromSeconds(2);
            options.AttemptTimeout.Timeout          = TimeSpan.FromSeconds(30);
            // Polly constraint 1: TotalRequestTimeout > AttemptTimeout.
            options.TotalRequestTimeout.Timeout     = TimeSpan.FromSeconds(180);
            options.CircuitBreaker.BreakDuration    = TimeSpan.FromSeconds(30);
            // Polly constraint 2: SamplingDuration >= AttemptTimeout * 2.
            options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(70);
        });
        httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() => handler);

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");

        // Act
        await client.PostAsync(
            "/v2/ugcPosts",
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        // Assert: at least one log message emitted during the retry attempt
        Assert.NotEmpty(logMessages);
    }
}
