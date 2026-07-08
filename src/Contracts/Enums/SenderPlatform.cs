namespace XPoster.Contracts;

/// <summary>
/// Identifies the target social platform for a scheduled posting slot.
/// </summary>
public enum SenderPlatform
{
    /// <summary>Posts to X (Twitter).</summary>
    X,
    /// <summary>Posts to LinkedIn.</summary>
    LinkedIn,
    /// <summary>Posts to Instagram.</summary>
    Instagram,
    /// <summary>Dry-run sender for local integration testing. Logs post output without publishing.</summary>
    DryRun,
}