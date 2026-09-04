using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;
using XPoster.Providers;
using XPoster.SenderPlugins;
using XPoster.Workflows.Engine;

namespace XPoster.Tests.Orchestrators;

/// <summary>
/// Tests for <see cref="OrchestratorFactory"/>.
///
/// Design principle: tests inject synthetic <see cref="ScheduledOrchestrationProfile"/> entries
/// via a mocked <see cref="ISlotProfileProvider"/>. Every slot now resolves as a
/// <see cref="WorkflowOrchestrator"/> driven by its <see cref="ScheduledOrchestrationProfile.OrchestratorContextKey"/>;
/// changing the business schedule requires no changes to these tests.
/// </summary>
public class OrchestratorFactoryTests
{
    private readonly Mock<IServiceProvider> _mockServiceProvider;
    private readonly Mock<ILogger<OrchestratorFactory>> _mockLogger;
    private readonly Mock<ITimeProvider> _mockTimeProvider;
    private readonly Mock<IDryRunSenderSource> _mockDryRunSenderSource;

    // ---------------------------------------------------------------------------
    // Helpers: profile builders
    // ---------------------------------------------------------------------------

    private static ScheduledOrchestrationProfile WorkflowProfile(
        string workflowKey,
        int hour,
        IReadOnlyList<SenderPlatform>? platforms = null) =>
        new(
            workflowKey,
            hour,
            platforms ?? new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            typeof(WorkflowOrchestrator));

    public OrchestratorFactoryTests()
    {
        _mockServiceProvider = new Mock<IServiceProvider>();
        _mockLogger = new Mock<ILogger<OrchestratorFactory>>();
        _mockTimeProvider = new Mock<ITimeProvider>();
        _mockDryRunSenderSource = new Mock<IDryRunSenderSource>();

        SetupMocksForOrchestratorFactory();
    }

