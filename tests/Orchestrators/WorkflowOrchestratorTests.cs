using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;
using XPoster.Workflows.Engine;
using XPoster.Workflows.Models;

namespace XPoster.Tests.Orchestrators;

public class WorkflowOrchestratorTests
{
    private static WorkflowDefinition MakeDefinition() =>
        new("Bitcoin", new List<WorkflowNodeDefinition>
        {
            new("fetch", "FetchRss", new Dictionary<string, object>(), null, new List<string>()),
            new("image", "AiImage", new Dictionary<string, object>(), null, new List<string>())
        });

    private static WorkflowDefinition MakeDefinitionWithoutImage() =>
        new("PowerLaw", new List<WorkflowNodeDefinition>
        {
            new("acquire", "AcquireCryptoValue", new Dictionary<string, object>(), null, new List<string>()),
            new("build", "BuildPowerLawPost", new Dictionary<string, object>(), null, new List<string>())
        });

    private static (WorkflowOrchestrator orchestrator, Mock<IWorkflowEngine> engineMock, WorkflowDefinition definition) CreateOrchestrator(
        WorkflowExecutionResult executionResult)
    {
        var definition = MakeDefinition();
        var engineMock = new Mock<IWorkflowEngine>();
        engineMock
            .Setup(e => e.ExecuteAsync(definition, It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(executionResult);

        var senders = new List<ISender>
        {
            new Mock<ISender>().Object
        }.AsReadOnly();

        var orchestrator = new WorkflowOrchestrator(
            senders,
            NullLogger<WorkflowOrchestrator>.Instance,
            engineMock.Object,
            definition);

        return (orchestrator, engineMock, definition);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsPostMap_OnSuccess()
    {
        var post = new Post { Content = "hello" };
        var context = new WorkflowContext { SlotKey = "Bitcoin" };
        context.SetData(WorkflowContextKeys.SendResults, new Dictionary<SenderPlatform, Post?>
        {
            [SenderPlatform.X] = post
        });

        var (orchestrator, engineMock, definition) = CreateOrchestrator(
            new WorkflowExecutionResult(true, context, null));

        var result = await orchestrator.OrchestrateAsync(CancellationToken.None);

        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Same(post, result[SenderPlatform.X]);
        engineMock.Verify(e => e.ExecuteAsync(definition, It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsEmptyDictionary_OnFailure()
    {
        var context = new WorkflowContext { SlotKey = "Bitcoin" };
        var (orchestrator, engineMock, definition) = CreateOrchestrator(
            new WorkflowExecutionResult(false, context, "boom"));

        var result = await orchestrator.OrchestrateAsync(CancellationToken.None);

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        engineMock.Verify(e => e.ExecuteAsync(definition, It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsEmptyDictionary_WhenSendResultsMissing()
    {
        var context = new WorkflowContext { SlotKey = "Bitcoin" };
        var (orchestrator, _, _) = CreateOrchestrator(
            new WorkflowExecutionResult(true, context, null));

        var result = await orchestrator.OrchestrateAsync(CancellationToken.None);

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
    }

    [Fact]
    public void Properties_AreConfigured()
    {
        var (orchestrator, _, _) = CreateOrchestrator(
            new WorkflowExecutionResult(true, new WorkflowContext { SlotKey = "Bitcoin" }, null));

        Assert.Equal("WorkflowOrchestrator", orchestrator.Name);
        Assert.True(orchestrator.SendIt);
        Assert.True(orchestrator.ProduceImage);
        Assert.DoesNotContain(SenderPlatform.DryRunMaxLength, orchestrator.SupportedPlatforms);
        Assert.DoesNotContain(SenderPlatform.DryRunShortLength, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.X, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.LinkedIn, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Instagram, orchestrator.SupportedPlatforms);
        Assert.Contains(SenderPlatform.Facebook, orchestrator.SupportedPlatforms);
    }

    [Fact]
    public void ProduceImage_IsFalse_WhenWorkflowHasNoAiImageNode()
    {
        var definition = MakeDefinitionWithoutImage();
        var engineMock = new Mock<IWorkflowEngine>();
        engineMock
            .Setup(e => e.ExecuteAsync(definition, It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new WorkflowExecutionResult(true, new WorkflowContext { SlotKey = "PowerLaw" }, null));

        var orchestrator = new WorkflowOrchestrator(
            new List<ISender> { new Mock<ISender>().Object }.AsReadOnly(),
            NullLogger<WorkflowOrchestrator>.Instance,
            engineMock.Object,
            definition);

        Assert.False(orchestrator.ProduceImage);
    }

    [Fact]
    public void ProduceImage_IsTrue_WhenWorkflowHasAiImageNode()
    {
        var (orchestrator, _, _) = CreateOrchestrator(
            new WorkflowExecutionResult(true, new WorkflowContext { SlotKey = "Bitcoin" }, null));

        Assert.True(orchestrator.ProduceImage);
    }

    [Fact]
    public void ProduceImage_Set_ThrowsNotSupported()
    {
        var (orchestrator, _, _) = CreateOrchestrator(
            new WorkflowExecutionResult(true, new WorkflowContext { SlotKey = "Bitcoin" }, null));

        Assert.Throws<NotSupportedException>(() => orchestrator.ProduceImage = false);
    }
}