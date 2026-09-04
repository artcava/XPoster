using Microsoft.Extensions.DependencyInjection;
using XPoster.Workflows.Abstractions;

namespace XPoster.Workflows.Engine;

/// <summary>
/// Static validator for <see cref="WorkflowDefinition"/> instances.
/// Structural validation (cycles, dangling refs, exactly one terminal) runs at
/// registration time; the <see cref="ITerminalNode"/> type check runs at execution time
/// when node instances are available via DI.
/// </summary>
public static class WorkflowDefinitionValidator
{
    /// <summary>
    /// Validates the structural integrity of the DAG: no missing node references,
    /// no cycles, and exactly one terminal node (a node with an empty <c>NextNodeIds</c>).
    /// </summary>
    /// <param name="definition">The workflow definition to validate.</param>
    /// <returns>An error message when invalid; <c>null</c> when valid.</returns>
    public static string? ValidateStructural(WorkflowDefinition definition)
    {
        if (definition.Nodes.Count == 0)
            return null;

        var nodeMap = definition.Nodes.ToDictionary(n => n.Id);

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

        var terminalNodes = definition.Nodes.Where(n => n.NextNodeIds.Count == 0).ToList();
        if (terminalNodes.Count == 0)
            return $"Workflow '{definition.SlotKey}' has no terminal node (a node with an empty NextNodeIds list).";
        if (terminalNodes.Count > 1)
            return $"Workflow '{definition.SlotKey}' has {terminalNodes.Count} terminal nodes ({string.Join(", ", terminalNodes.Select(n => $"'{n.Id}'"))}). Exactly one is required.";

        return null;
    }

    /// <summary>
    /// Validates that the terminal node of the DAG implements <see cref="ITerminalNode"/>.
    /// Requires DI to resolve the node instance.
    /// </summary>
    /// <param name="definition">The workflow definition to validate.</param>
    /// <param name="serviceProvider">DI service provider to resolve node instances.</param>
    /// <returns>An error message when invalid; <c>null</c> when valid.</returns>
    public static string? ValidateTerminalNodeContract(WorkflowDefinition definition, IServiceProvider serviceProvider)
    {
        var terminalNodeDef = definition.Nodes.FirstOrDefault(n => n.NextNodeIds.Count == 0);
        if (terminalNodeDef == null)
            return null;

        var nodeInstance = serviceProvider.GetKeyedService<IWorkflowNode>(terminalNodeDef.Type);
        if (nodeInstance == null)
            return null;

        if (nodeInstance is not ITerminalNode)
            return $"Terminal node '{terminalNodeDef.Id}' (type '{terminalNodeDef.Type}') does not implement ITerminalNode. All workflow terminal nodes must implement the ITerminalNode contract.";

        return null;
    }
}