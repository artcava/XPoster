using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="ITextToTextProvider"/> and <see cref="ITextToImageProvider"/>
/// by calling the OpenAI Chat Completions and Image Generations APIs.
/// Prompt data is read exclusively from the incoming <see cref="PromptRequest"/> /
/// <see cref="ImagePromptRequest"/>; no prompt fields are read from options.
/// </summary>
public class OpenAiService : ITextToTextProvider, ITextToImageProvider
{
    private readonly HttpClient _client;
    private readonly ILogger<OpenAiService> _logger;
    private readonly OpenAiOptions _options;
    /// <summary>
    /// Initialises a new instance of <see cref="OpenAiService"/>.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory used to create the OpenAI HTTP client.</param>
    /// <param name="options">The OpenAI options containing API key and endpoints.</param>
    /// <param name="logger">The logger instance.</param>
    public OpenAiService(
        IHttpClientFactory httpClientFactory,
        IOptions<OpenAiOptions> options,
        ILogger<OpenAiService> logger)
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
            var payload = BuildChatPayload(text, request);
            var response = await _client.PostAsJsonAsync(
                GetChatCompletionsEndpoint(), payload, cancellationToken);

            var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
                response, "OpenAI", "text generation", _logger, cancellationToken);

            if (!success) return string.Empty;
            text = content;
            tries++;
        }
        while (maxLength.HasValue && text.Length > maxLength.Value && tries <= 2);

        return text;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(
        ImagePromptRequest request,
        CancellationToken cancellationToken = default)
    {
        var prompt = request.InputText;
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("OpenAI GenerateImageAsync called with an empty or whitespace prompt.");
            return Array.Empty<byte>();
        }

        var imageModel = _options.ImageModelName;
        var quantity = request.ImageQuantity ?? 1;
        var size = request.ImageSize ?? "1024x1024";

        _logger.LogInformation(
            "Generating image with {ImageModel}, quantity: {Quantity}, size: {Size}.",
            imageModel, quantity, size);

        var body = new { model = imageModel, prompt, n = quantity, size };

        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsJsonAsync(
                GetImageGenerationEndpoint(), body, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "OpenAI image generation HTTP request failed.");
            return Array.Empty<byte>();
        }

        return await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, _client, _logger,
            allowedOrigin: null, cancellationToken);
    }
    /// <summary>
    /// Builds the payload for the OpenAI Chat Completions API request.
    /// </summary>
    /// <param name="text">The input text to include in the chat payload.</param>
    /// <param name="request">The prompt request containing templates and settings.</param>
    /// <returns>An object representing the payload for the OpenAI Chat Completions API request.</returns>
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
    private string GetChatCompletionsEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/chat/completions";
    private string GetImageGenerationEndpoint() => $"{_options.Endpoint.TrimEnd('/')}/images/generations";
}