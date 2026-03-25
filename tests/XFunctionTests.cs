using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Tests;

public class XFunctionTests
{
    private readonly Mock<IGeneratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>> _mockLogger;
    private readonly Mock<BaseGenerator> _mockGenerator;

    public XFunctionTests()
    {
        _mockFactory = new Mock<IGeneratorFactory>();
        _mockLogger = new Mock<ILogger<XFunction>>();

        // BaseGenerator ctor: (ISender? sender, ILogger logger)
        // CS8620: Mock<T>(MockBehavior, params object[]) requires object[], not object?[]
        // Sender is intentionally null (ISender? is nullable by design); cast suppresses nullability mismatch
        _mockGenerator = new Mock<BaseGenerator>(
            MockBehavior.Strict,
            new object[] { (ISender?)null!, Mock.Of<ILogger>() });
    }

    [Fact]
    public async Task Run_Should_DoNothing_When_GeneratorIsDisabled()
    {
        // ARRANGE
        _mockGenerator.Setup(g => g.SendIt).Returns(false);
        _mockGenerator.Setup(g => g.Name).Returns("DisabledTestGenerator");
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT
        await function.Run(null!);

        // ASSERT
        _mockGenerator.Verify(g => g.GenerateAsync(), Times.Never());
        _mockGenerator.Verify(g => g.PostAsync(It.IsAny<Post>()), Times.Never());
    }

    [Fact]
    public async Task Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()
    {
        // ARRANGE
        var testMessage = new Post { Content = "Test" };

        _mockGenerator.Setup(g => g.SendIt).Returns(true);
        _mockGenerator.Setup(g => g.Name).Returns("EnabledTestGenerator");
        _mockGenerator.Setup(g => g.GenerateAsync()).ReturnsAsync((Post?)testMessage);
        _mockGenerator.Setup(g => g.PostAsync(testMessage)).ReturnsAsync(true);
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT
        await function.Run(null!);

        // ASSERT
        _mockGenerator.Verify(g => g.GenerateAsync(), Times.Once());
        _mockGenerator.Verify(g => g.PostAsync(testMessage), Times.Once());
    }
}
