using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Carries the data needed to execute a text-to-text prompt step.
/// Constructed by the orchestrator and passed to <see cref="ITextToTextProvider"/>.
/// </summary>
public record PromptRequest
{
    /// <summary>
    /// The input text to be processed by the provider. 
    /// </summary>
    public required string InputText { get; init; }
    /// <summary>
    /// The system prompt template to be used by the provider.
    /// </summary>
    public required string SystemPromptTemplate { get; init; }
    /// <summary>
    /// The user prompt template to be used by the provider.
    /// </summary>
    public required string UserPromptTemplate { get; init; }
    /// <summary>
    /// The temperature to be used by the provider.
    /// </summary>
    public double? Temperature { get; init; }
    /// <summary>
    /// The maximum output length to be used by the provider.
    /// </summary>
    public int? MaxOutputLength { get; init; }
    /// <summary>
    /// The maximum token budget to be used by the provider.
    /// </summary>
    public int? MaxTokenBudget { get; init; }
    /// <summary>
    /// The label for the input text, used for substitutions in the prompt templates. Optional; if not provided, a default label will be used.
    /// </summary>
    public string? InputTextLabel { get; init; }
}

/// <summary>
/// Extends <see cref="PromptRequest"/> with image-generation parameters.
/// Constructed by the orchestrator and passed to <see cref="ITextToImageProvider"/>.
/// </summary>
public record ImagePromptRequest : PromptRequest
{
    /// <summary>
    /// The number of images to generate. Optional; if not provided, a default value will be used.
    /// </summary>
    public int? ImageQuantity { get; init; }
    /// <summary>
    /// The size of the generated images. Optional; if not provided, a default value will be used.
    /// </summary>
    public string? ImageSize { get; init; }
}
