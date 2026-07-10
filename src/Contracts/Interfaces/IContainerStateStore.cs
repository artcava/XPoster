using XPoster.Models;

namespace XPoster.Contracts;
/// <summary>
/// Defines a contract for a container state store that can save, retrieve, and update the status of containers.
/// </summary>
public interface IContainerStateStore
{
    /// <summary>
    /// Saves a new container state.
    /// </summary>
    /// <param name="creationId">The unique identifier for the container creation.</param>
    /// <param name="blobName">The name of the associated blob.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SaveAsync(string creationId, string blobName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all pending containers.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of pending containers.</returns>
    Task<IReadOnlyList<PendingContainer>> GetPendingAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the status of a container.
    /// </summary>
    /// <param name="creationId">The unique identifier for the container creation.</param>
    /// <param name="status">The new status of the container.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateStatusAsync(string creationId, ContainerStatus status, CancellationToken cancellationToken = default);
}


