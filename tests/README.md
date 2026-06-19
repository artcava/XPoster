# XPoster — Testing Strategy

This document describes the testing philosophy, tooling, naming conventions, mocking patterns, and coverage goals for the XPoster test suite.

> For the project overview, architecture, and contribution guidelines, see [README.md](../README.md) and [CONTRIBUTING.md](../CONTRIBUTING.md).

---

## 1. Testing Philosophy

XPoster uses a **unit-first** approach:

| Layer | Test Type | Goal |
|---|---|---|
| Orchestrators (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) | Unit | Verify content-production logic in isolation, with all external services mocked |
| Services (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `HybridAiService`, `FalAiImageService`, `FeedService`, `CryptoService`, `AiServiceHelper`) | Unit | Verify transformation and parsing logic; mock HTTP calls |
| Key Vault (`KeyVaultService` via `IKeyVaultService`) | Unit | Verify secret-name contracts, rotation behaviour, and constructor guards; mock `IKeyVaultService` — no live Key Vault connection |
| Sender plugins (`XSender`, `InSender`, `IgSender`, `DryRunSender`) | Unit | Verify request construction and error handling; mock the underlying API client and `IKeyVaultService`. `DryRunSender` additionally verifies the Key Vault connectivity probe, null-guard path, and that no outbound social API call is made |
| `OrchestratorFactory` | Unit | Verify correct orchestrator and sender selection per hour slot |
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

