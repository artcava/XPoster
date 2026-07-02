namespace XPoster.Contracts;

/// <summary>
/// Defines a contract for a meta publishing service that can retrieve the status of a container and publish it.
/// </summary>
public interface IMetaPublishingService
{
    /// <summary>
    /// Retrieves the status of a container.
    /// </summary>
    /// <param name="creationId">The unique identifier for the container creation.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the status of the container.</returns>
    Task<string> GetContainerStatusAsync(string creationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Publishes a container.
    /// </summary>
    /// <param name="creationId">The unique identifier for the container creation.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishContainerAsync(string creationId, CancellationToken cancellationToken = default);
}