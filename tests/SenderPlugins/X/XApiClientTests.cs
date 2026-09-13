using System.Net;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;
using XPoster.Credentials;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for <see cref="XApiClient"/> covering the v2 tweet publishing flow, the v1.1
/// chunked media upload flow, OAuth request signing, and X API error-body parsing.
/// </summary>
public class XApiClientTests
{
    private static readonly XCredentials TestCredentials = new()
    {
        XApiKey = "test_key",
        XApiSecret = "test_secret",
        XAccessToken = "test_token",
        XAccessTokenSecret = "test_token_secret"
    };

    private static XApiClient BuildApiClient(StubHttpMessageHandler handler)
        => new(ResilienceTestHelpers.BuildFactory("X", handler), Options.Create(TestCredentials), NullLogger<XApiClient>.Instance);

    private static HttpResponseMessage OkJson(string body)
        => new(HttpStatusCode.OK) { Content = new StringContent(body, Encoding.UTF8, "application/json") };

    [Fact]
    public async Task CreateTweetAsync_WithText_ReturnsTweetId()
    {
        var handler = new StubHttpMessageHandler(_ => OkJson("{\"data\":{\"id\":\"1234567890\"}}"));

        var tweetId = await BuildApiClient(handler).CreateTweetAsync("Hello world", mediaId: null, CancellationToken.None);

        Assert.Equal("1234567890", tweetId);
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Post, request.Message.Method);
        Assert.EndsWith("/2/tweets", request.Message.RequestUri!.AbsoluteUri);
        Assert.StartsWith("OAuth ", request.Message.Headers.GetValues("Authorization").Single());
        Assert.Contains("\"text\":\"Hello world\"", request.Body);
        Assert.DoesNotContain("media", request.Body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload()
    {
        var handler = new StubHttpMessageHandler(_ => OkJson("{\"data\":{\"id\":\"1\"}}"));

        await BuildApiClient(handler).CreateTweetAsync("Hello", "media-123", CancellationToken.None);

        var request = Assert.Single(handler.Requests);
        Assert.Contains("\"media_ids\":[\"media-123\"]", request.Body);
    }

    [Fact]
    public async Task CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails()
    {
        const string errorBody =
            "{\"title\":\"Usage Cap Exceeded\",\"detail\":\"The usage cap was exceeded.\"," +
            "\"type\":\"https://api.twitter.com/2/problems/usage-cap-exceeded\",\"label\":\"usage_cap_exceeded\"}";
        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.PaymentRequired)
        {
            Content = new StringContent(errorBody, Encoding.UTF8, "application/json")
        });

        var ex = await Assert.ThrowsAsync<XApiException>(
            () => BuildApiClient(handler).CreateTweetAsync("Hello", mediaId: null, CancellationToken.None));

