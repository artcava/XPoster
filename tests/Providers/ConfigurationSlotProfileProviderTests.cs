using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Providers;

namespace XPoster.Tests.Providers;

/// <summary>
/// Tests for <see cref="ConfigurationSlotProfileProvider"/>.
/// </summary>
public class ConfigurationSlotProfileProviderTests
{
    private static ConfigurationSlotProfileProvider CreateProvider(params (string Key, string? Value)[] settings) =>
        new(BuildConfiguration(settings), NullLogger<ConfigurationSlotProfileProvider>.Instance);

    private static IConfiguration BuildConfiguration(params (string Key, string? Value)[] settings)
    {
        var data = settings.ToDictionary(s => s.Key, s => s.Value);
        return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
    }

    // ---------------------------------------------------------------------------
    // Mapping
    // ---------------------------------------------------------------------------

    [Fact]
    public void GetProfiles_Should_MapEachSlotToWorkflowOrchestrator()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Workflow", "Bitcoin"),
            ("Schedule:0:Senders:0", "LinkedIn"),
            ("Schedule:1:Hour", "14"),
            ("Schedule:1:Workflow", "PowerLaw"),
            ("Schedule:1:Senders:0", "LinkedIn"));

        var profiles = provider.GetProfiles();

        Assert.Equal(2, profiles.Count);
        Assert.All(profiles, p => Assert.Equal(typeof(WorkflowOrchestrator), p.OrchestratorType));
        Assert.Equal("Bitcoin", profiles[0].OrchestratorContextKey);
        Assert.Equal(6, profiles[0].Hour);
        Assert.Equal("PowerLaw", profiles[1].OrchestratorContextKey);
        Assert.Equal(14, profiles[1].Hour);
    }

    [Fact]
    public void GetProfiles_Should_ParseSenderPlatforms()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Workflow", "Bitcoin"),
            ("Schedule:0:Senders:0", "LinkedIn"),
            ("Schedule:0:Senders:1", "X"));

        var profile = provider.GetProfiles().Single();

        Assert.Equal(new[] { SenderPlatform.LinkedIn, SenderPlatform.X }, profile.SenderPlatforms);
    }

    [Fact]
    public void GetProfiles_Should_OrderSlotsByHour()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "14"),
            ("Schedule:0:Workflow", "PowerLaw"),
            ("Schedule:0:Senders:0", "LinkedIn"),
            ("Schedule:1:Hour", "6"),
            ("Schedule:1:Workflow", "Bitcoin"),
            ("Schedule:1:Senders:0", "LinkedIn"));

        var hours = provider.GetProfiles().Select(p => p.Hour).ToList();

        Assert.Equal(new[] { 6, 14 }, hours);
    }

    // ---------------------------------------------------------------------------
    // Filtering / validation
    // ---------------------------------------------------------------------------

    [Fact]
    public void GetProfiles_Should_SkipSlot_WithNoWorkflowKey()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Senders:0", "LinkedIn"),
            ("Schedule:1:Hour", "14"),
            ("Schedule:1:Workflow", "PowerLaw"),
            ("Schedule:1:Senders:0", "LinkedIn"));

        var profiles = provider.GetProfiles();

        Assert.Single(profiles);
        Assert.Equal("PowerLaw", profiles[0].OrchestratorContextKey);
    }

    [Fact]
    public void GetProfiles_Should_SkipSlot_WithNoSenders()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Workflow", "Bitcoin"));

        Assert.Empty(provider.GetProfiles());
    }

    [Fact]
    public void GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Workflow", "Bitcoin"),
            ("Schedule:0:Senders:0", "Unknown"),
            ("Schedule:0:Senders:1", "LinkedIn"));

        var profile = provider.GetProfiles().Single();

        Assert.Equal(new[] { SenderPlatform.LinkedIn }, profile.SenderPlatforms);
    }

    [Fact]
    public void GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain()
    {
        var provider = CreateProvider(
            ("Schedule:0:Hour", "6"),
            ("Schedule:0:Workflow", "Bitcoin"),
            ("Schedule:0:Senders:0", "Unknown"));

        Assert.Empty(provider.GetProfiles());
    }

    [Fact]
    public void GetProfiles_Should_ReturnEmpty_WhenNoScheduleConfigured()
    {
        var provider = CreateProvider();

        Assert.Empty(provider.GetProfiles());
    }
}
