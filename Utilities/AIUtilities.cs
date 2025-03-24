using System.Net;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using XPoster.Models;
using Azure.AI.OpenAI;
using Azure;
using OpenAI.Images;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace XPoster.Utilities;

public static class AIUtilities
{
    private static readonly HttpClient _client = new();
    public static async Task<string> GetSummaryFromOpenAI(ILogger log, string text)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");

        int tries=0;

        while (text != null && text.Length > 250 && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetSummary(text));
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
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");

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

        var additionalInstructions = "no text, signs, or words included";
        // Lista statica di frasi legate a Bitcoin
        var bitcoinPhrases = new List<string>
        {
            "featuring a shiny golden Bitcoin coin in the foreground with the '₿' symbol clearly visible",
            "with a large Bitcoin coin resting on the ground, metallic and reflective",
            "including a floating Bitcoin coin glowing with a digital aura",
            "featuring a stack of Bitcoin coins piled up in the center",
            "with a single Bitcoin coin embedded in a futuristic circuit board",
            "including a golden Bitcoin coin held by a robotic hand",
            "featuring a Bitcoin coin shining brightly against a dark background",
            "with a Bitcoin coin placed on a wooden table, highly detailed",
            "including a massive Bitcoin coin rising from the ground like a monument",
            "featuring a Bitcoin coin surrounded by glowing blockchain patterns",
            "with a Bitcoin coin floating above a sea of digital data streams",
            "including a golden Bitcoin coin with holographic effects around it",
            "featuring a Bitcoin coin in a treasure chest overflowing with gold",
            "with a Bitcoin coin etched into a sleek, modern surface",
            "including a Bitcoin coin orbiting a digital globe",
            "featuring a Bitcoin coin embedded in a crystal structure",
            "with a Bitcoin coin displayed on a futuristic dashboard",
            "including a Bitcoin coin raining down from a cloud of binary code",
            "featuring a Bitcoin coin as the centerpiece of a cyberpunk marketplace",
            "with a Bitcoin coin glowing faintly in a pool of liquid metal"
        };
        // Selezione casuale di una frase
        var random = new Random();
        var randomBitcoinPhrase = bitcoinPhrases[random.Next(bitcoinPhrases.Count)];

        // Combina il prompt base, la frase casuale e le istruzioni aggiuntive
        var fullPrompt = $"{prompt}, {randomBitcoinPhrase}, {additionalInstructions}";

        log.LogInformation($"Generating image with prompt: {fullPrompt}");

        var imageResult = await imageClient.GenerateImageAsync(fullPrompt, new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            ResponseFormat = GeneratedImageFormat.Bytes
        });

        GeneratedImage image = imageResult.Value;
        return image.ImageBytes.ToArray();
    }

    private static object GetSummary(string text) 
    {
        return new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = "You are an assistant that summarizes text concisely. It's very important that you keep summaries under 250 characters." },
                new { role = "user", content = $"Summarize this text in a few sentences. text: {text}" }
            },
            max_tokens = 50, // Limit summary to 50 tokens
            temperature = 0.7 // Manage creativity (0 = more deterministic, 1 = more creative)
        };
    }

    private static object GetPromptForImage(string summary)
    {
        return new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = "You are an assistant that generates image prompts for DALL-E 3 based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Keep it under 200 characters." },
                new { role = "user", content = $"Generate an image prompt based on this summary: {summary}" }
            },
            max_tokens = 60, // Limita l'output a un prompt breve
            temperature = 0.5 // Meno creatività, più aderenza al riassunto
        };
    }
}
