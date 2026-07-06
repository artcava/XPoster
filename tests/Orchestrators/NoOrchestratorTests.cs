using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

public class NoOrchestratorTests
{
    private readonly Mock<ILogger<NoOrchestrator>> _mockLogger = new();

    private NoOrchestrator Build() => new(_mockLogger.Object);

    [Fact]
    public void SendIt_IsAlwaysFalse()
    {
        Assert.False(Build().SendIt);
    }

    [Fact]
    public void SendIt_Set_ThrowsNotImplementedException()
    {
        var o = Build();
        Assert.Throws<System.NotImplementedException>(() => o.SendIt = true);
    }

    [Fact]
    public void Name_IsNoOrchestrator()
    {
        Assert.Equal(nameof(NoOrchestrator), Build().Name);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsEmptyList()
    {
        var result = await Build().OrchestrateAsync();
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void SupportedPlatforms_IsEmpty()
    {
        Assert.Empty(Build().SupportedPlatforms);
    }
}
