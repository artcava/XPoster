using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Tests.Models;

/// <summary>
/// Tests for <see cref="ScheduledOrchestrationProfile"/> field initialisation.
/// Verifies that OrchestratorContextKey is correctly stored and may be null,
/// and that the constructor produces the correct property values.
/// </summary>
public class ScheduledOrchestrationProfileTests
{
    [Fact]
    public void Constructor_Should_SetAllFields()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed08",
            hour: 8,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn, SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(WorkflowOrchestrator));

        Assert.Equal("Feed08", profile.OrchestratorContextKey);
        Assert.Equal(8, profile.Hour);
        Assert.Contains(SenderPlatform.LinkedIn, profile.SenderPlatforms);
        Assert.Contains(SenderPlatform.X, profile.SenderPlatforms);
        Assert.Equal(typeof(WorkflowOrchestrator), profile.OrchestratorType);
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
            typeof(WorkflowOrchestrator));

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
            orchestratorType: typeof(WorkflowOrchestrator));

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
            orchestratorType: typeof(WorkflowOrchestrator));

        Assert.Equal("Feed06", profile.OrchestratorContextKey);
    }

    [Fact]
    public void OrchestratorContextKey_Should_BeNull_WhenNotProvided()
    {
        var profile = new ScheduledOrchestrationProfile(
            orchestratorContextKey: null,
            hour: 14,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(WorkflowOrchestrator));

        Assert.Null(profile.OrchestratorContextKey);
    }

    [Fact]
    public void TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys()
    {
        var slot06 = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed06",
            hour: 6,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.X }.AsReadOnly(),
            orchestratorType: typeof(WorkflowOrchestrator));

        var slot08 = new ScheduledOrchestrationProfile(
            orchestratorContextKey: "Feed08",
            hour: 8,
            senderPlatforms: new List<SenderPlatform> { SenderPlatform.LinkedIn }.AsReadOnly(),
            orchestratorType: typeof(WorkflowOrchestrator));

        Assert.Equal(typeof(WorkflowOrchestrator), slot06.OrchestratorType);
        Assert.Equal(typeof(WorkflowOrchestrator), slot08.OrchestratorType);
        Assert.NotEqual(slot06.OrchestratorContextKey, slot08.OrchestratorContextKey);
        Assert.Equal("Feed06", slot06.OrchestratorContextKey);
        Assert.Equal("Feed08", slot08.OrchestratorContextKey);
    }
}
