using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.SenderPlugins;

namespace XPoster.Tests;

public class GeneratorFactoryTests
{
    private readonly Mock<IServiceProvider> _mockServiceProvider;
    private readonly Mock<ILogger<GeneratorFactory>> _mockLogger;
    private readonly Mock<ITimeProvider> _mockTimeProvider;

    public GeneratorFactoryTests()
    {
        _mockServiceProvider = new Mock<IServiceProvider>();
        _mockLogger = new Mock<ILogger<GeneratorFactory>>();
        _mockTimeProvider = new Mock<ITimeProvider>();
    }

    [Theory]
    [InlineData(6, typeof(FeedGenerator))] // InSummaryFeed
    [InlineData(8, typeof(FeedGenerator))] // XSummaryFeed
    [InlineData(14, typeof(PowerLawGenerator))] // InPowerLaw
    [InlineData(16, typeof(PowerLawGenerator))] // XPowerLaw
    [InlineData(0, typeof(NoGenerator))] // NoSend
    [InlineData(12, typeof(NoGenerator))] // NoSend
    public void Generate_Should_ReturnCorrectGeneratorType_BasedOnHour(int hour, Type expectedType)
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, hour, 0, 0);
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        SetupMocksForGeneratorFactory();

        var factory = new GeneratorFactory(_mockServiceProvider.Object, _mockLogger.Object, _mockTimeProvider.Object);

        // ACT
        var generator = factory.Generate();

        // ASSERT
        Assert.IsType(expectedType, generator);
    }

    [Fact]
    public void Generate_Should_CreateFeedGeneratorWithInSender_At6AM()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 6, 0, 0); // 6 AM
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockInSender = new Mock<ISender>();
        var mockLoggerFeed = new Mock<ILogger<FeedGenerator>>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(InSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedGenerator>)))
        .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);

        var factory = new GeneratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object);

        // ACT
        var generator = factory.Generate();

        // ASSERT
        Assert.IsType<FeedGenerator>(generator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Generate_Should_CreateFeedGeneratorWithXSender_At8AM()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 8, 0, 0); // 8 AM
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockInSender = new Mock<ISender>();
        var mockLoggerFeed = new Mock<ILogger<FeedGenerator>>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(XSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedGenerator>)))
            .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);

        var factory = new GeneratorFactory(_mockServiceProvider.Object, _mockLogger.Object, _mockTimeProvider.Object);

        // ACT - Simulando le 8:00
        var generator = factory.Generate();

        // ASSERT
        Assert.IsType<FeedGenerator>(generator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }
    [Fact]
    public void Generate_Should_CreateNoGenerator_AtUnscheduledHours()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 3, 0, 0); // 3 AM - not scheduled
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockLoggerNo = new Mock<ILogger<NoGenerator>>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<NoGenerator>)))
            .Returns(mockLoggerNo.Object);

        var factory = new GeneratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object);

        // ACT
        var generator = factory.Generate();

        // ASSERT
        Assert.IsType<NoGenerator>(generator);
    }
    private void SetupMocksForGeneratorFactory()
    {
        // Setup base per tutti i tipi di generator
        var mockXSender = new Mock<ISender>();
        var mockInSender = new Mock<ISender>();
        var mockIgSender = new Mock<ISender>();

        var mockCryptoService = new Mock<ICryptoService>();
        var mockTimeProvider = new Mock<ITimeProvider>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        var mockLoggerPowerLaw = new Mock<ILogger<PowerLawGenerator>>();
        var mockLoggerFeed = new Mock<ILogger<FeedGenerator>>();
        var mockLoggerNo = new Mock<ILogger<NoGenerator>>();

        // Senders
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(XSender)))
            .Returns(mockXSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(InSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IgSender)))
            .Returns(mockIgSender.Object);

        // Loggers (GetRequiredService)
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<PowerLawGenerator>)))
            .Returns(mockLoggerPowerLaw.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedGenerator>)))
            .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<NoGenerator>)))
            .Returns(mockLoggerNo.Object);

        // Services (per ActivatorUtilities)
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ICryptoService)))
            .Returns(mockCryptoService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ITimeProvider)))
            .Returns(mockTimeProvider.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);
    }
}
