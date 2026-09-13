using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// Publishes posts to X (Twitter) using direct HTTP calls signed with OAuth 1.0a.
/// All outbound traffic is routed through <see cref="XApiClient"/>, which uses the
/// resilient <c>"X"</c> named <see cref="HttpClient"/>.
/// </summary>
public class XSender : ISender
{
    private readonly XApiClient _apiClient;
    private readonly ILogger<XSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="XSender"/>.
    /// </summary>
    /// <param name="apiClient">The X API client used to publish tweets and upload media.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public XSender(XApiClient apiClient, ILogger<XSender> logger)
    {
        ArgumentNullException.ThrowIfNull(apiClient);
        _apiClient = apiClient;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public SenderPlatform Platform => SenderPlatform.X;

    /// <summary>Gets the maximum number of characters allowed per tweet (250, leaving room for the firm footer).</summary>
    public int MessageMaxLength => 250;

    /// <summary>
    /// Publishes <paramref name="post"/> as a tweet. If an image is attached, it is uploaded
    /// first and the tweet is created with the resulting media ID.
    /// </summary>
    /// <param name="post">The post to publish. Must not be <c>null</c> and must have non-empty content.</param>
    /// <param name="ct">Cancellation token to signal operation cancellation.</param>
    /// <returns><c>true</c> if the tweet was published successfully; otherwise <c>false</c>.</returns>
    public async Task<bool> SendAsync(Post post, CancellationToken ct = default)
    {
        if (post == null)
        {
            _logger.LogWarning("[XSender] Post is null. Skipping.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(post.Content))
        {
            _logger.LogWarning("[XSender] Post content cannot be empty. Skipping.");
            return false;
        }

        try
        {
            var postText = post.Content + Post.Firm;
            string tweetId;

            if (post.Image is { Length: > 0 })
            {
                var mediaId = await _apiClient.UploadMediaAsync(post.Image, "image/jpeg", ct);
                tweetId = await _apiClient.CreateTweetAsync(postText, mediaId, ct);
            }
            else
            {
                tweetId = await _apiClient.CreateTweetAsync(postText, mediaId: null, ct);
            }

            _logger.LogInformation("[XSender] Published tweet: (ID: {TweetId})", tweetId);
            return true;
        }
        catch (XApiException ex)
        {
            _logger.LogError(
                ex,
                "[XSender] X API error — status {StatusCode}, label {Label}, detail {Detail}",
                ex.StatusCode,
                ex.ErrorInfo?.Label,
                ex.ErrorInfo?.Detail);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[XSender] {Message}", ex.Message);
            return false;
        }
    }
}