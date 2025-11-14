using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.SenderPlugins
{
    public class IgSender : ISender
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IgSender> _logger;
        private readonly string _accessToken;
        private readonly string _instagramAccountId;

        public IgSender(ILogger<IgSender> logger)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _accessToken = Environment.GetEnvironmentVariable("IG_ACCESS_TOKEN");
            _instagramAccountId = Environment.GetEnvironmentVariable("IG_ACCOUNT_ID");

            if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instagramAccountId))
            {
                throw new InvalidOperationException("InstagramAccessToken o InstagramAccountId non configurati.");
            }
        }

        public int MessageMaxLenght => 2200; // Limite di Instagram per le didascalie

        public async Task<bool> SendAsync(Post post)
        {
            try
            {
                string caption = $"{post.Content}{post.Firm}";
                if (caption.Length > MessageMaxLenght)
                {
                    _logger.LogWarning($"Il messaggio supera il limite di {MessageMaxLenght} caratteri. Verrà troncato.");
                    caption = caption.Substring(0, MessageMaxLenght);
                }

                if (post.Image != null && post.Image.Length > 0)
                {
                    // Step 1: Carica l'immagine su un URL pubblico (es. Azure Blob Storage)
                    string imageUrl = await UploadImageToPublicUrl(post.Image);
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        _logger.LogError("Impossibile caricare l'immagine per Instagram.");
                        return false;
                    }

                    // Step 2: Crea un media object
                    var mediaPayload = new
                    {
                        image_url = imageUrl,
                        caption = caption,
                        access_token = _accessToken
                    };
                    var mediaContent = new StringContent(JsonSerializer.Serialize(mediaPayload), Encoding.UTF8, "application/json");
                    var mediaResponse = await _httpClient.PostAsync($"https://graph.instagram.com/v20.0/{_instagramAccountId}/media", mediaContent);

                    if (!mediaResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Errore nella creazione del media: {await mediaResponse.Content.ReadAsStringAsync()}");
                        return false;
                    }

                    var mediaData = JsonSerializer.Deserialize<dynamic>(await mediaResponse.Content.ReadAsStringAsync());
                    string creationId = mediaData.GetProperty("id").GetString();

                    // Step 3: Pubblica il media
                    var publishPayload = new
                    {
                        creation_id = creationId,
                        access_token = _accessToken
                    };
                    var publishContent = new StringContent(JsonSerializer.Serialize(publishPayload), Encoding.UTF8, "application/json");
                    var publishResponse = await _httpClient.PostAsync($"https://graph.instagram.com/v20.0/{_instagramAccountId}/media_publish", publishContent);

                    if (!publishResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Errore nella pubblicazione: {await publishResponse.Content.ReadAsStringAsync()}");
                        return false;
                    }

                    _logger.LogInformation("Post con immagine pubblicato su Instagram con successo.");
                    return true;
                }
                else
                {
                    _logger.LogWarning("Instagram richiede un'immagine per i post. Pubblicazione non eseguita.");
                    return false; // Instagram non supporta post solo testo tramite API
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio a Instagram.");
                return false;
            }
        }

        private async Task<string> UploadImageToPublicUrl(byte[] image)
        {
            // TODO: Implementa il caricamento su un servizio pubblico (es. Azure Blob Storage)
            // Questo è un placeholder: dovrai sostituirlo con la tua logica reale
            _logger.LogInformation("Caricamento immagine su URL pubblico (da implementare).");
            throw new NotImplementedException("Caricamento immagine su URL pubblico non implementato.");
            // Esempio con Azure Blob Storage:
            // var blobClient = new BlobClient(connectionString, containerName, "image.jpg");
            // using var stream = new MemoryStream(image);
            // await blobClient.UploadAsync(stream);
            // return blobClient.Uri.ToString();
        }
    }
}