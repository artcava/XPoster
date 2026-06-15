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
    private static Mock<IKeyVaultService> InSenderKv()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("li-token");
        kv.Setup(s => s.GetSecretAsync("LinkedInOrgId"))
            .ThrowsAsync(new Azure.RequestFailedException("not found"));
        kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync("owner-123");
        return kv;
    }

    private static IHttpClientFactory HttpFactory(System.Net.HttpStatusCode status, string body)
    {
        var handler = new StubHttpMessageHandler(status, body);
        var client = new System.Net.Http.HttpClient(handler);
        var mock = new Mock<IHttpClientFactory>();
        mock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);
        return mock.Object;
    }

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
    // GAP-3: KeyVaultService — missing KEYVAULT_URI configuration
    // -----------------------------------------------------------------------

    /// <summary>
    /// GAP-3: When KEYVAULT_URI is absent from configuration, constructing
    /// KeyVaultService must throw <see cref="InvalidOperationException"/>.
    /// This prevents silent misconfiguration at startup.
    /// </summary>
    [Fact]
    public void KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException()
    {
        // Arrange: ensure the env var is absent for this test
        var original = Environment.GetEnvironmentVariable("KEYVAULT_URI");
        Environment.SetEnvironmentVariable("KEYVAULT_URI", null);

        try
        {
            Assert.Throws<InvalidOperationException>(
                () => new XPoster.Services.KeyVaultService());
        }
        finally
        {
            // Restore original value so other tests are not affected
            Environment.SetEnvironmentVariable("KEYVAULT_URI", original);
        }
    }

    // -----------------------------------------------------------------------
    // InSender — verifies correct Key Vault secret names are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task InSender_SendAsync_RequestsLinkedInAccessToken()
    {
        var kv = InSenderKv();
        var sender = new XPoster.SenderPlugins.InSender(
            HttpFactory(System.Net.HttpStatusCode.OK, "{}"),
            kv.Object,
            Microsoft.Extensions.Logging.Abstractions.NullLogger<XPoster.SenderPlugins.InSender>.Instance);

        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        kv.Verify(s => s.GetSecretAsync("LinkedInAccessToken"), Times.AtLeastOnce);
    }

    [Fact]
    public async Task InSender_SendAsync_RequestsLinkedInOwnerCode()
    {
        var kv = InSenderKv();
        var sender = new XPoster.SenderPlugins.InSender(
            HttpFactory(System.Net.HttpStatusCode.OK, "{}"),
            kv.Object,
            Microsoft.Extensions.Logging.Abstractions.NullLogger<XPoster.SenderPlugins.InSender>.Instance);

        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        kv.Verify(
            s => s.GetSecretAsync(It.Is<string>(n => n == "LinkedInOwnerCode" || n == "LinkedInOrgId")),
            Times.AtLeastOnce);
    }

    // -----------------------------------------------------------------------
    // XSender — verifies all four X credentials are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task XSender_SendAsync_RequestsAllFourXCredentials()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("XApiKey")).ReturnsAsync("key");
        kv.Setup(s => s.GetSecretAsync("XApiSecret")).ReturnsAsync("secret");
        kv.Setup(s => s.GetSecretAsync("XAccessToken")).ReturnsAsync("at");
        kv.Setup(s => s.GetSecretAsync("XAccessTokenSecret")).ReturnsAsync("ats");

        var sender = new XPoster.SenderPlugins.XSender(
            kv.Object,
            Microsoft.Extensions.Logging.Abstractions.NullLogger<XPoster.SenderPlugins.XSender>.Instance);

        await sender.SendAsync(new XPoster.Models.Post { Content = "hello" });

        kv.Verify(s => s.GetSecretAsync("XApiKey"),            Times.Once);
        kv.Verify(s => s.GetSecretAsync("XApiSecret"),         Times.Once);
        kv.Verify(s => s.GetSecretAsync("XAccessToken"),       Times.Once);
        kv.Verify(s => s.GetSecretAsync("XAccessTokenSecret"), Times.Once);
    }

    // -----------------------------------------------------------------------
    // IgSender — verifies both IG credentials are requested
    // -----------------------------------------------------------------------

    [Fact]
    public async Task IgSender_SendAsync_WithImage_RequestsBothIgSecrets()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("ig-token");
        kv.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("123456");

        var sender = new XPoster.SenderPlugins.IgSender(
            HttpFactory(System.Net.HttpStatusCode.OK, "{\"id\":\"media-1\"}"),
            kv.Object,
            Microsoft.Extensions.Logging.Abstractions.NullLogger<XPoster.SenderPlugins.IgSender>.Instance);

        var post = new XPoster.Models.Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };
        await sender.SendAsync(post);

        kv.Verify(s => s.GetSecretAsync("IgAccessToken"), Times.AtLeastOnce);
        kv.Verify(s => s.GetSecretAsync("IgAccountId"),   Times.AtLeastOnce);
    }

    [Fact]
    public async Task IgSender_SendAsync_WithoutImage_DoesNotRequestIgSecrets()
    {
        var kv = new Mock<IKeyVaultService>();
        var sender = new XPoster.SenderPlugins.IgSender(
            HttpFactory(System.Net.HttpStatusCode.OK, "{}"),
            kv.Object,
            Microsoft.Extensions.Logging.Abstractions.NullLogger<XPoster.SenderPlugins.IgSender>.Instance);

        var post = new XPoster.Models.Post { Content = "text only" };
        await sender.SendAsync(post);

        kv.Verify(s => s.GetSecretAsync(It.IsAny<string>()), Times.Never);
    }
}

/// <summary>
/// Minimal inline HTTP handler stub, replacing the missing HttpMessageHandlerStub reference.
/// </summary>
internal sealed class StubHttpMessageHandler : System.Net.Http.HttpMessageHandler
{
    private readonly System.Net.HttpStatusCode _status;
    private readonly string _body;

    public StubHttpMessageHandler(System.Net.HttpStatusCode status, string body)
    {
        _status = status;
        _body = body;
    }

    protected override Task<System.Net.Http.HttpResponseMessage> SendAsync(
        System.Net.Http.HttpRequestMessage request,
        System.Threading.CancellationToken cancellationToken)
    {
        var response = new System.Net.Http.HttpResponseMessage(_status)
        {
            Content = new System.Net.Http.StringContent(_body)
        };
        return Task.FromResult(response);
    }
}
