using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
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

                // Check if the image is a valid JPEG
                if (!IsJpeg(post.Image))
                {
                    _logger.LogWarning("L'immagine non è un JPEG valido. Pubblicazione non eseguita.");
                    return false;
                }

                string caption = $"{post.Content}{Post.Firm}";
                if (caption.Length > MessageMaxLenght)
                {
                    _logger.LogWarning("Il messaggio supera il limite di {MaxLength} caratteri. Verrà troncato.", MessageMaxLenght);
                    caption = caption.Substring(0, MessageMaxLenght);
                }

                var imageUrl = await UploadImageToPublicUrl(post.Image, ct);
                if (imageUrl is null)
                {
                    _logger.LogError("Impossibile caricare l'immagine per Instagram.");
                    return false;
                }

                string mediaUrl =
                    $"https://graph.instagram.com/v20.0/{_creds.InstagramAccountId}/media" +
                    $"?access_token={Uri.EscapeDataString(_creds.InstagramAccessToken)}";

                var mediaPayload = new
                {
                    image_url = imageUrl,
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

                var blobName = GetBlobNameFromSasUri(imageUrl);
                if (string.IsNullOrWhiteSpace(blobName))
                {
                    _logger.LogError("Impossibile determinare il nome del blob caricato.");
                    return false;
                }

                await _containerStateStore.SaveAsync(creationId, blobName, ct);
                _logger.LogInformation("Media container creato correttamente su Instagram.");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio a Instagram.");
                return false;
            }
        }

        /// <summary>
        /// Uploads the given image bytes to a publicly accessible URL so that the Instagram API
        /// can retrieve it during media container creation.
        /// </summary>
        /// <param name="image">The raw image bytes to upload.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns>The public URL of the uploaded image.</returns>
        /// <exception cref="NotImplementedException">
        /// Always thrown — this method is a placeholder pending integration with a public storage service
        /// such as Azure Blob Storage.
        /// </exception>
        private async Task<Uri?> UploadImageToPublicUrl(byte[] image, CancellationToken ct = default)
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

        /// <summary>
        /// Determines whether the provided image bytes represent a valid JPEG image by checking the magic number.
        /// </summary>
        /// <param name="image">The image bytes to check.</param>
        /// <returns>True if the image is a valid JPEG; otherwise, false.</returns>
        private static bool IsJpeg(byte[] image)
        {
            return image.Length >= 2 && image[0] == 0xFF && image[1] == 0xD8;
        }

        /// <summary>
        /// Extracts the blob name from the given URI.
        /// </summary>
        /// <param name="uri">The URI of the blob.</param>
        /// <returns>The name of the blob.</returns>
        private static string GetBlobNameFromSasUri(Uri uri)
        {
            var lastSegment = uri.Segments.Length > 0 ? uri.Segments[^1] : string.Empty;
            return lastSegment.Split('?', StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
