using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

public class AiService : IAiService
{
    private readonly HttpClient _client;
    private readonly ILogger<AiService> _logger;
    public AiService(IHttpClientFactory httpClientFactory, ILogger<AiService> logger)
    {
        _logger = logger;
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
    }

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
        return text;
    }

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

    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        // _client has Authorization: Bearer {OPENAI_API_KEY} already set from constructor
        _logger.LogInformation($"Generating image with gpt-image-1-mini, prompt: {prompt}");

        var body = new
        {
            model = "gpt-image-1-mini",
            prompt,
            n = 1,
            size = "1024x1024",
            response_format = "b64_json"
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
        return Convert.FromBase64String(base64!);
    }

    private static object GetSummary(string text, int messageMaxLenght)
    {
        var maxTokens = messageMaxLenght / 5; // Approximate token count (1 token ~ 4 characters)
        var underCharacters = messageMaxLenght - 50; // Leave space for the firm
        return new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = $"You are an assistant that summarizes text concisely. It's very important that you keep summaries under {underCharacters} characters." },
                new { role = "user", content = $"Summarize this text in a few sentences. text: {text}" }
            },
            max_tokens = maxTokens, // Limit summary to maxTokens tokens
            temperature = 0.5 // Manage creativity (0 = more deterministic, 1 = more creative)
        };
    }

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
