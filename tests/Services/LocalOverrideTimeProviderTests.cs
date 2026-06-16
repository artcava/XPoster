using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for <see cref="LocalOverrideTimeProvider"/>.
/// Verifies that the dev-only time override reads ForceHour correctly and
/// falls back gracefully when the setting is absent or invalid.
/// </summary>
public class LocalOverrideTimeProviderTests
{
    private static LocalOverrideTimeProvider BuildProvider(string? forceHour,
        ILogger<LocalOverrideTimeProvider>? logger = null)
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(forceHour is null
                ? Array.Empty<KeyValuePair<string, string?>>()
                : new[] { new KeyValuePair<string, string?>("ForceHour", forceHour) })
            .Build();

        var log = logger ?? NullLogger<LocalOverrideTimeProvider>.Instance;
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
    public void GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour()
    {
        // Arrange
        // Boundary distinct from null and non-numeric:
        // TryParse("", ...) returns false → fallback to DateTime.UtcNow.Hour.
        var provider = BuildProvider("");
        var before = DateTime.UtcNow;

        // Act — must not throw
        var result = provider.GetCurrentTime();

        var after = DateTime.UtcNow;

        // Assert
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
    public void GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow()
    {
        // Arrange
        // DateTime.UtcNow.Date.AddHours(99) overflows naturally:
        // 99 % 24 = 3  →  result.Hour == 3.
        // The provider stores the raw value without clamping; DateTime handles
        // the arithmetic. OrchestratorFactory will find no matching slot (no
        // profile has Hour == 3 for a ForceHour of 99), which is the expected
        // graceful miss behaviour.
        const int forceHour = 99;
        const int expectedHour = forceHour % 24; // 3
        var provider = BuildProvider(forceHour.ToString());

        // Act
        var result = provider.GetCurrentTime();

        // Assert
        Assert.Equal(expectedHour, result.Hour);
    }

    [Theory]
    [InlineData("8")]        // valid hour — forced path
    [InlineData(null)]       // absent — fallback path
    [InlineData("")]         // empty — fallback path
    [InlineData("not-a-number")] // non-numeric — fallback path
    public void Constructor_AlwaysEmitsDevOverrideWarning(string? forceHour)
    {
        // Arrange
        var loggerMock = new Mock<ILogger<LocalOverrideTimeProvider>>();

        // Act
        BuildProvider(forceHour, loggerMock.Object);

        // Assert — warning must be emitted exactly once regardless of ForceHour value
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("[DEV OVERRIDE]") &&
                    v.ToString()!.Contains("LocalOverrideTimeProvider active")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
