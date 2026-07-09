using System.Text.Json;
using Microsoft.Extensions.Options;
using SkiaSharp;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;

namespace XPoster.SenderPlugins
{
    /// <summary>
    /// Publishes image posts to Facebook using the Facebook Graph API (v20.0).
    /// Requires an image; text-only posts are not supported by the API and will return <c>false</c>.
    /// Credentials are resolved from <see cref="FacebookCredentials"/> bound via the Azure Key Vault Configuration Provider.
    /// </summary>
    public class FbSender : ISender
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FbSender> _logger;
        private readonly FacebookCredentials _creds;
        private readonly IBlobStorageService _blobStorageService;

        /// <summary>
        /// Initialises a new instance of <see cref="FbSender"/> using an <see cref="IHttpClientFactory"/>-provided
        /// client registered as "Facebook", which carries the Polly resilience pipeline.
        /// </summary>
        /// <param name="httpClientFactory">The factory used to create the named "Facebook" client.</param>
        /// <param name="credentials">Typed Facebook credentials resolved from configuration.</param>
        /// <param name="logger">The logger for diagnostic output.</param>
        /// <param name="blobStorageService">The blob storage service for uploading images.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
        public FbSender(
            IHttpClientFactory httpClientFactory,
            IOptions<FacebookCredentials> credentials,
            ILogger<FbSender> logger,
            IBlobStorageService blobStorageService)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            ArgumentNullException.ThrowIfNull(credentials);
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(blobStorageService);

