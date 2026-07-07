using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SkiaSharp;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;

namespace XPoster.SenderPlugins
{
    /// <summary>
    /// Publishes image posts to Instagram using the Instagram Graph API (v20.0).
    /// Requires an image; text-only posts are not supported by the API and will return <c>false</c>.
    /// Credentials are resolved from <see cref="InstagramCredentials"/> bound via the Azure Key Vault Configuration Provider.
    /// </summary>
    public class IgSender : ISender
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IgSender> _logger;
        private readonly InstagramCredentials _creds;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IContainerStateStore _containerStateStore;


        /// <summary>
        /// Initialises a new instance of <see cref="IgSender"/> using an <see cref="IHttpClientFactory"/>-provided
        /// client registered as "Instagram", which carries the Polly resilience pipeline.
        /// </summary>
        /// <param name="httpClientFactory">The factory used to create the named "Instagram" client.</param>
        /// <param name="credentials">Typed Instagram credentials resolved from configuration.</param>
        /// <param name="logger">The logger for diagnostic output.</param>
        /// <param name="blobStorageService">The blob storage service for uploading images.</param>
        /// <param name="containerStateStore">The container state store for managing container states.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
        public IgSender(
            IHttpClientFactory httpClientFactory, 
            IOptions<InstagramCredentials> credentials, 
            ILogger<IgSender> logger, 
            IBlobStorageService blobStorageService, 
            IContainerStateStore containerStateStore)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            ArgumentNullException.ThrowIfNull(credentials);
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(blobStorageService);
            ArgumentNullException.ThrowIfNull(containerStateStore);

            _creds = credentials.Value;
            _logger = logger;
            _blobStorageService = blobStorageService;
            _containerStateStore = containerStateStore;
            _httpClient = httpClientFactory.CreateClient("Instagram");
        }

        /// <inheritdoc/>
        public SenderPlatform Platform => SenderPlatform.Instagram;

        /// <summary>Gets the maximum caption length allowed by Instagram (2200 characters).</summary>
        public int MessageMaxLenght => 2200;

        /// <summary>
        /// Publishes <paramref name="post"/> to Instagram via a two-step Graph API flow:
        /// create a media container, then publish it. Requires a non-null image.
        /// </summary>
        /// <param name="post">The post to publish. Must include a non-null <see cref="Post.Image"/>.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the post was published successfully; <c>false</c> otherwise.</returns>
        public async Task<bool> SendAsync(Post post, CancellationToken ct = default)
        {
            try
            {
                // Guard clauses for null or invalid image
                if (post.Image is null || post.Image.Length == 0)
                {
                    _logger.LogWarning("Instagram richiede un'immagine per i post. Pubblicazione non eseguita.");
                    return false;
                }

                var normalizedImage = NormalizeImageForInstagram(post.Image);
                if (normalizedImage is null || normalizedImage.Length == 0)
                {
                    _logger.LogWarning("Immagine non supportata o conversione a JPEG fallita. Pubblicazione non eseguita.");
                    return false;
                }

                string caption = $"{post.Content}{Post.Firm}";
                if (caption.Length > MessageMaxLenght)
                {
                    _logger.LogWarning("Il messaggio supera il limite di {MaxLength} caratteri. Verrà troncato.", MessageMaxLenght);
                    caption = caption.Substring(0, MessageMaxLenght);
                }

                var uploadResult = await UploadImageToPublicUrl(post.Image, ct);
                if (uploadResult is null)
                {
                    _logger.LogError("Impossibile caricare l'immagine per Instagram.");
                    return false;
                }

                string mediaUrl =
                    $"https://graph.instagram.com/v20.0/{_creds.InstagramAccountId}/media" +
                    $"?access_token={Uri.EscapeDataString(_creds.InstagramAccessToken)}";

                var mediaPayload = new
                {
                    image_url = uploadResult.SasUri,
                    caption
                };

                using var mediaContent = new StringContent(
                    JsonSerializer.Serialize(mediaPayload), 
                    Encoding.UTF8, 
                    "application/json");

                using var mediaResponse = await _httpClient.PostAsync(mediaUrl, mediaContent, ct);

                if (!mediaResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Errore nella creazione del media su Instagram. StatusCode: {StatusCode}", mediaResponse.StatusCode);
                    return false;
                }

                var mediaJson = await mediaResponse.Content.ReadAsStringAsync(ct);
                using var mediaDocument = JsonDocument.Parse(mediaJson);

                if (!mediaDocument.RootElement.TryGetProperty("id", out var idProperty))
                {
                    _logger.LogError("Risposta Instagram non valida: missing id.");
                    return false;
                }

                var creationId = idProperty.GetString();
                if (string.IsNullOrWhiteSpace(creationId))
                {
                    _logger.LogError("Risposta Instagram non valida: empty id.");
                    return false;
                }

                await _containerStateStore.SaveAsync(creationId, uploadResult.BlobName, ct);
                _logger.LogInformation("Media container creato correttamente su Instagram.");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio a Instagram.");
                return false;
            }
        }

        private byte[]? NormalizeImageForInstagram(byte[] imageBytes)
        {
            try
            {
                using var codec = SKCodec.Create(new SKMemoryStream(imageBytes));
                if (codec is null)
                {
                    _logger.LogWarning("Formato immagine non rilevabile.");
                    return null;
                }

                _logger.LogInformation(
                    "Formato immagine rilevato per Instagram: {EncodedFormat}",
                    codec.EncodedFormat);

                if (codec.EncodedFormat == SKEncodedImageFormat.Jpeg)
                {
                    return imageBytes;
                }

                if (codec.EncodedFormat != SKEncodedImageFormat.Png)
                {
                    _logger.LogWarning(
                        "Formato immagine non supportato per Instagram: {EncodedFormat}",
                        codec.EncodedFormat);
                    return null;
                }

                using var bitmap = SKBitmap.Decode(imageBytes);
                if (bitmap is null)
                {
                    _logger.LogWarning("Decodifica PNG fallita.");
                    return null;
                }

                using var image = SKImage.FromBitmap(bitmap);
                using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);

                return data?.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la conversione dell'immagine in JPEG per Instagram.");
                return null;
            }
        }

        /// <summary>
        /// Uploads the given image bytes to Azure Blob Storage and returns the upload result
        /// containing the public SAS URI and the blob name.
        /// </summary>
        /// <param name="image">The raw image bytes to upload.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns>The <see cref="BlobUploadResult"/> or <c>null</c> on failure.</returns>
        private async Task<BlobUploadResult?> UploadImageToPublicUrl(byte[] image, CancellationToken ct = default)
        {
            try
            {
                return await _blobStorageService.UploadAsync(image, "image/jpeg", ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il caricamento dell'immagine su Blob Storage.");
                return null;
            }
        }
    }
}
