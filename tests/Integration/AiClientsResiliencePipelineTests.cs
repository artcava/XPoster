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
    [InlineData("OpenAI",       "https://api.openai.com",                "/v1/chat/completions")]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com",      "/openai/deployments/gpt-4/chat/completions?api-version=2024-02-01")]
    [InlineData("DeepSeek",     "https://api.deepseek.com",              "/v1/chat/completions")]
    [InlineData("FalAi",        "https://fal.run",                       "/fal-ai/flux/dev")]
    public async Task Polly_AiClient_RetriesOn429_AndEventuallySucceeds(
        string clientName, string baseUrl, string path)
    {
        // Arrange: two 429s followed by a 200 with minimal JSON
        var responseBody = "{\"choices\":[{\"message\":{\"content\":\"ok\"}}]}";
        var handler = BuildSequenceHandler(
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, responseBody));

        var timeoutSeconds = clientName == "FalAi" ? 60 : 30;
        var provider = BuildProviderWithHandler(clientName, handler, attemptTimeoutSeconds: timeoutSeconds);
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
    [InlineData("OpenAI",       "https://api.openai.com",           "/v1/chat/completions",       30)]
    [InlineData("AzureFoundry", "https://xposter.openai.azure.com", "/openai/deployments/gpt-4",  30)]
    [InlineData("DeepSeek",     "https://api.deepseek.com",         "/v1/chat/completions",       30)]
    [InlineData("FalAi",        "https://fal.run",                  "/fal-ai/flux/dev",           60)]
    public async Task Polly_AiClient_AttemptTimeout_CancelsSlowRequest(
        string clientName, string baseUrl, string path, int configuredTimeoutSeconds)
    {
        // Arrange: handler always takes longer than the timeout
        var handler = BuildDelayedHandler(delayMs: 5_000);
        var provider = BuildProviderWithHandler(
            clientName,
            handler,
            attemptTimeoutSeconds: 1 /* use 1 s so the test does not actually wait */ );
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient(clientName);
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(configuredTimeoutSeconds + 30);

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() =>
            client.PostAsync(
                path,
                new StringContent("{}", System.Text.Encoding.UTF8, "application/json")));
    }
}
