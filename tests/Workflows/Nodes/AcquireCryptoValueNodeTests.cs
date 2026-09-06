using Moq;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Nodes;

namespace XPoster.Tests.Workflows.Nodes;

public class AcquireCryptoValueNodeTests
{
    private readonly Mock<ICryptoService> _mockCryptoService;

    public AcquireCryptoValueNodeTests()
    {
        _mockCryptoService = new Mock<ICryptoService>();
    }

    private static WorkflowNodeInput Input(Dictionary<string, object>? parameters = null)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        return new WorkflowNodeInput(ctx, parameters ?? new Dictionary<string, object>(), Array.Empty<ISender>());
    }

    [Fact]
    public async Task Execute_ReturnsCryptoValue_WhenSymbolParameterProvided()
    {
        _mockCryptoService.Setup(s => s.GetCryptoValue("ETH")).ReturnsAsync(3000m);
        var node = new AcquireCryptoValueNode(_mockCryptoService.Object);

        var parameters = new Dictionary<string, object> { ["Symbol"] = "ETH" };
        var result = await node.ExecuteAsync(Input(parameters), CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal(3000m, result.Output);
        _mockCryptoService.Verify(s => s.GetCryptoValue("ETH"), Times.Once);
    }

    [Fact]
    public async Task Execute_UsesDefaultSymbol_WhenNotProvided()
    {
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(65000m);
        var node = new AcquireCryptoValueNode(_mockCryptoService.Object);

        var result = await node.ExecuteAsync(Input(), CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal(65000m, result.Output);
        _mockCryptoService.Verify(s => s.GetCryptoValue("BTC"), Times.Once);
    }

    [Fact]
    public async Task Execute_ReturnsZero_WhenCryptoServiceReturnsZero()
    {
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(0m);
        var node = new AcquireCryptoValueNode(_mockCryptoService.Object);

        var result = await node.ExecuteAsync(Input(), CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal(0m, result.Output);
        _mockCryptoService.Verify(s => s.GetCryptoValue("BTC"), Times.Once);
    }
}
