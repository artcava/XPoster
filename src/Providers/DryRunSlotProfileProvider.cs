using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Providers;

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
    /// Appends a <see cref="SenderPlatform.DryRun"/> slot at hour 9 to the profiles
    /// returned by the inner provider. Both text and image generation use OpenAi by default.
    /// </remarks>
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles()
    {
        var profiles = new List<ScheduledOrchestrationProfile>(_inner.GetProfiles())
        {
            new ScheduledOrchestrationProfile(
                orchestratorContextKey: "PowerLaw", // "Bitcoin"
                hour: 9,
                senderPlatforms: new[] { SenderPlatform.DryRun },
                orchestratorType: typeof(WorkflowOrchestrator),
                textProvider: AiProvider.OpenAi,
                imageProvider: AiProvider.OpenAi)
        };

        return profiles.AsReadOnly();
    }
}