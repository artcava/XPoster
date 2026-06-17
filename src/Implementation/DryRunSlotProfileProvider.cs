using XPoster.Abstraction;

namespace XPoster.Implementation;

/// <summary>
/// Decorator over <see cref="ISlotProfileProvider"/> that appends the DryRun slot
/// to the inner provider's schedule.
/// </summary>
/// <remarks>
/// Register this in place of <see cref="DefaultSlotProfileProvider"/> when the
/// <c>EnableDryRunSlot</c> configuration key is <c>true</c> (e.g. in local.settings.json).
/// This keeps the DryRun profile out of the production binary's hard-coded schedule
/// and eliminates the need to comment/uncomment code when switching environments.
/// </remarks>
public sealed class DryRunSlotProfileProvider : ISlotProfileProvider
{
    private readonly ISlotProfileProvider _inner;

    /// <summary>
    /// Initialises a new instance of <see cref="DryRunSlotProfileProvider"/>.
    /// </summary>
    /// <param name="inner">The underlying provider whose profiles are extended.</param>
    public DryRunSlotProfileProvider(ISlotProfileProvider inner)
    {
        _inner = inner;
    }

    /// <inheritdoc />
    /// <remarks>
    /// Appends <see cref="MessageSender.DryRunSend"/> at hour 9 to the profiles
    /// returned by the inner provider.
    /// </remarks>
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles()
    {
        var profiles = new List<ScheduledOrchestrationProfile>(_inner.GetProfiles())
        {
            new ScheduledOrchestrationProfile(9, MessageSender.DryRunSend, typeof(FeedOrchestrator), AiProvider.OpenAi)
        };
        return profiles.AsReadOnly();
    }
}
