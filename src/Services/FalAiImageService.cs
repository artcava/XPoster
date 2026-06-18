using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
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
    /// Generates an image from the given prompt using FLUX.1 Turbo on fal.ai.
    /// </summary>
    /// <param name="prompt">The text prompt describing the desired image.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A byte array containing the generated image data, or an empty array on failure.
    /// HTTP-level guards (429 <c>LogWarning</c>, non-2xx <c>LogError</c>, JSON deserialisation
    /// <c>LogError</c>) are handled by <see cref="AiServiceHelper.ParseImageResponseAsync"/>.
    /// <see cref="System.Net.Http.HttpRequestException"/> on both POST and image download are caught
    /// and logged as errors inside this service.
    /// </returns>
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
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
            num_inference_steps = _options.NumInferenceSteps,
            num_images = 1,
            enable_safety_checker = true,
            output_format = "png"
        };

        // ModelId may contain path separators (e.g. "fal-ai/flux/schnell").
        // Each segment is encoded individually so that slashes are preserved as
        // path delimiters while any reserved or unsafe characters within a segment
        // are percent-encoded. This is consistent with the AzureFoundryService
        // pattern that calls Uri.EscapeDataString on DeploymentName.
        var encodedModelPath = string.Join(
            "/",
            _options.ModelId.Split('/').Select(Uri.EscapeDataString));

        var endpoint = $"{FalApiBaseUrl}/{encodedModelPath}";

        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsJsonAsync(endpoint, requestBody, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request to fal.ai failed.");
            return Array.Empty<byte>();
        }

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "fal.ai", _logger, cancellationToken);

        if (!success || content is null)
            return Array.Empty<byte>();

        var result = content.Value;

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
            return await _client.GetByteArrayAsync(imageUrl, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to download generated image from fal.ai URL: {Url}", imageUrl);
            return Array.Empty<byte>();
        }
    }
}
