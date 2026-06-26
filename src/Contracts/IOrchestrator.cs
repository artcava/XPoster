using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Defines the contract for orchestrators that coordinate content production and publishing
/// of social-media posts.
/// </summary>
public interface IOrchestrator
{
    /// <summary>Gets the display name of this orchestrator, used for logging and diagnostics.</summary>
    string Name { get; }

    /// <summary>Gets or sets whether this orchestrator is enabled and should produce posts.</summary>
    bool SendIt { get; set; }

    /// <summary>Gets or sets whether this orchestrator is expected to attach an image to its posts.</summary>
    bool ProduceImage { get; set; }

    /// <summary>
    /// Gets the list of target platforms this orchestrator supports.
    /// Used for optional validation — confirms the resolved sender platform is compatible with this orchestrator.
    /// </summary>
    IReadOnlyList<SenderPlatform> SupportedPlatforms { get; }

    /// <summary>
    /// Asynchronously orchestrates the production of one <see cref="Post"/> per configured sender,
    /// keyed by <see cref="SenderPlatform"/>.
    /// </summary>
    /// <returns>
    /// An <see cref="IReadOnlyDictionary{SenderPlatform, Post}"/> mapping each target platform to its post.
    /// A <c>null</c> value for a given key signals that content generation failed for that platform.
    /// Returns an empty dictionary if orchestration fails or is not applicable.
    /// </returns>
    Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync();

    /// <summary>
    /// Dispatches each post to the matching sender, resolved by <see cref="SenderPlatform"/> key, in parallel.
    /// A <c>null</c> post for a platform causes that sender to be skipped with a warning.
    /// A sender whose platform is not present in <paramref name="posts"/> is also skipped with a warning.
    /// </summary>
    /// <param name="posts">Map of platform → post, as returned by <see cref="OrchestrateAsync"/>.</param>
    /// <returns><c>true</c> only if all dispatched senders succeed; otherwise <c>false</c>.</returns>
    Task<bool> PostAsync(IReadOnlyDictionary<SenderPlatform, Post?> posts);
}
