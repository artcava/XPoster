using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Provides the shared scaffolding for all content orchestrators: sender list, logger,
/// and a default <see cref="PostAsync"/> implementation with pre-condition guards and
/// parallel fan-out dispatch via <c>Task.WhenAll</c>.
/// Concrete orchestrators inherit from this class and implement <see cref="OrchestrateAsync"/>.
/// </summary>
public abstract class BaseOrchestrator : IOrchestrator
{
    /// <inheritdoc/>
    public abstract string Name { get; }

    /// <inheritdoc/>
    public abstract bool SendIt { get; set; }

    /// <inheritdoc/>
    public abstract bool ProduceImage { get; set; }

    /// <inheritdoc/>
    public abstract IReadOnlyList<SenderPlatform> SupportedPlatforms { get; }

    /// <summary>
    /// The ordered list of senders configured for this orchestration slot.
    /// Senders are ordered by descending <c>MessageMaxLength</c>; index 0 is the primary sender.
    /// </summary>
    protected IReadOnlyList<ISender> _senders { get; }

    /// <summary>
    /// The primary sender (index 0, widest <c>MessageMaxLength</c>).
    /// Used as the reference for base content generation in concrete orchestrators.
    /// Returns <c>null</c> when the sender list is empty.
    /// </summary>
    protected ISender? _sender => _senders.Count > 0 ? _senders[0] : null;

    /// <summary>The logger instance used by this orchestrator for diagnostic output.</summary>
    protected ILogger _logger { get; }

    /// <summary>
    /// Initialises a new instance of <see cref="BaseOrchestrator"/> with an ordered sender list and logger.
    /// </summary>
    /// <param name="senders">
    /// Ordered list of senders for this slot, by descending <c>MessageMaxLength</c>.
    /// The first sender drives base content generation.
    /// </param>
    /// <param name="logger">Logger instance for diagnostic output.</param>
    protected BaseOrchestrator(IReadOnlyList<ISender> senders, ILogger logger)
    {
        _senders = senders;
        _logger = logger;
    }

    /// <inheritdoc/>
    public abstract Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct = default);

    /// <summary>
    /// Dispatches each post to the sender whose <see cref="ISender.Platform"/> matches the dictionary key,
    /// in parallel via <c>Task.WhenAll</c>.
    /// A <c>null</c> post causes that sender to be skipped with a warning.
    /// A sender whose platform has no entry in <paramref name="posts"/> is skipped with a warning.
    /// </summary>
    /// <param name="posts">Map of platform → post, as returned by <see cref="OrchestrateAsync"/>.</param>
    /// <param name="ct">Cancellation token to signal operation cancellation.</param>
    /// <returns><c>true</c> only if all dispatched senders succeed; otherwise <c>false</c>.</returns>
    public virtual async Task<bool> PostAsync(IReadOnlyDictionary<SenderPlatform, Post?> posts, CancellationToken ct = default)
    {
        if (!SendIt)
        {
            _logger.LogInformation("Orchestrator {Name} cannot orchestrate messages to send", Name);
            return false;
        }

        if (_senders.Count == 0)
        {
            _logger.LogInformation("No sender configured with {Name}", Name);
            return false;
        }

        var results = await Task.WhenAll(_senders.Select(sender =>
        {
            if (!posts.TryGetValue(sender.Platform, out var post))
            {
                _logger.LogWarning(
                    "No post entry found for platform {Platform} in dispatch map — skipping sender {Sender}",
                    sender.Platform, sender.GetType().Name);
                return Task.FromResult(false);
            }
            return DispatchAsync(sender, post, ct);
        }));

        return results.All(r => r);
    }

    private async Task<bool> DispatchAsync(ISender sender, Post? post, CancellationToken ct)
    {
        if (post == null)
        {
            _logger.LogWarning("No post produced for sender {Sender} — skipping", sender.GetType().Name);
            return false;
        }

        if (string.IsNullOrWhiteSpace(post.Content))
        {
            _logger.LogInformation("Empty content for sender {Sender} — skipping", sender.GetType().Name);
            return false;
        }

        if (ProduceImage && post.Image == null)
            _logger.LogWarning("Orchestrator {Name} expected an image but none was produced for sender {Sender}", Name, sender.GetType().Name);

        var ok = await sender.SendAsync(post, ct);
        _logger.LogInformation("Sender {Sender} result: {Result}", sender.GetType().Name, ok);
        return ok;
    }
}
