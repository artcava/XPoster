using XPoster.Abstraction;
using XPoster.Contracts;

namespace XPoster.Orchestrators;

/// <summary>
/// Production implementation of <see cref="ISlotProfileProvider"/>.
/// Contains the canonical posting schedule without the DryRun slot,
/// which is intentionally excluded from production deployments.
/// <para>
/// Slots are defined as follows (UTC hours):
/// <list type="table">
///   <item><term>08:00</term><description>Fan-out: FeedOrchestrator → LinkedIn (primary), X, Instagram.</description></item>
///   <item><term>14:00</term><description>PowerLawOrchestrator → LinkedIn.</description></item>
///   <item><term>16:00</term><description>PowerLawOrchestrator → X.</description></item>
/// </list>
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
        // Fan-out slot — LinkedIn (widest limit) drives base summary and image generation.
        // X (280 chars) always trigger re-summarisation.
        new ScheduledOrchestrationProfile(
            hour: 6,
            senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X },
            orchestratorType: typeof(FeedOrchestrator),
            textProvider:  AiProvider.OpenAi,
            imageProvider: AiProvider.AzureFoundry),

        // PowerLaw slots — no AI provider required.
        new ScheduledOrchestrationProfile(
            hour: 14,
            senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X },
            orchestratorType: typeof(PowerLawOrchestrator)),

    }.AsReadOnly();

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() => _profiles;
}
