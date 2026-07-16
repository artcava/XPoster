namespace XPoster.Models;

/// <summary>
/// Configuration for a single prompt step identified by <see cref="PromptRole"/>.
/// </summary>
/// <remarks>
/// <para>
/// For the <see cref="PromptRole.Summary"/> step, <see cref="MaxOutputLength"/> is
/// <em>not</em> set in configuration — it is resolved at runtime from
/// <c>ISender.MessageMaxLength</c> of the target sender.
/// </para>
/// <para>
/// <see cref="ImageQuantity"/> and <see cref="ImageSize"/> are only relevant for
/// the <see cref="PromptRole.ImageGeneration"/> step.
/// </para>
/// </remarks>
public sealed record PromptStepOptions
{
    /// <summary>
    /// The role of this prompt step within the orchestration flow.
    /// </summary>
    public required PromptRole Role { get; init; }
    /// <summary>
    /// The system prompt template to use for this step.
    /// </summary>
    public required string SystemPromptTemplate { get; init; }
    /// <summary>
    /// The user prompt template to use for this step.
    /// </summary>
    public required string UserPromptTemplate { get; init; }
    /// <summary>
    /// The temperature to use for this step.
    /// </summary>
    public double? Temperature { get; init; }
    /// <summary>
    /// The maximum output length to use for this step.
    /// </summary>
    public int? MaxOutputLength { get; init; }
    /// <summary>
    /// The maximum token budget to use for this step.
    /// </summary>
    public int? MaxTokenBudget { get; init; }
    /// <summary>
    /// The label for the input text, used for substitutions in the prompt templates. Optional; if not provided, a default label will be used.
    /// </summary>
    public string? InputTextLabel { get; init; }
    /// <summary>
    /// The number of images to generate. Optional; if not provided, a default value will be used.
    /// </summary>
    public int? ImageQuantity { get; init; }
    /// <summary>
    /// The size of the generated images. Optional; if not provided, a default value will be used.
    /// </summary>
    public string? ImageSize { get; init; }
}
