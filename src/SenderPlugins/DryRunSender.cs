using Microsoft.Extensions.Configuration;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// A no-op sender designed for local integration testing.
/// Verifies configuration connectivity by checking that a known credential (<c>XApiKey</c>) is non-empty,
/// logs the orchestrated post output, and returns <c>true</c> without making any outbound call to a social platform.
/// </summary>
public class DryRunSender : ISender
{
    private const string ProbeKey = "XApiKey";

    private readonly IConfiguration _configuration;
    private readonly ILogger<DryRunSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="DryRunSender"/> with the default unlimited length.
    /// </summary>
    /// <param name="configuration">The application configuration used to probe credential availability.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public DryRunSender(IConfiguration configuration, ILogger<DryRunSender> logger)
        : this(configuration, logger, int.MaxValue)
    {
    }

    /// <summary>
    /// Initialises a new instance of <see cref="DryRunSender"/> with a specific maximum post length.
    /// </summary>
    /// <param name="configuration">The application configuration used to probe credential availability.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <param name="messageMaxLength">The maximum number of characters allowed for a post on this sender.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public DryRunSender(IConfiguration configuration, ILogger<DryRunSender> logger, int messageMaxLength)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        MessageMaxLength = messageMaxLength;
    }

    /// <inheritdoc/>
    public SenderPlatform Platform => SenderPlatform.DryRun;

    /// <summary>Gets the maximum number of characters allowed per post. Defaults to <see cref="int.MaxValue"/> (unlimited).</summary>
    public int MessageMaxLength { get; }

    /// <summary>
    /// Probes configuration for a known credential, logs the post content and image presence,
    /// and returns <c>true</c> without publishing to any social platform.
    /// Returns <c>false</c> if the post is <c>null</c> or if the probe credential is missing.
    /// </summary>
    /// <param name="post">The post produced by the orchestrator. Must not be <c>null</c>.</param>
    /// <param name="ct">Cancellation token to signal operation cancellation.</param>
    /// <returns>
    /// <c>true</c> when the probe credential is present and the post is valid;
    /// <c>false</c> when <paramref name="post"/> is <c>null</c> or the credential is missing.
    /// </returns>
    public Task<bool> SendAsync(Post post, CancellationToken ct = default)
    {
        if (post == null)
        {
            _logger.LogWarning("[DryRun] Post cannot be null");
            return Task.FromResult(false);
        }

        var probeValue = _configuration[ProbeKey];
        if (string.IsNullOrWhiteSpace(probeValue))
        {
            _logger.LogError("[DryRun] Configuration probe failed: '{Key}' is missing or empty. " +
                             "Ensure KEYVAULT_URI is set and AddAzureKeyVault is configured.", ProbeKey);
            return Task.FromResult(false);
        }

        _logger.LogInformation("[DryRun] Configuration probe succeeded ('{Key}' is present, length={Length})",
            ProbeKey, probeValue.Length);

        var hasImage = post.Image != null && post.Image.Length > 0;
        _logger.LogInformation(
            "[DryRun] Post content ({CharCount} chars): {Content} | Image: {HasImage}",
            post.Content?.Length ?? 0,
            post.Content,
            hasImage);

        return Task.FromResult(true);
    }
}
