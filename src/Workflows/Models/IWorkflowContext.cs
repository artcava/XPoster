namespace XPoster.Workflows.Models;

/// <summary>
/// Provides a thread-safe key-value store for workflow execution state.
/// Nodes read inputs from and write outputs to this context during DAG execution.
/// </summary>
public interface IWorkflowContext
{
    /// <summary>Gets the slot identifier this workflow instance is executing for.</summary>
    string SlotKey { get; }

    /// <summary>Retrieves a value by key, throwing if not found or type mismatch.</summary>
    T GetData<T>(string key);

    /// <summary>Tries to retrieve a value by key without throwing.</summary>
    bool TryGetData<T>(string key, out T? value);

    /// <summary>Stores a value by key, overwriting any existing value.</summary>
    void SetData(string key, object value);

    /// <summary>Returns <c>true</c> if the context contains a value for the given key.</summary>
    bool HasData(string key);
}
