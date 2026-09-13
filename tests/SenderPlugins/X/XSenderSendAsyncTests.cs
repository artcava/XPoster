using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for XSender.SendAsync input-validation branches.
/// Network calls are not exercised — only the guards that execute before any I/O are tested here.
/// </summary>
public class XSenderSendAsyncTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;
    private readonly XSender _sender;

    public XSenderSendAsyncTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
        var factory = ResilienceTestHelpers.BuildFactory("X", HttpStatusCode.OK, "{}");
        var apiClient = new XApiClient(
            factory,
            Options.Create(new XCredentials
            {
                XApiKey = "fake_key",
                XApiSecret = "fake_secret",
                XAccessToken = "fake_token",
                XAccessTokenSecret = "fake_token_secret"
            }),
            NullLogger<XApiClient>.Instance);
        _sender = new XSender(apiClient, _mockLogger.Object);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = string.Empty }));
    }

    [Fact]
    public async Task SendAsync_WithWhiteSpaceContent_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = "   " }));
    }
}