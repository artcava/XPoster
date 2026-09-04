using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Engine;
using XPoster.Workflows.Nodes;
using XPoster.Workflows.Services;

namespace XPoster.Workflows.Configuration;

/// <summary>
/// DI registration helpers for the workflow engine and its keyed adapter nodes.
/// </summary>
public static class WorkflowServiceCollectionExtensions
{
    /// <summary>
    /// Registers the workflow engine, step-options resolver, the built-in keyed adapter nodes,
    /// and each slot's <see cref="WorkflowDefinition"/> from the <c>Workflows</c> configuration section.
    /// </summary>
    /// <param name="services">The service collection to register onto.</param>
    /// <param name="configuration">Application configuration containing the <c>Workflows</c> section.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddWorkflows(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IStepOptionsResolver, ConfigurationStepOptionsResolver>();
        services.AddTransient<IWorkflowEngine, WorkflowExecutionEngine>();

        services.AddKeyedTransient<IWorkflowNode, FetchRssNode>("FetchRss");
        services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
        services.AddKeyedTransient<IWorkflowNode, AiImageNode>("AiImage");
        services.AddKeyedTransient<IWorkflowNode, FanOutSendNode>("FanOutSend");

        var workflowsSection = configuration.GetSection("Workflows");
        foreach (var slotSection in workflowsSection.GetChildren())
        {
            var slotKey = slotSection.Key;
            var options = slotSection.Get<WorkflowDefinitionOptions>();
            if (options is null)
                continue;

            var definition = options.ToDefinition(slotKey);
            var validationError = WorkflowDefinitionValidator.ValidateStructural(definition);
            if (validationError != null)
            {
                throw new InvalidOperationException(
                    $"Workflow '{slotKey}' is invalid: {validationError}");
            }

            services.AddKeyedSingleton<WorkflowDefinition>(slotKey, definition);
        }

        return services;
    }
}