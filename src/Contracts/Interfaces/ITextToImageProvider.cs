using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Capability contract for text-to-image AI operations.
/// Providers that support image generation implement this interface.
/// Prompt intent is owned by the orchestrator and transported via <see cref="ImagePromptRequest"/>.
/// </summary>
public interface ITextToImageProvider
{
    /// <summary>
    /// Generates an image from the supplied prompt request and returns it as a byte array.
    /// </summary>
    /// <param name="request">The image prompt request carrying prompt and generation parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The generated image as a byte array, or an empty array on failure.</returns>
    Task<byte[]> GenerateImageAsync(ImagePromptRequest request, CancellationToken cancellationToken = default);
}