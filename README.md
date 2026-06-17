# XPoster 🚀

[![Azure Functions](https://img.shields.io/badge/Azure%20Functions-v4-0062AD?logo=azurefunctions&logoColor=white)](https://azure.microsoft.com/en-us/services/functions/)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![AI Powered](https://img.shields.io/badge/AI-Powered-412991?logo=openai&logoColor=white)](https://azure.microsoft.com/en-us/products/ai-services/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Deployment](https://img.shields.io/badge/Deployed-Azure-blue)](https://xposterfunction.azurewebsites.net/)
[![Build and Deploy](https://github.com/artcava/XPoster/actions/workflows/ci.yml/badge.svg)](https://github.com/artcava/XPoster/actions/workflows/ci.yml)

> **AI-Powered Social Media Automation Platform**
> 
> XPoster is an Azure Function that automates content publishing across multiple social media platforms (Twitter/X, LinkedIn, Instagram) using artificial intelligence for content generation and curation.

---

## 📋 Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Deployment](#deployment)
- [Usage](#usage)
- [Scheduling](#scheduling)
- [Extensibility](#extensibility)
- [Testing](#testing)
- [Monitoring](#monitoring)
- [Roadmap](#roadmap)
- [Author](#author)

> 📐 For a deep-dive into architectural decisions, design patterns, ADRs, and extension contracts, see [docs/architecture.md](docs/architecture.md).

---

## Features

### 🤖 Content Generation
- **AI-Powered Summarization**: Intelligent RSS feed summaries via a configurable AI model of your choice
- **Image Generation**: Automatic contextual image creation using any supported image generation model
- **Smart Hashtags**: Automatic keyword conversion to optimized hashtags
- **Multi-Strategy**: Support for different content orchestration algorithms
- **Provider Agnostic**: The AI provider (e.g. OpenAI, Azure AI Foundry) and the specific model are selected by the operator through configuration — no code change required to swap models

### 🌐 Multi-Platform Publishing
- **Twitter/X**: Automated posting with image support
- **LinkedIn**: Posts on personal profiles and company pages
- **Instagram**: Publishing via Graph API (in development)

### ⚙️ Automation & Scheduling
- **Timer-Based Execution**: Configurable automatic execution
- **Smart Scheduling**: Different posting strategies based on time
- **Conditional Logic**: Publishing only when appropriate
- **Flexible Configuration**: Customizable schedule via environment variables

### 📊 Enterprise Features
- **Application Insights**: Complete monitoring and telemetry
- **Structured Logging**: Detailed logs for debugging and audit
- **Error Handling**: Robust error management with retry logic
- **Dependency Injection**: Modular and testable architecture

---

## Architecture

XPoster is a **serverless, event-driven pipeline** built on four structural pillars:

- **`XFunction`** — the Azure Timer Trigger entry point; it owns no business logic and drives the pipeline by calling `Resolve()` then `OrchestrateAsync()`
- **`OrchestratorFactory`** — maps the current UTC hour to a `ScheduledOrchestrationProfile` via `Resolve()`, selecting the right content strategy and sender for that slot (Strategy + Factory patterns)
- **Orchestrators** (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) — each encapsulates a self-contained content-production algorithm; orchestrators depend exclusively on injected abstractions and are unaware of target platforms
- **Sender Plugins** (`XSender`, `InSender`, `IgSender`, `DryRunSender`) — implement `ISender` to isolate all platform-specific API communication; adding a new platform requires zero changes to existing components

The AI layer is abstracted behind `IAiService` and resolved at runtime by `AiServiceFactory`, enabling per-slot provider assignment and global override via configuration without touching orchestrator code.

Secret resolution for platform tokens is handled by **`KeyVaultService`** (`IKeyVaultService`), which wraps `Azure.Security.KeyVault.Secrets` and is consumed by sender plugins at runtime to retrieve OAuth credentials from Azure Key Vault.

```
┌────────────────────────────┐
│   Azure Timer Trigger      │
│   (configurable schedule)  │
└───────────┬────────────────┘
            │
            ▼
┌────────────────────────────┐
│   OrchestratorFactory      │ ◄─── Strategy Pattern
│   (ISlotProfileProvider)   │
└───────────┬────────────────┘
            │
    ┌───────┴────────┬──────────────┐
    ▼                ▼              ▼
┌──────────────┐   ┌──────────────┐   ┌──────────────┐
│     Feed     │   │  PowerLaw    │   │      No      │
│ Orchestrator │   │ Orchestrator │   │ Orchestrator │
└─────┬────────┘   └─────┬────────┘   └──────────────┘
      │                  │
      └──────┬───────────┘
             │
             ▼
    ┌────────────────────┐
    │   Services         │
    ├────────────────────┤
    │ • AiServiceFactory │ ◄─── Resolves IAiService by AiProvider
    │ • AiServiceHelper  │ ◄─── HTTP response parsing / 429 handling
    │ • Feed Service     │ ◄─── RSS Parser
    │ • Crypto Service   │ ◄─── CryptoPrices HTTP client
    │ • KeyVaultService  │ ◄─── Azure Key Vault secret resolution
    └────────┬───────────┘
             │
             ▼
    ┌────────────────────┐
    │ Sender Plugins     │
    ├────────────────────┤
    │ • XSender          │ ◄─── Twitter/X API
    │ • InSender         │ ◄─── LinkedIn API
    │ • IgSender         │ ◄─── Instagram API
    │ • DryRunSender     │ ◄─── Local testing only (no outbound API calls)
    └────────────────────┘
```

> 📐 For the full architectural rationale, component responsibilities, design patterns (Strategy, Factory, Plugin, Abstract Factory), ADRs, extension contracts, and the end-to-end Mermaid sequence diagram, see **[docs/architecture.md](docs/architecture.md)**.

> 🤖 For AI-assisted development, an auto-generated code graph is available at [`docs/agent-graph/`](docs/agent-graph/). See [docs/agent-graph.md](docs/agent-graph.md) for usage.

---

## Technologies

### Core Framework

| Package | Version | Role |
|---------|---------|------|
| **.NET** | 8.0 | Target framework (isolated worker model) |
| **Azure Functions** | v4 | Serverless compute host |
| **C#** | 12 | Programming language |
| `Microsoft.Azure.Functions.Worker` | 2.2.0 | Isolated worker SDK |
| `Microsoft.Azure.Functions.Worker.Sdk` | 2.0.6 | Build-time analyzer |
| `Microsoft.Azure.Functions.Worker.Extensions.Timer` | 4.3.1 | Timer trigger support |
| `Microsoft.Azure.Functions.Worker.Extensions.Storage.Blobs` | 6.8.0 | Blob storage bindings |

### AI & ML

The AI layer is built on **Microsoft.Extensions.AI**, the provider-agnostic abstraction for .NET AI services. Each AI provider is registered as a keyed `IAiService` in the DI container and resolved at runtime by `AiServiceFactory` based on the `AiProvider` enum value set on each `ScheduledOrchestrationProfile`.

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Extensions.AI` | 10.6.0 | Provider-agnostic AI abstraction (chat + embeddings) |
| `Microsoft.Extensions.AI.OpenAI` | 10.6.0 | OpenAI/Azure OpenAI bridge for `Microsoft.Extensions.AI` |
| `Azure.AI.OpenAI` | 2.1.0 | Azure OpenAI REST client (used by `OpenAiService` and `AzureFoundryService`) |
| `Azure.Identity` | 1.13.2 | Managed Identity / `DefaultAzureCredential` support |

**Supported AI providers at runtime:**

| `AiProvider` enum value | Concrete service | Text backend | Image backend |
|-------------------------|-----------------|--------------|---------------|
| `OpenAi` | `OpenAiService` | Azure OpenAI / OpenAI-compatible endpoint | Same endpoint (e.g. `dall-e-3`, `gpt-image-1`) |
| `AzureFoundry` | `AzureFoundryService` | Azure AI Foundry deployment | Azure AI Foundry deployment |
| `DeepSeekWithFal` | `HybridAiService` | `DeepSeekService` → DeepSeek API | `FalAiImageService` → fal.ai FLUX.2 Turbo |

> ℹ️ `DeepSeekService` and `FalAiImageService` are independent services, each with their own registration and test coverage. `HybridAiService` composes the two, delegating text requests to `DeepSeekService` and image requests to `FalAiImageService`. This composition is transparent to orchestrators, which always program to `IAiService`.

### Social Media APIs

| Library / API | Version | Platform |
|---------------|---------|----------|
| `LinqToTwitter` | 6.15.0 | Twitter/X — OAuth 1.0a wrapper |
| LinkedIn REST API | v2 | LinkedIn — direct HTTP calls via `IHttpClientFactory` |
| Instagram Graph API | v21+ | Instagram — direct HTTP calls (in development) |

### Monitoring & Observability

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Azure.Functions.Worker.ApplicationInsights` | 2.0.0 | Auto-wires Application Insights for the isolated worker |
| `Microsoft.ApplicationInsights.WorkerService` | 2.23.0 | Telemetry pipeline for background services |
| `ILogger<T>` | (built-in) | Structured logging via `Microsoft.Extensions.Logging` |

### Utilities & Security

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Extensions.Http.Resilience` | 9.1.0 | Retry / resilience pipelines for outbound HTTP clients (`IHttpClientFactory`) |
| `System.Text.Json` | 10.0.8 | JSON serialization / deserialization |
| `Azure.Security.KeyVault.Secrets` | 4.7.0 | Azure Key Vault secret retrieval (used by `KeyVaultService`) |
| `Microsoft.AspNetCore.App` (framework ref) | 8.0 | ASP.NET Core primitives used by the Functions host |

> ℹ️ `Microsoft.Extensions.Http` is resolved transitively and is not pinned explicitly in the project file to avoid NU1603 version conflicts.

---

## Getting Started

### Prerequisites

- **.NET 8.0 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Visual Studio Code** ([Download](https://code.visualstudio.com/download))
- **Azure Functions Core Tools** ([Install](https://docs.microsoft.com/azure/azure-functions/functions-run-local))
- **Azure Account** (with active subscription)
- **AI Provider API access**: An endpoint and API key for at least one of the supported AI providers listed below

#### Supported AI Providers

| Provider | Website | Capabilities | Setup Guide |
|----------|---------|--------------|-------------|
| **Azure AI Foundry** | [azure.microsoft.com/ai-foundry](https://azure.microsoft.com/en-us/products/ai-foundry/) | Text + Image | [docs/integrations/setup-azure-foundry.md](docs/integrations/setup-azure-foundry.md) |
| **OpenAI** | [platform.openai.com](https://platform.openai.com/) | Text + Image | [docs/integrations/setup-openai.md](docs/integrations/setup-openai.md) |
| **DeepSeek** | [platform.deepseek.com](https://platform.deepseek.com/) | Text only | [docs/integrations/setup-deepseek.md](docs/integrations/setup-deepseek.md) |
| **fal.ai** | [fal.ai](https://fal.ai/) | Image only | [docs/integrations/setup-falai.md](docs/integrations/setup-falai.md) |

> ℹ️ **DeepSeek** and **fal.ai** are used together as the `HybridAiService` — DeepSeek handles text generation and fal.ai handles image generation. See [docs/architecture.md](docs/architecture.md) for details.
>
> ⚠️ The setup guides above are present and cover account creation, API key configuration, and troubleshooting. Some validation tasks (model names, key naming, SDK version checks) are tracked in issues [#130](https://github.com/artcava/XPoster/issues/130), [#131](https://github.com/artcava/XPoster/issues/131), and [#132](https://github.com/artcava/XPoster/issues/132) and will be completed before the next stable release.

### Clone the Repository

```bash
git clone https://github.com/artcava/XPoster.git
cd XPoster
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Project

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Configure Local Settings

A template file with all required keys and inline documentation is versioned at [`src/local.settings.json.example`](src/local.settings.json.example).

Copy it and fill in your credentials before running the function locally:

```bash
cp src/local.settings.json.example src/local.settings.json
```

Then open `src/local.settings.json` and replace every empty string `""` with the actual value for each service. See the [Configuration](#configuration) section for details on where to obtain each credential.

> ⚠️ `local.settings.json` is listed in `.gitignore` and will **never** be committed. The `.example` variant is safe to version because it contains no real secrets.

> 📖 For the full expanded setup guide with troubleshooting tips, see [docs/getting-started.md](docs/getting-started.md).

---

## Configuration

All configuration is driven by environment variables — there is no application-level config file to edit directly.

- **Locally**: copy [`src/local.settings.json.example`](src/local.settings.json.example) to `src/local.settings.json` and fill in your values.
- **On Azure**: add the same variables as Application Settings (**Azure Portal → Function App → Configuration**).

Platform OAuth credentials (Twitter/X, LinkedIn, Instagram) are **not** stored as environment variables. They are resolved at runtime by `KeyVaultService` directly from **Azure Key Vault**, using `DefaultAzureCredential` — which picks up your `az login` session locally and the Function App's Managed Identity in production.

> 📖 Full reference — variable names, types, defaults, allowed values, Key Vault secret names, and a step-by-step `DryRunSender` local-testing guide: **[docs/configuration.md](docs/configuration.md)**.

---

## Deployment

Three deployment methods are supported. **GitHub Actions (Option 1) is recommended for production** — the repository ships with a ready-to-use workflow at `.github/workflows/ci.yml`.

| Option | Best for |
|---|---|
| **1. GitHub Actions** | Production — automated CI/CD on every push to `master` |
| **2. Azure CLI** | Scripted / IaC provisioning, staging environments |
| **3. Visual Studio Code** | One-off deploys during early development |

### Branching Strategy

| Branch | Purpose |
|---|---|
| `develop` | Active development branch — all feature and fix work targets here |
| `master` | Production branch — holds the deployable state currently running on Azure; the CI/CD workflow deploys on every push to `master` |

Work is developed on `develop` (or short-lived feature branches off it) and promoted to `master` when ready for release. The GitHub Actions workflow is scoped to `master` and does not trigger on `develop` pushes.

### Quick Start: GitHub Actions

1. Create a **Function App** in Azure Portal (Runtime: `.NET 8 Isolated`, Plan: Consumption)
2. In Azure Portal, register an **App Registration** and configure federated credentials for GitHub Actions
3. Add the following secrets to your GitHub repository (Settings → Secrets and variables → Actions):
   - `AZUREAPPSERVICE_CLIENTID` — App Registration client ID
   - `AZUREAPPSERVICE_TENANTID` — Azure tenant ID
   - `AZUREAPPSERVICE_SUBSCRIPTIONID` — Azure subscription ID
4. Push to `master` — the workflow triggers automatically

> 📖 Full setup steps for all three options, post-deployment checklist, and Managed Identity configuration: **[docs/deployment.md](docs/deployment.md)**.

---

## Usage

### Local Execution

```bash
cd src
func start
```

The function will run locally according to the configured cron expression.

### Manual Trigger (Azure Portal)

1. Go to **Azure Portal** → **Function App** → **Functions**
2. Select `XPosterFunction`
3. Click **Test/Run**
4. Click **Run**

### HTTP Trigger (Optional)

Add an HTTP trigger for testing:

```csharp
[Function("XPosterHttpTrigger")]
public async Task<HttpResponseData> RunHttp(
    [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
{
    await Run(null);
    var response = req.CreateResponse(HttpStatusCode.OK);
    await response.WriteStringAsync("XPoster executed successfully");
    return response;
}
```

---

## Scheduling

### Schedule Configuration

The execution frequency is configurable via the `CronSchedule` environment variable:

**Format**: 6-field cron expression: `{second} {minute} {hour} {day} {month} {dayOfWeek}`

**Configuration**:

```json
// local.settings.json
{
  "Values": {
    "CronSchedule": "0 0 6,8,14,16 * * *"
  }
}
```

```bash
# Azure CLI
az functionapp config appsettings set \
  --name xposterfunction \
  --resource-group XPosterRG \
  --settings "CronSchedule=0 0 6,8,14,16 * * *"
```

### Cron Expression Examples

| Schedule | Cron Expression | Description |
|----------|-----------------|-------------|
| **Default** | `0 0 6,8,14,16 * * *` | Production slots: 6, 8, 14, 16 UTC |
| **Hourly** | `0 0 * * * *` | Every hour on the hour |
| **Every 4 hours** | `0 0 */4 * * *` | Every 4 hours |
| **Business Hours** | `0 0 9,12,15,18 * * 1-5` | 9, 12, 15, 18 (Mon-Fri) |
| **Morning/Evening** | `0 0 8,20 * * *` | At 8:00 and 20:00 |
| **Daily** | `0 0 9 * * *` | Every day at 9:00 |
| **Quick Test** | `*/30 * * * * *` | Every 30 seconds (dev only) |

### Time-based Strategy (ISlotProfileProvider)

The production schedule is defined in `DefaultSlotProfileProvider`, which returns four fixed profiles:

| UTC Hour | Sender | Orchestrator | AI Provider |
|----------|--------|--------------|-------------|
| 6 | `InSummaryFeed` | `FeedOrchestrator` | OpenAi |
| 8 | `XSummaryFeed` | `FeedOrchestrator` | OpenAi |
| 14 | `InPowerLaw` | `PowerLawOrchestrator` | *(default)* |
| 16 | `XPowerLaw` | `PowerLawOrchestrator` | *(default)* |

`OrchestratorFactory` no longer owns a static list of profiles. It receives an `ISlotProfileProvider` via constructor injection and calls `GetProfiles()` at resolution time — making the schedule a swappable dependency rather than embedded logic.

### Dry-Run Testing (Local)

To run the full pipeline locally without publishing to any social platform, activate the `DryRunSlotProfileProvider` via two environment variables — **no code changes required**:

```json
// local.settings.json
{
  "Values": {
    "EnableDryRunSlot": "true",
    "ForceHour": "9"
  }
}
```

| Key | Value | Effect |
|-----|-------|--------|
| `EnableDryRunSlot` | `true` | Registers `DryRunSlotProfileProvider` in DI, which decorates `DefaultSlotProfileProvider` and appends a `DryRunSend` entry at hour 9 |
| `ForceHour` | `9` | Overrides the UTC clock so `OrchestratorFactory` selects the dry-run slot at startup |

`DryRunSender` will probe Key Vault connectivity (reads the `XApiKey` secret), log the generated post content (character count + full text and image presence), and return `true` — without calling any social platform API.

> ⚠️ `EnableDryRunSlot` defaults to `false`. In production this key must be absent or explicitly set to `"false"`. Hour 9 is **never** part of the production schedule.

---

### Best Practices

✅ **Testing**: Use frequent schedules in development (`*/5 * * * * *` = every 5 secs)
✅ **Production**: More conservative schedules to avoid rate limiting
✅ **Multi-environment**: Different schedules for Dev/Staging/Prod
✅ **Monitoring**: Check logs to confirm execution

---

## Extensibility

XPoster is designed with explicit extension points that allow new capabilities to be added without modifying core logic. The table below lists what is extensible, and why each point was designed that way.

| Extension point | How to extend | Rationale |
|---|---|---|
| **Sender Plugins** (`ISender`) | Implement `ISender`, register in DI, add an enum value to `MessageSender`, configure a `ScheduledOrchestrationProfile` | Platform-specific code is fully isolated behind a single interface, so adding a new social network has zero impact on orchestrators or scheduling |
| **Content Orchestrators** (`BaseOrchestrator`) | Subclass `BaseOrchestrator`, override `OrchestrateAsync()`, register in `OrchestratorFactory` | The Strategy pattern in `OrchestratorFactory` decouples content logic from scheduling, making it safe to introduce new content strategies independently |
| **AI Providers** (`IAiService`) | Implement `IAiService`, register as a keyed service in DI, add an `AiProvider` enum value | All orchestrators depend only on `IAiService`, so swapping or adding a provider requires no changes outside the service layer and `Program.cs` |
| **Scheduling profiles** (`ISlotProfileProvider`) | Implement `ISlotProfileProvider` (or subclass `DryRunSlotProfileProvider` as a decorator) and register it in `Program.cs` | The schedule is a swappable dependency injected into `OrchestratorFactory` — operators can alter or extend the slot list without touching factory or orchestrator code |

> 📖 For step-by-step implementation guides, code contracts, design constraints, and worked examples for each extension point, see **[docs/extending-xposter.md](docs/extending-xposter.md)**.

---

## Testing

### Test Structure

```
tests/
├── XPoster.Tests.csproj
├── XFunctionTests.cs
├── XFunctionMissingBranchTests.cs
├── Abstraction/
│   └── BaseOrchestratorTests.cs
├── Helpers/
│   └── ResilienceTestHelpers.cs
├── Implementation/
│   ├── AiServiceFactoryTests.cs
│   ├── FeedOrchestratorTests.cs
│   ├── OrchestratorFactoryTests.cs
│   ├── NoOrchestratorTests.cs
│   ├── PowerLawOrchestratorTests.cs
│   └── SlotProfileProviderTests.cs
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
    └── TimeProviderTests.cs
```

| Folder | What is covered |
|---|---|
| *(root)* | `XFunction` entry point — happy path and missing-branch edge cases |
| `Abstraction/` | `BaseOrchestrator` abstract class contracts |
| `Helpers/` | Shared test utilities for resilience and HTTP mock setup (`ResilienceTestHelpers`) |
| `Implementation/` | `FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`, `AiServiceFactory` resolution logic; `OrchestratorFactory` using synthetic `ISlotProfileProvider` mocks; `DefaultSlotProfileProvider` and `DryRunSlotProfileProvider` provider behaviour (`SlotProfileProviderTests.cs`) |
| `Integration/` | Polly resilience pipeline integration tests (retry, circuit-breaker, attempt-timeout) — not run in CI |
| `Models/` | Domain model invariants, `Post` and `RSSFeed` missing-branch cases, options validators for OpenAI, Azure Foundry, DeepSeek, and fal.ai |
| `SenderPlugins/` | `XSender` and `InSender` (happy path, `SendAsync`, missing-branch, resilience); `IgSender` (happy path, resilience); `DryRunSender` (null guard, Key Vault probe, dry-run success/failure paths) |
| `Services/` | `OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `FalAiImageService`, `HybridAiService`, `AiServiceHelper`, `CryptoService`, `FeedService`, `TimeProvider`, and `KeyVaultService` unit tests |

### Running Tests

```bash
# All tests
dotnet test

# Specific tests
dotnet test --filter "FullyQualifiedName~FeedOrchestrator"

# With coverage (exclusions defined in coverlet.runsettings at repo root)
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
```

> 📖 Full testing strategy, mocking patterns, and coverage goals: [tests/README.md](tests/README.md).

### Mocking External Services

```csharp
[Fact]
public async Task FeedOrchestrator_ShouldGenerateSummary()
{
    // Arrange
    var mockAiService = new Mock<IAiService>();
    mockAiService
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
        .ReturnsAsync("Test summary");

    var orchestrator = new FeedOrchestrator(
        mockSender.Object,
        mockLogger.Object,
        mockFeedService.Object,
        mockAiService.Object
    );

    // Act
    var result = await orchestrator.OrchestrateAsync();

    // Assert
    Assert.NotNull(result);
    Assert.Contains("Test summary", result.Content);
}
```

---

## Monitoring

XPoster uses **Azure Application Insights** for full-stack observability: telemetry collection, structured logging via `ILogger<T>`, dependency tracking, and alerting.

Application Insights is activated automatically when the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable is present — no additional SDK code is required beyond the two registration calls already in `Program.cs`.

Key monitoring capabilities at a glance:
- **Execution tracking**: every `XPosterFunction` invocation appears as a `request` in Application Insights
- **Dependency tracing**: outbound HTTP calls to AI providers, social media APIs, and `cryptoprices.cc` are captured as `dependencies`
- **Structured logging**: all `ILogger<T>` calls flow to the `traces` table with full custom dimensions
- **Alerting**: recommended rules cover consecutive errors, high latency, token budget, and function downtime

> 📖 Full setup (resource creation, connection string, `Program.cs` wiring, KQL queries, alert rules, Bicep IaC, and live debugging): **[docs/monitoring.md](docs/monitoring.md)**.

---

## Roadmap

### ✅ Phase 1: Foundation (Complete)
- [x] Azure Function setup
- [x] Multi-platform sender architecture
- [x] AI integration (configurable provider and model)
- [x] Twitter/X publishing
- [x] LinkedIn publishing
- [x] RSS feed parsing
- [x] CI/CD pipeline

### 🚧 Phase 2: Stabilization (In Progress)
- [x] Configuration externalization
- [x] AI provider expansion
- [x] Retry & resilience for external HTTP calls [Issue #133](https://github.com/artcava/XPoster/issues/133)
- [ ] Extension-point refactoring — ADR-005 status: **Proposed** — implementation tracked in [Issue #134](https://github.com/artcava/XPoster/issues/134)
- [x] Test coverage gate at 80%

### 🎨 Phase 3: Admin Dashboard (TBD)
- [ ] Web based UI
- [ ] Real-time analytics
- [ ] Manual post scheduling
- [ ] Content calendar
- [ ] Performance metrics
- [ ] Mobile app (MAUI)

### 🧠 Phase 4: Intelligence & Engagement (TBD)
- [ ] **Post performance metrics collection** (impressions, reach, engagement rate per platform)
- [ ] **Adaptive scheduling** (recalibrate posting time slots based on collected engagement data)
- [ ] **A/B content testing** (generate prompt variants and track which strategy performs best)
- [ ] **Semantic post tagging** (structured labelling of published content to feed the analytics layer)
- [ ] **AI-driven comment and reaction handling** (autonomous agent trained on human interaction patterns)
- [ ] **AI performance analysis** (periodic review of metrics to propose improvements to content style and pipeline strategy)

---

## Author

**Marco Cavallo**

- 🌐 Website: [xposter.artcava.net](https://xposter.artcava.net)
- 💼 LinkedIn: [Marco Cavallo](https://linkedin.com/in/artcava)
- 🐦 Twitter: [@artcava](https://twitter.com/artcava)
- 📧 Email: cavallo.marco@gmail.com
- 🏢 Location: Turin, Italy

---

## Acknowledgments

- [Azure Functions](https://azure.microsoft.com/services/functions/) - Serverless platform
- [OpenAI](https://openai.com/) - AI models
- [Azure AI Foundry](https://azure.microsoft.com/en-us/products/ai-foundry/) - Alternative AI provider
- [DeepSeek](https://www.deepseek.com/) - Cost-effective text generation
- [fal.ai](https://fal.ai/) - FLUX.2 Turbo image generation
- [LinqToTwitter](https://github.com/JoeMayo/LinqToTwitter) - Twitter API wrapper
- [.NET Foundation](https://dotnetfoundation.org/) - Framework and community

---

## Support

- **Issues**: [GitHub Issues](https://github.com/artcava/XPoster/issues)
- **Discussions**: [GitHub Discussions](https://github.com/artcava/XPoster/discussions)
- **Linkedin**: [XPoster Page](https://www.linkedin.com/showcase/xposter)
- **Email**: cavallo.marco@gmail.com

---

## Star History

If you find this project useful, consider leaving a ⭐ on GitHub!

[![Star History Chart](https://api.star-history.com/svg?repos=artcava/XPoster&type=Date)](https://star-history.com/#artcava/XPoster&Date)

---

<div align="center">

**Made with ❤️ in Turin, Italy**

[🏠 Homepage](https://xposter.artcava.net/) • 
[📖 Documentation](docs/index.md) • 
[🐛 Report Bug](https://github.com/artcava/XPoster/issues) • 
[💡 Request Feature](https://github.com/artcava/XPoster/issues)

</div>