            _creds = credentials.Value;
            _logger = logger;
            _blobStorageService = blobStorageService;
            _httpClient = httpClientFactory.CreateClient("Facebook");
        }

        /// <inheritdoc/>
        public SenderPlatform Platform => SenderPlatform.Facebook;

        /// <summary>Gets the maximum caption length allowed by Facebook (3000 characters).</summary>
        public int MessageMaxLenght => 3000;

        /// <summary>
        /// Publishes <paramref name="post"/> to Facebook via a two-step Graph API flow:
        /// create a media container, then publish it. Requires a non-null image.
        /// </summary>
        /// <param name="post">The post to publish. Must include a non-null <see cref="Post.Image"/>.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the post was published successfully; <c>false</c> otherwise.</returns>
        public async Task<bool> SendAsync(Post post, CancellationToken ct = default)
        {
            try
            {
                // Guard clauses for null Post
                if (post is null)
                {
                    _logger.LogWarning("[FbSender] Received null post — skipping.");
                    return false;
                }

                // Guard clause for length of caption
                string caption = $"{post.Content}{Post.Firm}";
                if (caption.Length > MessageMaxLenght)
                {
                    _logger.LogWarning("[FbSender] Caption exceeds {MaxLength} characters and will be truncated.", MessageMaxLenght);
                    caption = caption[..MessageMaxLenght];
                }

                // Guard clause for null or empty image
                if (post.Image is null || post.Image.Length == 0)
                {
                    return await PublishTextOnlyAsync(caption, ct);
                }

                // Normalize the image for Facebook (JPEG, PNG, GIF, WebP, HEIF). Unsupported formats will return null.
                var normalizedImage = NormalizeImageForFacebook(post.Image);
                if (normalizedImage is null || normalizedImage.Length == 0)
                {
                    _logger.LogWarning("[FbSender] Image normalization failed. Falling back to text-only publish.");
                    return await PublishTextOnlyAsync(caption, ct);
                }

                BlobUploadResult? uploadResult = null;

                try
                {   
                    // Upload the normalized image to Azure Blob Storage to obtain a public SAS URL
                    uploadResult = await _blobStorageService.UploadAsync(normalizedImage, "image/jpeg", ct);

                    // Publish the photo post to Facebook using the SAS URL
                    return await PublishPhotoAsync(caption, uploadResult.SasUri.AbsoluteUri, ct);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "[FbSender] Image publish flow failed. Falling back to text-only publish.");
                    return await PublishTextOnlyAsync(caption, ct);
                }
                finally
                {
                    if (!string.IsNullOrWhiteSpace(uploadResult?.BlobName))
                    {
                        try
                        {
                            await _blobStorageService.DeleteAsync(uploadResult.BlobName, ct);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning(ex, "[FbSender] Failed to delete blob {BlobName} after Facebook publish flow.", uploadResult.BlobName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[FbSender] Error while sending post to Facebook.");
                return false;
            }
        }

        /// <summary>
        /// Normalizes the given image bytes for Facebook by checking the format and converting to JPEG if necessary.
        /// Supported formats: JPEG, PNG, GIF, WebP, HEIF. Unsupported formats will return <c>null</c>.
        /// </summary>
        /// <param name="imageBytes">The image bytes to normalize.</param>
        /// <returns>The normalized image bytes or <c>null</c> if the format is unsupported.</returns>
        private byte[]? NormalizeImageForFacebook(byte[] imageBytes)
        {
            try
            {
                using var codec = SKCodec.Create(new SKMemoryStream(imageBytes));
                if (codec is null)
                {
                    _logger.LogWarning("[FbSender] Unable to detect image format.");
                    return null;
                }

                _logger.LogInformation(
                    "[FbSender] Detected image format for Facebook: {EncodedFormat}",
                    codec.EncodedFormat);

                return codec.EncodedFormat switch
                {
                    SKEncodedImageFormat.Jpeg => imageBytes,
                    SKEncodedImageFormat.Png => imageBytes,
                    SKEncodedImageFormat.Gif => imageBytes,
                    SKEncodedImageFormat.Webp => imageBytes,
                    SKEncodedImageFormat.Heif => imageBytes,
                    SKEncodedImageFormat.Bmp => null,
                    SKEncodedImageFormat.Wbmp => null,
                    SKEncodedImageFormat.Ico => null,
                    SKEncodedImageFormat.Ktx => null,
                    SKEncodedImageFormat.Pkm => null,
                    SKEncodedImageFormat.Dng => null,
                    SKEncodedImageFormat.Astc => null,
                    _ => TryConvertToJpeg(imageBytes)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[FbSender] Error while validating Facebook image format.");
                return null;
            }
        }

        /// <summary>
        /// Attempts to convert the given image bytes to JPEG format using SkiaSharp. If the image is already in JPEG format, it returns the original bytes. If the conversion fails, it returns <c>null</c>.
        /// </summary>
        /// <param name="imageBytes">The image bytes to convert.</param>
        /// <returns>The converted image bytes in JPEG format or <c>null</c> if the conversion fails.</returns>
        private byte[]? TryConvertToJpeg(byte[] imageBytes)
        {
            try
            {
                using var bitmap = SKBitmap.Decode(imageBytes);
                if (bitmap is null)
                {
                    _logger.LogWarning("[FbSender] Image decode failed during JPEG conversion.");
                    return null;
                }

                using var image = SKImage.FromBitmap(bitmap);
                using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);

                return data?.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[FbSender] Error while converting image to JPEG for Facebook.");
                return null;
            }
        }

        /// <summary>
        /// Publishes a text-only post to Facebook.
        /// </summary>
        /// <param name="message">The message to publish.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the post was published successfully; otherwise, <c>false</c>.</returns>
        private async Task<bool> PublishTextOnlyAsync(string message, CancellationToken ct)
        {
            string url =
                $"https://graph.facebook.com/v23.0/{_creds.FacebookPageId}/feed" +
                $"?message={Uri.EscapeDataString(message)}" +
                $"&access_token={Uri.EscapeDataString(_creds.FacebookAccessToken)}";

            using var response = await _httpClient.PostAsync(url, content: null, ct);
            return await HandleResponseAsync(response, "feed", ct);
        }

        /// <summary>
        /// Publishes a photo post to Facebook.
        /// </summary>
        /// <param name="caption">The caption for the photo.</param>
        /// <param name="publicImageUrl">The public URL of the image to publish.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the post was published successfully; otherwise, <c>false</c>.</returns>
        private async Task<bool> PublishPhotoAsync(string caption, string publicImageUrl, CancellationToken ct)
        {
            string url =
                $"https://graph.facebook.com/v23.0/{_creds.FacebookPageId}/photos" +
                $"?caption={Uri.EscapeDataString(caption)}" +
                $"&url={Uri.EscapeDataString(publicImageUrl)}" +
                $"&access_token={Uri.EscapeDataString(_creds.FacebookAccessToken)}";

            using var response = await _httpClient.PostAsync(url, content: null, ct);
            return await HandleResponseAsync(response, "photos", ct);
        }

        /// <summary>
        /// Handles the response from a Facebook API call.
        /// </summary>
        /// <param name="response">The HTTP response message.</param>
        /// <param name="endpoint">The Facebook API endpoint.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the API call was successful; otherwise, <c>false</c>.</returns>
        private async Task<bool> HandleResponseAsync(
            HttpResponseMessage response,
            string endpoint,
            CancellationToken ct)
        {
            if (!response.IsSuccessStatusCode)
            {
                string? retryAfter = response.Headers.RetryAfter?.Delta?.TotalSeconds.ToString();

                _logger.LogError(
                    "[FbSender] Facebook API call to /{Endpoint} failed with status code {StatusCode}. RetryAfterSeconds: {RetryAfterSeconds}",
                    endpoint,
                    (int)response.StatusCode,
                    retryAfter ?? "n/a");

                return false;
            }

            var json = await response.Content.ReadAsStringAsync(ct);
            using var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty("id", out var idProperty))
            {
                _logger.LogError("[FbSender] Facebook API response for /{Endpoint} did not contain an id.", endpoint);
                return false;
            }

            var postId = idProperty.GetString();
            if (string.IsNullOrWhiteSpace(postId))
            {
                _logger.LogError("[FbSender] Facebook API response for /{Endpoint} contained an empty id.", endpoint);
                return false;
            }

            _logger.LogInformation(
                "[FbSender] Facebook publish completed successfully via /{Endpoint}. PostId: {PostId}",
                endpoint,
                postId);

            return true;
        }

    }
}
