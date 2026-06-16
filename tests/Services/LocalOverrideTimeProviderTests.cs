using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for <see cref="LocalOverrideTimeProvider"/>.
/// Verifies that the dev-only time override reads ForceHour correctly and
/// falls back gracefully when the setting is absent or invalid.
/// </summary>
public class LocalOverrideTimeProviderTests
{
    private static LocalOverrideTimeProvider BuildProvider(string? forceHour)
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(forceHour is null
                ? Array.Empty<KeyValuePair<string, string?>>()
                : new[] { new KeyValuePair<string, string?>("ForceHour", forceHour) })
            .Build();

        var log = NullLogger<LocalOverrideTimeProvider>.Instance;
        return new LocalOverrideTimeProvider(config, log);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(14)]
    [InlineData(16)]
    [InlineData(23)]
    public void GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(int hour)
    {
        // Arrange
        var provider = BuildProvider(hour.ToString());

        // Act
        var result = provider.GetCurrentTime();

        // Assert
        Assert.Equal(hour, result.Hour);
    }

    [Fact]
    public void GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind()
    {
        // Arrange
        var provider = BuildProvider("8");

        // Act
        var result = provider.GetCurrentTime();

        // Assert
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }

    [Fact]
    public void GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour()
    {
        // Arrange
        var provider = BuildProvider(null);
        var before = DateTime.UtcNow;

        // Act
        var result = provider.GetCurrentTime();

        var after = DateTime.UtcNow;

        // Assert — result hour must match current UTC hour (window: same minute)
        Assert.InRange(result.Hour, before.Hour, after.Hour);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }

    [Fact]
    public void GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour()
    {
        // Arrange
        var provider = BuildProvider("not-a-number");
        var before = DateTime.UtcNow;

        // Act — must not throw
        var result = provider.GetCurrentTime();

        var after = DateTime.UtcNow;

        // Assert
        Assert.InRange(result.Hour, before.Hour, after.Hour);
    }

    [Fact]
    public void GetCurrentTime_WhenForceHourIsOutOfRange_StillReturnsConfiguredValue()
    {
        // Arrange — no clamping in the provider; OrchestratorFactory handles no-match gracefully
        var provider = BuildProvider("99");

        // Act
        var result = provider.GetCurrentTime();

        // Assert — value is stored and returned as-is; slot miss is the factory's concern
        Assert.Equal(99, result.Hour);
    }
}
