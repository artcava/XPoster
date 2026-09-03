using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Providers;

/// <summary>
/// Production implementation of <see cref="ISlotProfileProvider"/>.
/// Contains the canonical posting schedule without the DryRun slot,
/// which is intentionally excluded from production deployments.
/// <para>
/// Slots are defined as follows (UTC hours):
/// <list type="table">
///   <item><term>06:00</term><description>Fan-out: WorkflowOrchestrator → LinkedIn (primary), X, Instagram, Facebook.</description></item>
///   <item><term>14:00</term><description>PowerLawOrchestrator → LinkedIn, X, Facebook.</description></item>
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
        new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Bitcoin",
            hour: 6,
            senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X, SenderPlatform.Instagram, SenderPlatform.Facebook },
            orchestratorType: typeof(WorkflowOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.AzureFoundry),

        new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: 14,
            senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X, SenderPlatform.Facebook },
            orchestratorType: typeof(PowerLawOrchestrator))
    }.AsReadOnly();

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() => _profiles;
}