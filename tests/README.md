# XPoster — Testing Strategy

This document describes the testing philosophy, tooling, naming conventions, mocking patterns, and coverage goals for the XPoster test suite.

> For the project overview, architecture, and contribution guidelines, see [README.md](../README.md) and [CONTRIBUTING.md](../CONTRIBUTING.md).

---

## 1. Testing Philosophy

XPoster uses a **unit-first** approach. Content production is a config-driven workflow DAG, so its behaviour is tested at three levels: the workflow engine (topological execution + validation), the individual node adapters, and the orchestrator bridge.

| Layer | Test Type | Goal |
|---|---|---|
| `WorkflowExecutionEngine` (DAG engine) | Unit | Verify topological execution order (linear chain, diamond, multi-branch), validation failures (cycles, dangling refs, multiple/zero terminals), terminal-node `ITerminalNode` contract, cancellation, and context population |
| `WorkflowDefinitionValidator` | Unit | Verify structural rules: missing node references, cycles, exactly one terminal node with empty `NextNodeIds` |
| Node adapters (`FetchRssNode`, `AiTextNode`, `AiImageNode`, `FanOutSendNode`, `AcquireCryptoValueNode`, `BuildPowerLawPostNode`) | Unit | Verify each node's parameter handling, input/output context keys, provider resolution, soft-fail (`AiImage Required:false`) vs hard-fail behaviour, and fan-out ordering/re-summarisation |
| `WorkflowOrchestrator` (bridge) | Unit | Verify it executes the bound `WorkflowDefinition` via `IWorkflowEngine`, extracts the `SenderPlatform → Post?` map from `WorkflowContextKeys.SendResults`, and degrades to an empty map (`SendIt = false`) on engine failure or missing `SendResults` |
| `WorkflowContext` | Unit | Verify thread-safe get/set under output keys and the required `SlotKey` |
| Providers (`ConfigurationSlotProfileProvider`, `ConfigurationTagReplacementProvider`) | Unit | Verify config-backed provider contract: correct profile/schedule from bound `IOptions`, empty results on absent/null config, `ArgumentNullException` on null options |
| Services (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `FalAiImageService`, `AiServiceHelper`, `FeedService`, `CryptoService`, `TimeProvider`, `LocalOverrideTimeProvider`) | Unit | Verify transformation, parsing, and prompt-request construction; mock HTTP calls |
| Sender plugins (`XSender`, `InSender`, `IgSender`, `FbSender`, `DryRunMaxLengthSender`, `DryRunShortLengthSender`) | Unit | Verify request construction and error handling; mock the underlying API client. Sender credentials are injected via `IOptions<TCredentials>` and bound from configuration — no `IKeyVaultService` mock required. `DryRunSender` additionally verifies the null-guard path, the `XApiKey` configuration probe, and that no outbound social API call is made |
| `OrchestratorFactory` | Unit | Verify correct orchestrator and sender list selection per hour slot; verify fan-out slot resolves multiple senders; verify `NoOrchestrator` fallback for unscheduled hours, missing workflow keys, and missing definitions |
| `BaseOrchestrator.PostAsync` | Unit | Verify parallel dispatch to all senders; verify partial failure logging; verify full success / full failure outcomes |
| Polly resilience pipelines | Integration | Verify retry, circuit-breaker, and attempt-timeout policies end-to-end using a real `IServiceProvider`; innermost `HttpMessageHandler` replaced with a test double — no outbound network calls |
| End-to-end flow | Integration (optional, not in CI) | Verify full pipeline against a staging environment with real credentials |

> Integration tests in `tests/Integration/` are kept out of the default `dotnet test` run and are gated by a `[Trait("Category", "Integration")]` attribute. They require real credentials and are **never run in CI**.

---

## 2. Tooling

| Tool | Purpose | NuGet Package |
|---|---|---|
| **xUnit** | Test framework | `xunit`, `xunit.runner.visualstudio` |
| **Moq** | Mocking library | `Moq` |
| **coverlet** | Code coverage collection | `coverlet.collector` |
| **ReportGenerator** | HTML coverage reports | `dotnet-reportgenerator-globaltool` |

