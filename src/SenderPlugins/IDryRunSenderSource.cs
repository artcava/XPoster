using XPoster.Contracts;

namespace XPoster.SenderPlugins;

/// <summary>
/// Builds the ordered set of dry-run senders for a dry-run slot.
/// The dry-run slot can fan out to several no-op senders with distinct
/// <see cref="ISender.MessageMaxLength"/> values to exercise the per-sender
/// re-summarisation path in <c>FanOutSendNode</c> without publishing anywhere.
/// </summary>
public interface IDryRunSenderSource
{
    /// <summary>
    /// Returns the configured dry-run senders, ordered by descending
    /// <see cref="ISender.MessageMaxLength"/> (widest first, matching the
    /// senders-by-declaration-order convention used by the orchestration slots).
    /// When no dry-run sender configuration is present, a single unlimited sender
    /// is returned as a fallback.
    /// </summary>
    IReadOnlyList<ISender> Resolve();
}