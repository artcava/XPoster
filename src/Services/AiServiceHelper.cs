using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Shared helper for parsing OpenAI-compatible chat completion HTTP responses.
/// Centralises the five-step guard pipeline used by every <see cref="IAiService"/> text implementation:
/// HTTP 429 intercept, non-2xx guard, JSON deserialisation, null/empty choices guard, content trim.
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
}
