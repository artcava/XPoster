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
    /// positionally aligned with the sender list.
    /// </summary>
    /// <returns>
    /// An <see cref="IReadOnlyList{T}"/> of <see cref="Post"/> instances, one per sender.
    /// A <c>null</c> entry at position <c>i</c> signals that content generation failed for that sender.
    /// Returns an empty list if orchestration fails or is not applicable.
    /// </returns>
    Task<IReadOnlyList<Post?>> OrchestrateAsync();

    /// <summary>
    /// Dispatches each post to its positionally aligned sender in parallel via <c>Task.WhenAll</c>.
    /// A <c>null</c> post at position <c>i</c> causes that sender to be skipped with a warning.
    /// </summary>
    /// <param name="posts">The list of posts to publish, positionally aligned with the sender list.</param>
    /// <returns><c>true</c> only if all dispatched senders succeed; otherwise <c>false</c>.</returns>
    Task<bool> PostAsync(IReadOnlyList<Post?> posts);
}
