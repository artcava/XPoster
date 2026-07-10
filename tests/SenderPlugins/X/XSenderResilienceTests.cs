using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for X sender failure handling.
/// These tests verify that XSender degrades gracefully when LinqToTwitter
/// operations fail and that guard clauses prevent invalid outbound calls.
/// </summary>
public class XSenderResilienceTests
{
    private readonly Mock<ILogger<XSender>> _loggerMock = new();

    private XSender BuildSender()
    {
        var creds = Options.Create(new XCredentials
        {
            XApiKey = "fake_key",
            XApiSecret = "fake_secret",
            XAccessToken = "fake_token",
            XAccessTokenSecret = "fake_token_secret"
        });

        return new XSender(creds, _loggerMock.Object);
    }

    [Fact]
    public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()
    {
        var sender = BuildSender();

        var result = await sender.SendAsync(null!);

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Post is null")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t\n")]
    public async Task SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(string content)
    {
        var sender = BuildSender();

        var result = await sender.SendAsync(new Post { Content = content });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Post content cannot be empty")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError()
    {
        var sender = BuildSender();

        var result = await sender.SendAsync(new Post { Content = "Valid content" });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("[XSender]")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError()
    {
        var sender = BuildSender();

        var result = await sender.SendAsync(new Post
        {
            Content = "Valid content",
            Image = new byte[] { 1, 2, 3 }
        });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("[XSender]")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }
}