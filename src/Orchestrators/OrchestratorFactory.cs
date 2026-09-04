using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Workflows.Engine;

namespace XPoster.Orchestrators;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseOrchestrator"/> for the current hour of the day
/// by consulting the <see cref="ISlotProfileProvider"/> schedule.
/// Sender resolution is O(senders) via <see cref="SenderPlatform"/> switch.
/// Text and image capabilities are resolved independently via keyed DI, allowing a slot to mix
/// different providers for each capability (e.g. DeepSeek for text, FalAi for image).
/// Multiple senders per slot are supported: senders are resolved in declaration order
/// (descending <c>MessageMaxLength</c> convention) and passed as <see cref="IReadOnlyList{ISender}"/>.
/// </summary>
public class OrchestratorFactory : IOrchestratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrchestratorFactory> _log;
    private readonly ITimeProvider _timeProvider;
    private readonly ISlotProfileProvider _slotProfileProvider;
    private readonly IWorkflowEngine _workflowEngine;

    /// <summary>
    /// Initialises a new instance of <see cref="OrchestratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">DI service provider used to resolve senders and keyed capability providers.</param>
    /// <param name="log">Factory logger.</param>
    /// <param name="timeProvider">Time provider used to determine current hour slot.</param>
    /// <param name="slotProfileProvider">Provider that supplies the scheduled orchestration profiles.</param>
    /// <param name="workflowEngine">Workflow DAG engine used by <see cref="WorkflowOrchestrator"/> slots.</param>
    public OrchestratorFactory(
        IServiceProvider serviceProvider,
        ILogger<OrchestratorFactory> log,
        ITimeProvider timeProvider,
        ISlotProfileProvider slotProfileProvider,
        IWorkflowEngine workflowEngine)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
        _slotProfileProvider = slotProfileProvider;
        _workflowEngine = workflowEngine;
    }

    /// <summary>
    /// Creates and returns the <see cref="BaseOrchestrator"/> mapped to the current hour.
    /// Falls back to <see cref="NoOrchestrator"/> when no entry exists for the current hour.
    /// Senders are resolved from <c>profile.SenderPlatforms</c> in declaration order
    /// (descending <c>MessageMaxLength</c> convention); unresolvable platforms are skipped with a warning.
    /// Every scheduled slot resolves as a <see cref="WorkflowOrchestrator"/> driven by its
    /// <see cref="ScheduledOrchestrationProfile.OrchestratorContextKey"/>.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseOrchestrator"/> instance.</returns>
    public BaseOrchestrator Resolve()
    {
        var currentHour = _timeProvider.GetCurrentTime().Hour;
        var profile = _slotProfileProvider.GetProfiles().FirstOrDefault(p => p.Hour == currentHour);

        if (profile == null)
        {
            _log.LogInformation("No slot profile for hour {Hour}, using NoOrchestrator", currentHour);
            return CreateEmptyNoOrchestrator();
        }

        var senders = profile.SenderPlatforms
            .SelectMany(ResolveSenders)
            .ToList()
            .AsReadOnly();

        _log.LogInformation(
            "Creating orchestrator {OrchestratorType} for platforms [{SenderPlatforms}] at hour {Hour} with ContextKey={ContextKey}",
            profile.OrchestratorType.Name,
            string.Join(", ", profile.SenderPlatforms),
            profile.Hour,
            profile.OrchestratorContextKey ?? "none");

        return ResolveWorkflowOrchestrator(profile, senders);
    }

    private BaseOrchestrator ResolveWorkflowOrchestrator(
        ScheduledOrchestrationProfile profile,
        IReadOnlyList<ISender> senders)
    {
        if (string.IsNullOrWhiteSpace(profile.OrchestratorContextKey))
        {
            _log.LogWarning(
                "Slot at hour {Hour} uses {OrchestratorType} but does not define {ContextKey}. Using {NoOrchestrator}.",
                profile.Hour,
                nameof(WorkflowOrchestrator),
                nameof(ScheduledOrchestrationProfile.OrchestratorContextKey),
                nameof(NoOrchestrator));
            return CreateEmptyNoOrchestrator();
        }

        var workflowDefinition = _serviceProvider.GetKeyedService<WorkflowDefinition>(profile.OrchestratorContextKey);
        if (workflowDefinition is null)
        {
            _log.LogWarning(
                "No {WorkflowDefinition} is registered for key '{ContextKey}'. Using {NoOrchestrator}.",
                nameof(WorkflowDefinition),
                profile.OrchestratorContextKey,
                nameof(NoOrchestrator));
            return CreateEmptyNoOrchestrator();
        }

        var logger = _serviceProvider.GetRequiredService<ILogger<WorkflowOrchestrator>>();
        return new WorkflowOrchestrator(senders, logger, _workflowEngine, workflowDefinition);
    }

    private BaseOrchestrator CreateEmptyNoOrchestrator()
    {
        var logger = _serviceProvider.GetRequiredService<ILogger<NoOrchestrator>>();
        return new NoOrchestrator(logger);
    }

    private IEnumerable<ISender> ResolveSenders(SenderPlatform platform)
    {
        try
        {
            var sender = _serviceProvider.GetKeyedService<ISender>(platform);
            if (sender == null)
            {
                _log.LogWarning("No sender registered for platform {Platform}", platform);
            }
            return sender == null ? Array.Empty<ISender>() : new[] { sender };
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Error resolving sender for platform {Platform}", platform);
            return Array.Empty<ISender>();
        }
    }
}