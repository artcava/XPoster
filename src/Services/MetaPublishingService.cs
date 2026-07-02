using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Credentials;

namespace XPoster.Services
{
    /// <summary>
    /// Implements <see cref="IMetaPublishingService"/> to interact with the Meta (Facebook/Instagram) Graph API for container status retrieval and publishing.
    /// </summary>
    public class MetaPublishingService : IMetaPublishingService
    {
        private readonly HttpClient _httpClient;
        private readonly InstagramCredentials _credentials;
        private readonly ILogger<MetaPublishingService> _logger;

        // Base graph host, e.g. https://graph.facebook.com
        private const string GraphBase = "https://graph.facebook.com";

        /// <summary>
        /// Initializes a new instance of <see cref="MetaPublishingService"/>.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="instagramCredentials">The Instagram credentials.</param>
        /// <param name="logger">The logger.</param>
        public MetaPublishingService(
            IHttpClientFactory httpClientFactory,
            IOptions<InstagramCredentials> instagramCredentials,
            ILogger<MetaPublishingService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("Instagram");
            _credentials = instagramCredentials?.Value ?? throw new ArgumentNullException(nameof(instagramCredentials));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Checks container status by calling GET /{creationId}?fields=status_code
        /// Returns the raw status_code string (e.g. "IN_PROGRESS","FINISHED","ERROR","EXPIRED").
        /// Throws HttpRequestException for non-success responses.
        /// </summary>
        public async Task<string> GetContainerStatusAsync(string creationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(creationId)) throw new ArgumentException("creationId is required", nameof(creationId));

            var uri = $"{GraphBase}/v{GetApiVersion()}/{creationId}?fields=status_code&access_token={Uri.EscapeDataString(_credentials.InstagramAccessToken)}";

            using var req = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage resp;
            try
            {
                resp = await _httpClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("GetContainerStatusAsync cancelled for creationId {CreationId}", creationId);
                throw;
            }

            if (resp.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Container {CreationId} not found (404).", creationId);
                throw new HttpRequestException($"Container {creationId} not found", null, resp.StatusCode);
            }

            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogError("GetContainerStatusAsync returned {StatusCode} for creationId {CreationId}", (int)resp.StatusCode, creationId);
                throw new HttpRequestException($"Unexpected response from Meta: {(int)resp.StatusCode}", null, resp.StatusCode);
            }

            var payload = await resp.Content.ReadFromJsonAsync<ContainerStatusResponse>(cancellationToken: cancellationToken).ConfigureAwait(false)
                          ?? throw new HttpRequestException("Empty response from Meta");

            // payload.status.code or status_code depending on API; map safely
            var status = payload.StatusCode ?? payload.Status?.Code ?? string.Empty;

            _logger.LogDebug("GetContainerStatusAsync for {CreationId} -> {Status}", creationId, status);

            return status;
        }

        /// <summary>
        /// Publishes the container by calling POST /{instagramAccountId}/media_publish?creation_id=...access_token=...
        /// Returns the publish response id (if any) or throws HttpRequestException on non-success.
        /// </summary>
        public async Task<string> PublishContainerAsync(string creationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(creationId)) throw new ArgumentException("creationId is required", nameof(creationId));

            var uri = $"{GraphBase}/v{GetApiVersion()}/{_credentials.InstagramAccountId}/media_publish?creation_id={Uri.EscapeDataString(creationId)}&access_token={Uri.EscapeDataString(_credentials.InstagramAccessToken)}";

            using var req = new HttpRequestMessage(HttpMethod.Post, uri);
            HttpResponseMessage resp;
            try
            {
                resp = await _httpClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("PublishContainerAsync cancelled for creationId {CreationId}", creationId);
                throw;
            }

            if (resp.StatusCode == (HttpStatusCode)429)
            {
                // Let caller's resilience/polly handle retries; log minimal info
                _logger.LogWarning("PublishContainerAsync received 429 for creationId {CreationId}", creationId);
                throw new HttpRequestException("Rate limited by Meta (429)", null, resp.StatusCode);
            }

            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogError("PublishContainerAsync returned {StatusCode} for creationId {CreationId}", (int)resp.StatusCode, creationId);
                throw new HttpRequestException($"Unexpected response from Meta: {(int)resp.StatusCode}", null, resp.StatusCode);
            }

            var payload = await resp.Content.ReadFromJsonAsync<PublishResponse>(cancellationToken: cancellationToken).ConfigureAwait(false)
                          ?? throw new HttpRequestException("Empty publish response from Meta");

            _logger.LogInformation("Published container {CreationId} -> publish id {PublishId}", creationId, payload.Id);

            return payload.Id ?? string.Empty;
        }

        private static string GetApiVersion()
        {
            // Centralise API version in one place; bump as needed.
            return "23.0";
        }

        // DTOs for deserialization. Keep minimal to avoid exposing raw response bodies in logs.
        private sealed class ContainerStatusResponse
        {
            public StatusField? Status { get; init; }
            public string? StatusCode { get; init; } // some versions use top-level status_code
        }

        private sealed class StatusField
        {
            public string? Code { get; init; }
            public string? Message { get; init; }
        }

        private sealed class PublishResponse
        {
            public string? Id { get; init; }
        }
    }
}