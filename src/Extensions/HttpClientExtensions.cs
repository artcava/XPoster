using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace XPoster.Extensions;

/// <summary>
/// Registers all named <see cref="System.Net.Http.HttpClient" /> instances with their
/// Polly standard resilience pipelines.
/// </summary>
/// <remarks>
/// Each client is configured with an explicit <c>ShouldHandle</c> predicate so that
/// Polly treats transient HTTP failures (429, 500, 502, 503, 504) as retriable/breaking
/// outcomes — not just network-level exceptions (which is the Polly default).
///
/// Polly proportionality constraints enforced at pipeline-build time:
///   1. CircuitBreaker.SamplingDuration >= AttemptTimeout * 2
///   2. TotalRequestTimeout > AttemptTimeout
/// </remarks>
public static class HttpClientExtensions
{
    /// <summary>
    /// Adds all named HTTP clients required by XPoster with their Polly resilience
    /// pipelines. Call once from <c>Program.cs</c>:
    /// <code>builder.Services.AddHttpClients();</code>
    /// </summary>
    public static IServiceCollection AddHttpClients(this IServiceCollection services)
    {
        // Standard options shared by all AI and social clients except FalAi.
        services.AddResilientHttpClient("OpenAI",       attemptTimeoutSeconds: 30,  totalRequestTimeoutSeconds: 180, samplingDurationSeconds: 70);
        services.AddResilientHttpClient("AzureFoundry", attemptTimeoutSeconds: 30,  totalRequestTimeoutSeconds: 180, samplingDurationSeconds: 70);
        services.AddResilientHttpClient("DeepSeek",     attemptTimeoutSeconds: 30,  totalRequestTimeoutSeconds: 180, samplingDurationSeconds: 70);
        services.AddResilientHttpClient("LinkedIn",     attemptTimeoutSeconds: 30,  totalRequestTimeoutSeconds: 180, samplingDurationSeconds: 70);
        services.AddResilientHttpClient("Instagram",    attemptTimeoutSeconds: 30,  totalRequestTimeoutSeconds: 180, samplingDurationSeconds: 70);

        // FalAi image generation is slower: wider timeouts to match.
        services.AddResilientHttpClient("FalAi",        attemptTimeoutSeconds: 60,  totalRequestTimeoutSeconds: 300, samplingDurationSeconds: 130);

        return services;
    }

    // ---------------------------------------------------------------------------
    // Private helpers
    // ---------------------------------------------------------------------------

    private static bool IsTransientHttpFailure(HttpResponseMessage? response) =>
        response?.StatusCode is
            HttpStatusCode.TooManyRequests or
            HttpStatusCode.InternalServerError or
            HttpStatusCode.BadGateway or
            HttpStatusCode.ServiceUnavailable or
            HttpStatusCode.GatewayTimeout;

    private static IServiceCollection AddResilientHttpClient(
        this IServiceCollection services,
        string clientName,
        int attemptTimeoutSeconds,
        int totalRequestTimeoutSeconds,
        int samplingDurationSeconds)
    {
        services.AddHttpClient(clientName)
            .AddStandardResilienceHandler(options =>
            {
                options.Retry.ShouldHandle = args =>
                    ValueTask.FromResult(
                        IsTransientHttpFailure(args.Outcome.Result)
                        || args.Outcome.Exception is not null);

                options.CircuitBreaker.ShouldHandle = args =>
                    ValueTask.FromResult(
                        IsTransientHttpFailure(args.Outcome.Result)
                        || args.Outcome.Exception is not null);

                options.Retry.MaxRetryAttempts          = 3;
                options.Retry.Delay                     = TimeSpan.FromSeconds(2);
                options.AttemptTimeout.Timeout          = TimeSpan.FromSeconds(attemptTimeoutSeconds);
                options.TotalRequestTimeout.Timeout     = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);
                options.CircuitBreaker.BreakDuration    = TimeSpan.FromSeconds(30);
                options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(samplingDurationSeconds);
            });

        return services;
    }
}
