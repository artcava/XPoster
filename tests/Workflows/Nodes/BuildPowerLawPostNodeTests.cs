using Moq;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Nodes;

namespace XPoster.Tests.Workflows.Nodes;

public class BuildPowerLawPostNodeTests
{
    private readonly Mock<ITimeProvider> _mockTimeProvider;

    public BuildPowerLawPostNodeTests()
    {
        _mockTimeProvider = new Mock<ITimeProvider>();
    }

    private static WorkflowNodeInput Input(
        DateTime date,
        decimal? actualValue = null,
        string actualValueKey = "actual",
        string? symbol = null)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        if (actualValue.HasValue)
        {
            ctx.SetData(actualValueKey, actualValue.Value);
        }

        var parameters = new Dictionary<string, object> { ["ActualValueKey"] = actualValueKey };
        if (symbol != null) parameters["Symbol"] = symbol;

        return new WorkflowNodeInput(ctx, parameters, Array.Empty<ISender>());
    }

    private BuildPowerLawPostNode CreateNode() =>
        new(_mockTimeProvider.Object);

    [Fact]
    public async Task Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var result = await CreateNode().ExecuteAsync(Input(fixedDate, actualValue: 65000m), CancellationToken.None);

        Assert.True(result.Success);
        var content = Assert.IsType<string>(result.Output);
        Assert.Contains("Value of #BTC for the #powerlaw today would be:", content);
        Assert.Contains("%", content);
    }

    [Fact]
    public async Task Execute_CalculatesCorrectPowerLawValue_ForFixedDate()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var expectedDays = (fixedDate.Date - BuildPowerLawPostNode.Genesis).Days;
        var expectedValue = Math.Pow(10, -17) * Math.Pow(expectedDays, 5.83d);

        var result = await CreateNode().ExecuteAsync(Input(fixedDate, actualValue: 65000m), CancellationToken.None);

        Assert.True(result.Success);
        var content = Assert.IsType<string>(result.Output);
        Assert.Contains($"would be: {expectedValue:F2} #USD", content);
    }

    [Fact]
    public async Task Execute_DateBeforeGenesis_ReturnsFailure()
    {
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(new DateTime(2008, 12, 31));

        var result = await CreateNode().ExecuteAsync(Input(new DateTime(2008, 12, 31)), CancellationToken.None);

        Assert.False(result.Success);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_OmitsDelta_WhenActualValueZeroOrMissing()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var result = await CreateNode().ExecuteAsync(Input(fixedDate, actualValue: 0m), CancellationToken.None);

        Assert.True(result.Success);
        var content = Assert.IsType<string>(result.Output);
        Assert.DoesNotContain("%", content);
    }

    [Fact]
    public async Task Execute_UsesSymbol_ForPostTag()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var result = await CreateNode().ExecuteAsync(
            Input(fixedDate, actualValue: 3000m, symbol: "eth"),
            CancellationToken.None);

        Assert.True(result.Success);
        var content = Assert.IsType<string>(result.Output);
        Assert.Contains("Value of #ETH for the #powerlaw today would be:", content);
    }
}
