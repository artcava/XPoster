using System.Threading;
using System.Threading.Tasks;

namespace XPoster.Contracts;

/// <summary>
/// Capability contract for text-to-image AI operations.
/// Providers that support image generation from a text prompt implement this interface.
/// </summary>
public interface ITextToImageProvider
{
    /// <summary>
    /// Generates an image from the supplied text prompt and returns it as a byte array.
    /// </summary>
    /// <param name="prompt">The text prompt describing the image to generate.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The generated image as a byte array.</returns>
    Task<byte[]> GenerateImageAsync(string prompt, CancellationToken ct = default);
}
