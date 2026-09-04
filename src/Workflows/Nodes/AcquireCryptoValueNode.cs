using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Fetches the current market price of a cryptocurrency and stores it into the context.
/// Adapter for <see cref="ICryptoService"/>. The symbol is a node parameter (default "BTC"),
/// so any crypto can be acquired by any workflow.
/// </summary>
public sealed class AcquireCryptoValueNode : IWorkflowNode
{
    /// <inheritdoc />
    public string NodeType => "AcquireCryptoValue";

    private readonly ICryptoService _cryptoService;

    /// <summary>Initializes a new instance of the <see cref="AcquireCryptoValueNode"/> class.</summary>
    public AcquireCryptoValueNode(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    /// <inheritdoc />
    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var symbol = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Symbol", "BTC");
        var actualValue = await _cryptoService.GetCryptoValue(symbol);

        return new WorkflowNodeResult(true, actualValue, null);
    }
}