    // ---------------------------------------------------------------------------
    // Orchestrator type resolution
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(SenderPlatform.LinkedIn)]
    [InlineData(SenderPlatform.X)]
    [InlineData(SenderPlatform.DryRun)]
    public void Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(
        SenderPlatform platform)
    {
        const int arbitraryHour = 10;
        var profile = WorkflowProfile("Bitcoin", arbitraryHour,
            new List<SenderPlatform> { platform }.AsReadOnly());

        var factory = CreateFactoryWithProfiles(arbitraryHour, profile);

        Assert.IsType<WorkflowOrchestrator>(factory.Resolve());
    }

    [Fact]
    public void Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour()
    {
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>());

        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, 3, 0, 0));

        var factory = CreateFactory(mockProfileProvider.Object);

        Assert.IsType<NoOrchestrator>(factory.Resolve());
    }

    // ---------------------------------------------------------------------------
    // WorkflowOrchestrator routing
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered()
    {
        const int hour = 9;
        var profile = WorkflowProfile("Bitcoin", hour);

        var factory = CreateFactoryWithProfiles(hour, profile);
        var orchestrator = factory.Resolve();

        Assert.IsType<WorkflowOrchestrator>(orchestrator);
    }

    [Fact]
    public void Resolve_ForMissingContextKey_ReturnsNoOrchestrator()
    {
        const int hour = 9;
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: hour,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(WorkflowOrchestrator));

        var factory = CreateFactoryWithProfiles(hour, profile);

        Assert.IsType<NoOrchestrator>(factory.Resolve());
    }

    [Fact]
    public void Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing()
    {
        const int hour = 9;
        var profile = WorkflowProfile("Workflow:Missing", hour);

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(WorkflowDefinition), "Workflow:Missing"))
            .Returns((object?)null);

        var factory = CreateFactoryWithProfiles(hour, profile);

        Assert.IsType<NoOrchestrator>(factory.Resolve());
    }

    // ---------------------------------------------------------------------------
    // Dry-run sender routing
    // ---------------------------------------------------------------------------

    [Fact]
    public void Resolve_ForDryRunProfile_ResolvesSendersFromTheDryRunSource()
    {
        const int hour = 9;
        var profile = WorkflowProfile("Bitcoin", hour,
            new List<SenderPlatform> { SenderPlatform.DryRun }.AsReadOnly());

        _mockDryRunSenderSource
            .Setup(s => s.Resolve())
            .Returns(new List<ISender> { new Mock<ISender>().Object }.AsReadOnly());

        var factory = CreateFactoryWithProfiles(hour, profile);

        Assert.IsType<WorkflowOrchestrator>(factory.Resolve());
        _mockDryRunSenderSource.Verify(s => s.Resolve(), Times.Once);
    }

    [Fact]
    public void Resolve_ForDryRunProfile_WithSourceFailure_FallsBackToEmptySenders()
    {
        const int hour = 9;
        var profile = WorkflowProfile("Bitcoin", hour,
            new List<SenderPlatform> { SenderPlatform.DryRun }.AsReadOnly());

        _mockDryRunSenderSource
            .Setup(s => s.Resolve())
            .Throws(new InvalidOperationException("boom"));

        var factory = CreateFactoryWithProfiles(hour, profile);

        Assert.IsType<WorkflowOrchestrator>(factory.Resolve());
        _mockDryRunSenderSource.Verify(s => s.Resolve(), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // Sender wiring
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(SenderPlatform.LinkedIn)]
    [InlineData(SenderPlatform.X)]
    [InlineData(SenderPlatform.Instagram)]
    [InlineData(SenderPlatform.Facebook)]
    public void Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(SenderPlatform platform)
    {
        var factory = CreateFactoryWithProfiles(10, WorkflowProfile("Bitcoin", 10,
            new List<SenderPlatform> { platform }.AsReadOnly()));

        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(sp => sp.GetKeyedService(typeof(ISender), platform), Times.Once);
    }

    [Fact]
    public void Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile()
    {
        const int hour = 8;
        var profile = WorkflowProfile("Bitcoin", hour,
            new List<SenderPlatform>
            {
                SenderPlatform.LinkedIn,
                SenderPlatform.X,
                SenderPlatform.Instagram
            }.AsReadOnly());

        var factory = CreateFactoryWithProfiles(hour, profile);
        factory.Resolve();

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider.Verify(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.LinkedIn), Times.Once);
        keyedProvider.Verify(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.X), Times.Once);
        keyedProvider.Verify(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.Instagram), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // DryRunSlotProfileProvider decorator
    // ---------------------------------------------------------------------------

    [Fact]
    public void DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles()
    {
        var innerProfile = WorkflowProfile("Bitcoin", 6,
            new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly());

        var mockInner = new Mock<ISlotProfileProvider>();
        mockInner.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile> { innerProfile });

        var provider = new DryRunSlotProfileProvider(mockInner.Object);
        var profiles = provider.GetProfiles();

        Assert.Equal(2, profiles.Count);
        Assert.Contains(profiles, p => p.SenderPlatforms.Contains(SenderPlatform.DryRun));
    }

    // ---------------------------------------------------------------------------
    // SupportedPlatforms contract
    // ---------------------------------------------------------------------------

    [Fact]
    public void WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()
    {
        var factory = CreateFactoryWithProfiles(14,
            WorkflowProfile("PowerLaw", 14,
                new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly()));
        var orchestrator = Assert.IsType<WorkflowOrchestrator>(factory.Resolve());

        Assert.Contains(SenderPlatform.X, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Instagram, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Facebook, orchestrator.SupportedPlatforms);
        Assert.DoesNotContain(SenderPlatform.DryRun, orchestrator.SupportedPlatforms);
    }

    [Fact]
    public void NoOrchestrator_SupportedPlatforms_IsEmpty()
    {
        var mockProfileProvider = new Mock<ISlotProfileProvider>();
        mockProfileProvider.Setup(p => p.GetProfiles())
            .Returns(new List<ScheduledOrchestrationProfile>());
        _mockTimeProvider.Setup(tp => tp.GetCurrentTime())
            .Returns(new DateTime(2025, 1, 1, 3, 0, 0));

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

        return CreateFactory(mockProfileProvider.Object);
    }

    private OrchestratorFactory CreateFactory(ISlotProfileProvider profileProvider) =>
        new(_mockServiceProvider.Object, _mockLogger.Object, _mockTimeProvider.Object, profileProvider, new Mock<IWorkflowEngine>().Object, _mockDryRunSenderSource.Object);

    private void SetupMocksForOrchestratorFactory()
    {
        var mockXSender = new Mock<ISender>();
        var mockInSender = new Mock<ISender>();
        var mockIgSender = new Mock<ISender>();
        var mockFbSender = new Mock<ISender>();

        _mockServiceProvider
            .Setup(sp => sp.GetService(typeof(ILogger<WorkflowOrchestrator>)))
            .Returns(new Mock<ILogger<WorkflowOrchestrator>>().Object);
        _mockServiceProvider
            .Setup(sp => sp.GetService(typeof(ILogger<NoOrchestrator>)))
            .Returns(new Mock<ILogger<NoOrchestrator>>().Object);

        var keyedProvider = _mockServiceProvider.As<IKeyedServiceProvider>();
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.X))
            .Returns(mockXSender.Object);
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.LinkedIn))
            .Returns(mockInSender.Object);
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.Instagram))
            .Returns(mockIgSender.Object);
        keyedProvider
            .Setup(sp => sp.GetKeyedService(typeof(ISender), SenderPlatform.Facebook))
            .Returns(mockFbSender.Object);

        foreach (var workflowKey in new[] { "Bitcoin", "PowerLaw" })
        {
            keyedProvider
                .Setup(sp => sp.GetKeyedService(typeof(WorkflowDefinition), workflowKey))
                .Returns(new WorkflowDefinition(workflowKey, new List<WorkflowNodeDefinition>()));
        }

        _mockDryRunSenderSource
            .Setup(s => s.Resolve())
            .Returns(new List<ISender> { new Mock<ISender>().Object }.AsReadOnly());
    }
}
