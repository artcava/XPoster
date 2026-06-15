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
///
/// Additionally, Polly's default ShouldHandle predicate treats HTTP responses as
/// successful regardless of status code — only network-level exceptions count as
/// failures by default. To make retry and circuit-breaker policies react to 4xx/5xx
/// responses, ShouldHandle must be configured explicitly.
///
/// CircuitBreaker.MinimumThroughput controls the minimum number of requests that
/// must pass through the sampling window before the breaker can open. The default
/// value (100) is appropriate for production but makes circuit-breaker tests
/// impractical. Tests that exercise the breaker must pass minimumThroughput: 2.
/// </remarks>
public abstract class PollyIntegrationTestBase
{
    private const int DefaultAttemptTimeoutSeconds      = 30;
    private const int DefaultTotalRequestTimeoutSeconds = 180;
    private const int DefaultBreakDurationSeconds       = 30;
    private const int DefaultMaxRetryAttempts           = 3;
    private const int DefaultRetryDelaySeconds          = 2;
    private const int DefaultMinimumThroughput          = 100; // Polly default — production value

    /// <summary>
    /// Builds an <see cref="IServiceProvider" /> with a named <see cref="System.Net.Http.HttpClient" />
    /// wired through the standard resilience pipeline and backed by <paramref name="innerHandler" />.
    /// Options mirror the values in <c>Program.cs</c>.
    /// Pass <paramref name="minimumThroughput"/>: 2 when the test needs to open the circuit breaker.
    /// </summary>
    protected static IServiceProvider BuildProviderWithHandler(
        string clientName,
        HttpMessageHandler innerHandler,
        int maxRetryAttempts           = DefaultMaxRetryAttempts,
        int retryDelaySeconds          = DefaultRetryDelaySeconds,
        int attemptTimeoutSeconds      = DefaultAttemptTimeoutSeconds,
        int totalRequestTimeoutSeconds = DefaultTotalRequestTimeoutSeconds,
        int breakDurationSeconds       = DefaultBreakDurationSeconds,
        int minimumThroughput          = DefaultMinimumThroughput)
    {
        // Polly constraint: SamplingDuration must be >= AttemptTimeout * 2.
        var samplingDurationSeconds = attemptTimeoutSeconds * 2 + 10;

        var services = new ServiceCollection();
        services.AddLogging();

        var builder = services.AddHttpClient(clientName);
        builder.AddStandardResilienceHandler(options =>
        {
            options.Retry.ShouldHandle = args => ValueTask.FromResult(
                args.Outcome.Result?.StatusCode is HttpStatusCode.TooManyRequests
                    or HttpStatusCode.InternalServerError
                    or HttpStatusCode.BadGateway
                    or HttpStatusCode.ServiceUnavailable
                    or HttpStatusCode.GatewayTimeout
                || args.Outcome.Exception is not null);

            options.CircuitBreaker.ShouldHandle = args => ValueTask.FromResult(
                args.Outcome.Result?.StatusCode is HttpStatusCode.TooManyRequests
                    or HttpStatusCode.InternalServerError
                    or HttpStatusCode.BadGateway
                    or HttpStatusCode.ServiceUnavailable
                    or HttpStatusCode.GatewayTimeout
                || args.Outcome.Exception is not null);

            options.Retry.MaxRetryAttempts               = maxRetryAttempts;
            options.Retry.Delay                          = TimeSpan.FromSeconds(retryDelaySeconds);
            options.AttemptTimeout.Timeout               = TimeSpan.FromSeconds(attemptTimeoutSeconds);
            options.TotalRequestTimeout.Timeout          = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);
            options.CircuitBreaker.BreakDuration         = TimeSpan.FromSeconds(breakDurationSeconds);
            options.CircuitBreaker.SamplingDuration      = TimeSpan.FromSeconds(samplingDurationSeconds);
            options.CircuitBreaker.MinimumThroughput     = minimumThroughput;
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
