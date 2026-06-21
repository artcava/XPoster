using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Options;

namespace XPoster.SenderPlugins
{
    /// <summary>
    /// Publishes image posts to Instagram using the Instagram Graph API (v20.0).
    /// Requires an image; text-only posts are not supported by the API and will return <c>false</c>.
    /// Credentials are resolved from <see cref="IgCredentials"/> bound via the Azure Key Vault Configuration Provider.
    /// </summary>
    public class IgSender : ISender
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IgSender> _logger;
        private readonly IgCredentials _creds;

        /// <summary>
        /// Initialises a new instance of <see cref="IgSender"/> using an <see cref="IHttpClientFactory"/>-provided
        /// client registered as "Instagram", which carries the Polly resilience pipeline.
        /// </summary>
        /// <param name="httpClientFactory">The factory used to create the named "Instagram" client.</param>
        /// <param name="credentials">Typed Instagram credentials resolved from configuration.</param>
        /// <param name="logger">The logger for diagnostic output.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
        public IgSender(IHttpClientFactory httpClientFactory, IOptions<IgCredentials> credentials, ILogger<IgSender> logger)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            ArgumentNullException.ThrowIfNull(credentials);
            _creds = credentials.Value;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClientFactory.CreateClient("Instagram");
        }

        /// <summary>Gets the maximum caption length allowed by Instagram (2200 characters).</summary>
        public int MessageMaxLenght => 2200;

        /// <summary>
        /// Publishes <paramref name="post"/> to Instagram via a two-step Graph API flow:
        /// create a media container, then publish it. Requires a non-null image.
        /// </summary>
        /// <param name="post">The post to publish. Must include a non-null <see cref="Post.Image"/>.</param>
        /// <returns><c>true</c> if the post was published successfully; <c>false</c> otherwise.</returns>
        public async Task<bool> SendAsync(Post post)
        {
            try
            {
                string caption = $"{post.Content}{Post.Firm}";
                if (caption.Length > MessageMaxLenght)
                {
                    _logger.LogWarning("Il messaggio supera il limite di {MaxLength} caratteri. Verrà troncato.", MessageMaxLenght);
                    caption = caption.Substring(0, MessageMaxLenght);
                }

                if (post.Image != null && post.Image.Length > 0)
                {
                    string imageUrl = await UploadImageToPublicUrl(post.Image);
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        _logger.LogError("Impossibile caricare l'immagine per Instagram.");
                        return false;
                    }

                    var mediaPayload = new
                    {
                        image_url = imageUrl,
                        caption = caption,
                        access_token = _creds.IgAccessToken
                    };
                    var mediaContent = new StringContent(JsonSerializer.Serialize(mediaPayload), Encoding.UTF8, "application/json");
                    var mediaResponse = await _httpClient.PostAsync(
                        $"https://graph.instagram.com/v20.0/{_creds.IgAccountId}/media", mediaContent);

                    if (!mediaResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError("Errore nella creazione del media: {Response}",
                            await mediaResponse.Content.ReadAsStringAsync());
                        return false;
                    }

                    var mediaData = JsonSerializer.Deserialize<JsonElement>(await mediaResponse.Content.ReadAsStringAsync());
                    string creationId = mediaData.GetProperty("id").GetString()
                        ?? throw new InvalidOperationException("id missing in Instagram media response.");

                    var publishPayload = new
                    {
                        creation_id = creationId,
                        access_token = _creds.IgAccessToken
                    };
                    var publishContent = new StringContent(JsonSerializer.Serialize(publishPayload), Encoding.UTF8, "application/json");
                    var publishResponse = await _httpClient.PostAsync(
                        $"https://graph.instagram.com/v20.0/{_creds.IgAccountId}/media_publish", publishContent);

                    if (!publishResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError("Errore nella pubblicazione: {Response}",
                            await publishResponse.Content.ReadAsStringAsync());
                        return false;
                    }

                    _logger.LogInformation("Post con immagine pubblicato su Instagram con successo.");
                    return true;
                }
                else
                {
                    _logger.LogWarning("Instagram richiede un'immagine per i post. Pubblicazione non eseguita.");
                    return false;
                }
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
        /// <returns>The public URL of the uploaded image.</returns>
        /// <exception cref="NotImplementedException">
        /// Always thrown — this method is a placeholder pending integration with a public storage service
        /// such as Azure Blob Storage.
        /// </exception>
        private Task<string> UploadImageToPublicUrl(byte[] image)
        {
            _logger.LogInformation("Caricamento immagine su URL pubblico (da implementare).");
            return Task.FromException<string>(new NotImplementedException("Caricamento immagine su URL pubblico non implementato."));
        }
    }
}
