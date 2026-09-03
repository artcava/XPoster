using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class DryRunSenderSourceTests
{
    private static IConfiguration BuildConfig(params int[] maxLengths)
    {
        var data = new Dictionary<string, string?>();
        for (var i = 0; i < maxLengths.Length; i++)
        {
            data[$"DryRunSenders:{i}:MaxLength"] = maxLengths[i].ToString();
        }

        return new ConfigurationBuilder()
            .AddInMemoryCollection(data)
            .Build();
    }

    private bool FoundSender(DryRunSenderSource source, int maxLength)
    {
        return source.Resolve().Any(s => s.MessageMaxLength == maxLength);
    }

    [Fact]
    public void Resolve_WithNoDryRunSendersConfig_ReturnsSingleUnlimitedSender()
    {
        var source = new DryRunSenderSource(BuildConfig(), NullLogger<DryRunSender>.Instance);
        var senders = source.Resolve();

        var sender = Assert.Single(senders);
        Assert.Equal(int.MaxValue, sender.MessageMaxLength);
    }

    [Fact]
    public void Resolve_WithSingleConfiguredSender_ReturnsThatSender()
    {
        var source = new DryRunSenderSource(BuildConfig(100), NullLogger<DryRunSender>.Instance);
        var senders = source.Resolve();

        var sender = Assert.Single(senders);
        Assert.Equal(100, sender.MessageMaxLength);
    }

    [Fact]
    public void Resolve_WithMultipleConfiguredSenders_ReturnsAllDistinctSenders()
    {
        var source = new DryRunSenderSource(
            BuildConfig(int.MaxValue, 100),
            NullLogger<DryRunSender>.Instance);

        var senders = source.Resolve();

        Assert.Equal(2, senders.Count);
        Assert.True(FoundSender(source, int.MaxValue));
        Assert.True(FoundSender(source, 100));
    }

    [Fact]
    public void Resolve_ReturnsSendersOrderedByDescendingMaxLength()
    {
        var source = new DryRunSenderSource(
            BuildConfig(100, int.MaxValue, 500),
            NullLogger<DryRunSender>.Instance);

        var senders = source.Resolve();

        Assert.Equal(3, senders.Count);
        Assert.True(senders[0].MessageMaxLength > senders[1].MessageMaxLength);
        Assert.True(senders[1].MessageMaxLength > senders[2].MessageMaxLength);
    }
}