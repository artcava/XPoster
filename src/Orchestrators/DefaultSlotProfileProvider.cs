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
        new ScheduledOrchestrationProfile(6,  SenderPlatform.LinkedIn,  typeof(FeedOrchestrator),      AiProvider.OpenAi),
        new ScheduledOrchestrationProfile(8,  SenderPlatform.X,         typeof(FeedOrchestrator),      AiProvider.AzureFoundry),
        //new ScheduledOrchestrationProfile(10, SenderPlatform.Instagram,  typeof(FeedOrchestrator),  AiProvider.OpenAi),
        new ScheduledOrchestrationProfile(14, SenderPlatform.LinkedIn,  typeof(PowerLawOrchestrator)),
        new ScheduledOrchestrationProfile(16, SenderPlatform.X,         typeof(PowerLawOrchestrator)),
        //new ScheduledOrchestrationProfile(18, SenderPlatform.Instagram,  typeof(PowerLawOrchestrator)),
    }.AsReadOnly();

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() => _profiles;
}
