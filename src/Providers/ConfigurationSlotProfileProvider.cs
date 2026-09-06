using Microsoft.Extensions.Configuration;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Providers;

/// <summary>
/// Configuration-driven <see cref="ISlotProfileProvider"/> that builds the orchestration
/// schedule from the <c>Schedule</c> configuration section. Every configured slot maps to a
/// <see cref="WorkflowOrchestrator"/> whose <see cref="ScheduledOrchestrationProfile.OrchestratorContextKey"/>
/// is the slot's workflow key, allowing new workflows to be scheduled at any hour with no code change.
/// </summary>
/// <remarks>
/// The schedule uses the flat <c>Schedule__N__*</c> convention (e.g. <c>Schedule__0__Hour</c>,
/// <c>Schedule__0__Workflow</c>, <c>Schedule__0__Senders__0</c>) so it replicates cleanly
/// into Azure Function Environment settings.
/// </remarks>
public sealed class ConfigurationSlotProfileProvider : ISlotProfileProvider
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ConfigurationSlotProfileProvider> _logger;

    /// <summary>Initialises a new instance of <see cref="ConfigurationSlotProfileProvider"/>.</summary>
    public ConfigurationSlotProfileProvider(IConfiguration configuration, ILogger<ConfigurationSlotProfileProvider> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    /// <inheritdoc />
    public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles()
    {
        var profiles = new List<ScheduledOrchestrationProfile>();
        var scheduleSection = _configuration.GetSection("Schedule");

        foreach (var slotSection in scheduleSection.GetChildren())
        {
            var options = slotSection.Get<SlotScheduleOptions>();
            if (options is null)
                continue;

            if (string.IsNullOrWhiteSpace(options.Workflow))
            {
                _logger.LogWarning("[ConfigurationSlotProfileProvider] Slot '{Slot}' at hour {Hour} has no Workflow key; skipping.",
                    slotSection.Key, options.Hour);
                continue;
            }

            if (options.Senders.Count == 0)
            {
                _logger.LogWarning("[ConfigurationSlotProfileProvider] Slot '{Slot}' at hour {Hour} has no senders; skipping.",
                    slotSection.Key, options.Hour);
                continue;
            }

            var senders = new List<SenderPlatform>();
            foreach (var senderName in options.Senders)
            {
                if (Enum.TryParse<SenderPlatform>(senderName, ignoreCase: true, out var platform))
                    senders.Add(platform);
                else
                    _logger.LogWarning("[ConfigurationSlotProfileProvider] Slot '{Slot}' has an unknown sender '{Sender}'; skipping.",
                        slotSection.Key, senderName);
            }

            if (senders.Count == 0)
            {
                _logger.LogWarning("[ConfigurationSlotProfileProvider] Slot '{Slot}' at hour {Hour} resolved to no valid senders; skipping.",
                    slotSection.Key, options.Hour);
                continue;
            }

            profiles.Add(new ScheduledOrchestrationProfile(
                orchestratorContextKey: options.Workflow,
                hour: options.Hour,
                senderPlatforms: senders.AsReadOnly(),
                orchestratorType: typeof(WorkflowOrchestrator)));
        }

        return profiles.OrderBy(p => p.Hour).ToList().AsReadOnly();
    }
}