One test file per production class, mirroring the `src/` directory structure. The folders below reflect the layout after the [issue #186](https://github.com/artcava/XPoster/issues/186) restructure.

```
tests/
├── XPoster.Tests.csproj
├── XFunctionTests.cs
├── XFunctionMissingBranchTests.cs
├── Contracts/                                    # mirrors src/Contracts/ and src/Abstraction/
│   ├── AiProviderExtensionsTests.cs              # XPoster.Contracts — AiProviderExtensions enum extension
│   └── BaseOrchestratorTests.cs                  # XPoster.Abstraction — BaseOrchestrator abstract contracts
├── Helpers/
│   └── ResilienceTestHelpers.cs                  # shared HTTP mock helpers for resilience tests
├── Orchestrators/                                # mirrors src/Orchestrators/
│   ├── AiServiceFactoryTests.cs                  # AiServiceFactory — provider resolution by AiProvider enum (includes Perplexity case)
│   ├── ConfigurationFeedUrlProviderTests.cs      # ConfigurationFeedUrlProvider — URL list from config
│   ├── FeedOrchestratorFeedUrlProviderTests.cs   # FeedOrchestrator — IFeedUrlProvider integration paths
│   ├── FeedOrchestratorTests.cs                  # FeedOrchestrator — main happy/failure paths
│   ├── NoOrchestratorTests.cs                    # NoOrchestrator — null-object contract
│   ├── OrchestratorFactoryTests.cs               # OrchestratorFactory + SlotProfileProvider behaviour
│   └── PowerLawOrchestratorTests.cs              # PowerLawOrchestrator — price/model computation
├── Integration/
│   ├── PollyIntegrationTestBase.cs
│   ├── LinkedInResiliencePipelineTests.cs
│   ├── InstagramResiliencePipelineTests.cs
│   ├── AiClientsResiliencePipelineTests.cs
│   └── CaptureLoggerProvider.cs
├── Models/
│   ├── AzureFoundryOptionsValidatorTests.cs
│   ├── DeepSeekOptionsTests.cs
│   ├── DeepSeekOptionsValidatorTests.cs
│   ├── FalAiOptionsValidatorTests.cs
│   ├── ModelsTests.cs
│   ├── OpenAiOptionsValidatorTests.cs
│   ├── PerplexityOptionsValidatorTests.cs        # PerplexityOptions — required fields, placeholder validation
│   ├── PostMissingBranchTests.cs
│   └── RSSFeedMissingBranchTests.cs
├── SenderPlugins/
│   ├── DryRunSenderTests.cs
│   ├── IgSenderResilienceTests.cs
│   ├── IgSenderTests.cs
│   ├── InSenderMissingBranchTests.cs
│   ├── InSenderResilienceTests.cs
│   ├── InSenderSendAsyncTests.cs
│   ├── InSenderTests.cs
│   ├── XSenderMissingBranchTests.cs
│   ├── XSenderSendAsyncTests.cs
│   └── XSenderTests.cs
└── Services/
    ├── AiServiceHelperTests.cs
    ├── AzureFoundryServiceTests.cs
    ├── CryptoServiceTests.cs
    ├── DeepSeekServiceTests.cs
    ├── FalAiImageServiceTests.cs
    ├── FeedServiceTests.cs
    ├── HybridAiServiceTests.cs
    ├── KeyVaultServiceTests.cs
    ├── OpenAiServiceTests.cs
    ├── PerplexityServiceTests.cs                 # PerplexityService — summary, image prompt, GenerateImageAsync graceful degradation
    └── TimeProviderTests.cs
```

### Folder responsibilities

| Folder | Namespace under test | What is covered |
|---|---|---|
| *(root)* | `XPoster` | `XFunction` entry point — happy path and missing-branch edge cases |
| `Contracts/` | `XPoster.Contracts`, `XPoster.Abstraction` | `AiProviderExtensions` enum extension method contracts; `BaseOrchestrator` abstract class contracts |
| `Helpers/` | — | Shared test utilities for resilience and HTTP mock setup (`ResilienceTestHelpers`) |
| `Orchestrators/` | `XPoster.Orchestrators` | `FeedOrchestrator` (main paths + `IFeedUrlProvider` integration); `PowerLawOrchestrator`; `NoOrchestrator`; `AiServiceFactory` provider resolution (including `AiProvider.Perplexity`); `OrchestratorFactory` slot selection with synthetic `ISlotProfileProvider` mocks; `DefaultSlotProfileProvider` and `DryRunSlotProfileProvider` behaviour; `ConfigurationFeedUrlProvider` URL binding from config |
| `Integration/` | `XPoster.*` | Polly resilience pipeline integration tests (retry, circuit-breaker, attempt-timeout) — **not run in CI** |
| `Models/` | `XPoster.Models` | Domain model invariants, `Post` and `RSSFeed` missing-branch cases, options validators for OpenAI, Azure Foundry, DeepSeek, fal.ai, and Perplexity |
| `SenderPlugins/` | `XPoster.SenderPlugins` | `XSender` and `InSender` (happy path, `SendAsync`, missing-branch, resilience); `IgSender` (happy path, resilience); `DryRunSender` (null guard, Key Vault probe, dry-run success/failure paths) |
| `Services/` | `XPoster.Services` | `OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `PerplexityService`, `FalAiImageService`, `HybridAiService`, `AiServiceHelper`, `CryptoService`, `FeedService`, `TimeProvider`, and `KeyVaultService` unit tests |

---

## 4. Naming Conventions

### Test files

Mirror the folder name from `src/` — e.g., new tests for `src/Services/KeyVaultService.cs` go in `tests/Services/KeyVaultServiceTests.cs`.

### Test method names

Follow the `MethodName_Condition_ExpectedResult` pattern:

```csharp
// ✅ Good
public async Task OrchestrateAsync_WhenAiServiceReturnsEmptySummary_ReturnsNull()
public async Task SendAsync_WhenTwitterApiThrows_ReturnsFalse()
public void Resolve_AtHour06_ReturnsInSummaryFeedProfile()
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

# Only DryRunSender tests
dotnet test --filter "FullyQualifiedName~DryRunSender"
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
open coverage-report/index.html   # macOS
start coverage-report/index.html  # Windows
```

---

## 6. Mocking External Services

All external dependencies (`IAiService`, `IFeedService`, `ISender`, `IKeyVaultService`, `ILogger`) are injected via constructor and replaced with Moq mocks in tests.

### Pattern — mocking `IAiService`

```csharp
[Fact]
public async Task OrchestrateAsync_WhenAiReturnsValidSummary_PostContentIsSet()
{
    // Arrange
    var mockAi = new Mock<IAiService>();
    mockAi
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
        .ReturnsAsync("BTC breaks ATH driven by ETF inflows");

    var mockSender  = new Mock<ISender>();
    var mockLogger  = new Mock<ILogger<FeedOrchestrator>>();
    var mockFeed    = new Mock<IFeedService>();
    mockFeed
        .Setup(x => x.GetLatestItemAsync())
        .ReturnsAsync(new FeedItem { Title = "BTC News", Content = "..." });

    var orchestrator = new FeedOrchestrator(mockSender.Object, mockLogger.Object,
                                            mockFeed.Object, mockAi.Object);

    // Act
    var post = await orchestrator.OrchestrateAsync();

    // Assert
    Assert.NotNull(post);
    Assert.Contains("BTC breaks ATH", post.Content);
    mockAi.Verify(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
}
```

### Pattern — mocking `ISender` to verify call

```csharp
[Fact]
public async Task OrchestrateAsync_WhenPostIsValid_CallsSendAsync()
{
    var mockSender = new Mock<ISender>();
    mockSender.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    // ... build orchestrator with mockSender ...

    await orchestrator.OrchestrateAsync();

    mockSender.Verify(x => x.SendAsync(It.IsAny<Post>()), Times.Once);
}
```

### Pattern — testing `DryRunSender` (no outbound call verification)

`DryRunSender` is a no-op sender: it must **never** make an outbound social API call. Tests verify this by confirming that only the Key Vault probe call is made and nothing beyond it.

```csharp
[Fact]
public async Task SendAsync_WhenPostIsValid_ReturnsTrueAndOnlyProbesKeyVault()
{
    // Arrange
    var mockKv     = new Mock<IKeyVaultService>();
    var mockLogger = new Mock<ILogger<DryRunSender>>();
    mockKv.Setup(x => x.GetSecretAsync("XApiKey")).ReturnsAsync("probe-value");

    var sender = new DryRunSender(mockKv.Object, mockLogger.Object);
    var post   = new Post { Content = "Test post content" };

    // Act
    var result = await sender.SendAsync(post);

    // Assert
    Assert.True(result);
    mockKv.Verify(x => x.GetSecretAsync("XApiKey"), Times.Once);  // probe only
    mockKv.Verify(x => x.GetSecretAsync(It.Is<string>(s => s != "XApiKey")), Times.Never);
}
```

---

## 7. Adding New Tests — Checklist

When adding a new feature or fixing a bug, follow this checklist before opening a PR:

- [ ] Create (or update) the corresponding `*Tests.cs` file in the mirrored directory
- [ ] Each public method has at least one **happy path** test and one **error/edge case** test
- [ ] All external dependencies are mocked — no real HTTP calls or API keys in unit tests
- [ ] Test method names follow the `MethodName_Condition_ExpectedResult` pattern
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
