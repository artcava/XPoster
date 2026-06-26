using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests;

public class XFunctionTests
{
    private readonly Mock<IOrchestratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>>   _mockLogger;
    private readonly Mock<BaseOrchestrator>     _mockOrchestrator;

    public XFunctionTests()
    {
        _mockFactory      = new Mock<IOrchestratorFactory>();
        _mockLogger       = new Mock<ILogger<XFunction>>();
        _mockOrchestrator = new Mock<BaseOrchestrator>(
            MockBehavior.Strict,
            new object[] { new List<ISender>().AsReadOnly(), Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_DoNothing_When_GeneratorIsDisabled()
    {
        _mockOrchestrator.Setup(g => g.SendIt).Returns(false);
        _mockOrchestrator.Setup(g => g.Name).Returns("DisabledTestOrchestrator");
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!, CancellationToken.None);

        _mockOrchestrator.Verify(g => g.OrchestrateAsync(CancellationToken.None), Times.Never());
        _mockOrchestrator.Verify(
            g => g.PostAsync(It.IsAny<IReadOnlyDictionary<SenderPlatform, Post?>>(), It.IsAny<CancellationToken>()), Times.Never());
    }

    [Fact]
    public async Task Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()
    {
        var testPosts = new Dictionary<SenderPlatform, Post?>
        {
            { SenderPlatform.X, new Post { Content = "Test" } }
        }.AsReadOnly();

        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("EnabledTestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync(CancellationToken.None))
            .ReturnsAsync((IReadOnlyDictionary<SenderPlatform, Post?>)testPosts);
        _mockOrchestrator.Setup(g => g.PostAsync(testPosts, CancellationToken.None)).ReturnsAsync(true);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!, CancellationToken.None);

        _mockOrchestrator.Verify(g => g.OrchestrateAsync(CancellationToken.None), Times.Once());
        _mockOrchestrator.Verify(g => g.PostAsync(testPosts, CancellationToken.None), Times.Once());
    }

    // ---------------------------------------------------------------------------
    // Cancellation
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully()
    {
        // ARRANGE — OrchestrateAsync throws OperationCanceledException with the same token
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("CancelledOrchestrator");
        _mockOrchestrator
            .Setup(g => g.OrchestrateAsync(cts.Token))
            .ThrowsAsync(new OperationCanceledException(cts.Token));
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT + ASSERT — must not throw
        await function.Run(null!, cts.Token);

        // Verify warning was logged (not error)
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("cancelled gracefully")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
