using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;

namespace XPoster.Tests.Integration;

/// <summary>
/// Base class for Polly resilience pipeline integration tests.
/// Builds a real <see cref="IServiceCollection" /> with <c>AddStandardResilienceHandler</c>
/// configured identically to <c>Program.cs</c>, then substitutes only the innermost
/// <see cref="HttpMessageHandler" /> with a controllable test double.
/// This ensures the full DelegatingHandler chain — including Polly — is exercised
/// without any real outbound network calls.
/// </summary>
/// <remarks>
/// Polly enforces two proportionality constraints at pipeline-build time:
/// 1. CircuitBreaker.SamplingDuration >= AttemptTimeout * 2
///    (so at least two attempts fit inside the sampling window).
/// 2. TotalRequestTimeout > AttemptTimeout
///    (the overall budget must exceed a single attempt).
/// Default values here are chosen to satisfy both constraints while mirroring
/// the production configuration in Program.cs.
/// </remarks>
public abstract class PollyIntegrationTestBase
{
    // Default production-like timeouts (seconds) — must obey Polly constraints.
    // SamplingDuration is derived automatically as attemptTimeout * 2 + 10 inside BuildProviderWithHandler.
    private const int DefaultAttemptTimeoutSeconds      = 30;
    private const int DefaultTotalRequestTimeoutSeconds = 180; // > attemptTimeout * maxRetries
    private const int DefaultBreakDurationSeconds       = 30;
    private const int DefaultMaxRetryAttempts           = 3;
    private const int DefaultRetryDelaySeconds          = 2;

    /// <summary>
    /// Builds an <see cref="IServiceProvider" /> with a named <see cref="System.Net.Http.HttpClient" />
    /// wired through the standard resilience pipeline and backed by <paramref name="innerHandler" />.
    /// Options mirror the values in <c>Program.cs</c>.
    /// </summary>
    protected static IServiceProvider BuildProviderWithHandler(
        string clientName,
        HttpMessageHandler innerHandler,
        int maxRetryAttempts           = DefaultMaxRetryAttempts,
        int retryDelaySeconds          = DefaultRetryDelaySeconds,
        int attemptTimeoutSeconds      = DefaultAttemptTimeoutSeconds,
        int totalRequestTimeoutSeconds = DefaultTotalRequestTimeoutSeconds,
        int breakDurationSeconds       = DefaultBreakDurationSeconds)
    {
        // Polly constraint: SamplingDuration must be >= AttemptTimeout * 2.
        // We add a 10-second margin to avoid edge-case equality failures.
        var samplingDurationSeconds = attemptTimeoutSeconds * 2 + 10;

        var services = new ServiceCollection();
        services.AddLogging();

        // AddStandardResilienceHandler returns IHttpStandardResiliencePipelineBuilder,
        // not IHttpClientBuilder — ConfigurePrimaryHttpMessageHandler must be called
        // on the IHttpClientBuilder returned by AddHttpClient, not chained after.
        var builder = services.AddHttpClient(clientName);
        builder.AddStandardResilienceHandler(options =>
        {
            options.Retry.MaxRetryAttempts                   = maxRetryAttempts;
            options.Retry.Delay                             = TimeSpan.FromSeconds(retryDelaySeconds);
            options.AttemptTimeout.Timeout                  = TimeSpan.FromSeconds(attemptTimeoutSeconds);
            // Polly constraint 1: TotalRequestTimeout > AttemptTimeout.
            options.TotalRequestTimeout.Timeout             = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);
            options.CircuitBreaker.BreakDuration            = TimeSpan.FromSeconds(breakDurationSeconds);
            // Polly constraint 2: SamplingDuration >= AttemptTimeout * 2.
            options.CircuitBreaker.SamplingDuration         = TimeSpan.FromSeconds(samplingDurationSeconds);
        });
        builder.ConfigurePrimaryHttpMessageHandler(() => innerHandler);

        return services.BuildServiceProvider();
    }

    /// <summary>
    /// Creates a handler that returns the given responses in sequence.
    /// Subsequent calls beyond the list repeat the last response.
    /// </summary>
    protected static HttpMessageHandler BuildSequenceHandler(
        params (HttpStatusCode statusCode, string body)[] responses)
    {
        var callIndex = 0;
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(() =>
            {
                var idx = Math.Min(callIndex++, responses.Length - 1);
                var (code, body) = responses[idx];
                return Task.FromResult(new HttpResponseMessage(code)
                {
                    Content = new StringContent(body, System.Text.Encoding.UTF8, "application/json")
                });
            });
        return mock.Object;
    }

    /// <summary>
    /// Creates a handler that delays responses beyond <paramref name="delayMs" /> to trigger
    /// the Polly attempt-timeout policy.
    /// </summary>
    protected static HttpMessageHandler BuildDelayedHandler(int delayMs)
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage _, CancellationToken ct) =>
            {
                await Task.Delay(delayMs, ct);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json")
                };
            });
        return mock.Object;
    }
}
