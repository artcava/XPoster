using Microsoft.Extensions.Logging;
using Moq;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class InSenderTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;
    public InSenderTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
    }

    [Fact]
    public void MessageMaxLength_Should_Return_800()
    {
        var sender = new InSender(_mockLogger.Object);

        Assert.Equal(800, sender.MessageMaxLenght);
    }

    // Test per upload immagini, gestione errori API, ecc.
}
