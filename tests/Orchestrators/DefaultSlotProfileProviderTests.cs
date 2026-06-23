using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

/// <summary>
/// Tests for <see cref="DefaultSlotProfileProvider"/> slot configuration.
/// Verifies that FeedOrchestrator slots have both AI capability providers configured
/// and that PowerLaw slots have neither (they require no language model).
/// </summary>
public class DefaultSlotProfileProviderTests
{
    private readonly DefaultSlotProfileProvider _provider = new();

    // ---------------------------------------------------------------------------
    // Slot count and hour uniqueness
    // ---------------------------------------------------------------------------

    [Fact]
    public void GetProfiles_Should_ReturnFourActiveSlots()
    {
        var profiles = _provider.GetProfiles();
        Assert.Equal(4, profiles.Count);
    }

    [Fact]
    public void GetProfiles_Should_HaveUniqueHours()
    {
        var profiles = _provider.GetProfiles();
        var hours = profiles.Select(p => p.Hour).ToList();
        Assert.Equal(hours.Count, hours.Distinct().Count());
    }

    // ---------------------------------------------------------------------------
    // FeedOrchestrator slots — must have both TextProvider and ImageProvider
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(6,  SenderPlatform.LinkedIn)]
    [InlineData(8,  SenderPlatform.X)]
    public void FeedOrchestratorSlot_Should_HaveTextProviderConfigured(int hour, SenderPlatform platform)
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == hour);

        Assert.Equal(platform,               profile.SenderPlatform);
        Assert.Equal(typeof(FeedOrchestrator), profile.OrchestratorType);
        Assert.NotNull(profile.TextProvider);
        Assert.NotEqual(AiProvider.None,     profile.TextProvider);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(8)]
    public void FeedOrchestratorSlot_Should_HaveImageProviderConfigured(int hour)
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == hour);

        Assert.NotNull(profile.ImageProvider);
        Assert.NotEqual(AiProvider.None, profile.ImageProvider);
    }

    // ---------------------------------------------------------------------------
    // PowerLaw slots — must have no AI provider (they compute, not generate)
    // ---------------------------------------------------------------------------

    [Theory]
    [InlineData(14, SenderPlatform.LinkedIn)]
    [InlineData(16, SenderPlatform.X)]
    public void PowerLawSlot_Should_HaveNullTextAndImageProvider(int hour, SenderPlatform platform)
    {
        var profile = _provider.GetProfiles().Single(p => p.Hour == hour);

        Assert.Equal(platform,                   profile.SenderPlatform);
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
        Assert.DoesNotContain(profiles, p => p.SenderPlatform == SenderPlatform.DryRun);
    }

    // ---------------------------------------------------------------------------
    // DryRunSlotProfileProvider — decorator correctness
    // ---------------------------------------------------------------------------

    [Fact]
    public void DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured()
    {
        var dryRunProvider = new DryRunSlotProfileProvider(_provider);
        var dryRunSlot = dryRunProvider.GetProfiles()
            .Single(p => p.SenderPlatform == SenderPlatform.DryRun);

        Assert.Equal(typeof(FeedOrchestrator), dryRunSlot.OrchestratorType);
        Assert.NotNull(dryRunSlot.TextProvider);
        Assert.NotNull(dryRunSlot.ImageProvider);
    }
}
