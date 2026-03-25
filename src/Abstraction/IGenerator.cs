using XPoster.Models;

namespace XPoster.Abstraction;

/// <summary>
/// Defines the contract for content generators that produce and publish social-media posts.
/// </summary>
public interface IGenerator
{
    /// <summary>Gets the display name of this generator, used for logging and diagnostics.</summary>
    string Name { get; }

    /// <summary>Gets or sets whether this generator is enabled and should produce posts.</summary>
    bool SendIt { get; set; }

    /// <summary>Gets or sets whether this generator is expected to attach an image to its posts.</summary>
    bool ProduceImage { get; set; }

    /// <summary>
    /// Asynchronously generates a <see cref="Post"/> ready for publishing.
    /// </summary>
    /// <returns>
    /// A <see cref="Post"/> instance, or <c>null</c> if generation fails or is not applicable.
    /// </returns>
    // CS8609: return type is Task<Post?> to allow generators to signal failure via null
    Task<Post?> GenerateAsync();

    /// <summary>
    /// Validates pre-conditions and publishes <paramref name="message"/> via the configured sender.
    /// </summary>
    /// <param name="message">The post to publish.</param>
    /// <returns><c>true</c> if published successfully; otherwise <c>false</c>.</returns>
    Task<bool> PostAsync(Post message);
}
