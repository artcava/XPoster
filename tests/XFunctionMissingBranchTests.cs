using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Tests;

/// <summary>
/// Additional XFunction.Run tests covering branches not exercised by XFunctionTests:
/// null post from GenerateAsync, PostAsync returning false, and exception re-throw.
/// </summary>
public class XFunctionMissingBranchTests
{
    private readonly Mock<IGeneratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>> _mockLogger;
    private readonly Mock<BaseGenerator> _mockGenerator;

    public XFunctionMissingBranchTests()
    {
        _mockFactory = new Mock<IGeneratorFactory>();
        _mockLogger = new Mock<ILogger<XFunction>>();
        _mockGenerator = new Mock<BaseGenerator>(
            MockBehavior.Strict,
            new object[] { (ISender?)null!, Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_LogError_When_GenerateAsync_ReturnsNull()
    {
        // post == null branch: LogError("Failed to generate message...") then return
        _mockGenerator.Setup(g => g.SendIt).Returns(true);
        _mockGenerator.Setup(g => g.Name).Returns("TestGenerator");
        _mockGenerator.Setup(g => g.GenerateAsync()).ReturnsAsync((Post?)null);
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockGenerator.Verify(g => g.PostAsync(It.IsAny<Post>()), Times.Never);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Failed to generate")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task Run_Should_LogError_When_PostAsync_ReturnsFalse()
    {
        // result == false branch: LogError("Failed to send Message...")
        var testPost = new Post { Content = "Test" };
        _mockGenerator.Setup(g => g.SendIt).Returns(true);
        _mockGenerator.Setup(g => g.Name).Returns("TestGenerator");
        _mockGenerator.Setup(g => g.GenerateAsync()).ReturnsAsync(testPost);
        _mockGenerator.Setup(g => g.PostAsync(testPost)).ReturnsAsync(false);
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Failed to send")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task Run_Should_Rethrow_When_Factory_Throws()
    {
        // catch block: LogError then re-throw
        _mockFactory.Setup(f => f.Generate()).Throws(new InvalidOperationException("factory error"));

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(() => function.Run(null!));
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<InvalidOperationException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
