using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using XPoster.Contracts;

namespace XPoster;

/// <summary>
/// Azure Function that polls pending Instagram media containers and publishes them once
/// Meta's processing pipeline reports <c>FINISHED</c>. Runs on a timer every 2 minutes
/// (configurable via <c>ContainerPollingSchedule</c> app setting).
/// </summary>
/// <remarks>
/// This function is sender-agnostic: it operates exclusively on
/// <see cref="IContainerStateStore"/> and <see cref="IMetaPublishingService"/>,
/// with no direct dependency on <c>IgSender</c> or any platform-specific sender.
/// Blob cleanup is delegated to <see cref="IBlobStorageService"/> after a confirmed
/// publish or terminal failure.
/// </remarks>
public class XPosterContainerPollingFunction
{
    private readonly IContainerStateStore _stateStore;
    private readonly IMetaPublishingService _metaPublishing;
    private readonly IBlobStorageService _blobStorage;
    private readonly ILogger<XPosterContainerPollingFunction> _log;

    /// <summary>
    /// Initialises a new instance of <see cref="XPosterContainerPollingFunction"/>.
    /// </summary>
    /// <param name="stateStore">Store that tracks pending Instagram media containers.</param>
    /// <param name="metaPublishing">Service that wraps Meta Graph API HTTP calls.</param>
    /// <param name="blobStorage">Service for deleting temporary image blobs after publish/failure.</param>
    /// <param name="log">Logger for structured diagnostic output.</param>
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
    /// Timer-triggered entry point. Polls all pending containers and drives each one
    /// through the Meta publishing pipeline.
    /// </summary>
    /// <param name="timer">Timer metadata injected by the Azure Functions runtime.</param>
    /// <param name="cancellationToken">
    /// Cancellation token injected by the Azure Functions runtime.
    /// Signalled on graceful shutdown or function timeout.
    /// </param>
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
            // Graceful shutdown or timeout — not an application error.
            _log.LogWarning(
                "XPosterContainerPollingFunction was cancelled gracefully at: {Time}",
                DateTimeOffset.UtcNow);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "XPosterContainerPollingFunction encountered an unexpected error: {Message}", ex.Message);
            throw;
        }

        _log.LogInformation("XPosterContainerPollingFunction ended at: {Time}", DateTimeOffset.UtcNow);
    }

    /// <summary>
    /// Optional HTTP trigger for manual invocation during staging and debugging.
    /// Disabled in production via <c>ContainerPollingHttpEnabled = false</c> app setting.
    /// </summary>
    /// <param name="req">The incoming HTTP request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An HTTP response indicating the outcome of the manual poll.</returns>
    [Function("XPosterContainerPollingHttpFunction")]
    public async Task<HttpResponseData> RunHttp(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "container-polling")] HttpRequestData req,
        CancellationToken cancellationToken)
    {
        _log.LogInformation("XPosterContainerPollingFunction HTTP trigger invoked at: {Time}", DateTimeOffset.UtcNow);

        try
        {
            await PollPendingContainersAsync(cancellationToken);
            var ok = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await ok.WriteStringAsync("Container polling completed.", cancellationToken);
            return ok;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            _log.LogWarning("XPosterContainerPollingFunction HTTP trigger was cancelled at: {Time}", DateTimeOffset.UtcNow);
            var cancelled = req.CreateResponse(System.Net.HttpStatusCode.ServiceUnavailable);
            await cancelled.WriteStringAsync("Request cancelled.", cancellationToken);
            return cancelled;
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "XPosterContainerPollingFunction HTTP trigger encountered an error: {Message}", ex.Message);
            var error = req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            await error.WriteStringAsync($"Error: {ex.Message}", cancellationToken);
            return error;
        }
    }

    // ── Core logic ───────────────────────────────────────────────────────────

    private async Task PollPendingContainersAsync(CancellationToken cancellationToken)
    {
        var pending = await _stateStore.GetPendingAsync(cancellationToken);

        if (pending.Count == 0)
        {
            _log.LogDebug("XPosterContainerPollingFunction: no pending containers found.");
            return;
        }

        _log.LogInformation(
            "XPosterContainerPollingFunction: processing {Count} pending container(s).",
            pending.Count);

        foreach (var container in pending)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await ProcessContainerAsync(container, cancellationToken);
        }
    }

    private async Task ProcessContainerAsync(PendingContainer container, CancellationToken cancellationToken)
    {
        var status = await _metaPublishing.GetContainerStatusAsync(container.CreationId, cancellationToken);

        switch (status)
        {
            case ContainerStatus.Finished:
                await HandleFinishedAsync(container, cancellationToken);
                break;

            case ContainerStatus.InProgress:
                _log.LogDebug(
                    "Container {CreationId} is still IN_PROGRESS — skipping this round.",
                    container.CreationId);
                break;

            case ContainerStatus.Error:
            case ContainerStatus.Expired:
                await HandleTerminalFailureAsync(container, status, cancellationToken);
                break;

            default:
                _log.LogWarning(
                    "Container {CreationId} returned unrecognised status {Status} — skipping.",
                    container.CreationId,
                    status);
                break;
        }
    }

    private async Task HandleFinishedAsync(PendingContainer container, CancellationToken cancellationToken)
    {
        await _metaPublishing.PublishContainerAsync(container.CreationId, cancellationToken);
        _log.LogInformation(
            "Container {CreationId} published successfully.",
            container.CreationId);

        await TryDeleteBlobAsync(container.BlobName, container.CreationId, cancellationToken);
        await _stateStore.UpdateStatusAsync(container.CreationId, ContainerStatus.Published, cancellationToken);
    }

    private async Task HandleTerminalFailureAsync(
        PendingContainer container,
        ContainerStatus status,
        CancellationToken cancellationToken)
    {
        _log.LogWarning(
            "Container {CreationId} reached terminal status {Status} — marking as Failed.",
            container.CreationId,
            status);

        await TryDeleteBlobAsync(container.BlobName, container.CreationId, cancellationToken);
        await _stateStore.UpdateStatusAsync(container.CreationId, ContainerStatus.Failed, cancellationToken);
    }

    /// <summary>
    /// Attempts to delete the staging blob. If deletion fails, the exception is logged
    /// and swallowed so that state is still updated to avoid the container being retried
    /// indefinitely.
    /// </summary>
    private async Task TryDeleteBlobAsync(string blobName, string creationId, CancellationToken cancellationToken)
    {
        try
        {
            await _blobStorage.DeleteAsync(blobName, cancellationToken);
        }
        catch (Exception ex)
        {
            _log.LogError(
                ex,
                "Failed to delete blob {BlobName} for container {CreationId}: {Message}",
                blobName,
                creationId,
                ex.Message);
            // Swallow: state must be updated regardless of blob cleanup outcome.
        }
    }
}
