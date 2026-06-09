// src/Services/DeepSeekAiService.cs
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenAI;
using System.ClientModel;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implementazione di IAiService usando DeepSeek API.
/// </summary>
public class DeepSeekService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<DeepSeekService> _logger;
    private readonly DeepSeekOptions _options;

    /// <summary>
    /// Initialises a new instance of <see cref="DeepSeekService"/> with configuration and logger.
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    public DeepSeekService(
        IHttpClientFactory httpClientFactory,
        IOptions<DeepSeekOptions> options,
        ILogger<DeepSeekService> logger)
    {
        _logger = logger;
        _options = options.Value;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("api-key", _options.ApiKey);
    }

    /// <summary>
    /// Genera un riassunto del testo.
    /// </summary>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength)
    {
        int tries = 0;

        while (text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildSummaryPayload(text, messageMaxLength));
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.LogInformation("DeepSeek returned 429 during summary generation.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("DeepSeek summary request failed with status code {StatusCode}", response.StatusCode);
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            text = result?.choices[0].message.content.Trim() ?? string.Empty;
        }

        return text;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text)
    {
        var response = await _client.PostAsJsonAsync(GetChatCompletionsEndpoint(), BuildImagePromptPayload(text));
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogInformation("DeepSeek returned 429 during image prompt generation.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("DeepSeek image prompt request failed with status code {StatusCode}", response.StatusCode);
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.choices[0].message.content.Trim() ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        var requestBody = new
        {
            prompt,
            n = 1,
            size = "1024x1024",
            response_format = "b64_json"
        };

        var response = await _client.PostAsJsonAsync(GetImageGenerationEndpoint(), requestBody);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("DeepSeek image generation failed with status code {StatusCode}", response.StatusCode);
            return Array.Empty<byte>();
        }

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        if (!result.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
        {
            _logger.LogError("DeepSeek image generation response does not contain data entries.");
            return Array.Empty<byte>();
        }

        var first = data[0];

        if (first.TryGetProperty("b64_json", out var b64Property))
        {
            var base64 = b64Property.GetString();
            return string.IsNullOrWhiteSpace(base64)
                ? Array.Empty<byte>()
                : Convert.FromBase64String(base64);
        }

        if (first.TryGetProperty("url", out var urlProperty))
        {
            var imageUrl = urlProperty.GetString();
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return Array.Empty<byte>();
            }

            return await _client.GetByteArrayAsync(imageUrl);
        }

        return Array.Empty<byte>();
    }

//     /// <summary>
//     /// Metodo di utilità (non parte di IAiService) per ottimizzare prompt per immagini.
//     /// </summary>
//     public async Task<string> OptimizePromptForImageAsync(string summary, string? style = null)
//     {
//         var styleInstruction = string.IsNullOrEmpty(style) 
//             ? "realistic and visually appealing" 
//             : style;

//         var prompt = $@"Sei un esperto nella creazione di prompt per modelli di generazione immagini AI.

// Basandoti sul seguente RIASSUNTO, crea un prompt dettagliato in INGLESE per generare un'immagine.

// RIASSUNTO: {summary}

// STILE RICHIESTO: {styleInstruction}

// REQUISITI DEL PROMPT:
// - Usa la struttura: '[Soggetto] + [dettagli specifici] + [stile/atmosfera] + [qualità]'
// - Includi dettagli su ambientazione, luci, colori, mood
// - Aggiungi specifiche tecniche: '4K', 'highly detailed'
// - Massimo 75 parole
// - Solo in inglese (ottimale per modelli come FLUX, DALL-E, Stable Diffusion)

// Fornisci SOLO il prompt, senza spiegazioni.";

//         var response = await _chatClient.CompleteAsync(prompt);
//         var optimizedPrompt = response.Message.Text?.Trim() ?? string.Empty;
//         _logger.LogInformation("Image prompt optimized: {Prompt}", optimizedPrompt);
//         return optimizedPrompt;
//     }

    private string GetChatCompletionsEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/openai/deployments/{Uri.EscapeDataString(_options.DeploymentName)}/chat/completions?api-version={Uri.EscapeDataString(_options.ApiVersion)}";

    private string GetImageGenerationEndpoint() =>
        $"{_options.Endpoint.TrimEnd('/')}/openai/deployments/{Uri.EscapeDataString(_options.ImageDeploymentName)}/images/generations?api-version={Uri.EscapeDataString(_options.ApiVersion)}";

    private object BuildSummaryPayload(string text, int messageMaxLength)
    {
        var tokenDivisor = Math.Max(1, _options.SummaryMaxTokensPerChar);
        var maxTokens = Math.Max(1, messageMaxLength / tokenDivisor);
        var underCharacters = Math.Max(1, messageMaxLength - _options.SummarySafetyMarginChars);

        var systemContent = _options.SummarySystemPromptTemplate
            .Replace("{MaxChars}", underCharacters.ToString(), StringComparison.Ordinal);
        var userContent = _options.SummaryUserPromptTemplate
            .Replace("{Text}", text, StringComparison.Ordinal);

        return new
        {
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user", content = userContent }
            },
            max_tokens = maxTokens,
            temperature = _options.SummaryTemperature
        };
    }

    private object BuildImagePromptPayload(string summary)
    {
        var userContent = _options.ImagePromptUserTemplate
            .Replace("{Summary}", summary, StringComparison.Ordinal);

        return new
        {
            messages = new[]
            {
                new { role = "system", content = _options.ImagePromptSystemTemplate },
                new { role = "user", content = userContent }
            },
            max_tokens = _options.ImagePromptMaxTokens,
            temperature = _options.ImagePromptTemperature
        };
    }
}