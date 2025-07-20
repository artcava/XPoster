using System.Net;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using XPoster.Models;
using Azure.AI.OpenAI;
using Azure;
using OpenAI.Images;
using Microsoft.Extensions.Logging;

namespace XPoster.Utilities;

public static class AIUtilities
{
    private static readonly HttpClient _client = new();
    public static async Task<string> GetSummaryFromOpenAI(ILogger log, string text, int messageMaxLenght)
    {
        if (!_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
        }

        int tries = 0;

        while (text != null && text.Length > messageMaxLenght && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetSummary(text, messageMaxLenght));
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                log.LogInformation("Too many requests. Please try again later.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                log.LogInformation($"Error: {response.StatusCode}");
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            text = result?.choices[0].message.content.Trim() ?? string.Empty;
        }
        return text;
    }
    public static async Task<string> GetImagePromptFromOpenAI(ILogger log, string text)
    {
        if(!_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");
        }

        var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetPromptForImage(text));
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            log.LogInformation("Too many requests. Please try again later.");
            return string.Empty;
        }

        if (!response.IsSuccessStatusCode)
        {
            log.LogInformation($"Error: {response.StatusCode}");
            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.choices[0].message.content.Trim() ?? string.Empty;
    }

    public static async Task<byte[]> GenerateImageWithOpenAI(ILogger log, string prompt)
    {
        var openAIEndpoint = "https://x-poster.openai.azure.com/";

        var client = new AzureOpenAIClient(
                        new Uri(openAIEndpoint),
                        new AzureKeyCredential(Environment.GetEnvironmentVariable("OPENAI_IMAGE_API_KEY")));

        var imageClient = client.GetImageClient("dall-e-3");

        log.LogInformation($"Generating image with prompt: {prompt}");

        var imageResult = await imageClient.GenerateImageAsync(prompt, new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            ResponseFormat = GeneratedImageFormat.Bytes
        });

        GeneratedImage image = imageResult.Value;
        return image.ImageBytes.ToArray();
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
                new { role = "system", content = "You are an assistant that generates image prompts for DALL-E 3 based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect policy for generating images with prompt." },
                new { role = "user", content = $"Generate an image prompt based on this summary: {summary}" }
            },
            max_tokens = 60, // Limita l'output a un prompt breve
            temperature = 0.7 // Meno creatività, più aderenza al riassunto
        };
    }
}
