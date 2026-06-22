using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
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
    // Orchestrator type resolution — platform-driven, not sender-enum-driven
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(typeof(FeedOrchestrator),     SenderPlatform.LinkedIn)]
    [InlineData(typeof(FeedOrchestrator),     SenderPlatform.X)]
    [InlineData(typeof(FeedOrchestrator),     SenderPlatform.DryRun)]
    [InlineData(typeof(PowerLawOrchestrator), SenderPlatform.LinkedIn)]
    [InlineData(typeof(PowerLawOrchestrator), SenderPlatform.X)]
    public void Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(
        Type expectedType, SenderPlatform platform)
    {
        // ARRANGE — synthetic profile at an arbitrary hour; no coupling to production schedule
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(arbitraryHour, platform, expectedType, AiProvider.OpenAi);
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
    // Sender wiring — O(senders) switch, independent of orchestrator type
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn()
    {
        // ARRANGE
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.LinkedIn, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveXSender_WhenProfileUsesX()
    {
        // ARRANGE
        const int arbitraryHour = 11;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.X, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram()
    {
        // ARRANGE
        const int arbitraryHour = 12;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.Instagram, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(IgSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun()
    {
        // ARRANGE — DryRun profile injected synthetically; no dependency on production schedule
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.DryRun, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<FeedOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(DryRunSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator()
    {
        // ARRANGE — same platform (LinkedIn), different orchestrator type: switch must be O(senders)
        const int arbitraryHour = 14;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.LinkedIn, typeof(PowerLawOrchestrator));
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<PowerLawOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveXSender_ForPowerLawOrchestrator()
    {
        // ARRANGE — same platform (X), different orchestrator type: switch must be O(senders)
        const int arbitraryHour = 16;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.X, typeof(PowerLawOrchestrator));
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        Assert.IsType<PowerLawOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
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
            arbitraryHour, SenderPlatform.X, typeof(FeedOrchestrator), AiProvider.OpenAi);
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
            arbitraryHour, SenderPlatform.LinkedIn, typeof(PowerLawOrchestrator));
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
            6, SenderPlatform.LinkedIn, typeof(FeedOrchestrator), AiProvider.OpenAi);

        var mockInner = new Mock<ISlotProfileProvider>();
        mockInner.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile> { innerProfile });

        var provider = new DryRunSlotProfileProvider(mockInner.Object);

        // ACT
        var profiles = provider.GetProfiles();

        // ASSERT
        Assert.Equal(2, profiles.Count);
        Assert.Contains(profiles, p => p.SenderPlatform == SenderPlatform.DryRun);
    }

    [Fact]
    public void DefaultSlotProfileProvider_Should_NotContainDryRunProfile()
    {
        // ARRANGE
        var provider = new DefaultSlotProfileProvider();

        // ACT
        var profiles = provider.GetProfiles();

        // ASSERT
        Assert.DoesNotContain(profiles, p => p.SenderPlatform == SenderPlatform.DryRun);
    }

    // ---------------------------------------------------------------------------
    // SupportedPlatforms contract
    // ---------------------------------------------------------------------------

    [Fact]
    public void FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()
    {
        // ARRANGE
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.X, typeof(FeedOrchestrator), AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        var feedOrchestrator = Assert.IsType<FeedOrchestrator>(orchestrator);
        Assert.Contains(SenderPlatform.X,         feedOrchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn,  feedOrchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Instagram, feedOrchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.DryRun,    feedOrchestrator.SupportedPlatforms);
    }

    [Fact]
    public void PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn()
    {
        // ARRANGE
        const int arbitraryHour = 14;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour, SenderPlatform.LinkedIn, typeof(PowerLawOrchestrator));
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        // ACT
        var orchestrator = factory.Resolve();

        // ASSERT
        var powerLawOrchestrator = Assert.IsType<PowerLawOrchestrator>(orchestrator);
        Assert.Contains(SenderPlatform.X,        powerLawOrchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn, powerLawOrchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.DryRun,   powerLawOrchestrator.SupportedPlatforms);
        Assert.DoesNotContain(SenderPlatform.Instagram, powerLawOrchestrator.SupportedPlatforms);
    }

    [Fact]
    public void NoOrchestrator_SupportedPlatforms_IsEmpty()
    {
        // ARRANGE — empty schedule forces NoOrchestrator
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
        var noOrchestrator = Assert.IsType<NoOrchestrator>(orchestrator);
        Assert.Empty(noOrchestrator.SupportedPlatforms);
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
