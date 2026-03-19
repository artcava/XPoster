using XPoster.Models;

namespace XPoster.Abstraction;

/// <summary>
/// Defines the contract for a content generator that can produce and publish social-media posts.
/// </summary>
public interface IGenerator
{
    /// <summary>Gets the human-readable name that identifies this generator.</summary>
    public string Name { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this generator is allowed to dispatch posts to the configured sender.
    /// </summary>
    public bool SendIt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this generator is expected to attach an AI-generated image to its posts.
    /// </summary>
    public bool ProduceImage { get; set; }

    /// <summary>
    /// Asynchronously generates a <see cref="Post"/> containing the content to be published.
    /// </summary>
    /// <returns>A <see cref="Post"/> instance, or <c>null</c> if no content could be generated.</returns>
    public Task<Post>? GenerateAsync();

    /// <summary>
    /// Asynchronously dispatches the given <see cref="Post"/> via the configured sender.
    /// </summary>
    /// <param name="message">The post to publish.</param>
    /// <returns><c>true</c> if the post was successfully sent; otherwise <c>false</c>.</returns>
    public Task<bool> PostAsync(Post message);
}
