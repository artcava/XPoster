using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class BlobStorageServiceTests
{
    private static BlobStorageService CreateSut(
        Mock<BlobServiceClient> blobServiceClientMock,
        Mock<ILogger<BlobStorageService>> loggerMock,
        string containerName = "xposter-images")
    {
        var options = Options.Create(new BlobStorageOptions
        {
            AzureStorageConnectionString = "UseDevelopmentStorage=true",
            AzureStorageContainerName = containerName
        });

        return new BlobStorageService(blobServiceClientMock.Object, options, loggerMock.Object);
    }

    [Fact]
    public async Task UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri()
    {
        var blobServiceClient = new Mock<BlobServiceClient>();
        var containerClient = new Mock<BlobContainerClient>();
        var blobClient = new Mock<BlobClient>();
        var logger = new Mock<ILogger<BlobStorageService>>();

        containerClient.Setup(x => x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<Azure.Response<BlobContainerInfo>>());
        containerClient.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
        blobServiceClient.Setup(x => x.GetBlobContainerClient("xposter-images")).Returns(containerClient.Object);
        blobClient.Setup(x => x.UploadAsync(It.IsAny<Stream>(), It.IsAny<BlobUploadOptions>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<Azure.Response<BlobContentInfo>>());
        blobClient.Setup(x => x.GenerateSasUri(It.IsAny<BlobSasBuilder>()))
            .Returns(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var sut = CreateSut(blobServiceClient, logger);
        var result = await sut.UploadAsync(new byte[] { 1, 2, 3 }, "image/jpeg");

        Assert.Equal("https://storage.example.com/xposter-images/blob1.jpg?sig=abc", result.SasUri.ToString());
        Assert.EndsWith(".jpg", result.BlobName);
        Assert.Matches(@"^[0-9a-fA-F-]{36}\.jpg$", result.BlobName);
        blobClient.Verify(x => x.GenerateSasUri(It.Is<BlobSasBuilder>(b =>
            b.BlobContainerName == "xposter-images" &&
            b.Resource == "b" &&
            b.Permissions.ToString() == "r")), Times.Once);
    }

    [Fact]
    public async Task UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads()
    {
        var blobServiceClient = new Mock<BlobServiceClient>();
        var containerClient = new Mock<BlobContainerClient>();
        var blobClient = new Mock<BlobClient>();
        var logger = new Mock<ILogger<BlobStorageService>>();

        containerClient.Setup(x => x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<Azure.Response<BlobContainerInfo>>());
        containerClient.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);
        blobServiceClient.Setup(x => x.GetBlobContainerClient("xposter-images")).Returns(containerClient.Object);
        blobClient.Setup(x => x.UploadAsync(It.IsAny<Stream>(), It.IsAny<BlobUploadOptions>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<Azure.Response<BlobContentInfo>>());
        blobClient.Setup(x => x.GenerateSasUri(It.IsAny<BlobSasBuilder>()))
            .Returns(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var sut = CreateSut(blobServiceClient, logger);
        await sut.UploadAsync(new byte[] { 1, 2, 3 }, "image/jpeg");

        containerClient.Verify(x => x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>()), Times.Once);
        blobClient.Verify(x => x.UploadAsync(
            It.IsAny<Stream>(),
            It.IsAny<BlobHttpHeaders>(),
            null,
            null,
            null,
            null,
            It.IsAny<Azure.Storage.StorageTransferOptions>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UploadAsync_WhenStorageThrows_PropagatesException()
    {
        var blobServiceClient = new Mock<BlobServiceClient>();
        var containerClient = new Mock<BlobContainerClient>();
        var logger = new Mock<ILogger<BlobStorageService>>();

        containerClient.Setup(x => x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("storage failure"));
        blobServiceClient.Setup(x => x.GetBlobContainerClient("xposter-images")).Returns(containerClient.Object);

        var sut = CreateSut(blobServiceClient, logger);

        await Assert.ThrowsAsync<InvalidOperationException>(() => sut.UploadAsync(new byte[] { 1, 2, 3 }, "image/jpeg"));
    }

    [Fact]
    public async Task DeleteAsync_WhenBlobExists_DeletesSuccessfully()
    {
        var blobServiceClient = new Mock<BlobServiceClient>();
        var containerClient = new Mock<BlobContainerClient>();
        var blobClient = new Mock<BlobClient>();
        var logger = new Mock<ILogger<BlobStorageService>>();

        blobServiceClient.Setup(x => x.GetBlobContainerClient("xposter-images")).Returns(containerClient.Object);
        containerClient.Setup(x => x.GetBlobClient("blob1.jpg")).Returns(blobClient.Object);
        blobClient.Setup(x => x.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Mock.Of<Azure.Response<bool>>());

        var sut = CreateSut(blobServiceClient, logger);
        await sut.DeleteAsync("blob1.jpg");

        blobClient.Verify(x => x.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null, It.IsAny<CancellationToken>()), Times.Once);
    }
}
