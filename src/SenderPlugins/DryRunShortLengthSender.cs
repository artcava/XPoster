using Microsoft.Extensions.Configuration;
using XPoster.Contracts;

namespace XPoster.SenderPlugins;

/// <summary>
/// A no-op dry-run sender with a short fixed post length (<see cref="ShortLength"/>),
/// for local integration testing. Logs post output without publishing.
/// </summary>
public sealed class DryRunShortLengthSender : DryRunSender
{
    /// <summary>The fixed maximum post length for <see cref="DryRunShortLengthSender"/>.</summary>
    public const int ShortLength = 250;

    /// <summary>Initialises a new instance of <see cref="DryRunShortLengthSender"/>.</summary>
    public DryRunShortLengthSender(IConfiguration configuration, ILogger<DryRunSender> logger)
        : base(configuration, logger, ShortLength)
    {
    }

    /// <inheritdoc/>
    public override SenderPlatform Platform => SenderPlatform.DryRunShortLength;
}
