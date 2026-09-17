using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Credentials;

namespace XPoster.SenderPlugins;

/// <summary>
/// HTTP client for the X (Twitter) APIs: the v2 tweets endpoint and the v1.1 chunked
/// media-upload endpoint. Every request is signed with OAuth 1.0a HMAC-SHA1 via
/// <see cref="XOAuth1Signer"/> and routed through the resilient <c>"X"</c> named client.
/// </summary>
public sealed class XApiClient
{
    /// <summary>Maximum byte size of a single media-upload APPEND segment (5 MB).</summary>
    public const int MediaSegmentMaxBytes = 5 * 1024 * 1024;

    private static readonly Uri TweetEndpoint = new("https://api.twitter.com/2/tweets");
    private static readonly Uri MediaEndpoint = new("https://upload.twitter.com/1.1/media/upload.json");

    private readonly HttpClient _httpClient;
    private readonly XCredentials _credentials;
    private readonly ILogger<XApiClient> _logger;

    /// <summary>
    /// Initialises a new instance using an <see cref="IHttpClientFactory"/>-provided
    /// client registered as <c>"X"</c>, which carries the Polly resilience pipeline.
    /// </summary>
    public XApiClient(IHttpClientFactory httpClientFactory, IOptions<XCredentials> credentials, ILogger<XApiClient> logger)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(credentials);
        _credentials = credentials.Value;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = httpClientFactory.CreateClient("X");
    }

    /// <summary>
    /// Publishes a new tweet with the given text, optionally attaching a previously
    /// uploaded media ID.
    /// </summary>
    /// <param name="text">The tweet text, including the firm footer.</param>
    /// <param name="mediaId">The media ID from <see cref="UploadMediaAsync"/>, or <c>null</c> for text-only tweets.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The ID of the created tweet.</returns>
    /// <exception cref="XApiException">Thrown when the API rejects the request.</exception>
    public async Task<string> CreateTweetAsync(string text, string? mediaId, CancellationToken ct)
    {
        var payload = mediaId is null
            ? JsonSerializer.Serialize(new { text })
            : JsonSerializer.Serialize(new { text, media = new { media_ids = new[] { mediaId } } });

        using var request = new HttpRequestMessage(HttpMethod.Post, TweetEndpoint)
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        SignRequest(request);

        using var response = await _httpClient.SendAsync(request, ct);
        var body = await response.Content.ReadAsStringAsync(ct);
        ThrowIfNotSuccess(response, body);

        using var document = JsonDocument.Parse(body);
        var data = document.RootElement.GetProperty("data");
        return data.GetProperty("id").GetString()
            ?? throw new XApiException(0, body, null);
    }

    /// <summary>
    /// Uploads an image using the v1.1 chunked media-upload flow: INIT → APPEND (per
    /// segment) → FINALIZE.
    /// </summary>
    /// <param name="media">The raw media bytes to upload.</param>
    /// <param name="mediaType">The media MIME type, e.g. <c>image/jpeg</c>.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The media ID string to attach to a tweet.</returns>
    /// <exception cref="XApiException">Thrown when any upload step is rejected.</exception>
    public async Task<string> UploadMediaAsync(byte[] media, string mediaType, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(media);
        if (media.Length == 0)
        {
            throw new ArgumentException("Media must not be empty.", nameof(media));
        }

        var mediaId = await InitializeMediaAsync(media.Length, mediaType, ct);
        await AppendMediaSegmentsAsync(media, mediaId, ct);
        await FinalizeMediaAsync(mediaId, ct);

        return mediaId;
    }

    /// <summary>
    /// Initialises an upload session and returns the assigned media ID.
    /// </summary>
    private async Task<string> InitializeMediaAsync(int totalBytes, string mediaType, CancellationToken ct)
    {
        var parameters = new Dictionary<string, string>
        {
            ["command"] = "INIT",
            ["media_type"] = mediaType,
            ["total_bytes"] = totalBytes.ToString(CultureInfo.InvariantCulture)
        };

        using var request = BuildSignedRequest(parameters);
        using var response = await _httpClient.SendAsync(request, ct);
        var body = await response.Content.ReadAsStringAsync(ct);
        ThrowIfNotSuccess(response, body);

        using var document = JsonDocument.Parse(body);
        var root = document.RootElement;

        if (root.TryGetProperty("media_id_string", out var mediaIdString) && !string.IsNullOrEmpty(mediaIdString.GetString()))
        {
            return mediaIdString.GetString()!;
        }

        return root.GetProperty("media_id").GetInt64().ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Uploads the media bytes in chunks of <see cref="MediaSegmentMaxBytes"/> or smaller.
    /// Each chunk is sent as a <c>media</c> part in a <c>multipart/form-data</c> body, as
    /// required by the v1.1 media-upload APPEND command.
    /// </summary>
    private async Task AppendMediaSegmentsAsync(byte[] media, string mediaId, CancellationToken ct)
    {
        var segmentCount = Math.Max(1, (int)Math.Ceiling(media.Length / (double)MediaSegmentMaxBytes));

        for (var segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
        {
            var offset = segmentIndex * MediaSegmentMaxBytes;
            var length = Math.Min(MediaSegmentMaxBytes, media.Length - offset);
            var chunk = media[offset..(offset + length)];

            var parameters = new Dictionary<string, string>
            {
                ["command"] = "APPEND",
                ["media_id"] = mediaId,
                ["segment_index"] = segmentIndex.ToString(CultureInfo.InvariantCulture)
            };

            using var request = BuildSignedRequest(parameters);
            var mediaPart = new ByteArrayContent(chunk)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/octet-stream") }
            };
            request.Content = new MultipartFormDataContent { { mediaPart, "media", "media" } };

            using var response = await _httpClient.SendAsync(request, ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            ThrowIfNotSuccess(response, body);
        }
    }

    /// <summary>
    /// Finalises the upload session started by <see cref="InitializeMediaAsync"/>.
    /// </summary>
    private async Task FinalizeMediaAsync(string mediaId, CancellationToken ct)
    {
        var parameters = new Dictionary<string, string>
        {
            ["command"] = "FINALIZE",
            ["media_id"] = mediaId
        };

        using var request = BuildSignedRequest(parameters);
        using var response = await _httpClient.SendAsync(request, ct);
        var body = await response.Content.ReadAsStringAsync(ct);
        ThrowIfNotSuccess(response, body);
    }

    /// <summary>
    /// Builds a POST request to the media endpoint with the given query parameters,
    /// signed with OAuth 1.0a (query parameters are part of the signature scope).
    /// </summary>
    private HttpRequestMessage BuildSignedRequest(IReadOnlyDictionary<string, string> parameters)
    {
        var query = string.Join("&", parameters.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));
        var uri = new Uri($"{MediaEndpoint}?{query}");
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        SignRequest(request);
        return request;
    }

    /// <summary>
    /// Attaches the OAuth 1.0a Authorization header for the given request.
    /// </summary>
    private void SignRequest(HttpRequestMessage request)
    {
        request.Headers.TryAddWithoutValidation(
            "Authorization",
            XOAuth1Signer.BuildAuthorizationHeader(request.Method, request.RequestUri!, _credentials));
    }

    /// <summary>
    /// Throws <see cref="XApiException"/> when the response is not a success or when the
    /// body carries an error payload.
    /// </summary>
    /// <remarks>
    /// The v1.1 media endpoint returns HTTP 200 together with an <c>errors</c> array for
    /// some failure modes, so an error payload is checked on successful status codes too.
    /// </remarks>
    private void ThrowIfNotSuccess(HttpResponseMessage response, string? body)
    {
        if (response.IsSuccessStatusCode && !HasErrorPayload(body))
        {
            return;
        }

        var errorInfo = XApiException.TryParseErrorBody(body);
        throw new XApiException((int)response.StatusCode, body, errorInfo);
    }

    /// <summary>
    /// Determines whether the body contains a v1.1 <c>errors</c> array.
    /// </summary>
    private static bool HasErrorPayload(string? body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return false;
        }

        try
        {
            using var document = JsonDocument.Parse(body);
            return document.RootElement.TryGetProperty("errors", out _);
        }
        catch (JsonException)
        {
            return false;
        }
    }
}