using XPoster.Abstraction;
using XPoster.Contracts;

namespace XPoster.Orchestrators;

/// <summary>
/// Production implementation of <see cref="ISlotProfileProvider"/>.
/// Contains the canonical posting schedule without the DryRun slot,
/// which is intentionally excluded from production deployments.
/// </summary>
public sealed class DefaultSlotProfileProvider : ISlotProfileProvider
{
    private static readonly IReadOnlyList<ScheduledOrchestrationProfile> _profiles = new List<ScheduledOrchestrationProfile>
    {
        new ScheduledOrchestrationProfile(6,  MessageSender.InSummaryFeed, typeof(FeedOrchestrator),      AiProvider.OpenAi),
        new ScheduledOrchestrationProfile(8,  MessageSender.XSummaryFeed,  typeof(FeedOrchestrator),      AiProvider.OpenAi),
        //new ScheduledOrchestrationProfile(10, MessageSender.IgSummaryFeed, typeof(FeedOrchestrator),  AiProvider.OpenAi),
        new ScheduledOrchestrationProfile(14, MessageSender.InPowerLaw,    typeof(PowerLawOrchestrator)),
        new ScheduledOrchestrationProfile(16, MessageSender.XPowerLaw,     typeof(PowerLawOrchestrator)),
        //new ScheduledOrchestrationProfile(18, MessageSender.IgPowerLaw,    typeof(PowerLawOrchestrator)),
    }.AsReadOnly();

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() => _profiles;
}
