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

public class FanOutSendNodeTests
{
    private static (FanOutSendNode node, Mock<ITextToTextProvider> textMock, Mock<ITagReplacementService> tagMock) CreateNode()
    {
        var textMock = new Mock<ITextToTextProvider>();
        textMock
            .Setup(p => p.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("re-summarised");

        var stepResolverMock = new Mock<IStepOptionsResolver>();
        stepResolverMock.Setup(s => s.Resolve(It.IsAny<string>())).Returns(new PromptStepOptions
        {
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u",
            MaxTokenBudget = 500,
            InputTextLabel = "{Text}"
        });

        var tagMock = new Mock<ITagReplacementService>();
        tagMock.Setup(t => t.Apply(It.IsAny<string>())).Returns((string s) => s);

        var services = new ServiceCollection();
        services.AddKeyedTransient<ITextToTextProvider>(AiProvider.OpenAi, (_, _) => textMock.Object);
        var provider = services.BuildServiceProvider();

        return (new FanOutSendNode(provider, stepResolverMock.Object, tagMock.Object), textMock, tagMock);
    }

    private static void SetupSender(Mock<ISender> mock, SenderPlatform platform, int maxLength)
    {
        mock.SetupGet(s => s.Platform).Returns(platform);
        mock.SetupGet(s => s.MessageMaxLength).Returns(maxLength);
    }

    private static WorkflowNodeInput Input(
        string primaryText,
        string? sourceContent = null,
        string? imageKey = null,
        byte[]? imageData = null,
        string? stepId = null,
        params ISender[] senders)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        ctx.SetData("text", primaryText);

        if (sourceContent != null) ctx.SetData("src", sourceContent);
        if (imageKey != null && imageData != null)
        {
            ctx.SetData(imageKey, new MediaAttachment(imageData, MediaType.Image, "image/png", "img.png"));
        }

        var parameters = new Dictionary<string, object>
        {
            ["TextKey"] = "text",
            ["FallbackSourceKey"] = "src",
            ["MediaKey"] = imageKey ?? "",
            ["Provider"] = "OpenAi",
        };
        if (stepId != null) parameters["StepId"] = stepId;

        return new WorkflowNodeInput(ctx, parameters, senders);
    }

    [Fact]
    public async Task Execute_ShortText_NoResummary()
    {
        var (node, textMock, tagMock) = CreateNode();
        var senderMock = new Mock<ISender>();
        SetupSender(senderMock, SenderPlatform.X, 280);

        var input = Input("short", senders: senderMock.Object);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        textMock.Verify(p => p.GenerateTextAsync(
            It.IsAny<PromptRequest>(),
            It.IsAny<CancellationToken>()), Times.Never);
        tagMock.Verify(t => t.Apply("short"), Times.Once);
    }

    [Fact]
    public async Task Execute_LongText_WithFallback_Resummarises()
    {
        var (node, textMock, _) = CreateNode();
        var senderMock = new Mock<ISender>();
        SetupSender(senderMock, SenderPlatform.X, 10);

        var input = Input("this is a very long text that exceeds the limit", sourceContent: "original source", stepId: "Feed.Summary", senders: senderMock.Object);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        textMock.Verify(p => p.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.InputText == "original source" && r.MaxOutputLength == 10),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender()
    {
        var (node, textMock, tagMock) = CreateNode();
        var wideMock = new Mock<ISender>();
        SetupSender(wideMock, SenderPlatform.DryRunMaxLength, int.MaxValue);
        var smallMock = new Mock<ISender>();
        SetupSender(smallMock, SenderPlatform.DryRunShortLength, 50);

        var longText = new string('A', 400);
        var input = Input(longText, sourceContent: "this is the fallback source", stepId: "Feed.Summary", senders: new[] { wideMock.Object, smallMock.Object });
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var postMap = Assert.IsType<Dictionary<SenderPlatform, Post?>>(result.Output);

        textMock.Verify(p => p.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.InputText == "this is the fallback source" && r.MaxOutputLength == 50),
            It.IsAny<CancellationToken>()), Times.Once);
        tagMock.Verify(t => t.Apply(longText), Times.Once);

        // Distinct platforms key distinct entries: the wide sender keeps the full text,
        // the short sender holds the re-summarised variant.
        Assert.Equal(longText, postMap[SenderPlatform.DryRunMaxLength]!.Content);
        Assert.Equal("re-summarised", postMap[SenderPlatform.DryRunShortLength]!.Content);
        Assert.False(postMap.ContainsKey(SenderPlatform.X));
    }

    [Fact]
    public async Task Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender()
    {
        var (node, textMock, _) = CreateNode();
        var wideMock = new Mock<ISender>();
        SetupSender(wideMock, SenderPlatform.DryRunMaxLength, 300);
        var smallMock = new Mock<ISender>();
        SetupSender(smallMock, SenderPlatform.DryRunShortLength, 50);

        var longText = new string('B', 350);
        var input = Input(longText, sourceContent: "src", stepId: "Feed.Summary", senders: new[] { wideMock.Object, smallMock.Object });
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var postMap = Assert.IsType<Dictionary<SenderPlatform, Post?>>(result.Output);
        textMock.Verify(p => p.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.InputText == "src" && r.MaxOutputLength == 300),
            It.IsAny<CancellationToken>()), Times.Once);
        textMock.Verify(p => p.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.InputText == "src" && r.MaxOutputLength == 50),
            It.IsAny<CancellationToken>()), Times.Once);
        Assert.True(postMap.ContainsKey(SenderPlatform.DryRunMaxLength));
        Assert.True(postMap.ContainsKey(SenderPlatform.DryRunShortLength));
    }

    [Fact]
    public async Task Execute_BridgesMediaAttachment_ToPostImage()
    {
        var (node, _, _) = CreateNode();
        var senderMock = new Mock<ISender>();
        SetupSender(senderMock, SenderPlatform.X, 5000);

        var imageData = new byte[] { 1, 2, 3 };
        var input = Input("text", imageKey: "img", imageData: imageData, senders: senderMock.Object);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var postMap = Assert.IsType<Dictionary<SenderPlatform, Post?>>(result.Output);
        Assert.Equal(imageData, postMap[SenderPlatform.X]!.Image);
    }

    [Fact]
    public async Task Execute_AppliesTagReplacements()
    {
        var (node, _, tagMock) = CreateNode();
        var senderMock = new Mock<ISender>();
        SetupSender(senderMock, SenderPlatform.X, 5000);
        tagMock.Setup(t => t.Apply(It.IsAny<string>())).Returns("FINAL");

        var input = Input("hello", senders: senderMock.Object);
        await node.ExecuteAsync(input, CancellationToken.None);

        tagMock.Verify(t => t.Apply("hello"), Times.Once);
    }

    [Fact]
    public async Task Execute_StoresSendResultsInContext()
    {
        var (node, _, _) = CreateNode();
        var senderMock = new Mock<ISender>();
        SetupSender(senderMock, SenderPlatform.LinkedIn, 2800);

        var input = Input("text", senders: senderMock.Object);
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var postMap = Assert.IsType<Dictionary<SenderPlatform, Post?>>(result.Output);
        Assert.True(postMap.ContainsKey(SenderPlatform.LinkedIn));
        input.Context.GetData<Dictionary<SenderPlatform, Post?>>(WorkflowContextKeys.SendResults);
    }
}