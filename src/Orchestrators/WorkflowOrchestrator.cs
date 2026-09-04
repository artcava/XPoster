using Microsoft.Extensions.Logging;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Engine;
using XPoster.Workflows.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Bridges the DAG workflow engine to the legacy <see cref="IOrchestrator"/> contract.
/// Executes a <see cref="WorkflowDefinition"/> via <see cref="IWorkflowEngine"/> and extracts
/// the final <see cref="SenderPlatform"/> → <see cref="Post"/> map from
/// <see cref="WorkflowContextKeys.SendResults"/>. On workflow failure it returns an empty map
/// so callers never crash.
/// </summary>
public class WorkflowOrchestrator : BaseOrchestrator
{
    private readonly IWorkflowEngine _workflowEngine;
    private readonly WorkflowDefinition _workflowDefinition;
    private bool _sendIt = true;

    /// <inheritdoc/>
    public override string Name => "WorkflowOrchestrator";

    /// <inheritdoc/>
    public override bool SendIt
    {
        get => _sendIt;
        set => _sendIt = value;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Derived from the workflow DAG: an image is expected only when the workflow
    /// contains an <c>AiImage</c> node. Not directly assignable.
    /// </remarks>
    public override bool ProduceImage
    {
        get => _workflowDefinition.Nodes.Any(n => n.Type == "AiImage");
        set => throw new NotSupportedException("ProduceImage is derived from the workflow DAG and cannot be set directly.");
    }

    /// <inheritdoc/>
    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        new List<SenderPlatform>
        {
            SenderPlatform.X,
            SenderPlatform.LinkedIn,
            SenderPlatform.Instagram,
            SenderPlatform.Facebook,
        }.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkflowOrchestrator"/> class.
    /// </summary>
    /// <param name="senders">Ordered list of senders for this slot, by descending <c>MessageMaxLength</c>.</param>
    /// <param name="logger">Logger for diagnostic output.</param>
    /// <param name="workflowEngine">The workflow DAG engine.</param>
    /// <param name="workflowDefinition">The workflow definition bound to this slot.</param>
    public WorkflowOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<WorkflowOrchestrator> logger,
        IWorkflowEngine workflowEngine,
        WorkflowDefinition workflowDefinition)
        : base(senders, logger)
    {
        _workflowEngine = workflowEngine;
        _workflowDefinition = workflowDefinition;
    }

    /// <inheritdoc/>
    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct = default)
    {
        var result = await _workflowEngine.ExecuteAsync(_workflowDefinition, _senders, ct);

        if (!result.Success)
        {
            _logger.LogError(
                "[WorkflowOrchestrator] Workflow '{SlotKey}' failed: {Error}",
                _workflowDefinition.SlotKey,
                result.ErrorMessage);
            _sendIt = false;
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
        }

        if (result.Context.TryGetData<Dictionary<SenderPlatform, Post?>>(WorkflowContextKeys.SendResults, out var postMap))
        {
            return postMap!.AsReadOnly();
        }

        _logger.LogError(
            "[WorkflowOrchestrator] Workflow '{SlotKey}' completed without {Key} in context. Nothing will be dispatched.",
            _workflowDefinition.SlotKey,
            WorkflowContextKeys.SendResults);
        _sendIt = false;
        return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
    }
}
