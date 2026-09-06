using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Builds the deterministic Power Law fair-value post text for a cryptocurrency.
/// Reads the acquired market price from the context (produced by
/// <see cref="AcquireCryptoValueNode"/>) and appends the signed percentage delta
/// between the live price and the model fair value when a positive value is present.
/// </summary>
public sealed class BuildPowerLawPostNode : IWorkflowNode
{
    /// <summary>The Bitcoin genesis block date, used as the Power Law model anchor.</summary>
    public static readonly DateTime Genesis = new(2009, 1, 3);

    /// <inheritdoc />
    public string NodeType => "BuildPowerLawPost";

    private readonly ITimeProvider _timeProvider;

    /// <summary>Initializes a new instance of the <see cref="BuildPowerLawPostNode"/> class.</summary>
    public BuildPowerLawPostNode(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    /// <inheritdoc />
    public Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var symbol = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Symbol", "BTC");
        var actualValueKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "ActualValueKey");
        var tag = "#" + symbol.ToUpperInvariant();

        var date = _timeProvider.GetCurrentTime().Date;
        if (date <= Genesis)
        {
            return Task.FromResult(new WorkflowNodeResult(false, null, $"Invalid date: {date:d} is on or before the Power Law genesis block."));
        }

        var days = (date - Genesis).Days;
        var fairValue = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

        var content = $"Value of {tag} for the #powerlaw today would be: {fairValue:F2} #USD";

        if (input.Context.TryGetData<decimal>(actualValueKey, out var actualValue) && actualValue > 0)
        {
            content += $"\n{100.00m - (actualValue / (decimal)fairValue * 100):+0.00;-0.00}%";
        }

        return Task.FromResult(new WorkflowNodeResult(true, content, null));
    }
}