---

## 3. Test Structure

One test file per production class, mirroring the `src/` directory structure.

```
tests/
├── XPoster.Tests.csproj
├── XFunctionTests.cs
├── XFunctionMissingBranchTests.cs
├── XPosterContainerPollingFunctionTests.cs
├── Contracts/
│   └── AiProviderExtensionsTests.cs
├── Extensions/
│   └── *ExtensionsTests.cs
│   └── SenderPluginsServiceCollectionExtensionsTests.cs
├── Helpers/
│   ├── ImageTestData.cs
│   └── ResilienceTestHelpers.cs
├── Integration/
│   ├── *ResiliencePipelineTests.cs
│   ├── CaptureLoggerProvider.cs
│   └── PollyIntegrationTestBase.cs
├── Models/
│   ├── *OptionsTests.cs
│   ├── *OptionsValidatorTests.cs
│   ├── ModelsTests.cs
│   ├── OptionsExtensionsTests.cs
│   ├── PostTests.cs
│   └── RSSFeedTests.cs
├── Orchestrators/
│   ├── OrchestratorFactoryTests.cs
│   ├── WorkflowOrchestratorTests.cs
│   └── BaseOrchestratorTests.cs
├── Providers/
│   ├── ConfigurationSlotProfileProviderTests.cs
│   └── ConfigurationTagReplacementProviderTests.cs
├── SenderPlugins/
│   ├── Facebook/
│   │   └── Fb*Tests.cs
│   ├── Instagram/
│   │   └── Ig*Tests.cs
│   ├── Linkedin/
│   │   └── In*Tests.cs
│   ├── X/
│   │   └── X*Tests.cs
│   └── DryRunSenderTests.cs
├── Workflows/
│   ├── Configuration/
│   │   ├── WorkflowServiceCollectionExtensionsTests.cs
│   │   └── ConfigurationStepOptionsResolverTests.cs
│   ├── Engine/
│   │   ├── WorkflowExecutionEngineTests.cs
│   │   └── WorkflowDefinitionValidatorTests.cs
│   ├── Models/
│   │   └── WorkflowContextTests.cs
│   ├── Nodes/
│   │   ├── FetchRssNodeTests.cs
│   │   ├── AiTextNodeTests.cs
│   │   ├── AiImageNodeTests.cs
│   │   ├── FanOutSendNodeTests.cs
│   │   ├── AcquireCryptoValueNodeTests.cs
│   │   └── BuildPowerLawPostNodeTests.cs
│   ├── Services/
│   │   └── ConfigurationStepOptionsResolverTests.cs
│   └── Utilities/
│       └── NodeParameterExtractorTests.cs
└── Services/
    ├── AI/
    │   └── *Tests.cs
    └── *Tests.cs
```

### Folder responsibilities

