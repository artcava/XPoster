using XPoster.Workflows.Models;

namespace XPoster.Workflows.Services;

/// <summary>
/// Resolves prompt configuration for a workflow step by step identifier.
/// Replaces the legacy <c>FeedPromptOptions.GetStep(PromptRole)</c> lookup.
/// </summary>
public interface IStepOptionsResolver
{
    /// <summary>
    /// Resolves the prompt options for the given step identifier.
    /// </summary>
    /// <param name="stepId">The step identifier (e.g., <c>"Feed.Summary"</c>).</param>
    /// <returns>The resolved prompt options.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the step configuration is missing.</exception>
    PromptStepOptions Resolve(string stepId);
}