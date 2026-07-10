using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XPoster.Tests.Integration;

[Trait("Category", "Integration")]
public sealed class FacebookResiliencePipelineTests : PollyIntegrationTestBase
{
    [Fact]
    public async Task Polly_Facebook_RetriesOn429_AndEventuallySucceeds()
    {
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"fb-post-1\"}"));

        var provider = BuildProviderWithHandler("Facebook", handler);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Facebook");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        var response = await client.PostAsync(
            "/v23.0/page-id/feed",
            content: null);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures()
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
            "Facebook",
            handler,
            maxRetryAttempts: 1,
            retryEnabled: false,
            breakDurationSeconds: 3600,
            minimumThroughput: 2);

        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Facebook");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        Exception? circuitBreakerException = null;
        for (var i = 0; i < 10; i++)
        {
            try
            {
                await client.PostAsync("/v23.0/page-id/feed", content: null);
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
    public async Task Polly_Facebook_AttemptTimeout_CancelsSlowRequest()
    {
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler("Facebook", handler, attemptTimeoutSeconds: 1);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Facebook");
        client.BaseAddress = new Uri("https://graph.facebook.com");
        client.Timeout = TimeSpan.FromSeconds(30);

        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync("/v23.0/page-id/feed", content: null));
    }

    [Fact]
    public async Task Polly_Facebook_OnRetry_LogEntryIsEmitted()
    {
        var logMessages = new List<string>();
        var services = new ServiceCollection();
        services.AddLogging(b => b.AddProvider(new CaptureLoggerProvider(logMessages)));

        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"fb-post-1\"}"));

        var httpClientBuilder = services.AddHttpClient("Facebook");
        httpClientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.ShouldHandle = args => ValueTask.FromResult(
                args.Outcome.Result?.StatusCode is HttpStatusCode.TooManyRequests
                || args.Outcome.Exception is not null);
            options.Retry.MaxRetryAttempts = 3;
            options.Retry.Delay = TimeSpan.FromSeconds(2);
            options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
            options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(180);
            options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
            options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(70);
        });
        httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() => handler);

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("Facebook");
        client.BaseAddress = new Uri("https://graph.facebook.com");

        await client.PostAsync("/v23.0/page-id/feed", content: null);

        Assert.NotEmpty(logMessages);
    }
}