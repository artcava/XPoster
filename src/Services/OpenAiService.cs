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

        while (text != null && text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(_options.ChatEndpoint, GetSummary(text, messageMaxLength), cancellationToken);
            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "OpenAI", "summary generation", _logger, cancellationToken);

            if (!success)
                return string.Empty;

            text = content;
        }

        return text ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(_options.ChatEndpoint, GetPromptForImage(text), cancellationToken);
        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "OpenAI", "image prompt generation", _logger, cancellationToken);

        return success ? content : string.Empty;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Delegates HTTP-level guards (429, non-2xx, JSON deserialisation failure) to
    /// <see cref="AiServiceHelper.ParseImageResponseAsync"/>.
    /// <see cref="System.Net.Http.HttpRequestException"/> on the POST call is caught and logged as an error.
    /// An empty or whitespace prompt emits <c>LogWarning</c> and returns immediately without making any HTTP call.
    /// Schema-specific parsing (<c>data[0].b64_json</c>) remains inside this service.
    /// </remarks>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("OpenAI GenerateImageAsync called with an empty or whitespace prompt.");
            return Array.Empty<byte>();
        }

        _logger.LogInformation("Generating image with {ImageModel}, prompt: {Prompt}", _options.ImageModel, prompt);

        var body = new
        {
            model = _options.ImageModel,
            prompt,
            n = _options.ImageCount,
            size = _options.ImageSize
        };

        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsJsonAsync(_options.ImageEndpoint, body, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "OpenAI image generation HTTP request failed.");
            return Array.Empty<byte>();
        }

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "OpenAI", _logger, cancellationToken);

        if (!success || content is null)
            return Array.Empty<byte>();

        var result = content.Value;

        if (!result.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            _logger.LogError("OpenAI image generation response does not contain data entries.");
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

        return Array.Empty<byte>();
    }

    private object GetSummary(string text, int messageMaxLength)
    {
        var maxTokens = messageMaxLength / _options.SummaryMaxTokensPerChar;
        var underCharacters = messageMaxLength - _options.SummarySafetyMarginChars;

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
