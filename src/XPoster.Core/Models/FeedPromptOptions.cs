namespace XPoster.Core.Models;

/// <summary>
/// Holds an ordered, role-keyed collection of prompt step configurations
/// for a <c>FeedOrchestrator</c> slot.
/// </summary>
public sealed record FeedPromptOptions
{
    /// <summary>
    /// Ordered list of prompt step options. Each step is identified by a
    /// unique <see cref="PromptRole"/> discriminator.
    /// Expected roles: <see cref="PromptRole.Summary"/>,
    /// <see cref="PromptRole.ImagePromptDerivation"/>,
    /// <see cref="PromptRole.ImageGeneration"/>.
    /// </summary>
    public required IReadOnlyList<PromptStepOptions> Steps { get; init; }

    /// <summary>
    /// Returns the <see cref="PromptStepOptions"/> for the given <paramref name="role"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no step with the specified role is found, or when more than one exists.
    /// </exception>
    public PromptStepOptions GetStep(PromptRole role) =>
        Steps.Single(s => s.Role == role);
}
