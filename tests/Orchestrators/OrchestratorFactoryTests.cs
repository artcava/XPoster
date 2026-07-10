using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;
using XPoster.Providers;
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

    // ---------------------------------------------------------------------------
    // Helpers: profile builders
    // ---------------------------------------------------------------------------

    private static ScheduledOrchestrationProfile FeedProfile(
        int hour,
        IReadOnlyList<SenderPlatform>? platforms = null,
        AiProvider? text = AiProvider.OpenAi,
        AiProvider? image = AiProvider.OpenAi) =>
        new(hour,
            platforms ?? new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            typeof(FeedOrchestrator),
            textProvider: text,
            imageProvider: image);

    private static ScheduledOrchestrationProfile PowerLawProfile(
        int hour,
        SenderPlatform platform = SenderPlatform.LinkedIn) =>
        new(hour,
            new List<SenderPlatform> { platform }.AsReadOnly(),
            typeof(PowerLawOrchestrator));

    public OrchestratorFactoryTests()
    {
        _mockServiceProvider = new Mock<IServiceProvider>();
        _mockLogger = new Mock<ILogger<OrchestratorFactory>>();
        _mockTimeProvider = new Mock<ITimeProvider>();
    }

    // ---------------------------------------------------------------------------
    // Orchestrator type resolution
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(typeof(FeedOrchestrator), SenderPlatform.LinkedIn)]
    [InlineData(typeof(FeedOrchestrator), SenderPlatform.X)]
    [InlineData(typeof(FeedOrchestrator), SenderPlatform.DryRun)]
    [InlineData(typeof(PowerLawOrchestrator), SenderPlatform.LinkedIn)]
    [InlineData(typeof(PowerLawOrchestrator), SenderPlatform.X)]
    public void Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(
        Type expectedType, SenderPlatform platform)
    {
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour,
            new List<SenderPlatform> { platform }.AsReadOnly(),
            expectedType,
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        var orchestrator = factory.Resolve();

        Assert.IsType(expectedType, orchestrator);
    }

    [Fact]
    public void Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour()
    {
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>());

        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, 3, 0, 0));

        SetupMocksForOrchestratorFactory();
        var factory = CreateFactory(mockProfileProvider.Object);

        Assert.IsType<NoOrchestrator>(factory.Resolve());
    }

    // ---------------------------------------------------------------------------
    // Sender wiring
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn()
    {
        var factory = CreateFactoryWithProfiles(10, FeedProfile(10,
            new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly()));

        factory.Resolve();

        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveXSender_WhenProfileUsesX()
    {
        var factory = CreateFactoryWithProfiles(11, FeedProfile(11,
            new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly()));

        factory.Resolve();

        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram()
    {
        var factory = CreateFactoryWithProfiles(12, FeedProfile(12,
            new List<SenderPlatform> { SenderPlatform.Instagram }.AsReadOnly()));

        factory.Resolve();

        _mockServiceProvider.Verify(sp => sp.GetService(typeof(IgSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun()
    {
        var factory = CreateFactoryWithProfiles(10, FeedProfile(10,
            new List<SenderPlatform> { SenderPlatform.DryRun }.AsReadOnly()));

        factory.Resolve();

        _mockServiceProvider.Verify(sp => sp.GetService(typeof(DryRunSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator()
    {
        var factory = CreateFactoryWithProfiles(14, PowerLawProfile(14, SenderPlatform.LinkedIn));

        var orchestrator = factory.Resolve();

        Assert.IsType<PowerLawOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveXSender_ForPowerLawOrchestrator()
    {
        var factory = CreateFactoryWithProfiles(16, PowerLawProfile(16, SenderPlatform.X));

        var orchestrator = factory.Resolve();

        Assert.IsType<PowerLawOrchestrator>(orchestrator);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // Fan-out: multi-platform profile resolves all senders
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile()
    {
        const int hour = 8;
        var profile = new ScheduledOrchestrationProfile(
            hour,
            new List<SenderPlatform>
            {
                SenderPlatform.LinkedIn,
                SenderPlatform.X,
                SenderPlatform.Instagram
            }.AsReadOnly(),
            typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);

        var factory = CreateFactoryWithProfiles(hour, profile);
        factory.Resolve();

        _mockServiceProvider.Verify(sp => sp.GetService(typeof(InSender)), Times.Once);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(XSender)), Times.Once);
        _mockServiceProvider.Verify(sp => sp.GetService(typeof(IgSender)), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // AI capability provider wiring
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider()
    {
        const int arbitraryHour = 10;
        var factory = CreateFactoryWithProfiles(arbitraryHour, FeedProfile(arbitraryHour));
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToTextProvider), (object)AiProvider.OpenAi),
            Times.Once);
    }

    [Fact]
    public void Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider()
    {
        const int arbitraryHour = 10;
        var factory = CreateFactoryWithProfiles(arbitraryHour, FeedProfile(arbitraryHour));
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToImageProvider), (object)AiProvider.OpenAi),
            Times.Once);
    }

    [Fact]
    public void Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent()
    {
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour,
            new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            typeof(FeedOrchestrator),
            textProvider: AiProvider.DeepSeek,
            imageProvider: AiProvider.FalAi);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToTextProvider), (object)AiProvider.DeepSeek), Times.Once);
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToImageProvider), (object)AiProvider.FalAi), Times.Once);
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToTextProvider), (object)AiProvider.FalAi), Times.Never);
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToImageProvider), (object)AiProvider.DeepSeek), Times.Never);
    }

    [Fact]
    public void Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider()
    {
        var factory = CreateFactoryWithProfiles(10, PowerLawProfile(10, SenderPlatform.LinkedIn));
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToTextProvider), It.IsAny<object>()), Times.Never);
    }

    [Fact]
    public void Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider()
    {
        const int arbitraryHour = 10;
        var profile = new ScheduledOrchestrationProfile(
            arbitraryHour,
            new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            typeof(FeedOrchestrator),
            textProvider: AiProvider.DeepSeek,
            imageProvider: null);
        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(
            sp => sp.GetKeyedService(typeof(ITextToImageProvider), It.IsAny<object>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // DryRunSlotProfileProvider decorator
    // ---------------------------------------------------------------------------

    [Fact]
    public void DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles()
    {
        var innerProfile = new ScheduledOrchestrationProfile(
            6,
            new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);

        var mockInner = new Mock<ISlotProfileProvider>();
        mockInner.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile> { innerProfile });

        var provider = new DryRunSlotProfileProvider(mockInner.Object);
        var profiles = provider.GetProfiles();

        Assert.Equal(2, profiles.Count);
        Assert.Contains(profiles, p => p.SenderPlatforms.Contains(SenderPlatform.DryRun));
    }

    [Fact]
    public void DefaultSlotProfileProvider_Should_NotContainDryRunProfile()
    {
        var provider = new DefaultSlotProfileProvider();
        var profiles = provider.GetProfiles();
        Assert.DoesNotContain(profiles, p => p.SenderPlatforms.Contains(SenderPlatform.DryRun));
    }

    // ---------------------------------------------------------------------------
    // SupportedPlatforms contract
    // ---------------------------------------------------------------------------

    [Fact]
    public void FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()
    {
        var factory = CreateFactoryWithProfiles(10, FeedProfile(10));
        var orchestrator = Assert.IsType<FeedOrchestrator>(factory.Resolve());

        Assert.Contains(SenderPlatform.X, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Instagram, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.DryRun, orchestrator.SupportedPlatforms);
    }

    [Fact]
    public void PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn()
    {
        var factory = CreateFactoryWithProfiles(14, PowerLawProfile(14));
        var orchestrator = Assert.IsType<PowerLawOrchestrator>(factory.Resolve());

        Assert.Contains(SenderPlatform.X, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.DryRun, orchestrator.SupportedPlatforms);
        Assert.DoesNotContain(SenderPlatform.Instagram, orchestrator.SupportedPlatforms);
    }

    [Fact]
    public void NoOrchestrator_SupportedPlatforms_IsEmpty()
    {
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>());
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, 3, 0, 0));

        SetupMocksForOrchestratorFactory();
        var factory = CreateFactory(mockProfileProvider.Object);

        var noOrchestrator = Assert.IsType<NoOrchestrator>(factory.Resolve());
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

    private OrchestratorFactory CreateFactory(ISlotProfileProvider profileProvider) =>
        new(_mockServiceProvider.Object, _mockLogger.Object, _mockTimeProvider.Object, profileProvider);

    private void SetupMocksForOrchestratorFactory()
    {
        var mockXSender = new Mock<ISender>();
        var mockInSender = new Mock<ISender>();
        var mockIgSender = new Mock<ISender>();
        var mockDryRunSender = new Mock<ISender>();

        var mockCryptoService = new Mock<ICryptoService>();
        var mockTimeProvider = new Mock<ITimeProvider>();
        var mockFeedService = new Mock<IFeedService>();
        var mockTextProvider = new Mock<ITextToTextProvider>();
        var mockImageProvider = new Mock<ITextToImageProvider>();

        var mockLoggerPowerLaw = new Mock<ILogger<PowerLawOrchestrator>>();
        var mockLoggerFeed = new Mock<ILogger<FeedOrchestrator>>();
        var mockLoggerNo = new Mock<ILogger<NoOrchestrator>>();

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

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ITextToTextProvider), It.IsAny<object>()))
            .Returns(mockTextProvider.Object);
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ITextToImageProvider), It.IsAny<object>()))
            .Returns(mockImageProvider.Object);
    }
}
