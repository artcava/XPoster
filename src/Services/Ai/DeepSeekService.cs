using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="IAiService"/> using the DeepSeek API.
/// </summary>
public class DeepSeekService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<DeepSeekService> _logger;
    private readonly DeepSeekOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="DeepSeekService"/>.
    /// </summary>
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

    /// <inheritdoc/>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength, CancellationToken cancellationToken = default)
    {
        int tries = 0;
        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildSummaryPayload(text, messageMaxLength), cancellationToken);
            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "DeepSeek", "summary generation", _logger, cancellationToken);
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
            response, "DeepSeek", "image prompt generation", _logger, cancellationToken);
        return success ? content : string.Empty;
    }

    /// <inheritdoc/>
    /// <exception cref="NotSupportedException">Always thrown. Use <see cref="HybridAiService"/>.</exception>
    public Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
        => throw new NotSupportedException(
            $"{nameof(DeepSeekService)} does not support image generation. " +
            $"Use {nameof(HybridAiService)} to delegate image generation to fal.ai.");

    private string GetChatCompletionsEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/chat/completions";

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
