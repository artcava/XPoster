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
        services.AddKeyedTransient<ITextToTextProvider>("OpenAi", (_, _) => textMock.Object);
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