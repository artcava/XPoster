using System.Collections.Concurrent;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// In-memory implementation of <see cref="IContainerStateStore"/>.
/// Suitable for staging and single-instance production (one post/day).
/// Replace with a Table Storage or Cosmos DB backed implementation
/// when multi-instance scale is required — no contract changes are needed.
/// </summary>
public class InMemoryContainerStateStore : IContainerStateStore
{
    private readonly ConcurrentDictionary<string, (string BlobName, ContainerStatus Status)> _store = new();

    /// <inheritdoc />
    public Task SaveAsync(string creationId, string blobName, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(creationId);
        ArgumentException.ThrowIfNullOrWhiteSpace(blobName);

        _store[creationId] = (blobName, ContainerStatus.Pending);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task<IReadOnlyList<PendingContainer>> GetPendingAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<PendingContainer> result = _store
            .Where(kv => kv.Value.Status == ContainerStatus.Pending)
            .Select(kv => new PendingContainer(kv.Key, kv.Value.BlobName))
            .ToList();

        return Task.FromResult(result);
    }

    /// <inheritdoc />
    public Task UpdateStatusAsync(string creationId, ContainerStatus status, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(creationId);

        _store.AddOrUpdate(
            creationId,
            key => (string.Empty, status),
            (key, existing) => (existing.BlobName, status));

        return Task.CompletedTask;
    }
}
