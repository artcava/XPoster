using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="IAiService"/> by calling the OpenAI Chat Completions and Image Generations APIs.
/// Endpoints, models, and behavioural parameters are supplied via <see cref="OpenAiOptions"/>.
/// </summary>
public class OpenAiService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<OpenAiService> _logger;
    private readonly OpenAiOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="OpenAiService"/>, configuring the HTTP client
    /// with the OpenAI Bearer token from <see cref="OpenAiOptions.ApiKey"/>.
    /// </summary>
    /// <param name="httpClientFactory">The factory used to create the underlying <see cref="HttpClient"/>.</param>
    /// <param name="options">The OpenAI provider options.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    public OpenAiService(IHttpClientFactory httpClientFactory, IOptions<OpenAiOptions> options, ILogger<OpenAiService> logger)
    {
        _logger = logger;
        _options = options.Value;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
    }

    /// <inheritdoc/>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength, CancellationToken cancellationToken = default)
    {
        int tries = 0;

        // text is a non-nullable string — the `text != null` guard was redundant and has been removed.
        // AzureFoundryService canonical pattern: guard only on Length and retry count.
        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(_options.ChatEndpoint, GetSummary(text, messageMaxLength), cancellationToken);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.LogInformation("OpenAI returned 429 during summary generation.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("OpenAI summary request failed with status code {StatusCode}", response.StatusCode);
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>(cancellationToken);
            if (result is null || result.choices is null || result.choices.Length == 0)
            {
                _logger.LogWarning("OpenAI returned a response with no choices during summary generation.");
                return string.Empty;
            }

            text = result.choices[0].message.content.Trim();
        }

        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(_options.ChatEndpoint, GetPromptForImage(text), cancellationToken);
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogInformation("OpenAI returned 429 during image prompt generation.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("OpenAI image prompt request failed with status code {StatusCode}", response.StatusCode);
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>(cancellationToken);
        if (result is null || result.choices is null || result.choices.Length == 0)
        {
            _logger.LogWarning("OpenAI returned a response with no choices during image prompt generation.");
            return string.Empty;
        }

        return result.choices[0].message.content.Trim();
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Generating image with model {ImageModel}, prompt: {Prompt}", _options.ImageModel, prompt);

        var body = new
        {
            model = _options.ImageModel,
            prompt,
            n = _options.ImageCount,
            size = _options.ImageSize
        };

        var response = await _client.PostAsJsonAsync(_options.ImageEndpoint, body, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("OpenAI image generation failed with status code {StatusCode}", response.StatusCode);
            return Array.Empty<byte>();
        }

        var result = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken);
        var base64 = result.GetProperty("data")[0].GetProperty("b64_json").GetString();
        // base64 cannot be null if API responded with 200 and valid JSON structure
        return Convert.FromBase64String(base64!);
    }

    /// <summary>
    /// Builds the request payload for the Chat Completions API to summarise <paramref name="text"/>
    /// within the given character budget.
    /// </summary>
    /// <param name="text">The text to summarise.</param>
    /// <param name="messageMaxLenght">The character limit that the summary must respect.</param>
    /// <returns>An anonymous object serialisable as a valid OpenAI Chat Completions request body.</returns>
    private object GetSummary(string text, int messageMaxLenght)
    {
        var maxTokens = messageMaxLenght / _options.SummaryMaxTokensPerChar;
        var underCharacters = messageMaxLenght - _options.SummarySafetyMarginChars;

        var systemContent = _options.SummarySystemPromptTemplate
            .Replace("{MaxChars}", underCharacters.ToString(), StringComparison.Ordinal);
        var userContent = _options.SummaryUserPromptTemplate
            .Replace("{Text}", text, StringComparison.Ordinal);

        return new
        {
            model = _options.ChatModel,
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user", content = userContent }
            },
            max_tokens = maxTokens,
            temperature = _options.SummaryTemperature
        };
    }

    /// <summary>
    /// Builds the request payload for the Chat Completions API to derive an image generation prompt
    /// from a news <paramref name="summary"/>.
    /// </summary>
    /// <param name="summary">The text summary to base the image prompt on.</param>
    /// <returns>An anonymous object serialisable as a valid OpenAI Chat Completions request body.</returns>
    private object GetPromptForImage(string summary)
    {
        var userContent = _options.ImagePromptUserTemplate
            .Replace("{Summary}", summary, StringComparison.Ordinal);

        return new
        {
            model = _options.ChatModel,
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
