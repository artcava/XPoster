using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Shared helper for parsing OpenAI-compatible HTTP responses.
/// Centralises guard pipelines used by every <see cref="IAiService"/> implementation.
/// </summary>
internal static class AiServiceHelper
{
    /// <summary>
    /// Parses an OpenAI-compatible chat completion HTTP response.
    /// Returns <c>(true, content)</c> on success;
    /// <c>(false, string.Empty)</c> on any failure path.
    /// Logs 429, non-2xx, and empty-choices cases via <paramref name="logger"/>.
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

        OpenAIResponse? result;
        try
        {
            result = await response.Content.ReadFromJsonAsync<OpenAIResponse>(cancellationToken);
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
    /// Legacy overload: parses HTTP guards and JSON only, returning the raw <see cref="JsonElement"/>.
    /// Schema-specific parsing remains the responsibility of the caller.
    /// Kept for backward compatibility; prefer the <see cref="AiProvider"/>-based overload for new callers.
    /// </summary>
    internal static async Task<(bool Success, JsonElement? Content)> ParseImageResponseAsync(
        HttpResponseMessage response,
        string providerName,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            logger.LogWarning("{Provider} returned 429 (TooManyRequests) during image generation.", providerName);
            return (false, null);
        }

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("{Provider} image generation failed with status code {StatusCode}.",
                providerName, response.StatusCode);
            return (false, null);
        }

        JsonElement result;
        try
        {
            result = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken);
        }
        catch (JsonException)
        {
            logger.LogError("{Provider} image generation returned malformed JSON.", providerName);
            return (false, null);
        }

        return (true, result);
    }

    /// <summary>
    /// Parses an image generation HTTP response end-to-end, applying the HTTP-level guard pipeline
    /// and provider-specific byte extraction determined by <paramref name="provider"/>.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> returned by the upstream API.</param>
    /// <param name="provider">The <see cref="AiProvider"/> that issued the request; drives extraction strategy.</param>
    /// <param name="httpClient">HTTP client used for downloading image bytes (fal.ai URL, AzureFoundry fallback URL).</param>
    /// <param name="logger">The <see cref="ILogger"/> to write structured diagnostics to.</param>
    /// <param name="allowedOrigin">Optional: expected origin for URL validation (used by AzureFoundry only).</param>
    /// <param name="cancellationToken">Propagates cancellation.</param>
    /// <returns>Decoded image bytes, or <see cref="Array.Empty{T}"/> on any failure.</returns>
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
            AiProvider.OpenAi        => ExtractOpenAiBytes(root, provider, logger),
            AiProvider.AzureFoundry  => await ExtractAzureFoundryBytesAsync(root, provider, allowedOrigin, httpClient, logger, cancellationToken),
            AiProvider.DeepSeekWithFal => await ExtractFalAiBytesAsync(root, provider, httpClient, logger, cancellationToken),
            _                        => LogAndReturnEmpty(logger, provider, "Image byte extraction is not supported for this provider.")
        };
    }

    // --- provider-specific extractors ---

    private static byte[] ExtractOpenAiBytes(JsonElement root, AiProvider provider, ILogger logger)
    {
        var label = provider.GetLabel();

        if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} image generation response does not contain data entries.", label);
            return Array.Empty<byte>();
        }

        var first = data[0];

        if (!first.TryGetProperty("b64_json", out var b64Property))
        {
            logger.LogError("{Provider} image data entry does not contain b64_json.", label);
            return Array.Empty<byte>();
        }

        var base64 = b64Property.GetString();
        if (string.IsNullOrWhiteSpace(base64))
        {
            logger.LogError("{Provider} image data entry contains an empty b64_json value.", label);
            return Array.Empty<byte>();
        }

        return Convert.FromBase64String(base64);
    }

    private static async Task<byte[]> ExtractAzureFoundryBytesAsync(
        JsonElement root,
        AiProvider provider,
        string? allowedOrigin,
        HttpClient httpClient,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        var label = provider.GetLabel();

        if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} image generation response does not contain data entries.", label);
            return Array.Empty<byte>();
        }

        var first = data[0];

        if (first.TryGetProperty("b64_json", out var b64Property))
        {
            var base64 = b64Property.GetString();
            if (string.IsNullOrWhiteSpace(base64))
            {
                logger.LogError("{Provider} image data entry contains an empty b64_json value.", label);
                return Array.Empty<byte>();
            }

            return Convert.FromBase64String(base64);
        }

        if (first.TryGetProperty("url", out var urlProperty))
        {
            var imageUrl = urlProperty.GetString();
            if (string.IsNullOrWhiteSpace(imageUrl))
                return Array.Empty<byte>();

            if (!string.IsNullOrWhiteSpace(allowedOrigin))
            {
                var imageOrigin = new Uri(imageUrl).GetLeftPart(UriPartial.Authority);
                if (!string.Equals(allowedOrigin, imageOrigin, StringComparison.OrdinalIgnoreCase))
                {
                    logger.LogWarning(
                        "{Provider} image generation returned a fallback URL from a different origin: {ImageUrl}. Expected origin: {ConfiguredOrigin}.",
                        label, imageUrl, allowedOrigin);
                }
            }

            try
            {
                return await httpClient.GetByteArrayAsync(imageUrl, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, "{Provider} failed to download image from fallback URL: {Url}", label, imageUrl);
                return Array.Empty<byte>();
            }
        }

        logger.LogError("{Provider} image data entry does not contain b64_json or url.", label);
        return Array.Empty<byte>();
    }

    private static async Task<byte[]> ExtractFalAiBytesAsync(
        JsonElement root,
        AiProvider provider,
        HttpClient httpClient,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        var label = provider.GetLabel();

        if (!root.TryGetProperty("images", out var images) || images.GetArrayLength() == 0)
        {
            logger.LogError("{Provider} response does not contain any images.", label);
            return Array.Empty<byte>();
        }

        var firstImage = images[0];

        if (!firstImage.TryGetProperty("url", out var urlProperty))
        {
            logger.LogError("{Provider} image entry does not contain a URL.", label);
            return Array.Empty<byte>();
        }

        var imageUrl = urlProperty.GetString();
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            logger.LogError("{Provider} returned an empty image URL.", label);
            return Array.Empty<byte>();
        }

        logger.LogInformation("Downloading generated image from {ImageUrl}", imageUrl);

        try
        {
            return await httpClient.GetByteArrayAsync(imageUrl, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "{Provider} failed to download generated image from URL: {Url}", label, imageUrl);
            return Array.Empty<byte>();
        }
    }

    // --- utilities ---

    private static byte[] LogAndReturnEmpty(ILogger logger, AiProvider provider, string reason)
    {
        logger.LogError("{Provider} image byte extraction skipped: {Reason}", provider.GetLabel(), reason);
        return Array.Empty<byte>();
    }
}
