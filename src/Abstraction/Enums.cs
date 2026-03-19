namespace XPoster.Abstraction;

/// <summary>
/// Identifies the target social platform and content strategy for a scheduled posting slot.
/// </summary>
public enum MessageSender
{
    /// <summary>No message will be sent during this time slot.</summary>
    NoSend,
    /// <summary>Posts a Bitcoin Power Law update to X (Twitter).</summary>
    XPowerLaw,
    /// <summary>Posts a Bitcoin Power Law update to LinkedIn.</summary>
    InPowerLaw,
    /// <summary>Posts a Bitcoin Power Law update to Instagram.</summary>
    IgPowerLow,
    /// <summary>Posts a news feed summary to X (Twitter).</summary>
    XSummaryFeed,
    /// <summary>Posts a news feed summary to LinkedIn.</summary>
    InSummaryFeed,
    /// <summary>Posts a news feed summary to Instagram.</summary>
    IgSummaryFeed,
}
