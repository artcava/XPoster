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

public class AiTextNodeTests
{
    private static (AiTextNode node, Mock<ITextToTextProvider> providerMock) CreateNode(
        string providerName = "OpenAi",
        string? registeredKey = null)
    {
        var providerMock = new Mock<ITextToTextProvider>();
        providerMock
            .Setup(p => p.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("generated text");

        var stepOptions = new PromptStepOptions
        {
            SystemPromptTemplate = "system",
            UserPromptTemplate = "user {Text}",
            Temperature = 0.5,
            MaxTokenBudget = 500,
            InputTextLabel = "{Text}"
        };

        var stepResolverMock = new Mock<IStepOptionsResolver>();
        stepResolverMock.Setup(s => s.Resolve(It.IsAny<string>())).Returns(stepOptions);

        var services = new ServiceCollection();
        services.AddKeyedTransient<ITextToTextProvider>(
            Enum.Parse<AiProvider>(registeredKey ?? providerName, ignoreCase: true),
            (_, _) => providerMock.Object);
        var provider = services.BuildServiceProvider();

        return (new AiTextNode(provider, stepResolverMock.Object), providerMock);
    }

    private static WorkflowNodeInput Input(string provider, string stepId, string inputKey, string text)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        ctx.SetData(inputKey, text);
        var parameters = new Dictionary<string, object>
        {
            ["Provider"] = provider,
            ["StepId"] = stepId,
            ["InputKey"] = inputKey,
        };
        return new WorkflowNodeInput(ctx, parameters, Array.Empty<ISender>());
    }

    [Fact]
    public async Task Execute_ReturnsGeneratedText()
    {
        var (node, _) = CreateNode();
        var input = Input("OpenAi", "Feed.Summary", "sourceContent", "some input");
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal("generated text", result.Output);
    }

    [Fact]
    public async Task Execute_Throws_WhenProviderNameIsUnknown()
    {
        var (node, _) = CreateNode(registeredKey: "OpenAi");
        var input = Input("Unknown", "Feed.Summary", "sourceContent", "input");
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => node.ExecuteAsync(input, CancellationToken.None));
        Assert.Contains("Unknown", ex.Message);
    }

    [Fact]
    public async Task Execute_Throws_WhenValidProviderNotRegistered()
    {
        var (node, _) = CreateNode(registeredKey: "OpenAi");
        var input = Input("Perplexity", "Feed.Summary", "sourceContent", "input");
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => node.ExecuteAsync(input, CancellationToken.None));
        Assert.Contains("not registered", ex.Message);
    }

    [Fact]
    public async Task Execute_ReturnsFailure_WhenProviderReturnsEmpty()
    {
        var providerMock = new Mock<ITextToTextProvider>();
        providerMock
            .Setup(p => p.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("");

        var stepResolverMock = new Mock<IStepOptionsResolver>();
        stepResolverMock.Setup(s => s.Resolve(It.IsAny<string>())).Returns(new PromptStepOptions
        {
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u"
        });

        var services = new ServiceCollection();
        services.AddKeyedTransient<ITextToTextProvider>(AiProvider.OpenAi, (_, _) => providerMock.Object);
        var sp = services.BuildServiceProvider();

        var node = new AiTextNode(sp, stepResolverMock.Object);
        var input = Input("OpenAi", "Feed.Summary", "sourceContent", "input");
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Contains("failed", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_PassesStepOptionsToPromptRequest()
    {
        var (node, providerMock) = CreateNode();
        var input = Input("OpenAi", "Feed.Summary", "sourceContent", "hello");
        await node.ExecuteAsync(input, CancellationToken.None);

        providerMock.Verify(p => p.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.InputText == "hello" &&
                r.SystemPromptTemplate == "system" &&
                r.UserPromptTemplate == "user {Text}" &&
                r.Temperature == 0.5 &&
                r.MaxTokenBudget == 500 &&
                r.InputTextLabel == "{Text}"),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}