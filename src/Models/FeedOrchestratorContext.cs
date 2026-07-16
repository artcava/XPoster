namespace XPoster.Models;

/// <summary>
/// Slot-scoped runtime context injected into <c>FeedOrchestrator</c>.
/// Carries the feed URLs and the ordered prompt options specific to one
/// scheduling slot (e.g. Feed06, Feed08).
/// </summary>
/// <remarks>
/// Registered as a keyed singleton in <c>Program.cs</c> using the slot's
/// logical key (e.g. <c>"Feed06"</c>) and resolved by <c>OrchestratorFactory</c>
/// via <see cref="ScheduledOrchestrationProfile.OrchestratorContextKey"/>.
/// </remarks>
public sealed record FeedOrchestratorContext
{
    /// <summary>Feed URLs consumed by this slot.</summary>
    public required IReadOnlyList<string> FeedUrls { get; init; }

    /// <summary>Ordered, role-keyed prompt options for this slot.</summary>
    public required FeedPromptOptions PromptOptions { get; init; }
}
