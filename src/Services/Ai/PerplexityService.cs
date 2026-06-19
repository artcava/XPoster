using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="IAiService"/> using the Perplexity Sonar Chat Completions API.
/// Image generation is not supported; <see cref="GenerateImageAsync"/> returns an empty
/// byte array and logs a warning instead of throwing, allowing callers to handle the
/// absence of an image gracefully.
/// </summary>
public class PerplexityService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<PerplexityService> _logger;
    private readonly PerplexityOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="PerplexityService"/>.
    /// </summary>
    public PerplexityService(
        IHttpClientFactory httpClientFactory,
        IOptions<PerplexityOptions> options,
        ILogger<PerplexityService> logger)
    {
        _logger  = logger;
        _options = options.Value;
        _client  = httpClientFactory.CreateClient("Perplexity");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
    }

    /// <inheritdoc/>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength, CancellationToken cancellationToken = default)
    {
        int tries = 0;
        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(
                GetChatCompletionsEndpoint(),
                BuildSummaryPayload(text, messageMaxLength),
                cancellationToken);

            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "Perplexity", "summary generation", _logger, cancellationToken);

            if (!success) return string.Empty;
            text = content;
        }
        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync(
            GetChatCompletionsEndpoint(),
            BuildImagePromptPayload(text),
            cancellationToken);

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "Perplexity", "image prompt generation", _logger, cancellationToken);

        return success ? content : string.Empty;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Perplexity does not offer an image generation API. This method always returns
    /// an empty <see cref="byte"/> array and logs a warning so the orchestrator can
    /// decide whether to skip the image or fall back to another provider.
    /// </remarks>
    public Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        _logger.LogWarning(
            "{Service} does not support image generation. Returning empty byte array.",
            nameof(PerplexityService));

        return Task.FromResult(Array.Empty<byte>());
    }

    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/chat/completions";

    private object BuildSummaryPayload(string text, int messageMaxLength)
    {
        var tokenDivisor    = Math.Max(1, _options.SummaryMaxTokensPerChar);
        var maxTokens       = Math.Max(1, messageMaxLength / tokenDivisor);
        var underCharacters = Math.Max(1, messageMaxLength - _options.SummarySafetyMarginChars);

        var systemContent = _options.SummarySystemPromptTemplate
            .Replace("{MaxChars}", underCharacters.ToString(), StringComparison.Ordinal);
        var userContent = _options.SummaryUserPromptTemplate
            .Replace("{Text}", text, StringComparison.Ordinal);

        return new
        {
            model       = _options.DeploymentName,
            messages    = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user",   content = userContent   }
            },
            max_tokens  = maxTokens,
            temperature = _options.SummaryTemperature
        };
    }

    private object BuildImagePromptPayload(string summary)
    {
        var userContent = _options.ImagePromptUserTemplate
            .Replace("{Summary}", summary, StringComparison.Ordinal);

        return new
        {
            model       = _options.DeploymentName,
            messages    = new[]
            {
                new { role = "system", content = _options.ImagePromptSystemTemplate },
                new { role = "user",   content = userContent                         }
            },
            max_tokens  = _options.ImagePromptMaxTokens,
            temperature = _options.ImagePromptTemperature
        };
    }
}
