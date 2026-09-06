using Microsoft.Extensions.DependencyInjection;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Nodes;
using XPoster.Workflows.Services;
using PromptStepOptions = XPoster.Workflows.Models.PromptStepOptions;

namespace XPoster.Tests.Workflows.Nodes;

public class AiImageNodeTests
{
    private static (AiImageNode node, Mock<ITextToImageProvider> providerMock) CreateNode(
        string providerName = "FalAi",
        string? registeredProvider = null,
        byte[]? imageBytes = null)
    {
        var providerMock = new Mock<ITextToImageProvider>();
        providerMock
            .Setup(p => p.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(imageBytes!);

        var stepOptions = new PromptStepOptions
        {
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user {Text}",
            Temperature = 0.7,
            ImageQuantity = 1,
            ImageSize = "1024x1024",
            InputTextLabel = "{Text}"
        };

        var stepResolverMock = new Mock<IStepOptionsResolver>();
        stepResolverMock.Setup(s => s.Resolve(It.IsAny<string>())).Returns(stepOptions);

        var services = new ServiceCollection();
        services.AddKeyedTransient<ITextToImageProvider>(
            Enum.Parse<AiProvider>(registeredProvider ?? providerName, ignoreCase: true),
            (_, _) => providerMock.Object);
        var provider = services.BuildServiceProvider();

        return (new AiImageNode(provider, stepResolverMock.Object), providerMock);
    }

    private static WorkflowNodeInput Input(string provider, string stepId, string inputKey, string prompt, bool? required = null)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        ctx.SetData(inputKey, prompt);
        var parameters = new Dictionary<string, object>
        {
            ["Provider"] = provider,
            ["StepId"] = stepId,
            ["InputKey"] = inputKey,
        };
        if (required.HasValue) parameters["Required"] = required.Value;
        return new WorkflowNodeInput(ctx, parameters, Array.Empty<ISender>());
    }

    [Fact]
    public async Task Execute_ReturnsMediaAttachment_OnSuccess()
    {
        var (node, _) = CreateNode(imageBytes: new byte[] { 0x89, 0x50, 0x4E, 0x47 });
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "a cat on mars");
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var media = Assert.IsType<MediaAttachment>(result.Output);
        Assert.Equal(MediaType.Image, media.Type);
        Assert.Equal("image/png", media.MimeType);
        Assert.Equal(4, media.Data.Length);
    }

    [Fact]
    public async Task Execute_ReturnsNullOutput_OnSoftFailure()
    {
        var (node, _) = CreateNode(imageBytes: null);
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt");
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        Assert.Null(result.Output);
    }

    [Fact]
    public async Task Execute_ReturnsNullOutput_OnEmptyArray()
    {
        var (node, _) = CreateNode(imageBytes: Array.Empty<byte>());
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt");
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        Assert.Null(result.Output);
    }

    [Fact]
    public async Task Execute_ReturnsFailure_WhenRequired_AndImageMissing()
    {
        var (node, _) = CreateNode(imageBytes: null);
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt", required: true);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Null(result.Output);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_ReturnsSuccess_WhenRequired_AndImageProduced()
    {
        var (node, _) = CreateNode(imageBytes: new byte[] { 0x89, 0x50, 0x4E, 0x47 });
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt", required: true);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        Assert.IsType<MediaAttachment>(result.Output);
    }

    [Fact]
    public async Task Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing()
    {
        var (node, _) = CreateNode(imageBytes: null);
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt", required: false);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        Assert.Null(result.Output);
    }

    [Fact]
    public async Task Execute_Throws_WhenProviderNameIsUnknown()
    {
        var (node, _) = CreateNode(registeredProvider: "FalAi");
        var input = Input("NonExistent", "Feed.ImageGeneration", "imagePrompt", "p");
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => node.ExecuteAsync(input, CancellationToken.None));
        Assert.Contains("NonExistent", ex.Message);
    }

    [Fact]
    public async Task Execute_Throws_WhenValidProviderNotRegistered()
    {
        var (node, _) = CreateNode(registeredProvider: "FalAi");
        var input = Input("DeepSeek", "Feed.ImageGeneration", "imagePrompt", "p");
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => node.ExecuteAsync(input, CancellationToken.None));
        Assert.Contains("not registered", ex.Message);
    }

    [Fact]
    public async Task Execute_PassesStepOptionsToImagePromptRequest()
    {
        var (node, providerMock) = CreateNode(imageBytes: new byte[] { 1 });
        var input = Input("FalAi", "Feed.ImageGeneration", "imagePrompt", "prompt text");
        await node.ExecuteAsync(input, CancellationToken.None);

        providerMock.Verify(p => p.GenerateImageAsync(
            It.Is<ImagePromptRequest>(r =>
                r.InputText == "prompt text" &&
                r.SystemPromptTemplate == "sys" &&
                r.Temperature == 0.7 &&
                r.ImageQuantity == 1 &&
                r.ImageSize == "1024x1024"),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}