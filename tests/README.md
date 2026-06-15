# XPoster — Testing Strategy

This document describes the testing philosophy, tooling, naming conventions, mocking patterns, and coverage goals for the XPoster test suite.

---

## 1. Testing Philosophy

XPoster uses a **unit-first** approach:

| Layer | Test Type | Goal |
|---|---|---|
| Generators (`FeedGenerator`, `PowerLawGenerator`) | Unit | Verify content-generation logic in isolation, with all external services mocked |
| Services (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `HybridAiService`, `FalAiImageService`, `FeedService`, `CryptoService`, `AiServiceHelper`) | Unit | Verify transformation and parsing logic; mock HTTP calls |
| Key Vault (`KeyVaultService` via `IKeyVaultService`) | Unit | Verify secret-name contracts, rotation behaviour, and constructor guards; mock `IKeyVaultService` — no live Key Vault connection |
| Sender plugins (`XSender`, `InSender`, `IgSender`) | Unit | Verify request construction and error handling; mock the underlying API client and `IKeyVaultService` |
| `GeneratorFactory` | Unit | Verify correct generator selection per hour |
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

## 3. Naming Conventions

### Test files

One test file per production class, mirroring the `src/` directory structure:

```
tests/
├── Abstraction/                     # tests for src/Abstraction/
├── Helpers/                         # shared test helpers (e.g. ResilienceTestHelpers)
├── Implementation/                  # tests for src/Implementation/ (FeedGenerator, PowerLawGenerator, GeneratorFactory…)
├── Integration/                     # Polly resilience pipeline integration tests (not in CI)
│   ├── PollyIntegrationTestBase.cs
│   ├── LinkedInResiliencePipelineTests.cs
│   ├── InstagramResiliencePipelineTests.cs
│   ├── AiClientsResiliencePipelineTests.cs
│   └── CaptureLoggerProvider.cs
├── Models/                          # tests for src/Models/
├── SenderPlugins/                   # tests for src/SenderPlugins/ (XSender, InSender, IgSender…)
├── Services/                        # tests for src/Services/ (OpenAiService, AzureFoundryService, KeyVaultService…)
├── XFunctionMissingBranchTests.cs
├── XFunctionTests.cs
└── XPoster.Tests.csproj
```

The `tests/` directory is itself the test project root. Mirror the folder name from `src/` — e.g., new tests for `src/Services/KeyVaultService.cs` go in `tests/Services/KeyVaultServiceTests.cs`.

### Test method names

Follow the `MethodName_Condition_ExpectedResult` pattern:

```csharp
// ✅ Good
public async Task GenerateAsync_WhenAiServiceReturnsEmptySummary_ReturnsNull()
public async Task SendAsync_WhenTwitterApiThrows_ReturnsFalse()
public void SelectGenerator_AtHour06_ReturnsInSummaryFeedGenerator()

// ❌ Avoid
public async Task TestGenerate()
public async Task SendTest2()
```

---

## 4. Running Tests Locally

### All tests

```bash
dotnet test
```

### Filter by category

```bash
# Only unit tests (excludes integration)
dotnet test --filter "Category!=Integration"

# Only a specific class
dotnet test --filter "FullyQualifiedName~FeedGenerator"
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

## 5. Mocking External Services

All external dependencies (`IAiService`, `IFeedService`, `ISender`, `IKeyVaultService`, `ILogger`) are injected via constructor and replaced with Moq mocks in tests.

### Pattern — mocking `IAiService`

```csharp
[Fact]
public async Task GenerateAsync_WhenAiReturnsValidSummary_PostContentIsSet()
{
    // Arrange
    var mockAi = new Mock<IAiService>();
    mockAi
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
        .ReturnsAsync("BTC breaks ATH driven by ETF inflows");

    var mockSender  = new Mock<ISender>();
    var mockLogger  = new Mock<ILogger<FeedGenerator>>();
    var mockFeed    = new Mock<IFeedService>();
    mockFeed
        .Setup(x => x.GetLatestItemAsync())
        .ReturnsAsync(new FeedItem { Title = "BTC News", Content = "..." });

    var generator = new FeedGenerator(mockSender.Object, mockLogger.Object,
                                       mockFeed.Object, mockAi.Object);

    // Act
    var post = await generator.GenerateAsync();

    // Assert
    Assert.NotNull(post);
    Assert.Contains("BTC breaks ATH", post.Content);
    mockAi.Verify(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
}
```

### Pattern — mocking `ISender` to verify call

```csharp
[Fact]
public async Task GenerateAsync_WhenPostIsValid_CallsSendAsync()
{
    var mockSender = new Mock<ISender>();
    mockSender.Setup(x => x.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

    // ... build generator with mockSender ...

    await generator.GenerateAsync();

    mockSender.Verify(x => x.SendAsync(It.IsAny<Post>()), Times.Once);
}
```

---

## 6. Adding New Tests — Checklist

When adding a new feature or fixing a bug, follow this checklist before opening a PR:

- [ ] Create (or update) the corresponding `*Tests.cs` file in the mirrored directory
- [ ] Each public method has at least one **happy path** test and one **error/edge case** test
- [ ] All external dependencies are mocked — no real HTTP calls or API keys in unit tests
- [ ] Test method names follow the `MethodName_Condition_ExpectedResult` pattern
- [ ] Run `dotnet test` locally — all tests pass
- [ ] Run coverage and confirm the changed class is above the 80% threshold
- [ ] Link the test file in the PR description

---

## 7. Coverage Target

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
