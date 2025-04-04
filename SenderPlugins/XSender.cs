using LinqToTwitter;
using LinqToTwitter.OAuth;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPoster.Abstraction;

namespace XPoster.SenderPlugins
{
    public class XSender : ISender
    {
        private readonly TwitterContext _twitterContext;
        private readonly ILogger _logger;
        public XSender(ILogger log) 
        {
            _logger = log;
            // Configure credentials
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

        public int MessageMaxLenght => 280;

        public async Task<bool> SendAsync(Message message)
        {
            try
            {
                var postText = message.Content + message.Firm;

                var tweetId = string.Empty;

                if (message.Image.Length > 0)
                {
                    var media = await _twitterContext.UploadMediaAsync(message.Image, "image/jpeg", "tweet_image");

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
}
