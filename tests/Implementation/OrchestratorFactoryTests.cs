using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.SenderPlugins;

namespace XPoster.Tests.Implementation;

public class OrchestratorFactoryTests
{
    private readonly Mock<IServiceProvider> _mockServiceProvider;
    private readonly Mock<ILogger<OrchestratorFactory>> _mockLogger;
    private readonly Mock<ITimeProvider> _mockTimeProvider;
    private readonly Mock<IAiServiceFactory> _mockAiServiceFactory;
    private readonly Mock<IAiService> _mockAiService;

    public OrchestratorFactoryTests()
    {
        _mockServiceProvider = new Mock<IServiceProvider>();
        _mockLogger = new Mock<ILogger<OrchestratorFactory>>();
        _mockTimeProvider = new Mock<ITimeProvider>();
        _mockAiServiceFactory = new Mock<IAiServiceFactory>();
        _mockAiService = new Mock<IAiService>();

        _mockAiServiceFactory
            .Setup(x => x.GetByProvider(AiProvider.OpenAi))
            .Returns(_mockAiService.Object);
    }

    [Theory]
    [InlineData(6, typeof(FeedOrchestrator))]          // InSummaryFeed
    [InlineData(8, typeof(FeedOrchestrator))]          // XSummaryFeed
    [InlineData(9, typeof(FeedOrchestrator))]          // DryRunSend
    [InlineData(14, typeof(PowerLawOrchestrator))]     // InPowerLaw
    [InlineData(16, typeof(PowerLawOrchestrator))]     // XPowerLaw
    [InlineData(0, typeof(NoOrchestrator))]            // NoSend
    [InlineData(12, typeof(NoOrchestrator))]           // NoSend
    public void Generate_Should_ReturnCorrectOrchestratorType_BasedOnHour(int hour, Type expectedType)
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, hour, 0, 0);
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        SetupMocksForOrchestratorFactory();

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType(expectedType, orchestrator);
    }

    [Fact]
    public void Generate_Should_CreateFeedOrchestratorWithInSender_At6AM()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 6, 0, 0); // 6 AM
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockInSender = new Mock<ISender>();
        var mockLoggerFeed = new Mock<ILogger<FeedOrchestrator>>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(InSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedOrchestrator>)))
        .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Generate_Should_CreateFeedOrchestratorWithXSender_At8AM()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 8, 0, 0); // 8 AM
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockInSender = new Mock<ISender>();
        var mockLoggerFeed = new Mock<ILogger<FeedOrchestrator>>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(XSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedOrchestrator>)))
            .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }

    [Fact]
    public void Generate_Should_CreateFeedOrchestratorWithDryRunSender_At9AM()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 9, 0, 0); // 9 AM - DryRun slot
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockDryRunSender = new Mock<ISender>();
        var mockLoggerFeed = new Mock<ILogger<FeedOrchestrator>>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(DryRunSender)))
            .Returns(mockDryRunSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedOrchestrator>)))
            .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService)))
            .Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService)))
            .Returns(mockAiService.Object);

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(DryRunSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_CreateNoOrchestrator_AtUnscheduledHours()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 3, 0, 0); // 3 AM - not scheduled
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);

        var mockLoggerNo = new Mock<ILogger<NoOrchestrator>>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<NoOrchestrator>)))
            .Returns(mockLoggerNo.Object);

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<NoOrchestrator>(orchestrator);
        _mockAiServiceFactory.Verify(x => x.GetByProvider(It.IsAny<AiProvider>()), Times.Never);
    }

    [Fact]
    public void Resolve_Should_RequestOpenAiProvider_ForScheduledFeedSlot()
    {
        // ARRANGE
        var testDate = new DateTime(2025, 11, 14, 6, 0, 0);
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime()).Returns(testDate);
        SetupMocksForOrchestratorFactory();

        var factory = new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockAiServiceFactory.Verify(x => x.GetByProvider(AiProvider.OpenAi), Times.Once);
    }

    private void SetupMocksForOrchestratorFactory()
    {
        var mockXSender = new Mock<ISender>();
        var mockInSender = new Mock<ISender>();
        var mockIgSender = new Mock<ISender>();
        var mockDryRunSender = new Mock<ISender>();

        var mockCryptoService = new Mock<ICryptoService>();
        var mockTimeProvider = new Mock<ITimeProvider>();
        var mockFeedService = new Mock<IFeedService>();
        var mockAiService = new Mock<IAiService>();

        var mockLoggerPowerLaw = new Mock<ILogger<PowerLawOrchestrator>>();
        var mockLoggerFeed = new Mock<ILogger<FeedOrchestrator>>();
        var mockLoggerNo = new Mock<ILogger<NoOrchestrator>>();

        // Senders
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(XSender)))
            .Returns(mockXSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(InSender)))
            .Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IgSender)))
            .Returns(mockIgSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(DryRunSender)))
            .Returns(mockDryRunSender.Object);

        // Loggers
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<PowerLawOrchestrator>)))
            .Returns(mockLoggerPowerLaw.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedOrchestrator>)))
            .Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<NoOrchestrator>)))
            .Returns(mockLoggerNo.Object);

        // Services
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
