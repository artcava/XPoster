namespace XPoster.SenderPlugins;

/// <summary>
/// Configuration entry for a single dry-run sender under the <c>DryRunSenders</c> section.
/// </summary>
public sealed record DryRunSenderOptions
{
    /// <summary>
    /// The maximum number of characters allowed for a post on this dry-run sender.
    /// Defaults to <see cref="int.MaxValue"/> (unlimited) when unspecified.
    /// </summary>
    public int MaxLength { get; init; } = int.MaxValue;
}