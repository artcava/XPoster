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
    /// Asynchronously orchestrates the production of a <see cref="Post"/> ready for publishing.
    /// </summary>
    /// <returns>
    /// A <see cref="Post"/> instance, or <c>null</c> if orchestration fails or is not applicable.
    /// </returns>
    // CS8609: return type is Task<Post?> to allow orchestrators to signal failure via null
    Task<Post?> OrchestrateAsync();

    /// <summary>
    /// Validates pre-conditions and publishes <paramref name="message"/> via the configured sender.
    /// </summary>
    /// <param name="message">The post to publish.</param>
    /// <returns><c>true</c> if published successfully; otherwise <c>false</c>.</returns>
    Task<bool> PostAsync(Post message);
}
