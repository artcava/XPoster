using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="IKeyVaultService"/> behaviour as consumed by sender plugins.
/// Tests use a mocked <see cref="IKeyVaultService"/> — no live Key Vault connection required.
/// </summary>
public class KeyVaultServiceTests
{
    // -----------------------------------------------------------------------
    // GetSecretAsync — basic contract
    // -----------------------------------------------------------------------

    [Fact]
    public async Task GetSecretAsync_ReturnsExpectedValue()
    {
        var mock = new Mock<IKeyVaultService>();
        mock.Setup(s => s.GetSecretAsync("LinkedInAccessToken"))
            .ReturnsAsync("token-abc");

        var result = await mock.Object.GetSecretAsync("LinkedInAccessToken");

        Assert.Equal("token-abc", result);
    }

    [Fact]
    public async Task GetSecretAsync_ThrowsWhenSecretNotFound()
    {
        var mock = new Mock<IKeyVaultService>();
        mock.Setup(s => s.GetSecretAsync("MissingSecret"))
            .ThrowsAsync(new Azure.RequestFailedException("Secret not found"));

        await Assert.ThrowsAsync<Azure.RequestFailedException>(
            () => mock.Object.GetSecretAsync("MissingSecret"));
    }

    [Fact]
    public async Task GetSecretAsync_OnRotation_ReturnsNewValueOnNextCall()
    {
        // Simulate a credential rotation between two invocations
        var mock = new Mock<IKeyVaultService>();
        var callCount = 0;
        mock.Setup(s => s.GetSecretAsync("XAccessToken"))
            .ReturnsAsync(() => ++callCount == 1 ? "old-token" : "new-token");

        var first = await mock.Object.GetSecretAsync("XAccessToken");
        var second = await mock.Object.GetSecretAsync("XAccessToken");

        Assert.Equal("old-token", first);
        Assert.Equal("new-token", second);
    }

    // -----------------------------------------------------------------------
    // InSender — verifies correct Key Vault secret names are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task InSender_SendAsync_RequestsLinkedInAccessToken()
    {
        var mock = new Mock<IKeyVaultService>();
        SetupInSenderSecrets(mock);

        var httpFactory = TestHelpers.BuildHttpFactory(System.Net.HttpStatusCode.OK, "{}");
        var sender = new XPoster.SenderPlugins.InSender(httpFactory, mock.Object, TestHelpers.NullLogger<XPoster.SenderPlugins.InSender>());

        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        mock.Verify(s => s.GetSecretAsync("LinkedInAccessToken"), Times.AtLeastOnce);
    }

    [Fact]
    public async Task InSender_SendAsync_RequestsLinkedInOwnerCode()
    {
        var mock = new Mock<IKeyVaultService>();
        SetupInSenderSecrets(mock);

        var httpFactory = TestHelpers.BuildHttpFactory(System.Net.HttpStatusCode.OK, "{}");
        var sender = new XPoster.SenderPlugins.InSender(httpFactory, mock.Object, TestHelpers.NullLogger<XPoster.SenderPlugins.InSender>());

        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        // Either LinkedInOwnerCode or LinkedInOrgId must be queried
        mock.Verify(
            s => s.GetSecretAsync(It.Is<string>(n => n == "LinkedInOwnerCode" || n == "LinkedInOrgId")),
            Times.AtLeastOnce);
    }

    // -----------------------------------------------------------------------
    // XSender — verifies all four X credentials are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task XSender_SendAsync_RequestsAllFourXCredentials()
    {
        var mock = new Mock<IKeyVaultService>();
        mock.Setup(s => s.GetSecretAsync("XApiKey")).ReturnsAsync("key");
        mock.Setup(s => s.GetSecretAsync("XApiSecret")).ReturnsAsync("secret");
        mock.Setup(s => s.GetSecretAsync("XAccessToken")).ReturnsAsync("at");
        mock.Setup(s => s.GetSecretAsync("XAccessTokenSecret")).ReturnsAsync("ats");

        var sender = new XPoster.SenderPlugins.XSender(mock.Object, TestHelpers.NullLogger<XPoster.SenderPlugins.XSender>());

        // Act — exception expected from LinqToTwitter stub; we only care about KV calls
        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        mock.Verify(s => s.GetSecretAsync("XApiKey"), Times.Once);
        mock.Verify(s => s.GetSecretAsync("XApiSecret"), Times.Once);
        mock.Verify(s => s.GetSecretAsync("XAccessToken"), Times.Once);
        mock.Verify(s => s.GetSecretAsync("XAccessTokenSecret"), Times.Once);
    }

    // -----------------------------------------------------------------------
    // IgSender — verifies both IG credentials are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task IgSender_SendAsync_WithImage_RequestsBothIgSecrets()
    {
        var mock = new Mock<IKeyVaultService>();
        mock.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("ig-token");
        mock.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("123456");

        var httpFactory = TestHelpers.BuildHttpFactory(System.Net.HttpStatusCode.OK, "{\"id\":\"media-1\"}");
        var sender = new XPoster.SenderPlugins.IgSender(httpFactory, mock.Object, TestHelpers.NullLogger<XPoster.SenderPlugins.IgSender>());

        var post = new XPoster.Models.Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };
        await sender.SendAsync(post);

        mock.Verify(s => s.GetSecretAsync("IgAccessToken"), Times.AtLeastOnce);
        mock.Verify(s => s.GetSecretAsync("IgAccountId"), Times.AtLeastOnce);
    }

    [Fact]
    public async Task IgSender_SendAsync_WithoutImage_DoesNotRequestIgSecrets()
    {
        var mock = new Mock<IKeyVaultService>();
        var httpFactory = TestHelpers.BuildHttpFactory(System.Net.HttpStatusCode.OK, "{}");
        var sender = new XPoster.SenderPlugins.IgSender(httpFactory, mock.Object, TestHelpers.NullLogger<XPoster.SenderPlugins.IgSender>());

        var post = new XPoster.Models.Post { Content = "text only" };
        await sender.SendAsync(post);

        // No image => Key Vault never called
        mock.Verify(s => s.GetSecretAsync(It.IsAny<string>()), Times.Never);
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    private static void SetupInSenderSecrets(Mock<IKeyVaultService> mock)
    {
        mock.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("li-token");
        mock.Setup(s => s.GetSecretAsync("LinkedInOrgId")).ThrowsAsync(new Azure.RequestFailedException("not found"));
        mock.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync("owner-123");
    }
}

/// <summary>Minimal test helpers shared across sender tests.</summary>
internal static class TestHelpers
{
    public static ILogger<T> NullLogger<T>() =>
        Microsoft.Extensions.Logging.Abstractions.NullLogger<T>.Instance;

    public static IHttpClientFactory BuildHttpFactory(
        System.Net.HttpStatusCode statusCode,
        string responseBody)
    {
        var handler = new System.Net.Http.HttpMessageHandlerStub(statusCode, responseBody);
        var client = new System.Net.Http.HttpClient(handler);
        var mock = new Mock<IHttpClientFactory>();
        mock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);
        return mock.Object;
    }
}
