using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="ITextToTextProvider"/> and <see cref="ITextToImageProvider"/>
/// by calling Azure AI Foundry OpenAI-compatible endpoints.
/// </summary>
public sealed class AzureFoundryService : ITextToTextProvider, ITextToImageProvider
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
                response, "Azure Foundry", "text generation", _logger, cancellationToken);
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
            _logger.LogWarning("Azure Foundry GenerateImageAsync called with empty prompt.");
            return Array.Empty<byte>();
        }
        var size = request.ImageSize ?? "1024x1024";
        var quantity = request.ImageQuantity ?? 1;
        var requestBody = new { model = _options.ImageDeploymentName, prompt, n = quantity, size };
        HttpResponseMessage response;
        try { response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody, cancellationToken); }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Azure Foundry image generation HTTP request failed.");
            return Array.Empty<byte>();
        }
        var allowedOrigin = new Uri(_options.Endpoint.TrimEnd('/')).GetLeftPart(UriPartial.Authority);
        return await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, _client, _logger, allowedOrigin, cancellationToken);
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
            model = _options.DeploymentName,
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
