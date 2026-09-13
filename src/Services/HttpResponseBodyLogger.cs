using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Logging;

namespace XPoster.Services;

/// <summary>
/// Maps HTTP responses to structured log entries: <see cref="LogLevel.Debug" /> for 2xx responses
/// and <see cref="LogLevel.Error" /> for 4xx/5xx (the latter also including the relevant response
/// headers). Bodies are sanitized and truncated before being written.
/// </summary>
public sealed class HttpResponseBodyLogger
{
    /// <summary>Maximum number of body bytes written to the log.</summary>
    public const long MaxBodyBytes = 4096;

    private const string NoBody = "(no body)";
    private const string TruncatedSuffix = "… (truncated)";

    private static readonly HashSet<string> RelevantHeaderNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "Content-Type", "Content-Length", "Retry-After"
    };

    private readonly ILogger _logger;
    private readonly HttpResponseBodySanitizer _sanitizer;

    /// <summary>Creates a logger over <paramref name="logger" /> that sanitizes via <paramref name="sanitizer" />.</summary>
    public HttpResponseBodyLogger(
        ILogger<HttpResponseBodyLogger> logger,
        HttpResponseBodySanitizer sanitizer)
    {
        _logger = logger;
        _sanitizer = sanitizer;
    }

    /// <summary>Returns <c>true</c> when an entry would actually be emitted for <paramref name="response" />.</summary>
    public bool IsEnabledFor(HttpResponseMessage response) =>
        response.IsSuccessStatusCode
            ? _logger.IsEnabled(LogLevel.Debug)
            : _logger.IsEnabled(LogLevel.Error);

    /// <summary>Writes one structured log entry for <paramref name="response" />.</summary>
    public void Log(HttpResponseMessage response, string? body, TimeSpan elapsed)
    {
        var method = response.RequestMessage?.Method?.Method ?? "GET";
        var url = response.RequestMessage?.RequestUri?.ToString();
        var urlText = string.IsNullOrEmpty(url) ? "(unknown)" : _sanitizer.SanitizeUrl(url);
        var status = (int)response.StatusCode;
        var elapsedMs = (long)elapsed.TotalMilliseconds;

        if (response.IsSuccessStatusCode)
        {
            _logger.LogDebug(
                "HTTP {Method} {Url} returned status {StatusCode} in {ElapsedMs}ms. Body: {Body}",
                method, urlText, status, elapsedMs, SanitizeAndTruncate(body));
            return;
        }

        _logger.LogError(
            "HTTP {Method} {Url} failed with status {StatusCode} in {ElapsedMs}ms. Response headers: {Headers}. Body: {Body}",
            method, urlText, status, elapsedMs, FormatResponseHeaders(response), SanitizeAndTruncate(body));
    }

    private string SanitizeAndTruncate(string? body)
    {
        if (string.IsNullOrEmpty(body))
        {
            return NoBody;
        }

        var sanitized = _sanitizer.Sanitize(body);
        return TruncateUtf8(sanitized);
    }

    private static string TruncateUtf8(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        if (bytes.Length <= MaxBodyBytes)
        {
            return value;
        }

        var cut = (int)MaxBodyBytes;
        while (cut > 0 && (bytes[cut] & 0xC0) == 0x80)
        {
            cut--;
        }

        return Encoding.UTF8.GetString(bytes, 0, cut) + TruncatedSuffix;
    }

private static string FormatResponseHeaders(HttpResponseMessage response)
    {
        var selected = new List<string>();

        foreach (var header in response.Headers.Concat(response.Content.Headers))
        {
            if (RelevantHeaderNames.Contains(header.Key)
                || header.Key.StartsWith("X-RateLimit", StringComparison.OrdinalIgnoreCase))
            {
                selected.Add($"{header.Key}: {string.Join(", ", header.Value)}");
            }
        }

        return selected.Count == 0 ? "(none)" : string.Join(", ", selected);
    }
}
