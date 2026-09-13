using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XPoster.Extensions;

namespace XPoster.Tests.Integration;

[Trait("Category", "Integration")]
public sealed class HttpResponseBodyLoggingPipelineTests : PollyIntegrationTestBase
{
    private static (IServiceProvider Provider, IReadOnlyList<string> Logs) BuildProvider(
        HttpMessageHandler innerHandler)
    {
        var logs = new List<string>();
        var services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddProvider(new CaptureLoggerProvider(logs));
        });
        services.AddHttpResponseBodyLogging();
        services.AddHttpClients();
        services.AddHttpClient("X").ConfigurePrimaryHttpMessageHandler(() => innerHandler);
        return (services.BuildServiceProvider(), logs);
    }

    [Fact]
    public async Task ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders()
    {
        var handler = BuildSequenceHandler((
            HttpStatusCode.PaymentRequired,
            "{\"title\":\"Not Eligible For Added Permissions\",\"detail\":\"credit limit reached\",\"access_token\":\"integSecret789\"}"));

        var (provider, logs) = BuildProvider(handler);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("X");

        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "https://api.x.com/2/tweets"));

        Assert.Equal(HttpStatusCode.PaymentRequired, response.StatusCode);
        Assert.Contains(logs, m => m.Contains("402", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(logs, m => m.Contains("Not Eligible For Added Permissions", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(logs, m => m.Contains("Content-Type", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(logs, m => m.Contains("integSecret789", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess()
    {
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, "{\"data\":{\"id\":\"1\"}}"));

        var (provider, logs) = BuildProvider(handler);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("X");

        var response = await client.PostAsync(
            "https://api.x.com/2/tweets",
            new System.Net.Http.StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var errorLogs = logs.Count(m => m.Contains("429", StringComparison.OrdinalIgnoreCase));
        Assert.True(errorLogs >= 2, $"expected at least 2 error-level entries for the retry attempts, got {errorLogs}");
        Assert.Contains(logs, m => m.Contains("200", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task ResponseBodyLogging_SuccessLogsBodyReadableByConsumer()
    {
        var handler = BuildSequenceHandler((HttpStatusCode.OK, "{\"data\":{\"id\":\"1\"}}"));

        var (provider, logs) = BuildProvider(handler);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("X");

        var response = await client.PostAsync(
            "https://api.x.com/2/tweets",
            new System.Net.Http.StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("{\"data\":{\"id\":\"1\"}}", await response.Content.ReadAsStringAsync());
        Assert.Contains(logs, m => m.Contains("200", StringComparison.OrdinalIgnoreCase)
            && m.Contains("\"id\":\"1\"", StringComparison.OrdinalIgnoreCase));
    }
}