using Microsoft.Extensions.Configuration;
using XPoster.Contracts;

namespace XPoster.SenderPlugins;

/// <summary>
/// Reads the configured dry-run senders from the <c>DryRunSenders</c> configuration section
/// and materialises them as no-op <see cref="DryRunSender"/> instances.
/// </summary>
public sealed class DryRunSenderSource : IDryRunSenderSource
{
    private const string SectionName = "DryRunSenders";

    private readonly IConfiguration _configuration;
    private readonly ILogger<DryRunSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="DryRunSenderSource"/>.
    /// </summary>
    /// <param name="configuration">Configuration containing the <c>DryRunSenders</c> section.</param>
    /// <param name="logger">Logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public DryRunSenderSource(IConfiguration configuration, ILogger<DryRunSender> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public IReadOnlyList<ISender> Resolve()
    {
        var entries = _configuration.GetSection(SectionName).Get<List<DryRunSenderOptions>>();
        if (entries == null || entries.Count == 0)
        {
            _logger.LogInformation(
                "No '{Section}' configuration found — using a single unlimited dry-run sender.",
                SectionName);
            return new List<ISender> { new DryRunSender(_configuration, _logger) }.AsReadOnly();
        }

        var senders = entries
            .Select(e => new DryRunSender(_configuration, _logger, Math.Max(0, e.MaxLength)))
            .OrderByDescending(s => s.MessageMaxLength)
            .Cast<ISender>()
            .ToList()
            .AsReadOnly();

        _logger.LogInformation(
            "Dry-run fan-out configured with {Count} senders: [{Limits}].",
            senders.Count,
            string.Join(", ", senders.Select(s => s.MessageMaxLength)));

        return senders;
    }
}