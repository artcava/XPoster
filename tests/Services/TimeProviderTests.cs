using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for the concrete TimeProvider implementation.
/// </summary>
public class TimeProviderTests
{
    [Fact]
    public void GetCurrentTime_ReturnsCurrentDateTime()
    {
        var provider = new TimeProvider();
        var before = DateTime.Now;
        var result = provider.GetCurrentTime();
        var after = DateTime.Now;

        Assert.InRange(result, before, after);
    }

    [Fact]
    public void GetCurrentTime_ReturnsLocalTime()
    {
        var provider = new TimeProvider();
        var result = provider.GetCurrentTime();

        // DateTime.Now is always Local or Unspecified, never Utc
        Assert.NotEqual(DateTimeKind.Utc, result.Kind);
    }
}
