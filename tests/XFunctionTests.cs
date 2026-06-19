using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests;

public class XFunctionTests
{
    private readonly Mock<IOrchestratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>> _mockLogger;
    private readonly Mock<BaseOrchestrator> _mockOrchestrator;

    public XFunctionTests()
    {
        _mockFactory = new Mock<IOrchestratorFactory>();
        _mockLogger = new Mock<ILogger<XFunction>>();

        // BaseOrchestrator ctor: (ISender? sender, ILogger logger)
        // CS8620: Mock<T>(MockBehavior, params object[]) requires object[], not object?[]
        // Sender is intentionally null (ISender? is nullable by design); cast suppresses nullability mismatch
        _mockOrchestrator = new Mock<BaseOrchestrator>(
            MockBehavior.Strict,
            new object[] { (ISender?)null!, Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_DoNothing_When_GeneratorIsDisabled()
    {
        // ARRANGE
        _mockOrchestrator.Setup(g => g.SendIt).Returns(false);
        _mockOrchestrator.Setup(g => g.Name).Returns("DisabledTestOrchestrator");
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT
        await function.Run(null!);

        // ASSERT
        _mockOrchestrator.Verify(g => g.OrchestrateAsync(), Times.Never());
        _mockOrchestrator.Verify(g => g.PostAsync(It.IsAny<Post>()), Times.Never());
    }

    [Fact]
    public async Task Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()
    {
        // ARRANGE
        var testMessage = new Post { Content = "Test" };

        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("EnabledTestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync()).ReturnsAsync((Post?)testMessage);
        _mockOrchestrator.Setup(g => g.PostAsync(testMessage)).ReturnsAsync(true);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT
        await function.Run(null!);

        // ASSERT
        _mockOrchestrator.Verify(g => g.OrchestrateAsync(), Times.Once());
        _mockOrchestrator.Verify(g => g.PostAsync(testMessage), Times.Once());
    }
}
