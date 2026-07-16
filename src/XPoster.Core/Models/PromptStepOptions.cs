namespace XPoster.Core.Models;

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
    public required PromptRole Role { get; init; }
    public required string SystemPromptTemplate { get; init; }
    public required string UserPromptTemplate { get; init; }
    public double? Temperature { get; init; }
    public int? MaxOutputLength { get; init; }
    public int? MaxTokenBudget { get; init; }
    public string? InputTextLabel { get; init; }
    public int? ImageQuantity { get; init; }
    public string? ImageSize { get; init; }
}
