using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XPoster.Tests.Integration;

/// <summary>
/// Integration tests verifying that the Polly standard resilience pipeline is correctly
/// wired for the AI-provider named HTTP clients: <c>OpenAI</c>, <c>AzureFoundry</c>,
/// <c>DeepSeek</c>, and <c>FalAi</c>.
///
/// Each test builds a real <see cref="IServiceProvider" /> with the same
/// <c>AddStandardResilienceHandler</c> configuration as <c>Program.cs</c> and verifies
/// that Polly retries on 429 and ultimately returns the final response to the caller.
/// </summary>
public sealed class AiClientsResiliencePipelineTests : PollyIntegrationTestBase
{
    [Theory]
    [InlineData("OpenAI",       "https://api.openai.com",                "/v1/chat/completions",                                          30, 180)]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com",      "/openai/deployments/gpt-4/chat/completions?api-version=2024-02-01", 30, 180)]
    [InlineData("DeepSeek",     "https://api.deepseek.com",              "/v1/chat/completions",                                          30, 180)]
    // FalAi uses a 60-second attempt timeout to accommodate image generation latency;
    // TotalRequestTimeout must exceed AttemptTimeout, so we use 300 s.
    [InlineData("FalAi",        "https://fal.run",                       "/fal-ai/flux/dev",                                              60, 300)]
    public async Task Polly_AiClient_RetriesOn429_AndEventuallySucceeds(
        string clientName, string baseUrl, string path,
        int attemptTimeoutSeconds, int totalRequestTimeoutSeconds)
    {
        // Arrange: two 429s followed by a 200 with minimal JSON
        var responseBody = "{\"choices\":[{\"message\":{\"content\":\"ok\"}}]}";
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, responseBody));

        var provider = BuildProviderWithHandler(
            clientName,
            handler,
            attemptTimeoutSeconds:      attemptTimeoutSeconds,
            totalRequestTimeoutSeconds: totalRequestTimeoutSeconds);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient(clientName);
        client.BaseAddress = new Uri(baseUrl);

        // Act
        var response = await client.PostAsync(
            path,
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("OpenAI",       "https://api.openai.com",           "/v1/chat/completions",       30, 180)]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com", "/openai/deployments/gpt-4",  30, 180)]
    [InlineData("DeepSeek",     "https://api.deepseek.com",         "/v1/chat/completions",       30, 180)]
    [InlineData("FalAi",        "https://fal.run",                  "/fal-ai/flux/dev",           60, 300)]
    public async Task Polly_AiClient_AttemptTimeout_CancelsSlowRequest(
        string clientName, string baseUrl, string path,
        int attemptTimeoutSeconds, int totalRequestTimeoutSeconds)
    {
        // Arrange: handler always takes longer than the 1-second test timeout.
        // We override attemptTimeoutSeconds to 1 so the test completes quickly,
        // but keep totalRequestTimeoutSeconds proportional (must be > 1).
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler(
            clientName,
            handler,
            attemptTimeoutSeconds:      1,
            totalRequestTimeoutSeconds: totalRequestTimeoutSeconds);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient(clientName);
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                path,
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }
}
