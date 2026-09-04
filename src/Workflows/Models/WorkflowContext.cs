using System.Collections.Concurrent;

namespace XPoster.Workflows.Models;

/// <summary>
/// Thread-safe implementation of <see cref="IWorkflowContext"/> backed by a <see cref="ConcurrentDictionary{TKey,TValue}"/>.
/// Safe for parallel DAG branch execution.
/// </summary>
public class WorkflowContext : IWorkflowContext
{
    private readonly ConcurrentDictionary<string, object> _data = new();

    /// <inheritdoc />
    public required string SlotKey { get; init; }

    /// <inheritdoc />
    public T GetData<T>(string key)
    {
        if (_data.TryGetValue(key, out var value) && value is T typedValue)
        {
            return typedValue;
        }
        throw new KeyNotFoundException($"Key '{key}' with type '{typeof(T).Name}' was not found in WorkflowContext.");
    }

    /// <inheritdoc />
    public bool TryGetData<T>(string key, out T? value)
    {
        if (_data.TryGetValue(key, out var val) && val is T typedValue)
        {
            value = typedValue;
            return true;
        }
        value = default;
        return false;
    }

    /// <inheritdoc />
    public void SetData(string key, object value) => _data[key] = value;

    /// <inheritdoc />
    public bool HasData(string key) => _data.ContainsKey(key);
}
