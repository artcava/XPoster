// CS0104: disambiguate between XPoster.Services.TimeProvider and System.TimeProvider
using XPosterTimeProvider = XPoster.Services.TimeProvider;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for the concrete <see cref="XPoster.Services.TimeProvider"/> implementation.
/// After issue #171, GetCurrentTime() returns DateTime.UtcNow.
/// </summary>
public class TimeProviderTests
{
    [Fact]
    public void GetCurrentTime_ReturnsCurrentDateTime()
    {
        // Arrange
        var provider = new XPosterTimeProvider();
        var before = DateTime.UtcNow;

        // Act
        var result = provider.GetCurrentTime();

        // Assert
        var after = DateTime.UtcNow;
        Assert.InRange(result, before, after);
    }

    [Fact]
    public void GetCurrentTime_ReturnsUtcTime()
    {
        // Arrange
        var provider = new XPosterTimeProvider();

        // Act
        var result = provider.GetCurrentTime();

        // Assert — must be UTC so OrchestratorFactory slot matching is timezone-agnostic
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }
}
