using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="ITextToTextProvider"/> using the DeepSeek API.
/// Image generation is not supported by this provider.
/// </summary>
public class DeepSeekService : ITextToTextProvider
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
                AiServiceHelper.BuildChatPayload(text, request, _options.TextModelName),
                cancellationToken);
            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "DeepSeek", "text generation", _logger, cancellationToken);
            if (!success) return string.Empty;
            text = content;
            tries++;
        }
        while (maxLength.HasValue && text.Length > maxLength.Value && tries <= 2);
        return text;
    }

    private string GetChatCompletionsEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/chat/completions";
}
