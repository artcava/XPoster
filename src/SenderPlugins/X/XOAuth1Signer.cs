using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using XPoster.Credentials;

namespace XPoster.SenderPlugins;

/// <summary>
/// Generates RFC 5849 OAuth 1.0a HMAC-SHA1 signatures for X (Twitter) API requests
/// using the single-user credentials in <see cref="XCredentials"/>.
/// </summary>
public static class XOAuth1Signer
{
    /// <summary>
    /// Builds the full <c>Authorization</c> header value for the given request.
    /// </summary>
    /// <param name="method">The HTTP method of the request.</param>
    /// <param name="uri">The full request URI. Query string parameters are included in the signature scope.</param>
    /// <param name="credentials">The OAuth 1.0a single-user credentials.</param>
    /// <param name="timestamp">Optional Unix epoch seconds override (used by tests for deterministic signatures).</param>
    /// <param name="nonce">Optional nonce override (used by tests for deterministic signatures).</param>
    /// <returns>The header value, always prefixed with <c>OAuth </c>.</returns>
    public static string BuildAuthorizationHeader(
        HttpMethod method,
        Uri uri,
        XCredentials credentials,
        long? timestamp = null,
        string? nonce = null)
    {
        var utcNowSeconds = timestamp ?? DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var token = nonce ?? Guid.NewGuid().ToString("N");

        var oauthParams = new Dictionary<string, string>
        {
            ["oauth_consumer_key"] = credentials.XApiKey,
            ["oauth_nonce"] = token,
            ["oauth_signature_method"] = "HMAC-SHA1",
            ["oauth_timestamp"] = utcNowSeconds.ToString(CultureInfo.InvariantCulture),
            ["oauth_token"] = credentials.XAccessToken,
            ["oauth_version"] = "1.0"
        };

        var baseParams = new Dictionary<string, string>(ParseQueryString(uri.Query), StringComparer.Ordinal);
        foreach (var pair in oauthParams)
        {
            baseParams[pair.Key] = pair.Value;
        }

        var signature = ComputeSignature(
            method.Method,
            uri,
            baseParams,
            credentials.XApiSecret,
            credentials.XAccessTokenSecret);

        oauthParams["oauth_signature"] = signature;

        var header = string.Join(", ", oauthParams.OrderBy(p => p.Key, StringComparer.Ordinal)
            .Select(p => $"{p.Key}=\"{p.Value}\""));

        return $"OAuth {header}";
    }

    /// <summary>
    /// Computes the OAuth 1.0a HMAC-SHA1 signature over the signature base string
    /// derived from <paramref name="uri"/> and <paramref name="parameters"/>.
    /// </summary>
    /// <returns>The signature as a Base64 string.</returns>
    public static string ComputeSignature(
        string httpMethod,
        Uri uri,
        IReadOnlyDictionary<string, string> parameters,
        string consumerSecret,
        string tokenSecret)
    {
        var baseString = ComputeSignatureBaseString(httpMethod, uri, parameters);
        var signingKey = $"{PercentEncode(consumerSecret)}&{PercentEncode(tokenSecret)}";

        using var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(signingKey));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(baseString));
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Builds the OAuth 1.0a signature base string per RFC 5849 §3.4.1.1.
    /// </summary>
    public static string ComputeSignatureBaseString(
        string httpMethod,
        Uri uri,
        IReadOnlyDictionary<string, string> parameters)
    {
        var normalized = parameters
            .Select(p => new
            {
                Key = PercentEncode(p.Key),
                Value = PercentEncode(p.Value)
            })
            .OrderBy(p => p.Key, StringComparer.Ordinal)
            .ThenBy(p => p.Value, StringComparer.Ordinal);

        var parameterString = string.Join("&", normalized.Select(p => $"{p.Key}={p.Value}"));

        var lowerMethod = httpMethod.ToUpperInvariant();
        return $"{lowerMethod}&{PercentEncode(GetBaseUri(uri))}&{PercentEncode(parameterString)}";
    }

    /// <summary>
    /// Percent-encodes a value per RFC 3986 (as required by RFC 5849 §3.6),
    /// leaving only unreserved characters as-is: ALPHA, DIGIT, '-', '.', '_', '~'.
    /// </summary>
    internal static string PercentEncode(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var builder = new StringBuilder(value.Length);
        foreach (var b in Encoding.UTF8.GetBytes(value))
        {
            if (b is (>= 0x30 and <= 0x39) or (>= 0x41 and <= 0x5A) or (>= 0x61 and <= 0x7A)
                or 0x2D or 0x2E or 0x5F or 0x7E)
            {
                builder.Append((char)b);
            }
            else
            {
                builder.Append('%').Append(b.ToString("X2"));
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Extracts the scheme://host[:port]/path portion of a URI, lower-casing the scheme
    /// and host and dropping the default port, per RFC 5849 §3.4.1.2.
    /// </summary>
    private static string GetBaseUri(Uri uri)
    {
        var scheme = uri.Scheme.ToLowerInvariant();
        var host = uri.Host.ToLowerInvariant();
        var defaultPort = string.Equals(uri.Scheme, "https", StringComparison.OrdinalIgnoreCase) ? 443 : 80;
        var authority = uri.Port == defaultPort || uri.Port == -1 ? host : $"{host}:{uri.Port}";

        return $"{scheme}://{authority}{uri.AbsolutePath}";
    }

    /// <summary>
    /// Parses a raw query string into a name/value dictionary using UTF-8 percent-decoding.
    /// </summary>
    private static Dictionary<string, string> ParseQueryString(string query)
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        if (string.IsNullOrEmpty(query))
        {
            return result;
        }

        foreach (var pair in query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = pair.Split('=', 2);
            var key = Uri.UnescapeDataString(parts[0]);
            var value = parts.Length == 2 ? Uri.UnescapeDataString(parts[1]) : string.Empty;
            result[key] = value;
        }

        return result;
    }
}