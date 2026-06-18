using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Abstraction;
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
    /// Initialises a new instance of <see cref="AzureFoundryService"/> with configuration and logger.
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

            if (!success)
                return string.Empty;

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
    /// <remarks>
    /// Delegates HTTP-level guards (429, non-2xx, JSON deserialisation failure) to
    /// <see cref="AiServiceHelper.ParseImageResponseAsync"/>.
    /// <see cref="System.Net.Http.HttpRequestException"/> on the POST call is caught and logged as an error.
    /// An empty or whitespace prompt emits <c>LogWarning</c> and returns immediately without making any HTTP call.
    /// Schema-specific parsing (<c>data[0].b64_json</c>, <c>data[0].url</c> fallback, origin validation)
    /// remains inside this service.
    /// </remarks>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("Azure Foundry GenerateImageAsync called with an empty or whitespace prompt.");
            return Array.Empty<byte>();
        }

        // Azure AI Foundry /openai/v1 expects the deployment name as `model` in the
        // request body. The endpoint does not embed it in the URL path.
        var requestBody = new
        {
            model = _options.ImageDeploymentName,
            prompt,
            n = 1,
            size = "1024x1024"
        };

        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Azure Foundry image generation HTTP request failed.");
            return Array.Empty<byte>();
        }

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "Azure Foundry", _logger, cancellationToken);

        if (!success || content is null)
            return Array.Empty<byte>();

        var result = content.Value;

        if (!result.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            _logger.LogError("Azure Foundry image generation response does not contain data entries.");
            return Array.Empty<byte>();
        }

        var first = data[0];

        if (first.TryGetProperty("b64_json", out var b64Property))
        {
            var base64 = b64Property.GetString();
            return string.IsNullOrWhiteSpace(base64)
                ? Array.Empty<byte>()
                : Convert.FromBase64String(base64);
        }

        if (first.TryGetProperty("url", out var urlProperty))
        {
            var imageUrl = urlProperty.GetString();
            if (string.IsNullOrWhiteSpace(imageUrl))
                return Array.Empty<byte>();

            // Warn when the fallback URL origin differs from the configured endpoint.
            var configuredOrigin = new Uri(_options.Endpoint.TrimEnd('/')).GetLeftPart(UriPartial.Authority);
            var imageOrigin = new Uri(imageUrl).GetLeftPart(UriPartial.Authority);
            if (!string.Equals(configuredOrigin, imageOrigin, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning(
                    "Azure Foundry image generation returned a fallback URL from a different origin: {ImageUrl}. Expected origin: {ConfiguredOrigin}.",
                    imageUrl, configuredOrigin);
            }

            return await _client.GetByteArrayAsync(imageUrl, cancellationToken);
        }

        return Array.Empty<byte>();
    }

    // Azure AI Foundry /openai/v1 exposes a unified chat completions path.
    // The deployment name is passed as `model` in the request body, so the URL
    // does not include the deployment segment or an api-version query parameter.
    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/chat/completions";

    // Azure AI Foundry /openai/v1 exposes a unified image generation path.
    // The deployment name is passed as `model` in the request body, so the URL
    // does not include the deployment segment or an api-version query parameter.
    private string GetImageGenerationEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/images/generations";

    private object BuildSummaryPayload(string text, int messageMaxLength)
    {
        var tokenDivisor = Math.Max(1, _options.SummaryMaxTokensPerChar);
        var maxTokens = Math.Max(1, messageMaxLength / tokenDivisor);
        var underCharacters = Math.Max(1, messageMaxLength - _options.SummarySafetyMarginChars);

        var systemContent = _options.SummarySystemPromptTemplate
            .Replace("{MaxChars}", underCharacters.ToString(), StringComparison.Ordinal);
        var userContent = _options.SummaryUserPromptTemplate
            .Replace("{Text}", text, StringComparison.Ordinal);

        return new
        {
            model = _options.DeploymentName,
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user", content = userContent }
            },
            max_tokens = maxTokens,
            temperature = _options.SummaryTemperature
        };
    }

    private object BuildImagePromptPayload(string summary)
    {
        var userContent = _options.ImagePromptUserTemplate
            .Replace("{Summary}", summary, StringComparison.Ordinal);

        return new
        {
            model = _options.DeploymentName,
            messages = new[]
            {
                new { role = "system", content = _options.ImagePromptSystemTemplate },
                new { role = "user", content = userContent }
            },
            max_tokens = _options.ImagePromptMaxTokens,
            temperature = _options.ImagePromptTemperature
        };
    }
}
