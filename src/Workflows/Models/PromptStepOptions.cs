namespace XPoster.Workflows.Models;

/// <summary>
/// Prompt configuration for a single workflow step, resolved by <c>IStepOptionsResolver</c>
/// from the <c>PromptSteps:{{StepId}}</c> configuration section.
/// </summary>
public sealed record PromptStepOptions
{
    /// <summary>Gets the system-level prompt template.</summary>
    public required string SystemPromptTemplate { get; init; }

    /// <summary>Gets the user-level prompt template.</summary>
    public required string UserPromptTemplate { get; init; }

    /// <summary>Gets the sampling temperature, or <c>null</c> to use the provider default.</summary>
    public double? Temperature { get; init; }

    /// <summary>Gets the maximum number of output characters, or <c>null</c>.</summary>
    public int? MaxOutputLength { get; init; }

    /// <summary>Gets the maximum token budget for the call, or <c>null</c>.</summary>
    public int? MaxTokenBudget { get; init; }

    /// <summary>Gets the label placed around the input text in templates, or <c>null</c>.</summary>
    public string? InputTextLabel { get; init; }

    /// <summary>Gets the number of images to generate (image steps only), or <c>null</c>.</summary>
    public int? ImageQuantity { get; init; }

    /// <summary>Gets the requested image size (image steps only), or <c>null</c>.</summary>
    public string? ImageSize { get; init; }
}