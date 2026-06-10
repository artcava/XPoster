using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster.Services;

/// <summary>
/// Hybrid AI service that delegates text generation to DeepSeek
/// and image generation to fal.ai (FLUX.2 Turbo).
/// </summary>
public sealed class HybridAiService : IAiService
{
    private readonly DeepSeekService _deepSeekService;
    private readonly FalAiImageService _falAiImageService;
    private readonly ILogger<HybridAiService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="HybridAiService"/> class.
    /// </summary>
    /// <param name="deepSeekService">Service used for summary and image prompt generation.</param>
    /// <param name="falAiImageService">Service used for image generation.</param>
    /// <param name="logger">Logger instance.</param>
    public HybridAiService(
        DeepSeekService deepSeekService,
        FalAiImageService falAiImageService,
        ILogger<HybridAiService> logger)
    {
        _deepSeekService = deepSeekService ?? throw new ArgumentNullException(nameof(deepSeekService));
        _falAiImageService = falAiImageService ?? throw new ArgumentNullException(nameof(falAiImageService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public async Task<string> GetSummaryAsync(string text, int messageMaxLength, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Generating summary with DeepSeek.");
        return await _deepSeekService.GetSummaryAsync(text, messageMaxLength, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string> GetImagePromptAsync(string text, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Generating image prompt with DeepSeek.");
        return await _deepSeekService.GetImagePromptAsync(text, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Generating image with fal.ai.");
        return await _falAiImageService.GenerateImageAsync(prompt, cancellationToken);
    }
}
