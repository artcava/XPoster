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
    /// <summary>Posts to Facebook.</summary>
    Facebook,
    /// <summary>Dry-run sender with an unlimited post length, for local integration testing. Logs post output without publishing.</summary>
    DryRunMaxLength,
    /// <summary>Dry-run sender with a short fixed post length, for local integration testing. Logs post output without publishing.</summary>
    DryRunShortLength,
}