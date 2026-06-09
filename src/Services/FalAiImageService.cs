using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Generates images using the fal.ai REST API with the FLUX.2 Turbo model.
/// </summary>
public sealed class FalAiImageService
{
    private const string FalApiBaseUrl = "https://fal.run";

    private readonly HttpClient _client;
    private readonly FalAiOptions _options;
    private readonly ILogger<FalAiImageService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="FalAiImageService"/>.
    /// </summary>
    /// <param name="httpClientFactory">Factory used to create the HTTP client.</param>
    /// <param name="options">Strongly-typed fal.ai configuration.</param>
    /// <param name="logger">Logger instance.</param>
    public FalAiImageService(
        IHttpClientFactory httpClientFactory,
        IOptions<FalAiOptions> options,
        ILogger<FalAiImageService> logger)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = httpClientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Key {_options.ApiKey}");
    }

    /// <summary>
    /// Generates an image from the given prompt using FLUX.2 Turbo on fal.ai.
    /// </summary>
    /// <param name="prompt">The text prompt describing the desired image.</param>
    /// <returns>A byte array containing the generated image data, or an empty array on failure.</returns>
    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("GenerateImageAsync called with an empty prompt.");
            return Array.Empty<byte>();
        }

        var requestBody = new
        {
            prompt,
            image_size = _options.ImageSize,
            num_images = 1,
            enable_safety_checker = true,
            output_format = "png"
        };

        var endpoint = $"{FalApiBaseUrl}/{_options.ModelId}";

        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsJsonAsync(endpoint, requestBody);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request to fal.ai failed.");
            return Array.Empty<byte>();
        }

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            _logger.LogWarning("fal.ai returned 429 Too Many Requests during image generation.");
            return Array.Empty<byte>();
        }

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError(
                "fal.ai image generation failed. StatusCode: {StatusCode}",
                response.StatusCode);
            return Array.Empty<byte>();
        }

        JsonElement result;
        try
        {
            result = await response.Content.ReadFromJsonAsync<JsonElement>();
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize fal.ai response.");
            return Array.Empty<byte>();
        }

        // Response schema: { "images": [{ "url": "...", ... }] }
        if (!result.TryGetProperty("images", out var images) || images.GetArrayLength() == 0)
        {
            _logger.LogError("fal.ai response does not contain any images.");
            return Array.Empty<byte>();
        }

        var firstImage = images[0];

        if (!firstImage.TryGetProperty("url", out var urlProperty))
        {
            _logger.LogError("fal.ai image entry does not contain a URL.");
            return Array.Empty<byte>();
        }

        var imageUrl = urlProperty.GetString();
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            _logger.LogError("fal.ai returned an empty image URL.");
            return Array.Empty<byte>();
        }

        _logger.LogInformation("Downloading generated image from {ImageUrl}", imageUrl);

        try
        {
            return await _client.GetByteArrayAsync(imageUrl);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to download generated image from fal.ai URL: {Url}", imageUrl);
            return Array.Empty<byte>();
        }
    }
}