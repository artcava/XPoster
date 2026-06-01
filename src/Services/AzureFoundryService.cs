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
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength)
    {
        int tries = 0;

        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildSummaryPayload(text, messageMaxLength));
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

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            text = result?.choices[0].message.content.Trim() ?? string.Empty;
        }

        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text)
    {
        var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildImagePromptPayload(text));
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

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.choices[0].message.content.Trim() ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        var requestBody = new
        {
            prompt,
            n = 1,
            size = "1024x1024",
            response_format = "b64_json"
        };

        var response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Azure Foundry image generation failed with status code {StatusCode}", response.StatusCode);
            return Array.Empty<byte>();
        }

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
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
            {
                return Array.Empty<byte>();
            }

            return await _client.GetByteArrayAsync(imageUrl);
        }

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
