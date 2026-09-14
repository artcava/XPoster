using System.Diagnostics;
using System.Net.Http;

namespace XPoster.Services;

/// <summary>
/// A <see cref="DelegatingHandler" /> that buffers a bounded copy of every HTTP response body,
/// sanitizes/truncates it, and writes it through <see cref="HttpResponseBodyLogger" /> — without
/// disturbing the body handed back to the caller (the content is buffered, so it remains readable).
/// </summary>
/// <remarks>
/// Binary payloads and bodies larger than <see cref="MaxBodyBytes" /> are skipped: only the status,
/// URL, timing and headers are logged. A single request can opt out entirely by setting the
/// <see cref="LoggingOptOutHeader" /> request header. Logging failures never break the pipeline.
/// </remarks>
public sealed class HttpResponseBodyLoggingHandler : DelegatingHandler
{
    /// <summary>Request header that opts an individual request out of response-body logging.</summary>
    public const string LoggingOptOutHeader = "X-XPoster-Skip-ResponseLog";

    /// <summary>Safety cap on the number of response body bytes that will ever be buffered or logged.</summary>
    public const long MaxBodyBytes = 4096;

    private static readonly HashSet<string> ExactBinaryMediaTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "application/octet-stream",
        "application/zip",
        "application/gzip",
        "application/pdf",
        "application/x-7z-compressed",
        "application/vnd.rar"
    };

    private static readonly string[] BinaryTypePrefixes =
        ["image/", "video/", "audio/", "font/", "multipart/"];

    private readonly HttpResponseBodyLogger _bodyLogger;

    /// <summary>Creates a handler that logs response bodies through <paramref name="bodyLogger" />.</summary>
    public HttpResponseBodyLoggingHandler(HttpResponseBodyLogger bodyLogger)
    {
        _bodyLogger = bodyLogger;
    }

    /// <inheritdoc />
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var response = await base.SendAsync(request, cancellationToken);
        stopwatch.Stop();

        await TryLogAsync(request, response, stopwatch.Elapsed, cancellationToken);

        return response;
    }

    private async Task TryLogAsync(
        HttpRequestMessage request,
        HttpResponseMessage response,
        TimeSpan elapsed,
        CancellationToken cancellationToken)
    {
        try
        {
            if (response.Content is null
                || request.Headers.Contains(LoggingOptOutHeader)
                || !_bodyLogger.IsEnabledFor(response))
            {
                return;
            }

            var body = await ReadBodyAsync(response, cancellationToken);
            _bodyLogger.Log(response, body, elapsed);
        }
        catch
        {
            // Logging must never break the request pipeline.
        }
    }

    private static async Task<string?> ReadBodyAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (IsBinaryMediaType(response))
        {
            return null;
        }

        if (response.Content.Headers.ContentLength is long knownLength && knownLength > MaxBodyBytes)
        {
            return null;
        }

        try
        {
            await response.Content.LoadIntoBufferAsync(MaxBodyBytes, cancellationToken);
        }
        catch
        {
            // Body larger than the cap (unknown content length) or not bufferable.
            return null;
        }

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    private static bool IsBinaryMediaType(HttpResponseMessage response)
    {
        var mediaType = response.Content.Headers.ContentType?.MediaType;
        if (string.IsNullOrEmpty(mediaType))
        {
            return false;
        }

        if (ExactBinaryMediaTypes.Contains(mediaType))
        {
            return true;
        }

        foreach (var prefix in BinaryTypePrefixes)
        {
            if (mediaType.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
