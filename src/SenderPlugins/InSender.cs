using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;

namespace XPoster.SenderPlugins;

/// <summary>
/// Publishes posts to LinkedIn using the LinkedIn UGC Posts API (v2).
/// Supports both text-only posts and posts with an image attachment via the LinkedIn asset upload flow.
/// Credentials are resolved from <see cref="LinkedInCredentials"/> bound via the Azure Key Vault Configuration Provider.
/// </summary>
public class InSender : ISender
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<InSender> _logger;
    private readonly LinkedInCredentials _creds;

    /// <summary>Gets the maximum number of characters allowed in a LinkedIn post caption.</summary>
    public int MessageMaxLenght => 800;

    /// <summary>
    /// Initialises a new instance of <see cref="InSender"/> using an <see cref="IHttpClientFactory"/>-provided
    /// client registered as "LinkedIn", which carries the Polly resilience pipeline.
    /// </summary>
    /// <param name="httpClientFactory">The factory used to create the named "LinkedIn" client.</param>
    /// <param name="credentials">Typed LinkedIn credentials resolved from configuration.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is <c>null</c>.</exception>
    public InSender(IHttpClientFactory httpClientFactory, IOptions<LinkedInCredentials> credentials, ILogger<InSender> logger)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(credentials);
        _creds = credentials.Value;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = httpClientFactory.CreateClient("LinkedIn");
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
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _creds.LinkedInAccessToken);

            var author = ResolveAuthorUrn();
            var postText = post.Content + Post.Firm;
            dynamic postPayload;

            if (post.Image != null && post.Image.Length > 0)
            {
                var initPayload = new
                {
                    registerUploadRequest = new
                    {
                        recipes = new[] { "urn:li:digitalmediaRecipe:feedshare-image" },
                        owner = author,
                        serviceRelationships = new[]
                        {
                            new { relationshipType = "OWNER", identifier = "urn:li:userGeneratedContent" }
                        }
                    }
                };

                var initJson = JsonSerializer.Serialize(initPayload);
                var initContent = new StringContent(initJson, Encoding.UTF8, "application/json");
                var initResponse = await _httpClient.PostAsync("https://api.linkedin.com/v2/assets?action=registerUpload", initContent);

                if (!initResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to initialize image upload: {Response}",
                        await initResponse.Content.ReadAsStringAsync());
                    return false;
                }

                var initData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(await initResponse.Content.ReadAsStringAsync());
                var valueElement = initData?["value"] as JsonElement? ?? throw new InvalidOperationException("Value element missing");

                var uploadMechanism = valueElement.GetProperty("uploadMechanism");
                var mediaUploadRequest = uploadMechanism.GetProperty("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest");

                string uploadUrl = mediaUploadRequest.GetProperty("uploadUrl").GetString()
                    ?? throw new InvalidOperationException("uploadUrl missing in LinkedIn response.");
                string asset = valueElement.GetProperty("asset").GetString()
                    ?? throw new InvalidOperationException("asset missing in LinkedIn response.");

                using (var memoryStream = new MemoryStream(post.Image))
                {
                    var imageContent = new StreamContent(memoryStream);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    var uploadResponse = await _httpClient.PostAsync(uploadUrl, imageContent);

                    if (!uploadResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError("Failed to upload image: {Response}",
                            await uploadResponse.Content.ReadAsStringAsync());
                        return false;
                    }
                }

                postPayload = generatePayLoad(asset, author, postText);
            }
            else
            {
                postPayload = generatePayLoad(null, author, postText);
            }

            var json = JsonSerializer.Serialize(postPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.linkedin.com/v2/ugcPosts", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to post to LinkedIn: {await response.Content.ReadAsStringAsync()}");

            _logger.LogInformation("Post published: {Response}.", await response.Content.ReadAsStringAsync());
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Resolves the LinkedIn author URN from bound credentials.
    /// Returns an organization URN when <see cref="LinkedInCredentials.LinkedInOrgId"/> is present;
    /// otherwise a person URN from <see cref="LinkedInCredentials.LinkedInOwnerCode"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when neither property resolves to a non-empty value.</exception>
    private string ResolveAuthorUrn()
    {
        if (!string.IsNullOrWhiteSpace(_creds.LinkedInOrgId))
            return $"urn:li:organization:{_creds.LinkedInOrgId}";

        if (string.IsNullOrWhiteSpace(_creds.LinkedInOwnerCode))
            throw new InvalidOperationException("Either LinkedInOwnerCode or LinkedInOrgId must be configured.");

        return $"urn:li:person:{_creds.LinkedInOwnerCode}";
    }

    /// <summary>
    /// Builds the LinkedIn UGC post payload, optionally embedding an image asset.
    /// </summary>
    /// <param name="asset">The LinkedIn asset URN of the uploaded image, or <c>null</c> for text-only posts.</param>
    /// <param name="authorUrn">The fully-qualified LinkedIn author URN (person or organization).</param>
    /// <param name="summary">The text body of the post.</param>
    /// <returns>An anonymous object serialisable as a valid LinkedIn UGC post request body.</returns>
    private dynamic generatePayLoad(string? asset, string authorUrn, string summary)
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
            author = authorUrn,
            lifecycleState = "PUBLISHED",
            specificContent,
            visibility
        };
    }
}
