using LinqToTwitter;
using LinqToTwitter.OAuth;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// Publishes posts to X (Twitter) using the LinqToTwitter library with OAuth 1.0a single-user authentication.
/// Credentials are read from environment variables at construction time.
/// </summary>
public class XSender : ISender
{
    private readonly TwitterContext _twitterContext;
    private readonly ILogger<XSender> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="XSender"/>, configuring OAuth credentials
    /// from the <c>X_API_KEY</c>, <c>X_API_SECRET</c>, <c>X_ACCESS_TOKEN</c>,
    /// and <c>X_ACCESS_TOKEN_SECRET</c> environment variables.
    /// </summary>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="logger"/> is <c>null</c>.</exception>
    public XSender(ILogger<XSender> logger)
    {
        _logger = logger ?? throw new ArgumentNullException("logger");
        var auth = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = Environment.GetEnvironmentVariable("X_API_KEY"),
                ConsumerSecret = Environment.GetEnvironmentVariable("X_API_SECRET"),
                AccessToken = Environment.GetEnvironmentVariable("X_ACCESS_TOKEN"),
                AccessTokenSecret = Environment.GetEnvironmentVariable("X_ACCESS_TOKEN_SECRET")
            }
        };
        _twitterContext = new TwitterContext(auth);
    }

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
            var postText = post.Content + Post.Firm;
            var tweetId = string.Empty;

            if (post.Image != null && post.Image.Length > 0)
            {
                var media = await _twitterContext.UploadMediaAsync(post.Image, "image/jpeg", "tweet_image");

                if (media == null) throw new Exception("Error uploading media");

                var imageTweet = await _twitterContext.TweetMediaAsync(
                    text: postText,
                    mediaIds: new List<string> { media.MediaID.ToString() }
                );
                if (imageTweet == null) throw new Exception("Error tweeting");

                tweetId = imageTweet.ID;
            }
            else
            {
                var tweet = await _twitterContext.TweetAsync(postText);

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