| Folder | Namespace under test | What is covered |
|---|---|---|
| *(root)* | `XPoster` | `XFunction` entry point — happy path and missing-branch edge cases |
| `Contracts/` | `XPoster.Contracts` | `AiProviderExtensions` enum extension method contracts; `BaseOrchestrator` abstract class contracts including `PostAsync` parallel dispatch, partial failure, and full failure paths |
| `Helpers/` | — | Shared test utilities for resilience and HTTP mock setup (`ResilienceTestHelpers`) |
| `Integration/` | `XPoster.*` | Polly resilience pipeline integration tests (retry, circuit-breaker, attempt-timeout) — **not run in CI** |
| `Models/` | `XPoster.Models` | Domain model invariants, `Post` and `RSSFeed` missing-branch cases, options validators for OpenAI, Azure Foundry, DeepSeek, fal.ai, and Perplexity |
| `Orchestrators/` | `XPoster.Orchestrators` | `WorkflowOrchestrator` (DAG bridge — success, engine failure, missing `SendResults`); `OrchestratorFactory` (slot selection, multi-sender fan-out, `NoOrchestrator` fallback); `BaseOrchestrator` (parallel `PostAsync` dispatch) |
| `Providers/` | `XPoster.Providers` | `ConfigurationSlotProfileProvider` (schedule binding from `Schedule` config); `ConfigurationTagReplacementProvider` (replacement map from config); `TimeProvider` / `LocalOverrideTimeProvider` |
| `SenderPlugins/` | `XPoster.SenderPlugins` | `XSender`, `InSender`, `IgSender`, `FbSender` (happy path, `SendAsync`, resilience); `DryRunSender` (null guard, `XApiKey` probe, dry-run success/failure paths) |
| `Workflows/` | `XPoster.Workflows` | Engine (topological execution + validation), `WorkflowDefinitionValidator`, `WorkflowContext`, `ConfigurationStepOptionsResolver`, `WorkflowServiceCollectionExtensions` (keyed node registrations + DAG binding), and each node adapter |
| `Services/` | `XPoster.Services` | `OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `FalAiImageService`, `AiServiceHelper`, `CryptoService`, `FeedService`, `TagReplacementService`, `BlobStorageService`, `MetaPublishingService`, `InMemoryContainerStateStore`, `MaskUrlTelemetryProcessor` unit tests |

---

## 4. Naming Conventions

### Test files

Mirror the folder name from `src/` — e.g., new tests for `src/Workflows/Nodes/AiTextNode.cs` go in `tests/Workflows/Nodes/AiTextNodeTests.cs`.

### Test method names

Follow the `MethodName_Condition_ExpectedResult` pattern:

```csharp
// ✅ Good
public async Task ExecuteAsync_WhenWorkflowHasCycle_ReturnsFailure()
public async Task ExecuteAsync_WithDiamondDag_RunsTopologically()
public async Task OrchestrateAsync_WhenWorkflowFails_ReturnsEmptyDictionary()
public async Task OrchestrateAsync_WhenWorkflowCompletesWithoutSendResults_ReturnsEmptyDictionary()
public async Task OrchestrateAsync_WithTwoSenders_ReturnsOneEntryPerSender()
public async Task PostAsync_WhenOneSenderFails_LogsPartialFailureAndReturnsFalse()
public async Task SendAsync_WhenTwitterApiThrows_ReturnsFalse()
public void Resolve_AtHour06_ReturnsBitcoinWorkflowOrchestrator()
public void Resolve_AtUnmatchedHour_ReturnsNoOrchestrator()
public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()  // DryRunSender

// ❌ Avoid
public async Task TestExecute()
public async Task SendTest2()
```

---

## 5. Running Tests Locally

### All tests

```bash
dotnet test
```

### Filter by category

```bash
# Only unit tests (excludes integration)
dotnet test --filter "Category!=Integration"

# Only a specific class
dotnet test --filter "FullyQualifiedName~WorkflowExecutionEngine"

# Only engine tests
dotnet test --filter "FullyQualifiedName~Workflows.Engine"

# Only node tests
dotnet test --filter "FullyQualifiedName~Workflows.Nodes"

# Only DryRunSender tests
dotnet test --filter "FullyQualifiedName~DryRunSender"

# Only slot-profile provider tests
dotnet test --filter "FullyQualifiedName~ConfigurationSlotProfileProvider"
```

### With coverage report

```bash
# Collect coverage (exclusions defined in coverlet.runsettings at repo root)
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings

# Install report generator (once)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Generate HTML report
reportgenerator \
  -reports:"**/coverage.cobertura.xml" \
  -targetdir:"coverage-report" \
  -reporttypes:Html

