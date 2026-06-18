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
    /// <param name="response">The <see cref="HttpResponseMessage"/> returned by the upstream API.</param>
    /// <param name="providerName">A human-readable provider label used in log messages (e.g. "OpenAI", "DeepSeek").</param>
    /// <param name="operationName">A human-readable operation label used in log messages (e.g. "summary generation").</param>
    /// <param name="logger">The <see cref="ILogger"/> to write structured diagnostics to.</param>
    /// <param name="cancellationToken">Propagates cancellation to the JSON deserialization step.</param>
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
    /// Parses an image generation HTTP response, applying the HTTP-level guard pipeline
    /// shared by all image provider implementations:
    /// HTTP 429 intercept, non-2xx guard, and JSON deserialisation failure.
    /// Schema-specific parsing (<c>data[0].b64_json</c>, <c>images[0].url</c>, etc.)
    /// remains the responsibility of the calling service.
    /// Returns <c>(true, JsonElement)</c> on success;
    /// <c>(false, null)</c> on any failure path.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> returned by the upstream API.</param>
    /// <param name="providerName">A human-readable provider label used in log messages (e.g. "OpenAI", "fal.ai").</param>
    /// <param name="logger">The <see cref="ILogger"/> to write structured diagnostics to.</param>
    /// <param name="cancellationToken">Propagates cancellation to the JSON deserialization step.</param>
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
}
