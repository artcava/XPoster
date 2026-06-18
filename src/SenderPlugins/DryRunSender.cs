using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// A no-op sender designed for local integration testing.
/// Verifies Key Vault connectivity by probing a known secret, logs the orchestrated post output,
/// and returns <c>true</c> without making any outbound call to a social platform.
/// </summary>
public class DryRunSender : ISender
{
    private const string ProbeSecretName = "XApiKey";

    private readonly IKeyVaultService _keyVaultService;
    private readonly ILogger<DryRunSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="DryRunSender"/>.
    /// </summary>
    /// <param name="keyVaultService">The Key Vault service used to probe connectivity.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public DryRunSender(IKeyVaultService keyVaultService, ILogger<DryRunSender> logger)
    {
        _keyVaultService = keyVaultService ?? throw new ArgumentNullException(nameof(keyVaultService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>Gets the maximum number of characters allowed per post (no real limit; returns <see cref="int.MaxValue"/>).</summary>
    public int MessageMaxLenght => int.MaxValue;

    /// <summary>
    /// Probes Key Vault connectivity, logs the post content and image presence,
    /// and returns <c>true</c> without publishing to any social platform.
    /// Returns <c>false</c> if the post is <c>null</c> or if the Key Vault probe throws.
    /// </summary>
    /// <param name="post">The post produced by the orchestrator. Must not be <c>null</c>.</param>
    /// <returns>
    /// <c>true</c> when the Key Vault probe succeeds and the post is valid;
    /// <c>false</c> when <paramref name="post"/> is <c>null</c> or Key Vault is unreachable.
    /// </returns>
    public async Task<bool> SendAsync(Post post)
    {
        if (post == null)
        {
            _logger.LogWarning("[DryRun] Post cannot be null");
            return false;
        }

        try
        {
            var probeValue = await _keyVaultService.GetSecretAsync(ProbeSecretName);
            _logger.LogInformation("[DryRun] Key Vault probe succeeded (secret '{SecretName}' is reachable, length={Length})",
                ProbeSecretName, probeValue?.Length ?? 0);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[DryRun] Key Vault probe failed for secret '{SecretName}': {Message}",
                ProbeSecretName, ex.Message);
            return false;
        }

        var hasImage = post.Image != null && post.Image.Length > 0;
        _logger.LogInformation(
            "[DryRun] Post content ({CharCount} chars): {Content} | Image: {HasImage}",
            post.Content?.Length ?? 0,
            post.Content,
            hasImage);

        return true;
    }
}
