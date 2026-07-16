namespace XPoster.Core.Models;

/// <summary>
/// Carries the data needed to execute a text-to-text prompt step.
/// Constructed by the orchestrator and passed to <see cref="Abstractions.ITextToTextProvider"/>.
/// </summary>
public sealed record PromptRequest
{
    public required string InputText { get; init; }
    public required string SystemPromptTemplate { get; init; }
    public required string UserPromptTemplate { get; init; }
    public double? Temperature { get; init; }
    public int? MaxOutputLength { get; init; }
    public int? MaxTokenBudget { get; init; }
    public string? InputTextLabel { get; init; }
}

/// <summary>
/// Extends <see cref="PromptRequest"/> with image-generation parameters.
/// Constructed by the orchestrator and passed to <see cref="Abstractions.ITextToImageProvider"/>.
/// </summary>
public sealed record ImagePromptRequest : PromptRequest
{
    public int? ImageQuantity { get; init; }
    public string? ImageSize { get; init; }
}
