using Microsoft.Extensions.Logging;
using Moq;
using XPoster.SenderPlugins;

namespace XPoster.Tests;

public class XSenderTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;

    public XSenderTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
    }

    [Fact]
    public void MessageMaxLength_Should_Return_250()
    {
        // ARRANGE & ACT
        var sender = new XSender(_mockLogger.Object);

        // ASSERT
        Assert.Equal(250, sender.MessageMaxLenght);
    }

    [Fact]
    public async Task SendAsync_Should_LogError_When_TweetFails()
    {
        // Questo test richiede di wrappare TwitterContext per poterlo mockare
        // Suggerisco di creare un'interfaccia ITwitterClient
    }
}

public class InSenderTests
{
    [Fact]
    public void MessageMaxLength_Should_Return_800()
    {
        var mockLogger = new Mock<ILogger<InSender>>();
        var sender = new InSender(mockLogger.Object);

        Assert.Equal(800, sender.MessageMaxLenght);
    }

    // Test per upload immagini, gestione errori API, ecc.
}
