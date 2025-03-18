using System.Net;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using XPoster.Models;

namespace XPoster.Utilities;

public static class AIUtilities
{
    private static readonly HttpClient _client = new();
    public static async Task<string> GetSummaryFromOpenAI(string text)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("OPENAI_API_KEY")}");

        int tries=0;

        while (text != null && text.Length > 250 && tries <= 2)
        {
            tries++;
            var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", GetRequestBody(text));
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                Console.WriteLine("Too many requests. Please try again later.");
                return string.Empty;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return string.Empty;
            }

            var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
            text = result?.choices[0].message.content.Trim() ?? string.Empty;
        }
        return text;
    }

    private static object GetRequestBody(string text) 
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
}
