using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Providers;

namespace XPoster.Tests.Providers;

/// <summary>
/// Tests for <see cref="DefaultSlotProfileProvider"/> slot configuration.
/// Verifies the fan-out slot structure, AI capability providers, and ordering conventions.
/// </summary>
public class DefaultSlotProfileProviderTests
{
    private readonly DefaultSlotProfileProvider _provider = new();

    // ---------------------------------------------------------------------------
    // Slot count and hour uniqueness
    // ---------------------------------------------------------------------------

    [Fact]
    public void GetProfiles_Should_ReturnWellFormedProfiles()
    {
        var provider = new DefaultSlotProfileProvider();

        var profiles = provider.GetProfiles().ToList();

        Assert.NotEmpty(profiles);

        Assert.All(profiles, profile =>
        {
            Assert.InRange(profile.Hour, 0, 23);
            Assert.NotNull(profile.SenderPlatforms);
            Assert.NotEmpty(profile.SenderPlatforms);
            Assert.NotNull(profile.OrchestratorType);
        });

        Assert.Equal(
            profiles.Select(p => p.Hour).Distinct().Count(),
            profiles.Count);
    }

    [Fact]
    public void GetProfiles_Should_HaveUniqueHours()
    {
        var profiles = _provider.GetProfiles();
        var hours = profiles.Select(p => p.Hour).ToList();
        Assert.Equal(hours.Count, hours.Distinct().Count());
    }

    // ---------------------------------------------------------------------------
    // Fan-out slot at hour 6: WorkflowOrchestrator with LinkedIn + X + Instagram + Facebook
    // ---------------------------------------------------------------------------

    [Fact]
    public void WorkflowOrchestratorSlot_Should_HaveTextProviderConfigured()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 6);

        Assert.Equal(typeof(WorkflowOrchestrator), profile.OrchestratorType);
        Assert.NotNull(profile.TextProvider);
        Assert.NotEqual(AiProvider.None, profile.TextProvider);
    }

    [Fact]
    public void WorkflowOrchestratorSlot_Should_HaveImageProviderConfigured()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 6);

        Assert.NotNull(profile.ImageProvider);
        Assert.NotEqual(AiProvider.None, profile.ImageProvider);
    }

    [Fact]
    public void WorkflowOrchestratorSlot_Should_HaveDistinctTextAndImageProviders()
    {
        // OpenAi for text, AzureFoundry for image — must be stored independently
        var profile = _provider.GetProfiles().Single(p => p.Hour == 6);

        Assert.NotEqual(profile.TextProvider, profile.ImageProvider);
        Assert.Equal(AiProvider.OpenAi, profile.TextProvider);
        Assert.Equal(AiProvider.AzureFoundry, profile.ImageProvider);
    }

    [Fact]
    public void WorkflowOrchestratorSlot_Should_ContainLinkedInAndX()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 6);

        Assert.Contains(SenderPlatform.LinkedIn, profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.X, profile.SenderPlatforms);
    }

    [Fact]
    public void WorkflowOrchestratorSlot_Should_HaveAtLeastOneSender()
    {
        // Declaration order in SenderPlatforms is not significant:
        // WorkflowOrchestrator re-orders senders internally by descending MessageMaxLength at runtime.
        var profile = _provider.GetProfiles().Single(p => p.Hour == 6);

        Assert.NotEmpty(profile.SenderPlatforms);
    }

    // ---------------------------------------------------------------------------
    // PowerLaw slot at hour 14 — LinkedIn + X, no AI provider
    // ---------------------------------------------------------------------------

    [Fact]
    public void PowerLawSlot_Should_ContainLinkedInAndX()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 14);

        Assert.Equal(typeof(PowerLawOrchestrator), profile.OrchestratorType);
        Assert.Contains(SenderPlatform.LinkedIn, profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.X, profile.SenderPlatforms);
    }

    [Fact]
    public void PowerLawSlot_Should_HaveNullTextAndImageProvider()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 14);

        Assert.Null(profile.TextProvider);
        Assert.Null(profile.ImageProvider);
    }

    // ---------------------------------------------------------------------------
    // DryRun absent from production schedule
    // ---------------------------------------------------------------------------

    [Fact]
    public void GetProfiles_Should_NotContainDryRunSlot()
    {
        var profiles = _provider.GetProfiles();
        Assert.DoesNotContain(profiles, p => p.SenderPlatforms.Contains(SenderPlatform.DryRun));
    }

    // ---------------------------------------------------------------------------
    // DryRunSlotProfileProvider decorator
    // ---------------------------------------------------------------------------

    [Fact]
    public void DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured()
    {
        var dryRunProvider = new DryRunSlotProfileProvider(_provider);
        var dryRunSlot = dryRunProvider.GetProfiles()
            .Single(p => p.SenderPlatforms.Contains(SenderPlatform.DryRun));

        Assert.Equal(typeof(WorkflowOrchestrator), dryRunSlot.OrchestratorType);
        Assert.NotNull(dryRunSlot.TextProvider);
        Assert.NotNull(dryRunSlot.ImageProvider);
    }
}