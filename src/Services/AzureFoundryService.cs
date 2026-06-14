using System.Net;
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
    /// <param name="httpClientFactory"></param>
    /// <param name="options"></param>
    /// <param name="logger"></param>
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
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.LogInformation("Azure Foundry returned 429 during summary generation.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Azure Foundry summary request failed with status code {StatusCode}", response.StatusCode);
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>(cancellationToken);
            if (result is null || result.choices is null || result.choices.Length == 0)
            {
                _logger.LogWarning("Azure Foundry returned a response with no choices during summary generation.");
                return string.Empty;
            }

            text = result.choices[0].message.content.Trim();
        }

        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildImagePromptPayload(text), cancellationToken);
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogInformation("Azure Foundry returned 429 during image prompt generation.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Azure Foundry image prompt request failed with status code {StatusCode}", response.StatusCode);
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>(cancellationToken);
        if (result is null || result.choices is null || result.choices.Length == 0)
        {
            _logger.LogWarning("Azure Foundry returned a response with no choices during image prompt generation.");
            return string.Empty;
        }

        return result.choices[0].message.content.Trim();
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("GenerateImageAsync called with an empty prompt.");
            return Array.Empty<byte>();
        }

        var requestBody = new
        {
            prompt,
            n = 1,
            size = "1024x1024",
            response_format = "b64_json"
        };

        var response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody, cancellationToken);

        // Intercept 429 before the generic success check — consistent with GetSummaryAsync
        // and GetImagePromptAsync in this class, and with FalAiImageService (reference implementation).
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogWarning("Azure Foundry returned 429 during image generation.");
            return Array.Empty<byte>();
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Azure Foundry image generation failed with status code {StatusCode}", response.StatusCode);
            return Array.Empty<byte>();
        }

        JsonElement result;
        try
        {
            result = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Azure Foundry image generation response contained invalid JSON.");
            return Array.Empty<byte>();
        }

        if (!result.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            _logger.LogError("Azure Foundry image generation response does not contain data entries.");
            return Array.Empty<byte>();
        }

        var first = data[0];

        if (first.TryGetProperty("b64_json", out var b64Property))
        {
            var base64 = b64Property.GetString();
            if (string.IsNullOrWhiteSpace(base64))
            {
                _logger.LogError("Azure Foundry image generation response contained a null or empty b64_json value.");
                return Array.Empty<byte>();
            }

            try
            {
                return Convert.FromBase64String(base64);
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex, "Azure Foundry image generation response contained an invalid base64 string.");
                return Array.Empty<byte>();
            }
        }

        if (first.TryGetProperty("url", out var urlProperty))
        {
            var imageUrl = urlProperty.GetString();
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                _logger.LogError("Azure Foundry image generation response contained an empty fallback URL.");
                return Array.Empty<byte>();
            }

            // Validate the fallback URL against the configured endpoint origin to prevent
            // SSRF-style downloads from arbitrary hosts returned by the API response.
            // If validation fails we still log and proceed rather than blocking — this is a
            // defence-in-depth warning that enables audit in Application Insights.
            var configuredOrigin = new Uri(_options.Endpoint.TrimEnd('/')).GetLeftPart(UriPartial.Authority);
            if (!imageUrl.StartsWith(configuredOrigin, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning(
                    "Azure Foundry image fallback URL {ImageUrl} does not originate from the configured endpoint {ConfiguredOrigin}. Proceeding with download.",
                    imageUrl,
                    configuredOrigin);
            }

            try
            {
                return await _client.GetByteArrayAsync(imageUrl, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Azure Foundry failed to download image from fallback URL: {Url}", imageUrl);
                return Array.Empty<byte>();
            }
        }

        _logger.LogError("Azure Foundry image generation response data entry is missing both b64_json and url.");
        return Array.Empty<byte>();
    }

    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/openai/deployments/{Uri.EscapeDataString(_options.DeploymentName)}/chat/completions?api-version={Uri.EscapeDataString(_options.ApiVersion)}";

    private string GetImageGenerationEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/openai/deployments/{Uri.EscapeDataString(_options.ImageDeploymentName)}/images/generations?api-version={Uri.EscapeDataString(_options.ApiVersion)}";

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
