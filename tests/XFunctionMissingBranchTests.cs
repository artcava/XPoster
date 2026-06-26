using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests;

/// <summary>
/// Additional XFunction.Run tests covering branches not exercised by XFunctionTests:
/// empty posts dictionary from OrchestrateAsync, PostAsync returning false, and exception re-throw.
/// </summary>
public class XFunctionMissingBranchTests
{
    private readonly Mock<IOrchestratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>>   _mockLogger;
    private readonly Mock<BaseOrchestrator>     _mockOrchestrator;

    public XFunctionMissingBranchTests()
    {
        _mockFactory      = new Mock<IOrchestratorFactory>();
        _mockLogger       = new Mock<ILogger<XFunction>>();
        _mockOrchestrator = new Mock<BaseOrchestrator>(
            MockBehavior.Strict,
            new object[] { new List<ISender>().AsReadOnly(), Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary()
    {
        // posts.Count == 0 branch: LogError("Failed to orchestrate messages...") then return
        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("TestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync())
            .ReturnsAsync((IReadOnlyDictionary<SenderPlatform, Post?>)
                new Dictionary<SenderPlatform, Post?>().AsReadOnly());
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockOrchestrator.Verify(
            g => g.PostAsync(It.IsAny<IReadOnlyDictionary<SenderPlatform, Post?>>()), Times.Never);
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
        var testPosts = new Dictionary<SenderPlatform, Post?>
        {
            { SenderPlatform.X, new Post { Content = "Test" } }
        }.AsReadOnly();

        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("TestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync())
            .ReturnsAsync((IReadOnlyDictionary<SenderPlatform, Post?>)testPosts);
        _mockOrchestrator.Setup(g => g.PostAsync(testPosts)).ReturnsAsync(false);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("One or more senders failed")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task Run_Should_Rethrow_When_Factory_Throws()
    {
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
