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
        // BaseOrchestrator ctor: (IReadOnlyList<ISender>, ILogger)
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
        await function.Run(null!);

        _mockOrchestrator.Verify(g => g.OrchestrateAsync(), Times.Never());
        _mockOrchestrator.Verify(
            g => g.PostAsync(It.IsAny<IReadOnlyList<Post?>>()), Times.Never());
    }

    [Fact]
    public async Task Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()
    {
        var testPosts = new List<Post?> { new Post { Content = "Test" } }.AsReadOnly();

        _mockOrchestrator.Setup(g => g.SendIt).Returns(true);
        _mockOrchestrator.Setup(g => g.Name).Returns("EnabledTestOrchestrator");
        _mockOrchestrator.Setup(g => g.OrchestrateAsync())
            .ReturnsAsync((IReadOnlyList<Post?>)testPosts);
        _mockOrchestrator.Setup(g => g.PostAsync(testPosts)).ReturnsAsync(true);
        _mockFactory.Setup(f => f.Resolve()).Returns(_mockOrchestrator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);
        await function.Run(null!);

        _mockOrchestrator.Verify(g => g.OrchestrateAsync(), Times.Once());
        _mockOrchestrator.Verify(g => g.PostAsync(testPosts), Times.Once());
    }
}
