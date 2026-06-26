namespace XPoster.Contracts;

/// <summary>
/// Identifies the target social platform for a scheduled posting slot.
/// Replaces <see cref="MessageSender"/> which coupled platform identity to orchestrator identity.
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

/// <summary>
/// Legacy enum kept temporarily for migration safety.
/// All production code must use <see cref="SenderPlatform"/> instead.
/// </summary>
[Obsolete("Use SenderPlatform instead. MessageSender will be removed once all references are migrated.")]
public enum MessageSender
{
    /// <summary>No message will be sent during this time slot.</summary>
    NoSend,
    /// <summary>Posts a Bitcoin Power Law update to X (Twitter).</summary>
    XPowerLaw,
    /// <summary>Posts a Bitcoin Power Law update to LinkedIn.</summary>
    InPowerLaw,
    /// <summary>Posts a Bitcoin Power Law update to Instagram.</summary>
    IgPowerLaw,
    /// <summary>Posts a news feed summary to X (Twitter).</summary>
    XSummaryFeed,
    /// <summary>Posts a news feed summary to LinkedIn.</summary>
    InSummaryFeed,
    /// <summary>Posts a news feed summary to Instagram.</summary>
    IgSummaryFeed,
    /// <summary>Dry-run sender for local integration testing. Logs post output without publishing.</summary>
    DryRunSend,
}
