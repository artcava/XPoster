using Microsoft.Extensions.Configuration;
using XPoster.Contracts;

namespace XPoster.SenderPlugins;

/// <summary>
/// A no-op dry-run sender with an unlimited post length (<see cref="int.MaxValue"/>),
/// for local integration testing. Logs post output without publishing.
/// </summary>
public sealed class DryRunMaxLengthSender : DryRunSender
{
    /// <summary>Initialises a new instance of <see cref="DryRunMaxLengthSender"/>.</summary>
    public DryRunMaxLengthSender(IConfiguration configuration, ILogger<DryRunSender> logger)
        : base(configuration, logger, int.MaxValue)
    {
    }

    /// <inheritdoc/>
    public override SenderPlatform Platform => SenderPlatform.DryRunMaxLength;
}
