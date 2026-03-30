// CS0104: disambiguate between XPoster.Services.TimeProvider and System.TimeProvider
using XPosterTimeProvider = XPoster.Services.TimeProvider;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for the concrete TimeProvider implementation.
/// </summary>
public class TimeProviderTests
{
    [Fact]
    public void GetCurrentTime_ReturnsCurrentDateTime()
    {
        var provider = new XPosterTimeProvider();
        var before = DateTime.Now;
        var result = provider.GetCurrentTime();
        var after = DateTime.Now;

        Assert.InRange(result, before, after);
    }

    [Fact]
    public void GetCurrentTime_ReturnsLocalTime()
    {
        var provider = new XPosterTimeProvider();
        var result = provider.GetCurrentTime();

        // DateTime.Now is always Local or Unspecified, never Utc
        Assert.NotEqual(DateTimeKind.Utc, result.Kind);
    }
}
