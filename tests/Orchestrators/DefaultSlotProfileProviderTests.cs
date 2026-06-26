using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

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
    public void GetProfiles_Should_ReturnThreeActiveSlots()
    {
        var profiles = _provider.GetProfiles();
        Assert.Equal(3, profiles.Count);
    }

    [Fact]
    public void GetProfiles_Should_HaveUniqueHours()
    {
        var profiles = _provider.GetProfiles();
        var hours = profiles.Select(p => p.Hour).ToList();
        Assert.Equal(hours.Count, hours.Distinct().Count());
    }

    // ---------------------------------------------------------------------------
    // Fan-out slot at hour 8: FeedOrchestrator with LinkedIn + X + Instagram
    // ---------------------------------------------------------------------------

    [Fact]
    public void FeedOrchestratorSlot_Should_HaveTextProviderConfigured()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 8);

        Assert.Equal(typeof(FeedOrchestrator), profile.OrchestratorType);
        Assert.NotNull(profile.TextProvider);
        Assert.NotEqual(AiProvider.None, profile.TextProvider);
    }

    [Fact]
    public void FeedOrchestratorSlot_Should_HaveImageProviderConfigured()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 8);

        Assert.NotNull(profile.ImageProvider);
        Assert.NotEqual(AiProvider.None, profile.ImageProvider);
    }

    [Fact]
    public void FeedOrchestratorSlot_Should_ContainLinkedInXAndInstagram()
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == 8);

        Assert.Contains(SenderPlatform.LinkedIn,  profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.X,         profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.Instagram, profile.SenderPlatforms);
    }

    [Fact]
    public void FeedOrchestratorSlot_Should_HaveLinkedInAsFirstSender()
    {
        // LinkedIn has the widest MessageMaxLength — must be the primary sender (index 0)
        var profile = _provider.GetProfiles().Single(p => p.Hour == 8);

        Assert.Equal(SenderPlatform.LinkedIn, profile.SenderPlatforms[0]);
    }

    // ---------------------------------------------------------------------------
    // PowerLaw slots — must have no AI provider
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(14, SenderPlatform.LinkedIn)]
    [InlineData(16, SenderPlatform.X)]
    public void PowerLawSlot_Should_HaveNullTextAndImageProvider(int hour, SenderPlatform platform)
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == hour);

        Assert.Equal(platform,                    profile.SenderPlatforms[0]);
        Assert.Equal(typeof(PowerLawOrchestrator), profile.OrchestratorType);
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

        Assert.Equal(typeof(FeedOrchestrator), dryRunSlot.OrchestratorType);
        Assert.NotNull(dryRunSlot.TextProvider);
        Assert.NotNull(dryRunSlot.ImageProvider);
    }
}
