using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Implementation;

namespace XPoster.Tests.Implementation;

/// <summary>
/// Tests for NoGenerator — the no-op generator used in non-posting time slots.
/// </summary>
public class NoGeneratorTests
{
    private readonly Mock<ILogger<NoGenerator>> _mockLogger;

    public NoGeneratorTests()
    {
        _mockLogger = new Mock<ILogger<NoGenerator>>();
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        var result = await generator.GenerateAsync();

        Assert.Null(result);
    }

    [Fact]
    public void SendIt_IsAlwaysFalse()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        Assert.False(generator.SendIt);
    }

    [Fact]
    public void ProduceImage_IsAlwaysFalse()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        Assert.False(generator.ProduceImage);
    }

    [Fact]
    public void Name_IsNoGenerator()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        Assert.Equal("NoGenerator", generator.Name);
    }

    [Fact]
    public void SendIt_Set_ThrowsNotImplementedException()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        Assert.Throws<System.NotImplementedException>(() => generator.SendIt = true);
    }

    [Fact]
    public void ProduceImage_Set_ThrowsNotImplementedException()
    {
        var generator = new NoGenerator(_mockLogger.Object);

        Assert.Throws<System.NotImplementedException>(() => generator.ProduceImage = true);
    }
}
