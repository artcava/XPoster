using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Generates images using the fal.ai REST API with the FLUX.1 Turbo model.
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
    /// Generates an image from the given prompt using FLUX.1 Turbo on fal.ai.
    /// </summary>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogWarning("GenerateImageAsync called with an empty prompt.");
            return Array.Empty<byte>();
        }
        var requestBody = new { prompt, image_size = _options.ImageSize, num_inference_steps = _options.NumInferenceSteps, num_images = 1, enable_safety_checker = true, output_format = "png" };
        var encodedModelPath = string.Join("/", _options.ModelId.Split('/').Select(Uri.EscapeDataString));
        var endpoint = $"{FalApiBaseUrl}/{encodedModelPath}";
        HttpResponseMessage response;
        try { response = await _client.PostAsJsonAsync(endpoint, requestBody, cancellationToken); }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request to fal.ai failed.");
            return Array.Empty<byte>();
        }
        return await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, _client, _logger, allowedOrigin: null, cancellationToken);
    }
}
