using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="ITextToTextProvider"/> using the Perplexity Sonar Chat Completions API.
/// Image generation is not supported by this provider; <see cref="ITextToImageProvider"/> is not implemented.
/// </summary>
public class PerplexityService : ITextToTextProvider
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
        _logger = logger;
        _options = options.Value;
        _client = httpClientFactory.CreateClient("Perplexity");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
    }

    /// <inheritdoc/>
    public async Task<string> GenerateTextAsync(
        PromptRequest request,
        CancellationToken cancellationToken = default)
    {
        var text = request.InputText;
        var maxLength = request.MaxOutputLength;
        int tries = 0;
        do
        {
            var response = await _client.PostAsJsonAsync(
                GetChatCompletionsEndpoint(),
                BuildChatPayload(text, request),
                cancellationToken);
            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "Perplexity", "text generation", _logger, cancellationToken);
            if (!success) return string.Empty;
            text = content;
            tries++;
        }
        while (maxLength.HasValue && text.Length > maxLength.Value && tries <= 2);
        return text;
    }

    private object BuildChatPayload(string text, PromptRequest request)
    {
        var systemContent = request.SystemPromptTemplate
            .Replace("{MaxChars}", request.MaxOutputLength.ToString(), StringComparison.Ordinal);
        var label = request.InputTextLabel ?? "{Text}";
        var userContent = request.UserPromptTemplate
            .Replace(label, text, StringComparison.Ordinal);
        return new
        {
            model = _options.TextModelName,
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user",   content = userContent   }
            },
            max_tokens = request.MaxTokenBudget,
            temperature = request.Temperature
        };
    }

    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/chat/completions";

}
