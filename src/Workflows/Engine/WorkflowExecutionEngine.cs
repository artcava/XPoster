using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;

namespace XPoster.Workflows.Engine;

/// <summary>
/// Default <see cref="IWorkflowEngine"/> implementation.
/// Executes nodes in topological order (Kahn's algorithm) after validating
/// the DAG for cycles and missing node references.
/// </summary>
public class WorkflowExecutionEngine : IWorkflowEngine
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WorkflowExecutionEngine> _logger;

    /// <summary>Initializes a new instance of the <see cref="WorkflowExecutionEngine"/> class.</summary>
    public WorkflowExecutionEngine(IServiceProvider serviceProvider, ILogger<WorkflowExecutionEngine> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<WorkflowExecutionResult> ExecuteAsync(
        WorkflowDefinition definition,
        IReadOnlyList<ISender> senders,
        CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(definition);

        var context = new WorkflowContext { SlotKey = definition.SlotKey };
        var nodeMap = definition.Nodes.ToDictionary(n => n.Id);

        var validationError = ValidateDag(definition, nodeMap);
        if (validationError != null)
        {
            _logger.LogError("Workflow '{SlotKey}' validation failed: {Error}", definition.SlotKey, validationError);
            return new WorkflowExecutionResult(false, context, validationError);
        }

        var inDegree = definition.Nodes.ToDictionary(n => n.Id, _ => 0);
        foreach (var node in definition.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (inDegree.ContainsKey(nextId))
                    inDegree[nextId]++;
            }
        }

        var readyNodes = new Queue<string>(inDegree.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key));

        while (readyNodes.Count > 0)
        {
            if (ct.IsCancellationRequested)
            {
                return new WorkflowExecutionResult(false, context, $"Workflow '{definition.SlotKey}' cancelled.");
            }

            var currentNodeId = readyNodes.Dequeue();
            var nodeDef = nodeMap[currentNodeId];

            _logger.LogInformation(
                "Executing node '{NodeId}' of type '{NodeType}' for slot '{SlotKey}'",
                nodeDef.Id, nodeDef.Type, definition.SlotKey);

            var nodeInstance = _serviceProvider.GetKeyedService<IWorkflowNode>(nodeDef.Type);
            if (nodeInstance == null)
            {
                return new WorkflowExecutionResult(false, context, $"No IWorkflowNode registered with key '{nodeDef.Type}'.");
            }

            var input = new WorkflowNodeInput(context, nodeDef.Parameters, senders);
            var result = await nodeInstance.ExecuteAsync(input, ct);

            if (!result.Success)
            {
                _logger.LogError("Node '{NodeId}' failed: {Error}", nodeDef.Id, result.ErrorMessage);
                return new WorkflowExecutionResult(false, context, result.ErrorMessage);
            }

            if (!string.IsNullOrEmpty(nodeDef.OutputKey) && result.Output != null)
            {
                context.SetData(nodeDef.OutputKey, result.Output);
            }

            foreach (var nextId in nodeDef.NextNodeIds)
            {
                inDegree[nextId]--;
                if (inDegree[nextId] == 0)
                {
                    readyNodes.Enqueue(nextId);
                }
            }
        }

        return new WorkflowExecutionResult(true, context, null);
    }

    /// <summary>
    /// Validates the DAG for missing node references and cycles.
    /// </summary>
    /// <returns>An error message when invalid, or <c>null</c> when valid.</returns>
    private static string? ValidateDag(WorkflowDefinition definition, Dictionary<string, WorkflowNodeDefinition> nodeMap)
    {
        if (definition.Nodes.Count == 0)
            return null;

        foreach (var node in definition.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (!nodeMap.ContainsKey(nextId))
                    return $"Node '{node.Id}' references non-existent node '{nextId}'.";
            }
        }

        var visited = new HashSet<string>();
        var inStack = new HashSet<string>();

        bool HasCycle(string nodeId)
        {
            if (inStack.Contains(nodeId)) return true;
            if (visited.Contains(nodeId)) return false;

            visited.Add(nodeId);
            inStack.Add(nodeId);

            if (nodeMap.TryGetValue(nodeId, out var nodeDef))
            {
                foreach (var nextId in nodeDef.NextNodeIds)
                {
                    if (HasCycle(nextId)) return true;
                }
            }

            inStack.Remove(nodeId);
            return false;
        }

        foreach (var nodeId in nodeMap.Keys)
        {
            if (HasCycle(nodeId))
                return $"Cycle detected involving node '{nodeId}'.";
        }

        return null;
    }
}