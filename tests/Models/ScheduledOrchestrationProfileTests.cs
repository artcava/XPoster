using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Tests.Models;

/// <summary>
/// Tests for <see cref="ScheduledOrchestrationProfile"/> field initialisation.
/// Verifies that TextProvider and ImageProvider are independently nullable,
/// that OrchestratorContextKey is correctly stored and may be null,
/// and that all constructor combinations produce the correct property values.
/// </summary>
public class ScheduledOrchestrationProfileTests
{
    [Fact]
    public void Constructor_Should_SetAllFields_WhenBothProvidersSupplied()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed08",
            hour: 8,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn, SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.AzureFoundry);

        Assert.Equal("Feed08", profile.OrchestratorContextKey);
        Assert.Equal(8, profile.Hour);
        Assert.Contains(SenderPlatform.LinkedIn, profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.X, profile.SenderPlatforms);
        Assert.Equal(typeof(FeedOrchestrator), profile.OrchestratorType);
        Assert.Equal(AiProvider.OpenAi, profile.TextProvider);
        Assert.Equal(AiProvider.AzureFoundry, profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed10",
            hour: 10,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.DeepSeek,
            imageProvider: null);

        Assert.Equal(AiProvider.DeepSeek, profile.TextProvider);
        Assert.Null(profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: 12,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.Instagram }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: null,
            imageProvider: AiProvider.FalAi);

        Assert.Null(profile.TextProvider);
        Assert.Equal(AiProvider.FalAi, profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: 14,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(PowerLawOrchestrator));

        Assert.Null(profile.TextProvider);
        Assert.Null(profile.ImageProvider);
    }

    [Fact]
    public void Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed06",
            hour: 6,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.DeepSeek,
            imageProvider: AiProvider.FalAi);

        Assert.Equal(AiProvider.DeepSeek, profile.TextProvider);
        Assert.Equal(AiProvider.FalAi, profile.ImageProvider);
        Assert.NotEqual(profile.TextProvider, profile.ImageProvider);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    [InlineData(23)]
    public void Constructor_Should_PreserveHour_ForBoundaryValues(int hour)
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour,
            new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            typeof(FeedOrchestrator));

        Assert.Equal(hour, profile.Hour);
    }

    [Fact]
    public void Constructor_Should_PreserveOrderOfSenderPlatforms()
    {
        var platforms = new List<SenderPlatform>
        {
            SenderPlatform.LinkedIn,
            SenderPlatform.X,
            SenderPlatform.Instagram
        }.AsReadOnly();

        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed08",
            hour: 8,
            senderPlatforms: platforms,
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);

        Assert.Equal(SenderPlatform.LinkedIn, profile.SenderPlatforms[0]);
        Assert.Equal(SenderPlatform.X, profile.SenderPlatforms[1]);
        Assert.Equal(SenderPlatform.Instagram, profile.SenderPlatforms[2]);
    }

    [Fact]
    public void OrchestratorContextKey_Should_BeSet_WhenProvided()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed06",
            hour: 6,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);

        Assert.Equal("Feed06", profile.OrchestratorContextKey);
    }

    [Fact]
    public void OrchestratorContextKey_Should_BeNull_WhenNotProvided()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: 14,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(PowerLawOrchestrator));

        Assert.Null(profile.OrchestratorContextKey);
    }

    [Fact]
    public void TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys()
    {
        var slot06 = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed06",
            hour: 6,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.OpenAi);

        var slot08 = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed08",
            hour: 8,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(FeedOrchestrator),
            textProvider: AiProvider.OpenAi,
            imageProvider: AiProvider.AzureFoundry);

        Assert.Equal(typeof(FeedOrchestrator), slot06.OrchestratorType);
        Assert.Equal(typeof(FeedOrchestrator), slot08.OrchestratorType);
        Assert.NotEqual(slot06.OrchestratorContextKey, slot08.OrchestratorContextKey);
        Assert.Equal("Feed06", slot06.OrchestratorContextKey);
        Assert.Equal("Feed08", slot08.OrchestratorContextKey);
    }
}
