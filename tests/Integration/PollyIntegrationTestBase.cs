using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;

namespace XPoster.Tests.Integration;

/// <summary>
/// Base class for Polly resilience pipeline integration tests.
/// Builds a real <see cref="IServiceCollection" /> with <c>AddStandardResilienceHandler</c>
/// configured identically to <c>Program.cs</c>, then substitutes only the innermost
/// <see cref="HttpMessageHandler" /> with a controllable test double.
/// </summary>
public abstract class PollyIntegrationTestBase
{
    private const int DefaultAttemptTimeoutSeconds = 30;
    private const int DefaultTotalRequestTimeoutSeconds = 180;
    private const int DefaultBreakDurationSeconds = 30;
    private const int DefaultMaxRetryAttempts = 3;
    private const int DefaultRetryDelaySeconds = 2;
    private const int DefaultMinimumThroughput = 100;

    /// <summary>
    /// Builds an <see cref="IServiceProvider" /> with the named HTTP client wired through
    /// the standard Polly resilience pipeline backed by <paramref name="innerHandler" />.
    /// <para>
    /// Pass <paramref name="retryEnabled"/>: <c>false</c> together with
    /// <paramref name="minimumThroughput"/>: 2 when the test needs to open the circuit
    /// breaker deterministically: retries are suppressed so each <c>PostAsync</c> counts
    /// as exactly one failure, and the low throughput threshold lets the breaker open
    /// after just two consecutive failures.
    /// </para>
    /// </summary>
    protected static IServiceProvider BuildProviderWithHandler(
        string clientName,
        HttpMessageHandler innerHandler,
        int maxRetryAttempts = DefaultMaxRetryAttempts,
        int retryDelaySeconds = DefaultRetryDelaySeconds,
        int attemptTimeoutSeconds = DefaultAttemptTimeoutSeconds,
        int totalRequestTimeoutSeconds = DefaultTotalRequestTimeoutSeconds,
        int breakDurationSeconds = DefaultBreakDurationSeconds,
        int minimumThroughput = DefaultMinimumThroughput,
        bool retryEnabled = true)
    {
        var samplingDurationSeconds = attemptTimeoutSeconds * 2 + 10;

        var services = new ServiceCollection();
        services.AddLogging();

        var builder = services.AddHttpClient(clientName);
        builder.AddStandardResilienceHandler(options =>
        {
            options.Retry.ShouldHandle = retryEnabled
                ? args => ValueTask.FromResult(
                    args.Outcome.Result?.StatusCode is
                        HttpStatusCode.TooManyRequests or
                        HttpStatusCode.InternalServerError or
                        HttpStatusCode.BadGateway or
                        HttpStatusCode.ServiceUnavailable or
                        HttpStatusCode.GatewayTimeout
                    || args.Outcome.Exception is not null)
                : _ => ValueTask.FromResult(false);

            options.CircuitBreaker.ShouldHandle = args => ValueTask.FromResult(
                args.Outcome.Result?.StatusCode is
                    HttpStatusCode.TooManyRequests or
                    HttpStatusCode.InternalServerError or
                    HttpStatusCode.BadGateway or
                    HttpStatusCode.ServiceUnavailable or
                    HttpStatusCode.GatewayTimeout
                || args.Outcome.Exception is not null);

            options.Retry.MaxRetryAttempts = maxRetryAttempts;
            options.Retry.Delay = TimeSpan.FromSeconds(retryDelaySeconds);
            options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(attemptTimeoutSeconds);
            options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);
            options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(breakDurationSeconds);
            options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(samplingDurationSeconds);
            options.CircuitBreaker.MinimumThroughput = minimumThroughput;
        });
        builder.ConfigurePrimaryHttpMessageHandler(() => innerHandler);

        return services.BuildServiceProvider();
    }

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
