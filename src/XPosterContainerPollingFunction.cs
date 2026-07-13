using Microsoft.Azure.Functions.Worker;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster;

/// <summary>
/// Azure Function that polls pending Instagram media containers and publishes them once
/// Meta's processing pipeline reports the container as ready. Runs on a timer every 2 minutes
/// (configurable via <c>ContainerPollingSchedule</c> app setting).
/// </summary>
public class XPosterContainerPollingFunction
{
    private readonly IContainerStateStore _stateStore;
    private readonly IMetaPublishingService _metaPublishing;
    private readonly IBlobStorageService _blobStorage;
    private readonly ILogger<XPosterContainerPollingFunction> _log;

    /// <summary>
    /// Initializes a new instance of the <see cref="XPosterContainerPollingFunction"/> class.
    /// </summary>
    /// <param name="stateStore"></param>
    /// <param name="metaPublishing"></param>
    /// <param name="blobStorage"></param>
    /// <param name="log"></param>
    public XPosterContainerPollingFunction(
        IContainerStateStore stateStore,
        IMetaPublishingService metaPublishing,
        IBlobStorageService blobStorage,
        ILogger<XPosterContainerPollingFunction> log)
    {
        _stateStore = stateStore;
        _metaPublishing = metaPublishing;
        _blobStorage = blobStorage;
        _log = log;
    }

    /// <summary>
    /// Timer-triggered function body. Polls the state store for pending containers, checks their status with Meta,
    /// and publishes them if they are ready. Cleans up blobs and updates the state store accordingly. Handles graceful cancellation and logs unexpected errors.
    /// </summary>
    /// <param name="timer"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Function("XPosterContainerPollingFunction")]
    public async Task Run(
        [TimerTrigger("%ContainerPollingSchedule%")] TimerInfo timer,
        CancellationToken cancellationToken)
    {
        _log.LogInformation("XPosterContainerPollingFunction started at: {Time}", DateTimeOffset.UtcNow);

        try
        {
            await PollPendingContainersAsync(cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            _log.LogWarning("XPosterContainerPollingFunction was cancelled gracefully at: {Time}", DateTimeOffset.UtcNow);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "XPosterContainerPollingFunction encountered an unexpected error: {Message}", ex.Message);
            throw;
        }

        _log.LogInformation("XPosterContainerPollingFunction ended at: {Time}", DateTimeOffset.UtcNow);
    }

    private async Task PollPendingContainersAsync(CancellationToken cancellationToken)
    {
        var pending = await _stateStore.GetPendingAsync(cancellationToken);

        if (pending.Count == 0)
        {
            _log.LogDebug("XPosterContainerPollingFunction: no pending containers found.");
            return;
        }

        _log.LogInformation("XPosterContainerPollingFunction: processing {Count} pending container(s).", pending.Count);

        foreach (var container in pending)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await ProcessContainerAsync(container, cancellationToken);
        }
    }

    private async Task ProcessContainerAsync(PendingContainer container, CancellationToken cancellationToken)
    {
        var remoteStatus = await _metaPublishing.GetContainerStatusAsync(container.CreationId, cancellationToken);

        switch (remoteStatus.ToUpperInvariant())
        {
            case "FINISHED":
                await HandleFinishedAsync(container, cancellationToken);
                break;

            case "IN_PROGRESS":
                _log.LogDebug("Container {CreationId} is still IN_PROGRESS — skipping this round.", container.CreationId);
                break;

            case "ERROR":
            case "EXPIRED":
                await HandleTerminalFailureAsync(container, remoteStatus, cancellationToken);
                break;

            default:
                _log.LogWarning(
                    "Container {CreationId} returned unknown remote status {RemoteStatus}.",
                    container.CreationId,
                    remoteStatus);
                break;
        }
    }

    private async Task HandleFinishedAsync(PendingContainer container, CancellationToken cancellationToken)
    {
        await _metaPublishing.PublishContainerAsync(container.CreationId, cancellationToken);
        _log.LogInformation("Container {CreationId} published successfully.", container.CreationId);

        await TryDeleteBlobAsync(container.BlobName, container.CreationId, cancellationToken);
        await _stateStore.UpdateStatusAsync(container.CreationId, ContainerStatus.Published, cancellationToken);
    }

    private async Task HandleTerminalFailureAsync(PendingContainer container, string remoteStatus, CancellationToken cancellationToken)
    {
        _log.LogWarning("Container {CreationId} reached terminal status {RemoteStatus} — marking as Failed.", container.CreationId, remoteStatus);
        await TryDeleteBlobAsync(container.BlobName, container.CreationId, cancellationToken);
        await _stateStore.UpdateStatusAsync(container.CreationId, ContainerStatus.Failed, cancellationToken);
    }

    private async Task TryDeleteBlobAsync(string blobName, string creationId, CancellationToken cancellationToken)
    {
        try
        {
            await _blobStorage.DeleteAsync(blobName, cancellationToken);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Failed to delete blob {BlobName} for container {CreationId}: {Message}", blobName, creationId, ex.Message);
        }
    }
}