using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.SenderPlugins;

namespace XPoster.Tests.Orchestrators;

/// <summary>
/// Tests for <see cref="OrchestratorFactory"/>.
///
/// Design principle: tests inject synthetic <see cref="ScheduledOrchestrationProfile"/> entries
/// via a mocked <see cref="ISlotProfileProvider"/>, making them fully agnostic from the
/// production schedule defined in <see cref="DefaultSlotProfileProvider"/>.
/// Changing business scheduling decisions does NOT require touching these tests.
/// </summary>
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

    // ---------------------------------------------------------------------------
    // Orchestrator type resolution — sender-driven, not hour-driven
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(typeof(FeedOrchestrator),     MessageSender.InSummaryFeed)]
    [InlineData(typeof(FeedOrchestrator),     MessageSender.XSummaryFeed)]
    [InlineData(typeof(FeedOrchestrator),     MessageSender.DryRunSend)]
    [InlineData(typeof(PowerLawOrchestrator), MessageSender.InPowerLaw)]
    [InlineData(typeof(PowerLawOrchestrator), MessageSender.XPowerLaw)]
    public void Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(
        Type expectedType, MessageSender sender)
    {
        // ARRANGE — synthetic profile at an arbitrary hour; no coupling to slotProfiles
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(arbitraryHour, sender, expectedType, AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType(expectedType, orchestrator);
    }

    [Fact]
    public void Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour()
    {
        // ARRANGE — empty schedule: any hour maps to NoOrchestrator
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>());

        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, 3, 0, 0));

        SetupMocksForOrchestratorFactory();
        var factory = CreateFactory(mockProfileProvider.Object);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<NoOrchestrator>(orchestrator);
        _mockAiServiceFactory.Verify(x => x.GetByProvider(It.IsAny<AiProvider>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Sender wiring verification
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed()
    {
        // ARRANGE
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, MessageSender.InSummaryFeed, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed()
    {
        // ARRANGE
        const int arbitraryHour = 11;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, MessageSender.XSummaryFeed, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend()
    {
        // ARRANGE — DryRun profile injected synthetically; no dependency on production schedule
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, MessageSender.DryRunSend, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(DryRunSender)), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // AI provider wiring
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne()
    {
        // ARRANGE
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, MessageSender.XSummaryFeed, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        factory.Resolve();

        // ASSERT
        _mockAiServiceFactory.Verify(x => x.GetByProvider(AiProvider.OpenAi), Times.Once);
    }

    [Fact]
    public void Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider()
    {
        // ARRANGE
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, MessageSender.InPowerLaw, typeof(PowerLawOrchestrator));
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        factory.Resolve();

        // ASSERT
        _mockAiServiceFactory.Verify(x => x.GetByProvider(It.IsAny<AiProvider>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // DryRunSlotProfileProvider decorator
    // ---------------------------------------------------------------------------

    [Fact]
    public void DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles()
    {
        // ARRANGE
        var innerProfile = new ScheduledOrchestrationProfile(
            6, MessageSender.InSummaryFeed, typeof(FeedOrchestrator), AiProvider.OpenAi);

        var mockInner = new Mock<ISlotProfileProvider>();
        mockInner.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile> { innerProfile });

        var provider = new DryRunSlotProfileProvider(mockInner.Object);

        // ACT
        var profiles = provider.GetProfiles();

        // ASSERT
        Assert.Equal(2, profiles.Count);
        Assert.Contains(profiles, p => p.SenderType == MessageSender.DryRunSend);
    }

    [Fact]
    public void DefaultSlotProfileProvider_Should_NotContainDryRunProfile()
    {
        // ARRANGE
        var provider = new DefaultSlotProfileProvider();

        // ACT
        var profiles = provider.GetProfiles();

        // ASSERT
        Assert.DoesNotContain(profiles, p => p.SenderType == MessageSender.DryRunSend);
    }

    // ---------------------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------------------

    private OrchestratorFactory CreateFactoryWithProfiles(
        int currentHour, params ScheduledOrchestrationProfile[] profiles)
    {
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>(profiles));

        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, currentHour, 0, 0));

        SetupMocksForOrchestratorFactory();
        return CreateFactory(mockProfileProvider.Object);
    }

    private OrchestratorFactory CreateFactory(ISlotProfileProvider profileProvider)
    {
        return new OrchestratorFactory(
            _mockServiceProvider.Object,
            _mockLogger.Object,
            _mockTimeProvider.Object,
            _mockAiServiceFactory.Object,
            profileProvider);
    }

    private void SetupMocksForOrchestratorFactory()
    {
        var mockXSender      = new Mock<ISender>();
        var mockInSender     = new Mock<ISender>();
        var mockIgSender     = new Mock<ISender>();
        var mockDryRunSender = new Mock<ISender>();

        var mockCryptoService  = new Mock<ICryptoService>();
        var mockTimeProvider   = new Mock<ITimeProvider>();
        var mockFeedService    = new Mock<IFeedService>();
        var mockAiService      = new Mock<IAiService>();

        var mockLoggerPowerLaw = new Mock<ILogger<PowerLawOrchestrator>>();
        var mockLoggerFeed     = new Mock<ILogger<FeedOrchestrator>>();
        var mockLoggerNo       = new Mock<ILogger<NoOrchestrator>>();

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(XSender))).Returns(mockXSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(InSender))).Returns(mockInSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IgSender))).Returns(mockIgSender.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(DryRunSender))).Returns(mockDryRunSender.Object);

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<PowerLawOrchestrator>))).Returns(mockLoggerPowerLaw.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<FeedOrchestrator>))).Returns(mockLoggerFeed.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ILogger<NoOrchestrator>))).Returns(mockLoggerNo.Object);

        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ICryptoService))).Returns(mockCryptoService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(ITimeProvider))).Returns(mockTimeProvider.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedService))).Returns(mockFeedService.Object);
        _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAiService))).Returns(mockAiService.Object);
    }
}
