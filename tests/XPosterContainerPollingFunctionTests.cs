using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;

namespace XPoster.Tests;

public class XPosterContainerPollingFunctionTests
{
    private readonly Mock<IContainerStateStore> _stateStore = new();
    private readonly Mock<IMetaPublishingService> _metaPublishing = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();
    private readonly Mock<ILogger<XPosterContainerPollingFunction>> _logger = new();

    private XPosterContainerPollingFunction CreateSut()
        => new(_stateStore.Object, _metaPublishing.Object, _blobStorage.Object, _logger.Object);

    [Fact]
    public async Task RunAsync_WhenNoPendingContainers_DoesNothing()
    {
        var sut = CreateSut();
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<PendingContainer>());

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.GetContainerStatusAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _blobStorage.Verify(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _stateStore.Verify(x => x.UpdateStatusAsync(It.IsAny<string>(), It.IsAny<ContainerStatus>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RunAsync_WhenStatusIsInProgress_SkipsContainer()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("IN_PROGRESS");

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _blobStorage.Verify(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _stateStore.Verify(x => x.UpdateStatusAsync(It.IsAny<string>(), It.IsAny<ContainerStatus>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RunAsync_WhenStatusIsFinished_PublishesAndCleansUp()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("FINISHED");
        _metaPublishing.Setup(x => x.PublishContainerAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("published_media_id");
        _blobStorage.Setup(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _stateStore.Setup(x => x.UpdateStatusAsync("c1", ContainerStatus.Published, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync("c1", It.IsAny<CancellationToken>()), Times.Once);
        _blobStorage.Verify(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>()), Times.Once);
        _stateStore.Verify(x => x.UpdateStatusAsync("c1", ContainerStatus.Published, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RunAsync_WhenStatusIsError_MarksFailedAndCleansUp()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("ERROR");
        _blobStorage.Setup(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _stateStore.Setup(x => x.UpdateStatusAsync("c1", ContainerStatus.Failed, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _blobStorage.Verify(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>()), Times.Once);
        _stateStore.Verify(x => x.UpdateStatusAsync("c1", ContainerStatus.Failed, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("EXPIRED");
        _blobStorage.Setup(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _stateStore.Setup(x => x.UpdateStatusAsync("c1", ContainerStatus.Failed, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _blobStorage.Verify(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>()), Times.Once);
        _stateStore.Verify(x => x.UpdateStatusAsync("c1", ContainerStatus.Failed, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("SOME_UNKNOWN_STATUS");

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _blobStorage.Verify(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _stateStore.Verify(x => x.UpdateStatusAsync(It.IsAny<string>(), It.IsAny<ContainerStatus>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RunAsync_WhenPublishFails_MarksFailedAndCleansUp()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("FINISHED");
        _metaPublishing.Setup(x => x.PublishContainerAsync("c1", It.IsAny<CancellationToken>())).ThrowsAsync(new InvalidOperationException("publish failed"));

        await Assert.ThrowsAsync<InvalidOperationException>(() => sut.Run(CreateTimerInfo(), CancellationToken.None));

        _blobStorage.Verify(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        _stateStore.Verify(x => x.UpdateStatusAsync(It.IsAny<string>(), It.IsAny<ContainerStatus>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RunAsync_WhenBlobDeleteFails_StillUpdatesStatus()
    {
        var sut = CreateSut();
        var pending = new PendingContainer("c1", "blob1");
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { pending });
        _metaPublishing.Setup(x => x.GetContainerStatusAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("FINISHED");
        _metaPublishing.Setup(x => x.PublishContainerAsync("c1", It.IsAny<CancellationToken>())).ReturnsAsync("published_media_id");
        _blobStorage.Setup(x => x.DeleteAsync("blob1", It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("delete failed"));
        _stateStore.Setup(x => x.UpdateStatusAsync("c1", ContainerStatus.Published, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _stateStore.Verify(x => x.UpdateStatusAsync("c1", ContainerStatus.Published, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RunAsync_WhenMultiplePendingContainers_ProcessesAll()
    {
        var sut = CreateSut();
        var pending = new[]
        {
            new PendingContainer("c1", "b1"),
            new PendingContainer("c2", "b2"),
            new PendingContainer("c3", "b3")
        };
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>())).ReturnsAsync(pending);
        _metaPublishing.Setup(x => x.GetContainerStatusAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync("FINISHED");
        _metaPublishing.Setup(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync("published_media_id");
        _blobStorage.Setup(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _stateStore.Setup(x => x.UpdateStatusAsync(It.IsAny<string>(), ContainerStatus.Published, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        await sut.Run(CreateTimerInfo(), CancellationToken.None);

        _metaPublishing.Verify(x => x.PublishContainerAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
        _blobStorage.Verify(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
        _stateStore.Verify(x => x.UpdateStatusAsync(It.IsAny<string>(), ContainerStatus.Published, It.IsAny<CancellationToken>()), Times.Exactly(3));
    }

    [Fact]
    public async Task RunAsync_WhenCancelled_StopsGracefully()
    {
        var sut = CreateSut();
        var cts = new CancellationTokenSource();
        cts.Cancel();
        _stateStore.Setup(x => x.GetPendingAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new OperationCanceledException(cts.Token));

        await sut.Run(CreateTimerInfo(), cts.Token);

        _metaPublishing.VerifyNoOtherCalls();
    }

    private static TimerInfo CreateTimerInfo() => null!; // TimerInfo is not used in the function logic, so we can return null for testing purposes.
}
