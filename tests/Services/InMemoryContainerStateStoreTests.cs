using XPoster.Contracts;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class InMemoryContainerStateStoreTests
{
    [Fact]
    public async Task SaveAsync_WithValidInputs_StoresPendingEntry()
    {
        var sut = new InMemoryContainerStateStore();

        await sut.SaveAsync("creation-1", "blob-1.jpg");

        var pending = await sut.GetPendingAsync();

        var container = Assert.Single(pending);
        Assert.Equal("creation-1", container.CreationId);
        Assert.Equal("blob-1.jpg", container.BlobName);
    }

    [Fact]
    public async Task SaveAsync_WithNullCreationId_ThrowsArgumentNullException()
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SaveAsync(null!, "blob-1.jpg"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(string creationId)
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentException>(() => sut.SaveAsync(creationId, "blob-1.jpg"));
    }

    [Fact]
    public async Task SaveAsync_WithNullBlobName_ThrowsArgumentNullException()
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SaveAsync("creation-1", null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(string blobName)
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentException>(() => sut.SaveAsync("creation-1", blobName));
    }

    [Fact]
    public async Task GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList()
    {
        var sut = new InMemoryContainerStateStore();

        var pending = await sut.GetPendingAsync();

        Assert.Empty(pending);
    }

    [Fact]
    public async Task GetPendingAsync_ReturnsOnlyPendingEntries()
    {
        var sut = new InMemoryContainerStateStore();

        await sut.SaveAsync("creation-1", "blob-1.jpg");
        await sut.SaveAsync("creation-2", "blob-2.jpg");
        await sut.SaveAsync("creation-3", "blob-3.jpg");
        await sut.UpdateStatusAsync("creation-2", ContainerStatus.Published);
        await sut.UpdateStatusAsync("creation-3", ContainerStatus.Failed);

        var pending = await sut.GetPendingAsync();

        var container = Assert.Single(pending);
        Assert.Equal("creation-1", container.CreationId);
        Assert.Equal("blob-1.jpg", container.BlobName);
    }

    [Fact]
    public async Task UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending()
    {
        var sut = new InMemoryContainerStateStore();

        await sut.SaveAsync("creation-1", "blob-1.jpg");
        await sut.UpdateStatusAsync("creation-1", ContainerStatus.Published);

        var pending = await sut.GetPendingAsync();

        Assert.Empty(pending);
    }

    [Fact]
    public async Task UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException()
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatusAsync(null!, ContainerStatus.Failed));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(string creationId)
    {
        var sut = new InMemoryContainerStateStore();

        await Assert.ThrowsAsync<ArgumentException>(() => sut.UpdateStatusAsync(creationId, ContainerStatus.Failed));
    }

    [Fact]
    public async Task UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName()
    {
        var sut = new InMemoryContainerStateStore();

        await sut.UpdateStatusAsync("creation-1", ContainerStatus.Failed);

        var pending = await sut.GetPendingAsync();

        Assert.Empty(pending);
    }

    [Fact]
    public async Task UpdateStatusAsync_CanMoveEntryBackToPending()
    {
        var sut = new InMemoryContainerStateStore();

        await sut.SaveAsync("creation-1", "blob-1.jpg");
        await sut.UpdateStatusAsync("creation-1", ContainerStatus.Published);
        await sut.UpdateStatusAsync("creation-1", ContainerStatus.Pending);

        var pending = await sut.GetPendingAsync();

        var container = Assert.Single(pending);
        Assert.Equal("creation-1", container.CreationId);
        Assert.Equal("blob-1.jpg", container.BlobName);
    }
}
