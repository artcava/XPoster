using System.Text.RegularExpressions;
using System.Web;

namespace XPoster.Services;

/// <summary>
/// Masks sensitive data (bearer tokens, API keys, access tokens) in HTTP response bodies
/// and request URLs before they are written to the log pipeline. The query-string masking
/// logic mirrors the approach used by <c>MaskUrlTelemetryProcessor</c> for dependency telemetry.
/// </summary>
public sealed class HttpResponseBodySanitizer
{
    private static readonly Regex BearerTokenPattern = new(
        @"Bearer\s+[A-Za-z0-9\-._~+/]+=*",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex ApiKeyPattern = new(
        @"(api[_-]?key)[""']?\s*[:=]\s*[""']?[A-Za-z0-9\-._~+/]{4,}",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex SensitiveTokenPattern = new(
        @"(access_token|refresh_token|client_secret|session_token|token)[""']?\s*[:=]\s*[""']?[A-Za-z0-9\-._~+/]{6,}",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly HashSet<string> SensitiveQueryKeys = new(StringComparer.OrdinalIgnoreCase)
    {
        "access_token", "refresh_token", "client_secret", "session_token", "api_key", "apikey", "token"
    };

    /// <summary>Replaces known secret patterns with placeholders.</summary>
    public string Sanitize(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var result = BearerTokenPattern.Replace(value, "Bearer ***");
        result = ApiKeyPattern.Replace(result, "$1=***");
        result = SensitiveTokenPattern.Replace(result, "$1=***");
        return result;
    }

    /// <summary>Masks sensitive query-string parameter values in a URL.</summary>
    public string SanitizeUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return url;
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)
            || string.IsNullOrEmpty(uri.Query))
        {
            return Sanitize(url);
        }

        var query = HttpUtility.ParseQueryString(uri.Query);
        foreach (var key in query.AllKeys)
        {
            if (key is not null && SensitiveQueryKeys.Contains(key))
            {
                query[key] = "***";
            }
        }

        var builder = new UriBuilder(uri) { Query = query.ToString() };
        return builder.Uri.ToString();
    }
}
