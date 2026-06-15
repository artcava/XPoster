using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XPoster.Tests.Integration;

/// <summary>
/// Integration tests verifying that the Polly standard resilience pipeline is correctly
/// wired for the AI-provider named HTTP clients: <c>OpenAI</c>, <c>AzureFoundry</c>,
/// <c>DeepSeek</c>, and <c>FalAi</c>.
/// </summary>
public sealed class AiClientsResiliencePipelineTests : PollyIntegrationTestBase
{
    [Theory]
    [InlineData("OpenAI",       "https://api.openai.com",                "/v1/chat/completions",                                             30, 180)]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com",      "/openai/deployments/gpt-4/chat/completions?api-version=2024-02-01", 30, 180)]
    [InlineData("DeepSeek",     "https://api.deepseek.com",              "/v1/chat/completions",                                             30, 180)]
    // FalAi uses a 60-second attempt timeout; TotalRequestTimeout must exceed it.
    [InlineData("FalAi",        "https://fal.run",                       "/fal-ai/flux/dev",                                                 60, 300)]
    public async Task Polly_AiClient_RetriesOn429_AndEventuallySucceeds(
        string clientName, string baseUrl, string path,
        int attemptTimeoutSeconds, int totalRequestTimeoutSeconds)
    {
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

        var response = await client.PostAsync(
            path,
            new StringContent("{}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    // attemptTimeoutSeconds is overridden to 1 s inside the test body so the test
    // completes quickly; the InlineData value is intentionally unused — removed to
    // avoid xUnit1026. totalRequestTimeoutSeconds must remain > 1.
    [InlineData("OpenAI",       "https://api.openai.com",           "/v1/chat/completions", 180)]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com", "/openai/deployments/gpt-4", 180)]
    [InlineData("DeepSeek",     "https://api.deepseek.com",         "/v1/chat/completions", 180)]
    [InlineData("FalAi",        "https://fal.run",                  "/fal-ai/flux/dev",    300)]
    public async Task Polly_AiClient_AttemptTimeout_CancelsSlowRequest(
        string clientName, string baseUrl, string path,
        int totalRequestTimeoutSeconds)
    {
        // Override attemptTimeoutSeconds to 1 s so the test does not actually wait.
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler(
            clientName,
            handler,
            attemptTimeoutSeconds:      1,
            totalRequestTimeoutSeconds: totalRequestTimeoutSeconds);
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient(clientName);
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(totalRequestTimeoutSeconds);

        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                path,
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }
}
