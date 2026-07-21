using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Shared helper for parsing OpenAI-compatible HTTP responses and building
/// shared chat completion payloads.
/// Centralises guard pipelines and prompt-building logic used by every AI
/// provider implementation.
/// </summary>
internal static class AiServiceHelper
{
    /// <summary>
    /// Builds a shared OpenAI-compatible chat completion payload.
    /// Interpolates <c>{MaxChars}</c> into <see cref="PromptRequest.SystemPromptTemplate"/>,
    /// substitutes the input text label into <see cref="PromptRequest.UserPromptTemplate"/>
    /// (falling back to <c>{Text}</c> when <see cref="PromptRequest.InputTextLabel"/> is <see langword="null"/>),
    /// and returns an anonymous object with <c>model</c>, <c>messages</c>,
    /// <c>max_tokens</c>, and <c>temperature</c>.
    /// </summary>
    /// <param name="text">The input text to embed in the user message.</param>
    /// <param name="request">The prompt request containing templates and generation settings.</param>
    /// <param name="modelName">The provider-specific model identifier (e.g. from <c>options.TextModelName</c>).</param>
    /// <returns>An anonymous object suitable for serialisation as a chat completion request body.</returns>
    internal static object BuildChatPayload(string text, PromptRequest request, string modelName)
    {
        var systemContent = request.SystemPromptTemplate
            .Replace("{MaxChars}", request.MaxOutputLength.ToString(), StringComparison.Ordinal);

        var label = request.InputTextLabel ?? "{Text}";
        var userContent = request.UserPromptTemplate
            .Replace(label, text, StringComparison.Ordinal);