# Open report
start coverage-report/index.html   # Windows
open  coverage-report/index.html   # macOS
```

---

## 6. Testing the Workflow Engine

`WorkflowExecutionEngine` is the heart of content production. Tests drive it with **stub `IWorkflowNode`s registered as keyed DI services** (rather than real nodes) to keep each test focused on the engine's contract.

### Pattern — stub nodes in the DI container

```csharp
[Fact]
public async Task ExecuteAsync_WithLinearChain_RunsInTopologicalOrder()
{
    // Arrange — register keyed stub nodes
    var order = new List<string>();
    var services = new ServiceCollection();
    services.AddKeyedTransient<IWorkflowNode>("nodeA", (_, _) =>
        new StubNode("A", t => order.Add(t)));
    services.AddKeyedTransient<IWorkflowNode>("nodeB", (_, _) =>
        new StubNode("B", t => order.Add(t)));
    services.AddKeyedTransient<IWorkflowNode>("nodeC", (_, _) =>
        new StubNode("C", t => order.Add(t)));

    var provider = services.BuildServiceProvider();
    var engine = new WorkflowExecutionEngine(provider, new NullLogger<WorkflowExecutionEngine>());

    var definition = new WorkflowDefinition("Linear", new()
    {
        new("A", "nodeA", new(), OutputKey: "a", NextNodeIds: new() { "B" }),
        new("B", "nodeB", new(), OutputKey: "b", NextNodeIds: new() { "C" }),
        new("C", "nodeC", new(), OutputKey: "c", NextNodeIds: new()),
    });

    // Act
    var result = await engine.ExecuteAsync(definition, new List<ISender>(), CancellationToken.None);

    // Assert
    Assert.True(result.Success);
    Assert.Equal(["A", "B", "C"], order);
}
```

The `StubNode` test double (as in `WorkflowExecutionEngineTests.cs`) implements `ITerminalNode` so it satisfies the engine's terminal-node contract validation and can record its execution into a shared list. The same pattern covers diamond DAGs, multi-branch execution, cancellation, and single-node workflows.

### Pattern — validation failures

Structural validation runs at registration time (`WorkflowServiceCollectionExtensions.AddWorkflows` throws) and again at every execution (`WorkflowEngine` returns `WorkflowExecutionResult(false, …)`). Test the validator directly:

```csharp
[Fact]
public void ValidateStructural_WithCycle_ReturnsCycleError()
{
    var definition = new WorkflowDefinition("Cyclic", new()
    {
        new("A", "nodeA", new(), OutputKey: null, NextNodeIds: new() { "B" }),
        new("B", "nodeB", new(), OutputKey: null, NextNodeIds: new() { "A" }),
    });

    var error = WorkflowDefinitionValidator.ValidateStructural(definition);

    Assert.NotNull(error);
    Assert.Contains("Cycle", error);
}

[Fact]
public void ValidateStructural_WithZeroTerminalNodes_ReturnsError()
{
    var definition = new WorkflowDefinition("NoTerminal", new()
    {
        new("A", "nodeA", new(), OutputKey: null, NextNodeIds: new() { "B" }),
        new("B", "nodeB", new(), OutputKey: null, NextNodeIds: new() { "A" }),
    });

    Assert.NotNull(WorkflowDefinitionValidator.ValidateStructural(definition));
}

