using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Implements <see cref="IAiService"/> by calling the OpenAI Chat Completions and Image Generations APIs.
/// Uses <c>gpt-4o-mini</c> for text tasks and <c>gpt-image-1</c> for image generation.
/// </summary>
public class AiService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<AiService> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="AiService"/>, configuring the HTTP client
    /// with the OpenAI Bearer token read from the <c>OPENAI_API_KEY</c> environment variable.
    /// </summary>
    /// <param name="httpClientFactory">The factory used to create the underlying <see cref="HttpClient"/>.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    public AiService(IHttpClientFactory httpClientFactory, ILogger<AiService> logger)
    {
        _logger = logger;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
    }

    /// <inheritdoc/>
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength)
    {
        if (!_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
        }

        int tries = 0;

        while (text != null && text.Length > messageMaxLength && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetSummary(text, messageMaxLength));
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                _logger.LogInformation("Too many requests. Please try again later.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Error: {response.StatusCode}");
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            text = result?.choices[0].message.content.Trim() ?? string.Empty;
        }
        // CS8603: text cannot be null here — while loop guard ensures non-null or early return
        return text ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<string> GetImagePromptAsync(string text)
    {
        if (!_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
        }

        var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetPromptForImage(text));
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogInformation("Too many requests. Please try again later.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation($"Error: {response.StatusCode}");
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.choices[0].message.content.Trim() ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        _logger.LogInformation($"Generating image with gpt-image-1, prompt: {prompt}");

        var body = new
        {
            model = "gpt-image-1",
            prompt,
            n = 1,
            size = "1024x1024"
        };

        var response = await _client.PostAsJsonAsync(
            "https://api.openai.com/v1/images/generations", body);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Image generation failed: {response.StatusCode}");
            return Array.Empty<byte>();
        }

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        var base64 = result.GetProperty("data")[0].GetProperty("b64_json").GetString();
        // base64 cannot be null if API responded with 200 and valid JSON structure
        return Convert.FromBase64String(base64!);
    }

    /// <summary>
    /// Builds the request payload for the Chat Completions API to summarise <paramref name="text"/>
    /// within the given character budget.
    /// </summary>
    /// <param name="text">The text to summarise.</param>
    /// <param name="messageMaxLenght">The character limit that the summary must respect.</param>
    /// <returns>An anonymous object serialisable as a valid OpenAI Chat Completions request body.</returns>
    private static object GetSummary(string text, int messageMaxLenght)
    {
        var maxTokens = messageMaxLenght / 5;
        var underCharacters = messageMaxLenght - 50;
        return new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = $"You are an assistant that summarizes text concisely. It's very important that you keep summaries under {underCharacters} characters." },
                new { role = "user", content = $"Summarize this text in a few sentences. text: {text}" }
            },
            max_tokens = maxTokens,
            temperature = 0.5
        };
    }

    /// <summary>
    /// Builds the request payload for the Chat Completions API to derive an image generation prompt
    /// from a news <paramref name="summary"/>.
    /// </summary>
    /// <param name="summary">The text summary to base the image prompt on.</param>
    /// <returns>An anonymous object serialisable as a valid OpenAI Chat Completions request body.</returns>
    private static object GetPromptForImage(string summary)
    {
        return new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images." },
                new { role = "user", content = $"Generate an image prompt based on this summary: {summary}" }
            },
            max_tokens = 60,
            temperature = 0.7
        };
    }
}
