using System.Text.Json;

namespace XPoster.SenderPlugins;

/// <summary>
/// Represents an error response returned by the X (Twitter) API.
/// Carries the HTTP status code, the parsed problem details, and the raw response body
/// so that senders can produce operationally actionable log entries.
/// </summary>
public sealed class XApiException : Exception
{
    /// <summary>Gets the HTTP status code returned by the API.</summary>
    public int StatusCode { get; }

    /// <summary>Gets the parsed problem details, or <c>null</c> when the body could not be parsed.</summary>
    public XErrorInfo? ErrorInfo { get; }

    /// <summary>Gets the raw response body (when available) for full diagnostic context.</summary>
    public string? ResponseBody { get; }

    /// <summary>
    /// Initialises a new instance with the given status code and parsed problem details.
    /// </summary>
    public XApiException(int statusCode, string? responseBody, XErrorInfo? errorInfo)
        : base(BuildMessage(statusCode, errorInfo))
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
        ErrorInfo = errorInfo;
    }

    private static string BuildMessage(int statusCode, XErrorInfo? errorInfo)
    {
        if (errorInfo is null)
        {
            return $"X API HTTP {statusCode}";
        }

        var parts = new List<string> { $"X API HTTP {statusCode}" };
        if (!string.IsNullOrWhiteSpace(errorInfo.Title))
        {
            parts.Add(errorInfo.Title);
        }

        if (!string.IsNullOrWhiteSpace(errorInfo.Detail))
        {
            parts.Add(errorInfo.Detail);
        }

        if (errorInfo.Errors is { Count: > 0 })
        {
            var messages = errorInfo.Errors
                .Where(e => !string.IsNullOrWhiteSpace(e.Message))
                .Select(e => e.Message);
            parts.Add(string.Join("; ", messages));
        }

        return string.Join(" — ", parts);
    }

    /// <summary>
    /// Attempts to parse an X error payload. Supports both the v2 problem details shape
    /// (<c>title</c>/<c>detail</c>/<c>type</c>/<c>label</c>) and the v1.1 shape
    /// (<c>errors[]</c> with <c>code</c>/<c>message</c>/<c>label</c>).
    /// </summary>
    internal static XErrorInfo? TryParseErrorBody(string? body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return null;
        }

        try
        {
            using var document = JsonDocument.Parse(body);
            var root = document.RootElement;

            var title = root.TryGetProperty("title", out var titleElement) ? titleElement.GetString() : null;
            var detail = root.TryGetProperty("detail", out var detailElement) ? detailElement.GetString() : null;
            var type = root.TryGetProperty("type", out var typeElement) ? typeElement.GetString() : null;
            var label = root.TryGetProperty("label", out var labelElement) ? labelElement.GetString() : null;

            var errors = new List<XErrorDetail>();
            if (root.TryGetProperty("errors", out var errorsElement) && errorsElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var errorElement in errorsElement.EnumerateArray())
                {
                    errors.Add(new XErrorDetail
                    {
                        Code = errorElement.TryGetProperty("code", out var codeElement) && codeElement.TryGetInt32(out var code)
                            ? code
                            : null,
                        Message = errorElement.TryGetProperty("message", out var messageElement) ? messageElement.GetString() : null,
                        Label = errorElement.TryGetProperty("label", out var errorLabelElement) ? errorLabelElement.GetString() : null
                    });
                }
            }

            if (title is not null || label is not null || errors.Count > 0)
            {
                return new XErrorInfo
                {
                    Title = title,
                    Detail = detail,
                    Type = type,
                    Label = label,
                    Errors = errors.Count > 0 ? errors : null
                };
            }

            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }
}

/// <summary>
/// Parsed problem details from an X API error response.
/// </summary>
public sealed class XErrorInfo
{
    /// <summary>Gets the short problem title (v2 shape).</summary>
    public string? Title { get; init; }

    /// <summary>Gets the human-readable problem detail (v2 shape).</summary>
    public string? Detail { get; init; }

    /// <summary>Gets the problem type URI (v2 shape).</summary>
    public string? Type { get; init; }

    /// <summary>Gets the problem label, e.g. <c>usage_cap_exceeded</c> (v2 shape).</summary>
    public string? Label { get; init; }

    /// <summary>Gets the detailed error entries (v1.1 shape), or <c>null</c> when absent.</summary>
    public IReadOnlyList<XErrorDetail>? Errors { get; init; }
}

/// <summary>
/// A single error entry from an X API <c>errors[]</c> array (v1.1 shape).
/// </summary>
public sealed class XErrorDetail
{
    /// <summary>Gets the X error code.</summary>
    public int? Code { get; init; }

    /// <summary>Gets the error message.</summary>
    public string? Message { get; init; }

    /// <summary>Gets the error label (v2 shape extension).</summary>
    public string? Label { get; init; }
}