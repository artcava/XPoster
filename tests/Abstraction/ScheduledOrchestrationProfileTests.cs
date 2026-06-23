using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Orchestrators;

namespace XPoster.Tests.Abstraction;

/// <summary>
/// Tests for <see cref="ScheduledOrchestrationProfile"/> field initialisation.
/// Verifies that TextProvider and ImageProvider are independently nullable
/// and that all constructor combinations produce the correct property values.
/// </summary>
public class ScheduledOrchestrationProfileTests
{
    [Fact]
    public void Constructor_Should_SetAllFields_WhenBothProvidersSupplied()
    {
        // ARRANGE + ACT
        var profile = new ScheduledOrchestrationProfile(
            hour: 8,
            senderPlatform: SenderPlatform.X,
            orchestratorType: typeof(FeedOrchestrator),
            textProvider:  AiProvider.OpenAi,
            imageProvider: AiProvider.AzureFoundry);

        // ASSERT
        Assert.Equal(8,                       profile.Hour);
        Assert.Equal(SenderPlatform.X,        profile.SenderPlatform);
        Assert.Equal(typeof(FeedOrchestrator), profile.OrchestratorType);
        Assert.Equal(AiProvider.OpenAi,       profile.TextProvider);
        Assert.Equal(AiProvider.AzureFoundry, profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied()
    {
        // ARRANGE + ACT — text-only slot (e.g. DeepSeek for summarisation, no image)
        var profile = new ScheduledOrchestrationProfile(
            hour: 10,
            senderPlatform: SenderPlatform.LinkedIn,
            orchestratorType: typeof(FeedOrchestrator),
            textProvider:  AiProvider.DeepSeek,
            imageProvider: null);

        // ASSERT
        Assert.Equal(AiProvider.DeepSeek, profile.TextProvider);
        Assert.Null(profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied()
    {
        // ARRANGE + ACT — hypothetical image-only slot
        var profile = new ScheduledOrchestrationProfile(
            hour: 12,
            senderPlatform: SenderPlatform.Instagram,
            orchestratorType: typeof(FeedOrchestrator),
            textProvider:  null,
            imageProvider: AiProvider.FalAi);

        // ASSERT
        Assert.Null(profile.TextProvider);
        Assert.Equal(AiProvider.FalAi, profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied()
    {
        // ARRANGE + ACT — no-AI slot (e.g. PowerLaw which needs no language model)
        var profile = new ScheduledOrchestrationProfile(
            hour: 14,
            senderPlatform: SenderPlatform.LinkedIn,
            orchestratorType: typeof(PowerLawOrchestrator));

        // ASSERT
        Assert.Null(profile.TextProvider);
        Assert.Null(profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot()
    {
        // ARRANGE + ACT — canonical split-provider scenario: DeepSeek text + FalAi image
        var profile = new ScheduledOrchestrationProfile(
            hour: 6,
            senderPlatform: SenderPlatform.X,
            orchestratorType: typeof(FeedOrchestrator),
            textProvider:  AiProvider.DeepSeek,
            imageProvider: AiProvider.FalAi);

        // ASSERT — providers must be stored independently, no cross-contamination
        Assert.Equal(AiProvider.DeepSeek, profile.TextProvider);
        Assert.Equal(AiProvider.FalAi,    profile.ImageProvider);
        Assert.NotEqual(profile.TextProvider, profile.ImageProvider);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    [InlineData(23)]
    public void Constructor_Should_PreserveHour_ForBoundaryValues(int hour)
    {
        var profile = new ScheduledOrchestrationProfile(
            hour, SenderPlatform.X, typeof(FeedOrchestrator));

        Assert.Equal(hour, profile.Hour);
    }
}
