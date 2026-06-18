using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="IAiService"/> by calling Azure AI Foundry OpenAI-compatible endpoints.
/// </summary>
public sealed class AzureFoundryService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<AzureFoundryService> _logger;
    private readonly AzureFoundryOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="AzureFoundryService"/>.
    /// </summary>
    public AzureFoundryService(
        IHttpClientFactory httpClientFactory,
        IOptions<AzureFoundryOptions> options,
        ILogger<AzureFoundryService> logger)
    {
        _logger = logger;
        _options = options.Value;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("api-key", _options.ApiKey);
    }

    /// <inheritdoc/>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength, CancellationToken cancellationToken = default)
    {
        int tries = 0;
        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildSummaryPayload(text, messageMaxLength), cancellationToken);
            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "Azure Foundry", "summary generation", _logger, cancellationToken);
            if (!success) return string.Empty;
            text = content;
        }
        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildImagePromptPayload(text), cancellationToken);
        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "Azure Foundry", "image prompt generation", _logger, cancellationToken);
        return success ? content : string.Empty;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("Azure Foundry GenerateImageAsync called with an empty or whitespace prompt.");
            return Array.Empty<byte>();
        }
        var requestBody = new { model = _options.ImageDeploymentName, prompt, n = 1, size = "1024x1024" };
        HttpResponseMessage response;
        try { response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody, cancellationToken); }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Azure Foundry image generation HTTP request failed.");
            return Array.Empty<byte>();
        }
        var allowedOrigin = new Uri(_options.Endpoint.TrimEnd('/')).GetLeftPart(UriPartial.Authority);
        return await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, _client, _logger, allowedOrigin, cancellationToken);
    }

    private string GetChatCompletionsEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/chat/completions";
    private string GetImageGenerationEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/images/generations";

    private object BuildSummaryPayload(string text, int messageMaxLength)
    {
        var tokenDivisor = Math.Max(1, _options.SummaryMaxTokensPerChar);
        var maxTokens = Math.Max(1, messageMaxLength / tokenDivisor);
        var underCharacters = Math.Max(1, messageMaxLength - _options.SummarySafetyMarginChars);
        var systemContent = _options.SummarySystemPromptTemplate.Replace("{MaxChars}", underCharacters.ToString(), StringComparison.Ordinal);
        var userContent = _options.SummaryUserPromptTemplate.Replace("{Text}", text, StringComparison.Ordinal);
        return new { model = _options.DeploymentName, messages = new[] { new { role = "system", content = systemContent }, new { role = "user", content = userContent } }, max_tokens = maxTokens, temperature = _options.SummaryTemperature };
    }

    private object BuildImagePromptPayload(string summary)
    {
        var userContent = _options.ImagePromptUserTemplate.Replace("{Summary}", summary, StringComparison.Ordinal);
        return new { model = _options.DeploymentName, messages = new[] { new { role = "system", content = _options.ImagePromptSystemTemplate }, new { role = "user", content = userContent } }, max_tokens = _options.ImagePromptMaxTokens, temperature = _options.ImagePromptTemperature };
    }
}
