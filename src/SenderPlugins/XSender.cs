using LinqToTwitter;
using LinqToTwitter.OAuth;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// Publishes posts to X (Twitter) using the LinqToTwitter library with OAuth 1.0a single-user authentication.
/// Credentials are resolved from <see cref="XCredentials"/> bound via the Azure Key Vault Configuration Provider.
/// A <see cref="TwitterContext"/> is rebuilt per invocation.
/// </summary>
public class XSender : ISender
{
    private readonly XCredentials _creds;
    private readonly ILogger<XSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="XSender"/>.
    /// </summary>
    /// <param name="credentials">Typed X credentials resolved from configuration.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public XSender(IOptions<XCredentials> credentials, ILogger<XSender> logger)
    {
        ArgumentNullException.ThrowIfNull(credentials);
        _creds = credentials.Value;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public SenderPlatform Platform => SenderPlatform.X;

    /// <summary>Gets the maximum number of characters allowed per tweet (250, leaving room for the firm footer).</summary>
    public int MessageMaxLenght => 250;

    /// <summary>
    /// Publishes <paramref name="post"/> as a tweet. If an image is attached, it is uploaded
    /// first and the tweet is created with the resulting media ID.
    /// </summary>
    /// <param name="post">The post to publish. Must not be <c>null</c> and must have non-empty content.</param>
    /// <returns><c>true</c> if the tweet was published successfully; otherwise <c>false</c>.</returns>
    public async Task<bool> SendAsync(Post post)
    {
        if (post == null)
        {
            _logger.LogWarning("Post cannot be null");
            return false;
        }

        if (string.IsNullOrWhiteSpace(post.Content))
        {
            _logger.LogWarning("Post content cannot be empty");
            return false;
        }

        try
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = _creds.XApiKey,
                    ConsumerSecret = _creds.XApiSecret,
                    AccessToken = _creds.XAccessToken,
                    AccessTokenSecret = _creds.XAccessTokenSecret
                }
            };
            using var twitterContext = new TwitterContext(auth);

            var postText = post.Content + Post.Firm;
            var tweetId = string.Empty;

            if (post.Image != null && post.Image.Length > 0)
            {
                var media = await twitterContext.UploadMediaAsync(post.Image, "image/jpeg", "tweet_image");

                if (media == null) throw new Exception("Error uploading media");

                var imageTweet = await twitterContext.TweetMediaAsync(
                    text: postText,
                    mediaIds: new List<string> { media.MediaID.ToString() }
                );
                if (imageTweet == null) throw new Exception("Error tweeting");

                tweetId = imageTweet.ID;
            }
            else
            {
                var tweet = await twitterContext.TweetAsync(postText);

                if (tweet == null) throw new Exception("Error tweeting");

                tweetId = tweet.ID;
            }

            _logger.LogInformation("Published tweet: (ID: {0})", tweetId);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }
}
