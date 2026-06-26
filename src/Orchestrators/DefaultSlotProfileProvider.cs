using XPoster.Abstraction;
using XPoster.Contracts;

namespace XPoster.Orchestrators;

/// <summary>
/// Production implementation of <see cref="ISlotProfileProvider"/>.
/// Contains the canonical posting schedule without the DryRun slot,
/// which is intentionally excluded from production deployments.
/// <para>
/// Each slot declares <see cref="ScheduledOrchestrationProfile.TextProvider"/> and
/// <see cref="ScheduledOrchestrationProfile.ImageProvider"/> independently, allowing
/// different AI providers to be used for text generation and image generation within
/// the same slot (e.g. DeepSeek for text, FalAi for image).
/// </para>
/// <para>
/// Senders within a slot are declared in <b>descending <c>MessageMaxLength</c> order</b>.
/// The first sender (widest limit) drives base summary generation.
/// Subsequent senders receive AI re-summarisation only when the base summary exceeds their limit.
/// </para>
/// </summary>
public sealed class DefaultSlotProfileProvider : ISlotProfileProvider
{
    private static readonly IReadOnlyList<ScheduledOrchestrationProfile> _profiles = new List<ScheduledOrchestrationProfile>
    {
        // Fan-out slot: LinkedIn (widest) drives base summary and image generation.
        // X (280 chars) always triggers re-summarisation.
        new ScheduledOrchestrationProfile(
            6,
            new[] { SenderPlatform.LinkedIn, SenderPlatform.X },
            typeof(FeedOrchestrator),
            textProvider:  AiProvider.AzureFoundry,
            imageProvider: AiProvider.AzureFoundry),

        new ScheduledOrchestrationProfile(
            14,
            new[] { SenderPlatform.LinkedIn, SenderPlatform.X },
            typeof(PowerLawOrchestrator)),

    }.AsReadOnly();

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() => _profiles;
}