        return new
        {
            model = modelName,
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user",   content = userContent   }
            },
            max_tokens = request.MaxTokenBudget,
            temperature = request.Temperature
        };
    }

    /// <summary>
    /// Parses an OpenAI-compatible chat completion HTTP response.
    /// </summary>
    internal static async Task<(bool Success, string Content)> ParseChatCompletionResponseAsync(
        HttpResponseMessage response,
        string providerName,
        string operationName,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            logger.LogInformation("{Provider} returned 429 (TooManyRequests) during {Operation}.", providerName, operationName);
            return (false, string.Empty);
        }

        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation("{Provider} {Operation} request failed with status code {StatusCode}.",
                providerName, operationName, response.StatusCode);
            return (false, string.Empty);
        }

        AIResponse? result;
        try
        {
            result = await response.Content.ReadFromJsonAsync<AIResponse>(cancellationToken);
        }
        catch (JsonException)
        {
            logger.LogWarning("{Provider} returned malformed JSON during {Operation}.", providerName, operationName);
            return (false, string.Empty);
        }

        if (result is null || result.choices is null || result.choices.Length == 0)
        {
            logger.LogWarning("{Provider} returned a response with no choices during {Operation}.",
                providerName, operationName);
            return (false, string.Empty);
        }

        return (true, result.choices[0].message.content.Trim());
    }

    /// <summary>
    /// Parses an image generation HTTP response end-to-end.
    /// Handles HTTP guard pipeline, JSON deserialization, and provider-specific
    /// byte extraction (base64 or URL download).
    /// </summary>
    internal static async Task<byte[]> ParseImageResponseAsync(
        HttpResponseMessage response,
        AiProvider provider,
        HttpClient httpClient,
        ILogger logger,
        string? allowedOrigin,
        CancellationToken cancellationToken)
    {
        var label = provider.GetLabel();

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            logger.LogWarning("{Provider} returned 429 (TooManyRequests) during image generation.", label);
            return Array.Empty<byte>();
        }

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("{Provider} image generation failed with status code {StatusCode}.",
                label, response.StatusCode);
            return Array.Empty<byte>();
        }

        JsonElement root;
        try
        {
            root = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken);
        }
        catch (JsonException)
        {
            logger.LogError("{Provider} image generation returned malformed JSON.", label);
            return Array.Empty<byte>();
        }

        return provider switch
        {
            AiProvider.OpenAi => ExtractOpenAiBytes(root, label, logger),
            AiProvider.AzureFoundry => await ExtractAzureFoundryBytesAsync(root, label, allowedOrigin, httpClient, logger, cancellationToken),
            AiProvider.FalAi => await ExtractFalAiBytesAsync(root, label, httpClient, logger, cancellationToken),
            _ => LogAndReturnEmpty(logger, label, "Image byte extraction is not supported for this provider.")
        };
    }

    private static byte[] ExtractOpenAiBytes(JsonElement root, string provider, ILogger logger)
    {
        if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} image generation response does not contain data entries.", provider);
            return Array.Empty<byte>();
        }
        var first = data[0];
        if (!first.TryGetProperty("b64_json", out var b64Property))
        {
            logger.LogError("{Provider} image data entry does not contain b64_json.", provider);
            return Array.Empty<byte>();
        }
        var base64 = b64Property.GetString();
        if (string.IsNullOrWhiteSpace(base64))
        {
            logger.LogError("{Provider} b64_json value is empty.", provider);
            return Array.Empty<byte>();
        }
        return Convert.FromBase64String(base64);
    }

    private static async Task<byte[]> ExtractAzureFoundryBytesAsync(
        JsonElement root, string provider, string? allowedOrigin,
        HttpClient httpClient, ILogger logger, CancellationToken cancellationToken)
    {
        if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} image generation response does not contain data entries.", provider);
            return Array.Empty<byte>();
        }
        var first = data[0];
        if (first.TryGetProperty("b64_json", out var b64Prop))
        {
            var b64 = b64Prop.GetString();
            if (!string.IsNullOrWhiteSpace(b64))
                return Convert.FromBase64String(b64);
        }
        if (!first.TryGetProperty("url", out var urlProp))
        {
            logger.LogError("{Provider} image data entry contains neither b64_json nor url.", provider);
            return Array.Empty<byte>();
        }
        var imageUrl = urlProp.GetString();
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            logger.LogError("{Provider} image url value is empty.", provider);
            return Array.Empty<byte>();
        }
        if (!string.IsNullOrWhiteSpace(allowedOrigin))
        {
            var uri = new Uri(imageUrl);
            var origin = uri.GetLeftPart(UriPartial.Authority);
            if (!string.Equals(origin, allowedOrigin, StringComparison.OrdinalIgnoreCase))
            {
                logger.LogWarning("{Provider} image URL has a different origin '{Origin}' than expected '{Expected}': {ImageUrl}.",
                    provider, origin, allowedOrigin, imageUrl);
                return Array.Empty<byte>();
            }
        }
        try { return await httpClient.GetByteArrayAsync(imageUrl, cancellationToken); }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "{Provider} failed to download image from fallback URL {ImageUrl}.", provider, imageUrl);
            return Array.Empty<byte>();
        }
    }

    private static async Task<byte[]> ExtractFalAiBytesAsync(
        JsonElement root, string provider,
        HttpClient httpClient, ILogger logger, CancellationToken cancellationToken)
    {
        if (!root.TryGetProperty("images", out var images) || images.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} image generation response does not contain images entries.", provider);
            return Array.Empty<byte>();
        }
        var first = images[0];
        if (!first.TryGetProperty("url", out var urlProp))
        {
            logger.LogError("{Provider} image entry does not contain url.", provider);
            return Array.Empty<byte>();
        }
        var imageUrl = urlProp.GetString();
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            logger.LogError("{Provider} image url is empty.", provider);
            return Array.Empty<byte>();
        }
        try { return await httpClient.GetByteArrayAsync(imageUrl, cancellationToken); }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "{Provider} failed to download generated image from URL {ImageUrl}.", provider, imageUrl);
            return Array.Empty<byte>();
        }
    }

    private static byte[] LogAndReturnEmpty(ILogger logger, string provider, string message)
    {
        logger.LogError("{Provider}: {Message}", provider, message);
        return Array.Empty<byte>();
    }
}