[Fact]
public void ValidateTerminalNodeContract_WhenTerminalIsNotITerminalNode_ReturnsError()
{
    // resolve a non-terminal node instance for the terminal's Type via the DI provider
    // and assert the returned error mentions ITerminalNode
}
```

---

## 7. Testing Node Adapters

Each built-in node is a thin adapter over an injected service, so tests mock that service and assert the `WorkflowNodeResult` and context/output keys. Nodes read their parameters from the `WorkflowNodeInput.Parameters` dictionary via `NodeParameterExtractor` and the step options from `IStepOptionsResolver`.

### Pattern — testing `AiTextNode`

```csharp
[Fact]
public async Task ExecuteAsync_WhenProviderMissing_ThrowsInvalidOperationException()
{
    // Arrange — no ITextToTextProvider registered under the provider key
    var services = new ServiceCollection();
    var provider = services.BuildServiceProvider();
    var resolver = new Mock<IStepOptionsResolver>();
    var node = new AiTextNode(provider, resolver.Object);
    var input = new WorkflowNodeInput(
        new WorkflowContext { SlotKey = "s" },
        new Dictionary<string, object> { ["Provider"] = "FalAi", ["StepId"] = "Feed.Summary" },  // text-only provider → throws
        new List<ISender>());

    // Act & Assert
    var ex = await Assert.ThrowsAsync<InvalidOperationException>(
        () => node.ExecuteAsync(input, CancellationToken.None));
    Assert.Contains("ITextToTextProvider", ex.Message);
}
```

### Pattern — testing `AiImageNode` soft-failure

```csharp
[Fact]
public async Task ExecuteAsync_WhenImageEmptyAndRequiredFalse_ReturnsSuccessWithoutOutput()
{
    // Arrange — register an ITextToImageProvider that returns empty bytes
    services.AddKeyedTransient<ITextToImageProvider, StubImageProvider>(AiProvider.FalAi);
    // context has "imagePrompt" = "…"; Parameters: Provider=FalAi, StepId, InputKey=imagePrompt, Required=false

    // Act
    var result = await node.ExecuteAsync(input, CancellationToken.None);

    // Assert — soft failure: workflow continues without an image
    Assert.True(result.Success);
    Assert.Null(result.Output);
}
```

### Pattern — testing `FanOutSendNode` fan-out ordering

`FanOutSendNode` orders senders by `MessageMaxLength` descending and re-summarises over-long text via `FallbackSourceKey`/`StepId` (or truncates). Assert it writes `WorkflowContextKeys.SendResults` and applies per-sender adaptation:

```csharp
[Fact]
public async Task ExecuteAsync_WithTwoSenders_WritesSendResultsPerPlatform()
{
    // Arrange — senders: LinkedIn (700) primary, X (250) secondary
    var linkedIn = MockSender(SenderPlatform.LinkedIn, 700);
    var x = MockSender(SenderPlatform.X, 250);
    // text from "PowerLaw.PostText" fits LinkedIn but is re-summarised/truncated for X

    // Act
    var result = await node.ExecuteAsync(input, CancellationToken.None);

    // Assert
    Assert.True(result.Success);
    input.Context.TryGetData<Dictionary<SenderPlatform, Post?>>(
        WorkflowContextKeys.SendResults, out var posts);
    Assert.Equal(2, posts!.Count);
    Assert.Contains(SenderPlatform.LinkedIn, posts.Keys);
    Assert.Contains(SenderPlatform.X, posts.Keys);
}
```

### Pattern — testing config-driven nodes (`AcquireCryptoValueNode`, `BuildPowerLawPostNode`)

```csharp
[Fact]
public async Task ExecuteAsync_WhenPriceAcquired_StoresDecimalOutput()
{
    var mockCrypto = new Mock<ICryptoService>();
    mockCrypto.Setup(c => c.GetCryptoValue("BTC")).ReturnsAsync(65432.10m);

    var node = new AcquireCryptoValueNode(mockCrypto.Object);
    var context = new WorkflowContext { SlotKey = "s" };
    var input = new WorkflowNodeInput(context, new Dictionary<string, object>(), new List<ISender>());

    var result = await node.ExecuteAsync(input, CancellationToken.None);

    Assert.True(result.Success);
    Assert.Equal(65432.10m, result.Output);
}
```

`BuildPowerLawPostNode` is deterministic: feed a fixed `ITimeProvider` and assert the fair-value text (`value = 10⁻¹⁷ × days^5.83`, anchored at the 2009-01-03 genesis block) and the signed percentage delta.

---

## 8. Testing the Orchestrator Bridge

`WorkflowOrchestrator` delegates to `IWorkflowEngine` and extracts `WorkflowContextKeys.SendResults`. Mock the engine to test the bridge in isolation:

### Pattern — successful fan-out bridge

```csharp
[Fact]
public async Task OrchestrateAsync_WhenSuccessful_ReturnsPostMapFromContext()
{
    // Arrange — mock engine returns a Success result whose context contains SendResults
    var context = new WorkflowContext { SlotKey = "Bitcoin" };
    var postMap = new Dictionary<SenderPlatform, Post?>
    {
        [SenderPlatform.X]    = new Post { Content = "BTC update" },
        [SenderPlatform.LinkedIn] = new Post { Content = "BTC update" },
    };
    context.SetData(WorkflowContextKeys.SendResults, postMap);

    var mockEngine = new Mock<IWorkflowEngine>();
    mockEngine
        .Setup(e => e.ExecuteAsync(It.IsAny<WorkflowDefinition>(), It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new WorkflowExecutionResult(true, context, null));

    var orchestrator = new WorkflowOrchestrator(
        new[] { MockSender(SenderPlatform.X, 250), MockSender(SenderPlatform.LinkedIn, 700) },
        new NullLogger<WorkflowOrchestrator>(),
        mockEngine.Object,
        new WorkflowDefinition("Bitcoin", new() { /* … */ }));

    // Act
    var result = await orchestrator.OrchestrateAsync();

    // Assert
    Assert.True(orchestrator.SendIt);
    Assert.Equal(2, result.Count);
}
```

### Pattern — engine failure degrades gracefully

```csharp
[Fact]
public async Task OrchestrateAsync_WhenEngineFails_ReturnsEmptyAndDisablesSend()
{
    // Arrange — mock engine returns failure result
    var context = new WorkflowContext { SlotKey = "Bitcoin" };
    var mockEngine = new Mock<IWorkflowEngine>();
    mockEngine
        .Setup(e => e.ExecuteAsync(It.IsAny<WorkflowDefinition>(), It.IsAny<IReadOnlyList<ISender>>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new WorkflowExecutionResult(false, context, "node 'x' failed"));

    var orchestrator = /* new WorkflowOrchestrator(…) with mockEngine … */;

    // Act
    var result = await orchestrator.OrchestrateAsync();

    // Assert — graceful skip, no throw
    Assert.False(orchestrator.SendIt);
    Assert.Empty(result);
}
```

---

## 9. Mocking External Services

All external dependencies (`ITextToTextProvider`, `ITextToImageProvider`, `IFeedService`, `ITagReplacementProvider`, `ISender`, `IWorkflowEngine`, `ILogger`) are injected via constructor and replaced with Moq mocks in tests. Nodes resolve keyed capability providers via `IServiceProvider`; in tests, register stub/mock providers under the same `AiProvider` key.

Sender credentials are bound from `IConfiguration` at application startup via the Key Vault Configuration Provider and consumed through `IOptions<TCredentials>`. In unit tests, use `Options.Create(new TCredentials { ... })` to supply test values — no `IKeyVaultService` mock is needed.

### Pattern — mocking the AI text provider (per-node resolution)

Instead of a global `AiProvider` switch, each node resolves its provider by key. Register the mock under the provider key the node names:

```csharp
[Fact]
public async Task GenerateTextAsync_WhenRequestIsValid_ReturnsText()
{
    var mockTextProvider = new Mock<ITextToTextProvider>();
    mockTextProvider
        .Setup(x => x.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync("BTC breaks ATH driven by ETF inflows");

    // register mockTextProvider.Object under AiProvider.DeepSeek in a ServiceCollection,
    // then construct AiTextNode; the node resolves GetKeyedService<ITextToTextProvider>(DeepSeek)
}
```

### Pattern — supplying sender credentials via `IOptions<T>`

```csharp
[Fact]
public async Task SendAsync_WhenPostIsValid_ReturnsTrue()
{
    // Arrange
    var credentials = Options.Create(new XCredentials
    {
        ApiKey    = "test-api-key",
        ApiSecret = "test-api-secret",
        // ... other required fields
    });
    var mockLogger = new Mock<ILogger<XSender>>();
    var mockClient = new Mock<IXApiClient>();
    mockClient
        .Setup(x => x.PostTweetAsync(It.IsAny<string>()))
        .ReturnsAsync(true);

    var sender = new XSender(credentials, mockClient.Object, mockLogger.Object);
    var post   = new Post { Content = "Test post content" };

    // Act
    var result = await sender.SendAsync(post);

    // Assert
    Assert.True(result);
}
```

### Pattern — testing `ConfigurationTagReplacementProvider`

```csharp
[Fact]
public void GetReplacements_WhenConfigured_ReturnsExpectedMap()
{
    // Arrange
    var options = Options.Create(new TagReplacementOptions
    {
        Replacements = new Dictionary<string, string>
        {
            { "bitcoin", "#Bitcoin" },
            { "btc",     "#BTC"     }
        }
    });
    var provider = new ConfigurationTagReplacementProvider(options);

    // Act
    var replacements = provider.GetReplacements();

    // Assert
    Assert.Equal(2, replacements.Count);
    Assert.Equal("#Bitcoin", replacements["bitcoin"]);
    Assert.Equal("#BTC",     replacements["btc"]);
}

[Fact]
public void GetReplacements_WhenSectionAbsent_ReturnsEmptyDictionary()
{
    var options  = Options.Create(new TagReplacementOptions());
    var provider = new ConfigurationTagReplacementProvider(options);

    Assert.Empty(provider.GetReplacements());
}

[Fact]
public void Constructor_WhenOptionsIsNull_ThrowsArgumentNullException()
{
    Assert.Throws<ArgumentNullException>(
        () => new ConfigurationTagReplacementProvider(null!));
}
```

> `FetchRssNode` also reads the tag keys from `ITagReplacementProvider` to pre-filter feed items, and fetches via `IFeedService.GetFeedsAsync(urls, start, end, keywords, ct)` — mock both when testing that node.

### Pattern — testing `DryRunSender` (probe + no outbound call)

`DryRunSender` is a no-op sender: it must **never** make an outbound social API call. It probes configuration for a non-empty top-level `XApiKey` before returning. Tests cover the null guard, the probe success, and the probe failure path.

```csharp
[Fact]
public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()
{
    // Arrange
    var config = new ConfigurationBuilder().Build(); // empty — probe would fail, but null-guard short-circuits first
    var mockLogger = new Mock<ILogger<DryRunSender>>();
    var sender     = new DryRunMaxLengthSender(config, mockLogger.Object);

    // Act
    var result = await sender.SendAsync(null);

    // Assert
    Assert.False(result);
    mockLogger.Verify(
        x => x.Log(
            LogLevel.Warning,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("null")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
        Times.Once);
}
```

---

## 10. Adding New Tests — Checklist

When adding a new feature or fixing a bug, follow this checklist before opening a PR:

- [ ] Create (or update) the corresponding `*Tests.cs` file in the mirrored directory
- [ ] Each public method has at least one **happy path** test and one **error/edge case** test
- [ ] All external dependencies are mocked — no real HTTP calls or API keys in unit tests
- [ ] Sender credentials supplied via `Options.Create(new TCredentials { ... })` — no `IKeyVaultService` mock
- [ ] Test method names follow the `MethodName_Condition_ExpectedResult` pattern
- [ ] **Workflow nodes**: verify parameter resolution via `NodeParameterExtractor`, `OutputKey`/context reads, provider resolution via keyed DI, and `Required` soft-fail behaviour on `AiImage`
- [ ] **Engine**: new validation rules must have tests in `WorkflowDefinitionValidatorTests`; execution order tests in `WorkflowExecutionEngineTests`
- [ ] **Fan-out**: if the change touches `FanOutSendNode`, `WorkflowOrchestrator`, or `BaseOrchestrator`, add tests for both single-sender and multi-sender paths
- [ ] **Fan-out**: verify the `WorkflowContextKeys.SendResults` map has one key per configured sender; mock `ISender.Platform` and `ISender.MessageMaxLength` in all sender mocks
- [ ] **Orchestrator bridge**: verify graceful `SendIt = false` + empty-map degradation on engine failure and on missing `SendResults`
- [ ] Run `dotnet test` locally — all tests pass
- [ ] Run coverage and confirm the changed class is above the 80% threshold
- [ ] Link the test file in the PR description

---

## 11. Coverage Target

The project targets **≥ 80% line coverage** across all non-generated code.

Coverage is collected on every CI run via the `dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings` step in `.github/workflows/ci.yml`.

Classes excluded from coverage are declared in `coverlet.runsettings` at the repo root. Current exclusions (auto-generated Azure Functions isolated-worker classes):
- `Program`
- `DirectFunctionExecutor`
- `FunctionExecutorAutoStartup`
- `FunctionExecutorHostBuilderExtensions`
- `FunctionMetadataProviderAutoStartup`
- `GeneratedFunctionMetadataProvider`
- `WorkerExtensionStartupCodeExecutor`
- `WorkerHostBuilderFunctionMetadataProviderExtension`
- `HttpClientExtensions`

---

*For contribution guidelines, see [CONTRIBUTING.md](../CONTRIBUTING.md).*
