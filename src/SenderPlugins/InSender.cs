using System.Text;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// Publishes posts to LinkedIn using the LinkedIn UGC Posts API (v2).
/// Supports both text-only posts and posts with an image attachment via the LinkedIn asset upload flow.
/// Credentials are read from the <c>IN_ACCESS_TOKEN</c> and <c>IN_OWNER</c> environment variables.
/// </summary>
public class InSender : ISender
{
    private static readonly HttpClient httpClient = new();
    private readonly ILogger<InSender> _logger;

    /// <summary>Gets the maximum number of characters allowed in a LinkedIn post caption.</summary>
    public int MessageMaxLenght => 800;

    /// <summary>
    /// Initialises a new instance of <see cref="InSender"/>, setting the Bearer token
    /// for all outgoing LinkedIn API requests.
    /// </summary>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="logger"/> is <c>null</c>.</exception>
    public InSender(ILogger<InSender> logger)
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("IN_ACCESS_TOKEN"));
        _logger = logger ?? throw new ArgumentNullException("logger");
    }

    /// <summary>
    /// Publishes <paramref name="post"/> to LinkedIn. When an image is present, it is registered
    /// and uploaded via the LinkedIn asset API before the UGC post is created.
    /// </summary>
    /// <param name="post">The post to publish. Must not be <c>null</c> and must have non-empty content.</param>
    /// <returns><c>true</c> if the post was published successfully; otherwise <c>false</c>.</returns>
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
            // CS8600/CS8604: inOwner from env var is nullable — guard before use
            var inOwner = Environment.GetEnvironmentVariable("IN_OWNER")
                ?? throw new InvalidOperationException("IN_OWNER environment variable is not set.");

            var postText = post.Content + Post.Firm;
            dynamic postPayload;

            if (post.Image != null && post.Image.Length > 0)
            {
                var initPayload = new
                {
                    registerUploadRequest = new
                    {
                        recipes = new[] { "urn:li:digitalmediaRecipe:feedshare-image" },
                        owner = $"urn:li:person:{inOwner}",
                        serviceRelationships = new[]
                        {
                            new { relationshipType = "OWNER", identifier = "urn:li:userGeneratedContent" }
                        }
                    }
                };

                var initJson = JsonSerializer.Serialize(initPayload);
                var initContent = new StringContent(initJson, Encoding.UTF8, "application/json");
                var initResponse = await httpClient.PostAsync("https://api.linkedin.com/v2/assets?action=registerUpload", initContent);

                if (!initResponse.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to initialize image upload: {await initResponse.Content.ReadAsStringAsync()}");
                    return false;
                }

                var initData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(await initResponse.Content.ReadAsStringAsync());
                var valueElement = initData?["value"] as JsonElement? ?? throw new InvalidOperationException("Value element missing");

                var uploadMechanism = valueElement.GetProperty("uploadMechanism");
                var mediaUploadRequest = uploadMechanism.GetProperty("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest");

                // CS8602/CS8600: GetString() can return null — guard with null-coalescing throw
                string uploadUrl = mediaUploadRequest.GetProperty("uploadUrl").GetString()
                    ?? throw new InvalidOperationException("uploadUrl missing in LinkedIn response.");
                string asset = valueElement.GetProperty("asset").GetString()
                    ?? throw new InvalidOperationException("asset missing in LinkedIn response.");

                using (var memoryStream = new MemoryStream(post.Image))
                {
                    var imageContent = new StreamContent(memoryStream);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    var uploadResponse = await httpClient.PostAsync(uploadUrl, imageContent);

                    if (!uploadResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Failed to upload image: {await uploadResponse.Content.ReadAsStringAsync()}");
                        return false;
                    }
                }

                postPayload = generatePayLoad(asset, inOwner, postText);
            }
            else
            {
                postPayload = generatePayLoad(null, inOwner, postText);
            }

            var json = JsonSerializer.Serialize(postPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.linkedin.com/v2/ugcPosts", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to post to LinkedIn: {await response.Content.ReadAsStringAsync()}");

            _logger.LogInformation($"Post published: {await response.Content.ReadAsStringAsync()}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Builds the LinkedIn UGC post payload, optionally embedding an image asset.
    /// </summary>
    /// <param name="asset">The LinkedIn asset URN of the uploaded image, or <c>null</c> for text-only posts.</param>
    /// <param name="owner">The LinkedIn person URN of the post author (from <c>IN_OWNER</c>).</param>
    /// <param name="summary">The text body of the post.</param>
    /// <returns>An anonymous object serialisable as a valid LinkedIn UGC post request body.</returns>
    private dynamic generatePayLoad(string? asset, string owner, string summary)
    {
        Dictionary<string, object> specificContent;
        if (string.IsNullOrEmpty(asset))
        {
            specificContent = new Dictionary<string, object>
            {
                {
                    "com.linkedin.ugc.ShareContent",
                    new
                    {
                        shareCommentary = new { text = summary },
                        shareMediaCategory = "NONE"
                    }
                }
            };
        }
        else
        {
            specificContent = new Dictionary<string, object>
            {
                {
                    "com.linkedin.ugc.ShareContent",
                    new
                    {
                        shareCommentary = new { text = summary },
                        shareMediaCategory = "IMAGE",
                        media = new[]
                        {
                            new
                            {
                                status = "READY",
                                media = asset
                            }
                        }
                    }
                }
            };
        }

        var visibility = new Dictionary<string, string>
        {
            { "com.linkedin.ugc.MemberNetworkVisibility", "PUBLIC" }
        };

        return new
        {
            author = $"urn:li:person:{owner}",
            lifecycleState = "PUBLISHED",
            specificContent,
            visibility
        };
    }
}
