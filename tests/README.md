# XPoster — Testing Strategy

This document describes the testing philosophy, tooling, naming conventions, mocking patterns, and coverage goals for the XPoster test suite.

> For the project overview, architecture, and contribution guidelines, see [README.md](../README.md) and [CONTRIBUTING.md](../CONTRIBUTING.md).

---

## 1. Testing Philosophy

XPoster uses a **unit-first** approach:

| Layer | Test Type | Goal |
|---|---|---|
| Orchestrators (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) | Unit | Verify content-production logic in isolation, with all external services mocked. Fan-out paths verify that `OrchestrateAsync` returns the correct `IReadOnlyDictionary<SenderPlatform, Post?>` per configured sender list |
| Providers (`ConfigurationFeedUrlProvider`, `ConfigurationTagReplacementProvider`) | Unit | Verify config-backed provider contract: correct return value from bound `IOptions`, empty-collection on absent/null config, `ArgumentNullException` on null options |
| Services (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `FalAiImageService`, `FeedService`, `CryptoService`, `AiServiceHelper`) | Unit | Verify transformation and parsing logic; mock HTTP calls |
| Sender plugins (`XSender`, `InSender`, `IgSender`, `FbSender`, `DryRunSender`) | Unit | Verify request construction and error handling; mock the underlying API client. Sender credentials are injected via `IOptions<TCredentials>` and bound from configuration — no `IKeyVaultService` mock required. `DryRunSender` additionally verifies the null-guard path and that no outbound social API call is made |
| `OrchestratorFactory` | Unit | Verify correct orchestrator and sender list selection per hour slot; verify fan-out slot resolves multiple senders in declared order |
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

