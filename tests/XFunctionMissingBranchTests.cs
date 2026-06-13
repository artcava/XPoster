using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Tests;

/// <summary>
/// Additional XFunction.Run tests covering branches not exercised by XFunctionTests:
/// null post from OrchestrateAsync, PostAsync returning false, and exception re-throw.
/// </summary>
public class XFunctionMissingBranchTests
{
    private readonly Mock<IOrchestratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>> _mockLogger;
    private readonly Mock<BaseOrchestrator> _mockOrchestrator;

    public XFunctionMissingBranchTests()
    {
        _mockFactory = new Mock<IOrchestratorFactory>();
        _mockLogger = new Mock<ILogger<XFunction>>();
        _mockOrchestrator = new Mock<BaseOrchestrator>(
            MockBehavior.Strict,
            new object[] { (ISender?)null!, Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()
    {
        // post == null branch: LogError("Failed to orchestrate message...") then return
        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("TestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync()).ReturnsAsync((Post?)null);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockOrchestrator.Verify(g => g.PostAsync(It.IsAny<Post>()), Times.Never);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Failed to orchestrate")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task Run_Should_LogError_When_PostAsync_ReturnsFalse()
    {
        // result == false branch: LogError("Failed to send Message...")
        var testPost = new Post { Content = "Test" };
        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("TestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync()).ReturnsAsync(testPost);
        _mockOrchestrator.Setup(g => g.PostAsync(testPost)).ReturnsAsync(false);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

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
        _mockFactory.Setup(f => f.Resolve()).Throws(new InvalidOperationException("factory error"));

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