        Assert.Equal((int)HttpStatusCode.PaymentRequired, ex.StatusCode);
        Assert.NotNull(ex.ErrorInfo);
        Assert.Equal("Usage Cap Exceeded", ex.ErrorInfo!.Title);
        Assert.Equal("usage_cap_exceeded", ex.ErrorInfo.Label);
        Assert.Contains("The usage cap was exceeded.", ex.Message);
        Assert.Equal(errorBody, ex.ResponseBody);
    }

    [Fact]
    public async Task CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException()
    {
        var handler = new StubHttpMessageHandler(
            _ => OkJson("{\"errors\":[{\"code\":39,\"message\":\"Your credentials do not allow access.\"}]}"));

        var ex = await Assert.ThrowsAsync<XApiException>(
            () => BuildApiClient(handler).CreateTweetAsync("Hello", mediaId: null, CancellationToken.None));

        Assert.Equal((int)HttpStatusCode.OK, ex.StatusCode);
        Assert.Contains("Your credentials do not allow access.", ex.Message);
    }

    [Fact]
    public async Task UploadMediaAsync_SmallImage_UsesInitAppendFinalizeFlow()
    {
        var image = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 };
        var handler = new StubHttpMessageHandler(request =>
        {
            var query = request.RequestUri!.Query;
            if (query.Contains("command=INIT"))
            {
                return OkJson("{\"media_id\":123,\"media_id_string\":\"123\"}");
            }

            if (query.Contains("command=APPEND"))
            {
                return OkJson("{}");
            }

            if (query.Contains("command=FINALIZE"))
            {
                return OkJson("{\"media_id\":123,\"media_id_string\":\"123\"}");
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        });

        var mediaId = await BuildApiClient(handler).UploadMediaAsync(image, "image/jpeg", CancellationToken.None);

        Assert.Equal("123", mediaId);
        Assert.Equal(3, handler.Requests.Count);

        var initQuery = handler.Requests[0].Message.RequestUri!.Query;
        Assert.Contains("command=INIT", initQuery);
        Assert.Contains("media_type=image%2Fjpeg", initQuery);
        Assert.Contains($"total_bytes={image.Length}", initQuery);

        var appendQuery = handler.Requests[1].Message.RequestUri!.Query;
        Assert.Contains("command=APPEND", appendQuery);
        Assert.Contains("segment_index=0", appendQuery);

        var finalizeQuery = handler.Requests[2].Message.RequestUri!.Query;
        Assert.Contains("command=FINALIZE", finalizeQuery);

        foreach (var captured in handler.Requests)
        {
            Assert.StartsWith("OAuth ", captured.Message.Headers.GetValues("Authorization").Single());
        }
    }

    [Fact]
    public async Task UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments()
    {
        var image = new byte[XApiClient.MediaSegmentMaxBytes + 1];
        var handler = new StubHttpMessageHandler(request =>
        {
            var query = request.RequestUri!.Query;
            if (query.Contains("command=INIT"))
            {
                return OkJson("{\"media_id\":1,\"media_id_string\":\"1\"}");
            }

            if (query.Contains("command=APPEND"))
            {
                return OkJson("{}");
            }

            if (query.Contains("command=FINALIZE"))
            {
                return OkJson("{\"media_id\":1,\"media_id_string\":\"1\"}");
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        });

        await BuildApiClient(handler).UploadMediaAsync(image, "image/jpeg", CancellationToken.None);

        Assert.Equal(4, handler.Requests.Count);
        Assert.Contains("segment_index=0", handler.Requests[1].Message.RequestUri!.Query);
        Assert.Contains("segment_index=1", handler.Requests[2].Message.RequestUri!.Query);
        Assert.Contains("command=FINALIZE", handler.Requests[3].Message.RequestUri!.Query);
    }

    [Fact]
    public async Task UploadMediaAsync_WhenInitRejected_ThrowsXApiException()
    {
        var handler = new StubHttpMessageHandler(request =>
            request.RequestUri!.Query.Contains("command=INIT")
                ? new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                }
                : OkJson("{}"));

        var ex = await Assert.ThrowsAsync<XApiException>(
            () => BuildApiClient(handler).UploadMediaAsync(new byte[] { 1 }, "image/jpeg", CancellationToken.None));

        Assert.Equal((int)HttpStatusCode.Forbidden, ex.StatusCode);
    }

    [Fact]
    public async Task UploadMediaAsync_WhenAppendRejected_ThrowsXApiException()
    {
        var handler = new StubHttpMessageHandler(request =>
        {
            var query = request.RequestUri!.Query;
            if (query.Contains("command=INIT"))
            {
                return OkJson("{\"media_id\":1,\"media_id_string\":\"1\"}");
            }

            if (query.Contains("command=APPEND"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "{\"errors\":[{\"code\":38,\"message\":\"ADMIN_MEDIA_VERIFICATION\"}]}",
                        Encoding.UTF8,
                        "application/json")
                };
            }

            return OkJson("{\"media_id\":1, \"media_id_string\":\"1\"}");
        });

        var ex = await Assert.ThrowsAsync<XApiException>(
            () => BuildApiClient(handler).UploadMediaAsync(new byte[] { 1, 2, 3 }, "image/jpeg", CancellationToken.None));

        Assert.Equal((int)HttpStatusCode.BadRequest, ex.StatusCode);
        Assert.Contains("ADMIN_MEDIA_VERIFICATION", ex.Message);
    }

    [Fact]
    public async Task UploadMediaAsync_EmptyMedia_ThrowsArgumentException()
    {
        var handler = new StubHttpMessageHandler(_ => OkJson("{}"));

        await Assert.ThrowsAsync<ArgumentException>(
            () => BuildApiClient(handler).UploadMediaAsync(Array.Empty<byte>(), "image/jpeg", CancellationToken.None));
    }
}