One test file per production class, mirroring the `src/` directory structure. The folders below reflect the layout after the [issue #224](https://github.com/artcava/XPoster/issues/224) restructure.

```
tests/
├── XPoster.Tests.csproj
├── XFunctionTests.cs
├── XFunctionMissingBranchTests.cs
├── XPosterContainerPollingFunctionTests.cs
├── Abstraction/
│   ├── ScheduledOrchestrationProfileTests.cs
├── Contracts/
│   ├── AiProviderExtensionsTests.cs
│   └── BaseOrchestratorTests.cs
├── Helpers/
│   ├── ImageTestData.cs
│   └── ResilienceTestHelpers.cs
├── Integration/
│   ├── AiClientsResiliencePipelineTests.cs
│   ├── CaptureLoggerProvider.cs
│   ├── InstagramResiliencePipelineTests.cs
│   ├── LinkedInResiliencePipelineTests.cs
│   └── PollyIntegrationTestBase.cs
├── Models/
│   ├── AzureFoundryOptionsTests.cs
│   ├── AzureFoundryOptionsValidatorTests.cs
│   ├── DeepSeekOptionsTests.cs
│   ├── DeepSeekOptionsValidatorTests.cs
│   ├── FalAiOptionsValidatorTests.cs
│   ├── ModelsTests.cs
│   ├── OpenAiOptionsValidatorTests.cs
│   ├── OptionsExtensionsTests.cs
│   ├── PerplexityOptionsValidatorTests.cs
│   ├── PostMissingBranchTests.cs
│   └── RSSFeedMissingBranchTests.cs
├── Orchestrators/
│   ├── ConfigurationFeedUrlProviderTests.cs
│   ├── ConfigurationTagReplacementProviderTests.cs
│   ├── DefaultSlotProfileProviderTests.cs
│   ├── FeedOrchestratorFeedUrlProviderTests.cs
│   ├── FeedOrchestratorTests.cs
│   ├── NoOrchestratorTests.cs
│   ├── OrchestratorFactoryTests.cs
│   └── PowerLawOrchestratorTests.cs
├── SenderPlugins/
│   ├── DryRunSenderTests.cs
│   ├── FbSenderImageFlowTests.cs
│   ├── FbSenderResilienceTests.cs
│   ├── FbSenderSendAsyncTests.cs
│   ├── FbSenderTests.cs
│   ├── IgSenderResilienceTests.cs
│   ├── IgSenderTests.cs
│   ├── InSenderResilienceTests.cs
│   ├── InSenderSendAsyncTests.cs
│   ├── InSenderTests.cs
│   ├── XSenderSendAsyncTests.cs
│   └── XSenderTests.cs
└── Services/
    ├── AiServiceHelperImageTests.cs
    ├── AiServiceHelperTests.cs
    ├── AzureFoundryServiceTests.cs
    ├── BlobStorageServiceTests.cs
    ├── CryptoServiceTests.cs
    ├── DeepSeekServiceTests.cs
    ├── FalAiImageServiceTests.cs
    ├── FeedServiceTests.cs
    ├── InMemoryContainerStateStoreTests.cs
    ├── LocalOverrideTimeProviderTests.cs
    ├── MaskUrlTelemetryInitializerTests.cs
    ├── MetaPublishingServiceTests.cs
    ├── OpenAiServiceTests.cs
    ├── PerplexityServiceTests.cs
    ├── TagReplacementServiceTests.cs
    └── TimeProviderTests.cs
```

### Folder responsibilities

| Folder | Namespace under test | What is covered |
|---|---|---|
| *(root)* | `XPoster` | `XFunction` entry point — happy path and missing-branch edge cases |
| `Abstraction/` | `XPoster.Abstraction` | `ScheduledOrchestrationProfile` |
| `Contracts/` | `XPoster.Contracts` | `AiProviderExtensions` enum extension method contracts; `BaseOrchestrator` abstract class contracts including `PostAsync` parallel dispatch, partial failure, and full failure paths |
| `Helpers/` | — | Shared test utilities for resilience and HTTP mock setup (`ResilienceTestHelpers`) |
| `Integration/` | `XPoster.*` | Polly resilience pipeline integration tests (retry, circuit-breaker, attempt-timeout) — **not run in CI** |
| `Models/` | `XPoster.Models` | Domain model invariants, `Post` and `RSSFeed` missing-branch cases, options validators for OpenAI, Azure Foundry, DeepSeek, fal.ai, and Perplexity |
| `Orchestrators/` | `XPoster.Orchestrators` | `FeedOrchestrator` (main paths + `IFeedUrlProvider` integration + #216 explicit-pipeline scenarios + #176 multi-sender fan-out); `PowerLawOrchestrator`; `NoOrchestrator`; `OrchestratorFactory` slot selection with synthetic `ISlotProfileProvider` mocks including multi-sender slots and ordering; `DefaultSlotProfileProvider` and `DryRunSlotProfileProvider` behaviour; `ConfigurationFeedUrlProvider` URL binding from config; `ConfigurationTagReplacementProvider` replacement map from config |
| `SenderPlugins/` | `XPoster.SenderPlugins` | `XSender`, `InSender`, `IgSender`, `FbSender` (happy path, `SendAsync`, resilience); `DryRunSender` (null guard, dry-run success/failure paths — no Key Vault probe) |
| `Services/` | `XPoster.Services` | `OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `FalAiImageService`, `AiServiceHelper`, `CryptoService`, `FeedService`, `TimeProvider` unit tests |

---

## 4. Naming Conventions

### Test files

Mirror the folder name from `src/` — e.g., new tests for `src/Services/OpenAiService.cs` go in `tests/Services/OpenAiServiceTests.cs`.

### Test method names

Follow the `MethodName_Condition_ExpectedResult` pattern:

```csharp
// ✅ Good
public async Task OrchestrateAsync_WhenAiServiceReturnsEmptySummary_ReturnsEmptyDictionary()
public async Task OrchestrateAsync_WithThreeSenders_ReturnsOneEntryPerSender()
public async Task PostAsync_WhenOneSenderFails_LogsPartialFailureAndReturnsFalse()
public async Task SendAsync_WhenTwitterApiThrows_ReturnsFalse()
public void Resolve_AtHour08_ReturnsThreeSenderFanOutProfile()
public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()  // DryRunSender

// ❌ Avoid
public async Task TestOrchestrate()
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
dotnet test --filter "FullyQualifiedName~FeedOrchestrator"

# Only fan-out tests
dotnet test --filter "FullyQualifiedName~FanOut"

# Only DryRunSender tests
dotnet test --filter "FullyQualifiedName~DryRunSender"

# Only tag replacement provider tests
dotnet test --filter "FullyQualifiedName~ConfigurationTagReplacementProvider"
```

### With coverage report

```bash
# Collect coverage (exclusions defined in coverlet.runsettings at repo root)
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings

# Install report generator (once)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Generate HTML report
reportgenerator \\
  -reports:"**/coverage.cobertura.xml" \\
  -targetdir:"coverage-report" \\
  -reporttypes:Html

# Open report
open coverage-report/index.html   # macOS
start coverage-report/index.html  # Windows
```

---

## 6. Mocking External Services

All external dependencies (`ITextToTextProvider`, `ITextToImageProvider`, `IFeedService`, `IFeedUrlProvider`, `ITagReplacementProvider`, `ISender`, `ILogger`) are injected via constructor and replaced with Moq mocks in tests.

Sender credentials are bound from `IConfiguration` at application startup via the Key Vault Configuration Provider and consumed through `IOptions<TCredentials>`. In unit tests, use `Options.Create(new TCredentials { ... })` to supply test values — no `IKeyVaultService` mock is needed.

### Pattern — mocking `ITextToTextProvider` and `ITagReplacementProvider`

```csharp
[Fact]
public async Task OrchestrateAsync_WhenSummaryIsValid_AppliesTagReplacementsOnce()
{
    // Arrange
    var mockTextProvider = new Mock<ITextToTextProvider>();
    mockTextProvider
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync("BTC breaks ATH driven by ETF inflows");
    mockTextProvider
        .Setup(x => x.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync("A chart showing BTC price spike");

    var mockTagProvider = new Mock<ITagReplacementProvider>();
    mockTagProvider
        .Setup(x => x.GetReplacements())
        .Returns(new Dictionary<string, string> { { "btc", "#BTC" } });

    var mockSender = new Mock<ISender>();
    mockSender.Setup(x => x.Platform).Returns(SenderPlatform.LinkedIn);
    mockSender.Setup(x => x.MessageMaxLenght).Returns(700);

    var mockLogger      = new Mock<ILogger<FeedOrchestrator>>();
    var mockFeedService = new Mock<IFeedService>();
    mockFeedService
        .Setup(x => x.GetFeedItemsAsync(It.IsAny<IEnumerable<string>>()))
        .ReturnsAsync([new FeedItem { Title = "BTC News", Content = "BTC breaks ATH" }]);

    var mockFeedUrlProvider = new Mock<IFeedUrlProvider>();
    mockFeedUrlProvider.Setup(x => x.GetUrls()).Returns(["https://example.com/feed"]);

    var orchestrator = new FeedOrchestrator(
        new[] { mockSender.Object },   // IReadOnlyList<ISender>
        mockLogger.Object,
        mockTextProvider.Object, null,
        mockFeedService.Object, mockFeedUrlProvider.Object,
        mockTagProvider.Object);

    // Act
    var result = await orchestrator.OrchestrateAsync();

    // Assert
    Assert.NotEmpty(result);
    mockTagProvider.Verify(x => x.GetReplacements(), Times.Once);
}
```

### Pattern — fan-out with multiple senders

To test a multi-sender fan-out slot, pass a list of mocked senders with distinct `Platform` and `MessageMaxLenght` values. Declare them in **descending `MessageMaxLenght` order** (widest first), matching the production ordering rule:

```csharp
[Fact]
public async Task OrchestrateAsync_WithTwoSenders_ReturnsOneEntryPerPlatform()
{
    // Arrange
    var mockLinkedIn = new Mock<ISender>();
    mockLinkedIn.Setup(x => x.Platform).Returns(SenderPlatform.LinkedIn);
    mockLinkedIn.Setup(x => x.MessageMaxLenght).Returns(700);

    var mockX = new Mock<ISender>();
    mockX.Setup(x => x.Platform).Returns(SenderPlatform.X);
    mockX.Setup(x => x.MessageMaxLenght).Returns(280);

    // ... build orchestrator with new[] { mockLinkedIn.Object, mockX.Object } ...

    // Act
    var result = await orchestrator.OrchestrateAsync();

    // Assert
    Assert.Equal(2, result.Count);
    Assert.True(result.ContainsKey(SenderPlatform.LinkedIn));
    Assert.True(result.ContainsKey(SenderPlatform.X));
}
```

### Pattern — verifying `PostAsync` parallel dispatch

`BaseOrchestrator.PostAsync` dispatches all senders via `Task.WhenAll`. To verify each sender received its correct post:

```csharp
[Fact]
public async Task PostAsync_WithTwoSenders_CallsSendAsyncOnEach()
{
    // Arrange
    var mockLinkedIn = new Mock<ISender>();
    mockLinkedIn.Setup(x => x.Platform).Returns(SenderPlatform.LinkedIn);
    mockLinkedIn.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    var mockX = new Mock<ISender>();
    mockX.Setup(x => x.Platform).Returns(SenderPlatform.X);
    mockX.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    var posts = new Dictionary<SenderPlatform, Post?>
    {
        [SenderPlatform.LinkedIn] = new Post { Content = "LinkedIn post (700 chars)" },
        [SenderPlatform.X]        = new Post { Content = "X post (280 chars)" }
    };

    // Act (call PostAsync on a concrete BaseOrchestrator subclass or testable stub)
    var success = await orchestrator.PostAsync(posts);

    // Assert
    Assert.True(success);
    mockLinkedIn.Verify(x => x.SendAsync(It.IsAny<Post>()), Times.Once);
    mockX.Verify(x => x.SendAsync(It.IsAny<Post>()), Times.Once);
}

[Fact]
public async Task PostAsync_WhenOneSenderFails_ReturnsFalseAndLogsPartialFailure()
{
    // Arrange
    var mockLinkedIn = new Mock<ISender>();
    mockLinkedIn.Setup(x => x.Platform).Returns(SenderPlatform.LinkedIn);
    mockLinkedIn.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    var mockX = new Mock<ISender>();
    mockX.Setup(x => x.Platform).Returns(SenderPlatform.X);
    mockX.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(false); // <─ failure

    // ... build and act ...

    // Assert
    Assert.False(success);
    // Verify Warning log for partial failure
    mockLogger.Verify(
        x => x.Log(
            LogLevel.Warning,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Partial failure")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
        Times.Once);
}
```

### Pattern — mocking `ISender` to verify call (single sender)

```csharp
[Fact]
public async Task OrchestrateAsync_WhenPostIsValid_CallsSendAsync()
{
    var mockSender = new Mock<ISender>();
    mockSender.Setup(x => x.Platform).Returns(SenderPlatform.X);
    mockSender.Setup(x => x.MessageMaxLenght).Returns(280);
    mockSender.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    // ... build orchestrator with new[] { mockSender.Object } ...

    await orchestrator.OrchestrateAsync();

    mockSender.Verify(x => x.SendAsync(It.IsAny<Post>()), Times.Once);
}
```

### Pattern — supplying sender credentials via `IOptions<T>`

Sender implementations receive credentials through `IOptions<TCredentials>`. In unit tests, use `Options.Create(...)` to provide test values without wiring up Key Vault or configuration infrastructure:

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

### Pattern — testing `DryRunSender` (no outbound call verification)

`DryRunSender` is a no-op sender: it must **never** make an outbound social API call. Tests verify only the null-guard path and the dry-run success return — no Key Vault probe is expected.

```csharp
[Fact]
public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()
{
    // Arrange
    var mockLogger = new Mock<ILogger<DryRunSender>>();
    var sender     = new DryRunSender(mockLogger.Object);

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

[Fact]
public async Task SendAsync_WhenPostIsValid_ReturnsTrueWithoutCallingAnyApi()
{
    // Arrange
    var mockLogger = new Mock<ILogger<DryRunSender>>();
    var sender     = new DryRunSender(mockLogger.Object);
    var post       = new Post { Content = "Test post content" };

    // Act
    var result = await sender.SendAsync(post);

    // Assert
    Assert.True(result);
    // No API client or Key Vault interaction expected — DryRunSender is a pure no-op.
}
```

---

## 7. Adding New Tests — Checklist

When adding a new feature or fixing a bug, follow this checklist before opening a PR:

- [ ] Create (or update) the corresponding `*Tests.cs` file in the mirrored directory
- [ ] Each public method has at least one **happy path** test and one **error/edge case** test
- [ ] All external dependencies are mocked — no real HTTP calls or API keys in unit tests
- [ ] Sender credentials supplied via `Options.Create(new TCredentials { ... })` — no `IKeyVaultService` mock
- [ ] Test method names follow the `MethodName_Condition_ExpectedResult` pattern
- [ ] **Fan-out**: if the changed class is an orchestrator or `BaseOrchestrator`, add tests for both single-sender and multi-sender paths
- [ ] **Fan-out**: verify `OrchestrateAsync` returns `IReadOnlyDictionary<SenderPlatform, Post?>` with one key per configured sender
- [ ] **Fan-out**: mock `ISender.Platform` and `ISender.MessageMaxLenght` in all sender mocks — orchestrators read both properties
- [ ] Run `dotnet test` locally — all tests pass
- [ ] Run coverage and confirm the changed class is above the 80% threshold
- [ ] Link the test file in the PR description

---

## 8. Coverage Target

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
