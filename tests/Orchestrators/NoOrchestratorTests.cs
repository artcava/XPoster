using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

/// <summary>
/// Tests for NoOrchestrator — the no-op orchestrator used in non-posting time slots.
/// </summary>
public class NoOrchestratorTests
{
    private readonly Mock<ILogger<NoOrchestrator>> _mockLogger;

    public NoOrchestratorTests()
    {
        _mockLogger = new Mock<ILogger<NoOrchestrator>>();
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsNull()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Null(result);
    }

    [Fact]
    public void SendIt_IsAlwaysFalse()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        Assert.False(orchestrator.SendIt);
    }

    [Fact]
    public void ProduceImage_IsAlwaysFalse()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        Assert.False(orchestrator.ProduceImage);
    }

    [Fact]
    public void Name_IsNoOrchestrator()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        Assert.Equal("NoOrchestrator", orchestrator.Name);
    }

    [Fact]
    public void SendIt_Set_ThrowsNotImplementedException()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        Assert.Throws<System.NotImplementedException>(() => orchestrator.SendIt = true);
    }

    [Fact]
    public void ProduceImage_Set_ThrowsNotImplementedException()
    {
        var orchestrator = new NoOrchestrator(_mockLogger.Object);

        Assert.Throws<System.NotImplementedException>(() => orchestrator.ProduceImage = true);
    }
}
