// src/Services/DeepSeekAiService.cs
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implementazione di IAiService usando DeepSeek API.
/// Gestisce solo la generazione di testo (summary e image prompt).
/// La generazione di immagini è delegata a <see cref="FalAiImageService"/> tramite <see cref="HybridAiService"/>.
/// </summary>
public class DeepSeekService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<DeepSeekService> _logger;
    private readonly DeepSeekOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="DeepSeekService"/> with configuration and logger.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    public DeepSeekService(
        IHttpClientFactory httpClientFactory,
        IOptions<DeepSeekOptions> options,
        ILogger<DeepSeekService> logger)
    {
        _logger = logger;
        _options = options.Value;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
    }

    /// <summary>
    /// Genera un riassunto del testo.
    /// </summary>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength)
    {
        int tries = 0;

        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildSummaryPayload(text, messageMaxLength));
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.LogInformation("DeepSeek returned 429 during summary generation.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("DeepSeek summary request failed with status code {StatusCode}", response.StatusCode);
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
            _logger.LogInformation("DeepSeek returned 429 during image prompt generation.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("DeepSeek image prompt request failed with status code {StatusCode}", response.StatusCode);
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.choices[0].message.content.Trim() ?? string.Empty;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Image generation is not supported by DeepSeek.
    /// In the hybrid setup this method is never called directly —
    /// <see cref="HybridAiService"/> delegates image generation to <see cref="FalAiImageService"/>.
    /// </remarks>
    public Task<byte[]> GenerateImageAsync(string prompt)
    {
        _logger.LogWarning(
            "GenerateImageAsync was called on DeepSeekService, but image generation is handled by fal.ai in the hybrid setup.");

        return Task.FromResult(Array.Empty<byte>());
    }

    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/chat/completions";

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
