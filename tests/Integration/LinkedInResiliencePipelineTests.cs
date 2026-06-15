using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Xunit;

namespace XPoster.Tests.Integration;

/// <summary>
/// Integration tests verifying that the Polly standard resilience pipeline wired
/// for the <c>LinkedIn</c> named <see cref="System.Net.Http.HttpClient" /> behaves
/// correctly in a real <see cref="IServiceProvider" /> context.
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
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"urn:li:ugcPost:1\"}"));

        var client = BuildClient(handler);
        client.BaseAddress = new Uri("https://api.linkedin.com");

        var response = await client.PostAsync(
            "/v2/ugcPosts",
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()
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
            "LinkedIn",
            handler,
            maxRetryAttempts:     3,
            breakDurationSeconds: 3600);
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

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

        Assert.NotNull(circuitBreakerException);
    }

    [Fact]
    public async Task Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()
    {
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler(
            "LinkedIn",
            handler,
            attemptTimeoutSeconds: 1);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");
        client.Timeout = TimeSpan.FromSeconds(30);

        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                "/v2/ugcPosts",
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }

    [Fact]
    public async Task Polly_LinkedIn_OnRetry_LogEntryIsEmitted()
    {
        var logMessages = new List<string>();
        var services = new ServiceCollection();
        services.AddLogging(b => b.AddProvider(new CaptureLoggerProvider(logMessages)));

        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"id\":\"ok\"}"));

        var httpClientBuilder = services.AddHttpClient("LinkedIn");
        httpClientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.ShouldHandle = args => ValueTask.FromResult(
                args.Outcome.Result?.StatusCode is HttpStatusCode.TooManyRequests
                || args.Outcome.Exception is not null);

            options.Retry.MaxRetryAttempts               = 3;
            options.Retry.Delay                          = TimeSpan.FromSeconds(2);
            options.AttemptTimeout.Timeout               = TimeSpan.FromSeconds(30);
            options.TotalRequestTimeout.Timeout          = TimeSpan.FromSeconds(180);
            options.CircuitBreaker.BreakDuration         = TimeSpan.FromSeconds(30);
            options.CircuitBreaker.SamplingDuration      = TimeSpan.FromSeconds(70);
        });
        httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() => handler);

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("LinkedIn");
        client.BaseAddress = new Uri("https://api.linkedin.com");

        await client.PostAsync(
            "/v2/ugcPosts",
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.NotEmpty(logMessages);
    }
}
