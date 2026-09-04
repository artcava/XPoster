# XPoster 🚀

[![Azure Functions](https://img.shields.io/badge/Azure%20Functions-v4-0062AD?logo=azurefunctions&logoColor=white)](https://azure.microsoft.com/en-us/services/functions/)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![AI Powered](https://img.shields.io/badge/AI-Powered-412991?logo=openai&logoColor=white)](https://azure.microsoft.com/en-us/products/ai-services/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Deployment](https://img.shields.io/badge/Deployed-Azure-blue)](https://xposterfunction.azurewebsites.net/)
[![Build and Deploy](https://github.com/artcava/XPoster/actions/workflows/ci.yml/badge.svg)](https://github.com/artcava/XPoster/actions/workflows/ci.yml)

> **AI-Powered Social Media Automation Platform**
> 
> XPoster is an Azure Function that automates content publishing across multiple social media platforms (Twitter/X, LinkedIn, Instagram, Facebook) using artificial intelligence for content generation and curation.

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

---

## Features

### 🤖 Content Generation
- **AI-Powered Summarization**: Intelligent RSS feed summaries via a configurable AI model of your choice
- **Image Generation**: Automatic contextual image creation using any supported image generation model
- **Smart Hashtags**: Automatic keyword-to-hashtag conversion driven by a configurable replacement map (`TagReplacementOptions`) — no redeployment required to change the hashtag set
- **Multi-Strategy**: Config-driven content workflows (DAG nodes) — e.g. RSS news summarisation, Bitcoin Power Law posts — scheduled per hour with no code change
- **Provider Agnostic**: The AI provider (e.g. OpenAI, Azure AI Foundry) and the specific model are selected by the operator through configuration — no code change required to swap models

### 🌐 Multi-Platform Publishing
- **Twitter/X**: Automated posting with image support
- **LinkedIn**: Posts on personal profiles and company pages
- **Instagram**: Publishing via Graph API
- **Facebook**: Publishing via Graph API
- **Multi-Platform Fan-Out**: A single scheduled slot can publish to multiple platforms simultaneously. The base summary and image are generated once; per-platform re-summarisation is applied only when needed, reducing AI token and image credit consumption by up to ~67% compared to separate slots.

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

XPoster is a **serverless, event-driven pipeline** that runs on a timer, selects a workflow for the current hour from the configuration-driven schedule, executes its node DAG (optionally using AI), and publishes the resulting posts to one or more platforms via pluggable sender components.

> 📐 For the full architectural rationale, component responsibilities, design patterns (Strategy, Factory, Plugin), ADRs, extension contracts, and the end-to-end Mermaid sequence diagram, see **[docs/architecture.md](docs/architecture.md)**.

> 🤖 For AI-assisted development, an auto-generated code graph is available at [`docs/agent-graph/`](docs/agent-graph/). See [docs/agent-graph.md](docs/agent-graph.md) for usage.

---

## Technologies

### Core Framework

| Package | Version | Role |
|---------|---------|------|
| **.NET** | 10.0 | Target framework (isolated worker model) |
| **Azure Functions** | v4 | Serverless compute host |
| **C#** | 14 | Programming language |
| `Microsoft.Azure.Functions.Worker` | 2.52.0 | Isolated worker SDK |
| `Microsoft.Azure.Functions.Worker.Sdk` | 2.0.7 | Build-time analyzer |
| `Microsoft.Azure.Functions.Worker.Extensions.Timer` | 4.3.1 | Timer trigger support |
| `Microsoft.Azure.Functions.Worker.Extensions.Storage.Blobs` | 6.8.1 | Blob storage bindings |

### AI & ML

The AI layer uses two capability interfaces — `ITextToTextProvider` (text summarisation + image prompt generation) and `ITextToImageProvider` (image generation) — registered as **keyed services** in the DI container, keyed by `AiProvider` enum value. Providers are selected at **workflow-node level**: each `AiText` / `AiImage` node names its provider via the `Provider` parameter, so a single workflow can mix different providers per step (e.g. DeepSeek for text, FalAi for image) — entirely through configuration. Node inputs/outputs are wired via explicit keyed references in the config; the keyed service falls back to `null` when a capability is unsupported and the node degrades gracefully (e.g. `AiImage` with `Required: false` publishes a text-only post).

Shared AI utility logic is centralised in **`AiServiceHelper`**, which exposes the following static methods used by all AI provider implementations:

| Method | Description |
|--------|-------------|
| `BuildChatPayload(string text, PromptRequest request, string modelName)` | Builds the chat completion request payload — interpolates `{MaxChars}` in the system prompt, substitutes the input text label in the user prompt, and assembles the `model`, `messages`, `max_tokens`, and `temperature` fields. The `modelName` parameter is supplied by each provider from its own options, keeping provider-specific config out of the helper. |
| `ParseChatCompletionResponseAsync(HttpResponseMessage response, string providerName, string operationName, ILogger logger, CancellationToken ct)` | Deserialises the chat completion HTTP response and extracts the generated text content, returning `(bool Success, string Content)`. |
| `ParseImageResponseAsync(HttpResponseMessage response, AiProvider provider, HttpClient httpClient, ILogger logger, string? allowedOrigin, CancellationToken ct)` | Deserialises the image generation HTTP response, extracts the image bytes (base64 payload or downloaded URL, with origin validation), and returns `byte[]`. |

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Extensions.AI` | 10.7.0 | Provider-agnostic AI abstraction (chat + embeddings) |
| `Microsoft.Extensions.AI.OpenAI` | 10.7.0 | OpenAI/Azure OpenAI bridge for `Microsoft.Extensions.AI` |
| `Azure.AI.OpenAI` | 2.1.0 | Azure OpenAI REST client |
| `Azure.Identity` | 1.21.0 | Managed Identity / `DefaultAzureCredential` support |

**Supported AI providers at runtime:**

| `AiProvider` value | `ITextToTextProvider` | `ITextToImageProvider` | Notes |
|---|---|---|---|
| `OpenAi` | ✅ `OpenAiService` | ✅ `OpenAiService` | Full text + image |
| `AzureFoundry` | ✅ `AzureFoundryService` | ✅ `AzureFoundryService` | Full text + image |
| `DeepSeek` | ✅ `DeepSeekService` | ❌ | Text only — workflows without an image node publish text-only posts |
| `Perplexity` | ✅ `PerplexityService` | ❌ | Text only — workflows without an image node publish text-only posts |
| `FalAi` | ❌ | ✅ `FalAiImageService` | Image only — valid in `AiImage` nodes; the workflow must not require text output, or the text node must be optional (`Required: false`) |

### Social Media APIs

| Library / API | Version | Platform |
|---------------|---------|----------|
| `LinqToTwitter` | 6.15.0 | Twitter/X — OAuth 1.0a wrapper |
| LinkedIn REST API | v2 | LinkedIn — direct HTTP calls via `IHttpClientFactory` |
| Graph API (Meta) | v23.0 | Instagram + Facebook — direct HTTP calls; async container flow for Instagram |

### Monitoring & Observability

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Azure.Functions.Worker.ApplicationInsights` | 2.51.0 | Auto-wires Application Insights for the isolated worker |
| `Microsoft.ApplicationInsights.WorkerService` | 2.23.0 | Telemetry pipeline for background services |
| `ILogger<T>` | (built-in) | Structured logging via `Microsoft.Extensions.Logging` |

### Utilities & Security

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Extensions.Http.Resilience` | 10.7.0 | Retry / resilience pipelines for outbound HTTP clients (`IHttpClientFactory`) |
| `Azure.Extensions.AspNetCore.Configuration.Secrets` | 1.5.1 | Azure Key Vault Configuration Provider (startup secret loading) |
| `Microsoft.AspNetCore.App` (framework ref) | 10.0 | ASP.NET Core primitives used by the Functions host |
| `SkiaSharp` | 4.150.0 | cross-platform 2D graphics API for .NET |

> ℹ️ `Microsoft.Extensions.Http` is resolved transitively and is not pinned explicitly in the project file to avoid NU1603 version conflicts.

---

## Getting Started

### Prerequisites

- **.NET 10.0 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/10.0))
- **Visual Studio Code** ([Download](https://code.visualstudio.com/download))
- **Azure Functions Core Tools** ([Install](https://docs.microsoft.com/azure/azure-functions/functions-run-local))
- **Azure Account** (with active subscription)
- **AI Provider API access**: An endpoint and API key for at least one of the supported AI providers listed below

#### Supported AI Providers

| Provider | Website | Capabilities | Setup Guide |
|----------|---------|--------------|-------------|
| **Azure AI Foundry** | [azure.microsoft.com/ai-foundry](https://azure.microsoft.com/en-us/products/ai-foundry/) | Text + Image | [setup-azure-foundry.md](docs/integrations/AiProviders/setup-azure-foundry.md) |
| **OpenAI** | [platform.openai.com](https://platform.openai.com/) | Text + Image | [setup-openai.md](docs/integrations/AiProviders/setup-openai.md) |
| **DeepSeek** | [platform.deepseek.com](https://platform.deepseek.com/) | Text only | [setup-deepseek.md](docs/integrations/AiProviders/setup-deepseek.md) |
| **fal.ai** | [fal.ai](https://fal.ai/) | Image only | [setup-falai.md](docs/integrations/AiProviders/setup-falai.md) |
| **Perplexity** | [perplexity.ai](https://www.perplexity.ai/) | Text only | [setup-perplexity.md](docs/integrations/AiProviders/setup-perplexity.md) |

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

Platform OAuth credentials (Twitter/X, LinkedIn, Instagram, Facebook) are **not** stored as environment variables. They are loaded from **Azure Key Vault** at application startup via the Key Vault Configuration Provider and injected into senders through `IOptions<TCredentials>` — no runtime Key Vault calls occur during post publishing. `DefaultAzureCredential` picks up your `az login` session locally and the Function App's Managed Identity in production.

> 📖 Full reference — variable names, types, defaults, allowed values, Key Vault secret names, `TagReplacementOptions` hashtag map, workflow and schedule (`Workflows__*` / `Schedule__N`) examples, and a dry-run local-testing guide: **[docs/configuration.md](docs/configuration.md)**.

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

1. Create a **Function App** in Azure Portal (Runtime: `.NET 10 Isolated`, Plan: Consumption)
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

The **timer firing frequency** is configurable via the `CronSchedule` environment variable; a second timer (`ContainerPollingSchedule`) handles Instagram async container publication.

**Format**: 6-field cron expression: `{second} {minute} {hour} {day} {month} {dayOfWeek}`

**Configuration**:

```json
// local.settings.json
{
  "Values": {
    "CronSchedule": "0 50 * * * *"
  }
}
```

```bash
# Azure CLI
az functionapp config appsettings set \
  --name xposterfunction \
  --resource-group XPosterRG \
  --settings "CronSchedule=0 50 * * * *"
```

The function fires according to the cron expression, but **which workflow runs at a given UTC hour is decided by the `Schedule` configuration section** (`Schedule__N__Hour`, `Schedule__N__Workflow`, `Schedule__N__Senders__M`). If no slot matches the current hour, `NoOrchestrator` is used.

### Cron Expression Examples

| Schedule | Cron Expression | Description |
|----------|-----------------|-------------|
| **Default** | `0 50 * * * *` | Every hour at minute 50; `Schedule__N` decides the workflow per hour |
| **Hourly** | `0 0 * * * *` | Every hour on the hour |
| **Every 4 hours** | `0 0 */4 * * *` | Every 4 hours |
| **Business Hours** | `0 0 9,12,15,18 * * 1-5` | 9, 12, 15, 18 (Mon-Fri) |
| **Morning/Evening** | `0 0 8,20 * * *` | At 8:00 and 20:00 |
| **Daily** | `0 0 9 * * *` | Every day at 9:00 |
| **Quick Test** | `*/30 * * * * *` | Every 30 seconds (dev only) |

### Config-driven Slot Selection (`Schedule` / `Workflows`)

The schedule is read from the `Schedule` configuration section by `ConfigurationSlotProfileProvider` (the single `ISlotProfileProvider`), which maps every entry to a `WorkflowOrchestrator`. Production slots are defined entirely via app settings:

```json
// local.settings.json — production schedule
{
  "Values": {
    "CronSchedule": "0 50 * * * *",
    "Schedule__0__Hour": "6",
    "Schedule__0__Workflow": "Bitcoin",
    "Schedule__0__Senders__0": "LinkedIn",
    "Schedule__0__Senders__1": "X",
    "Schedule__0__Senders__2": "Facebook",
    "Schedule__0__Senders__3": "Instagram",

    "Schedule__1__Hour": "14",
    "Schedule__1__Workflow": "PowerLaw",
    "Schedule__1__Senders__0": "LinkedIn",
    "Schedule__1__Senders__1": "X",
    "Schedule__1__Senders__2": "Facebook"
  }
}
```

| UTC Hour | `Workflow` | `Senders` | Content |
|----------|-----------|-----------|---------|
| 6 | `Bitcoin` | `LinkedIn`, `X`, `Facebook`, `Instagram` | RSS news summarisation + AI image |
| 14 | `PowerLaw` | `LinkedIn`, `X`, `Facebook` | Deterministic post from crypto price data |

> ℹ️ The fan-out slot at hour 6 generates the base summary and image **once** (sized for Facebook's 3 000-char limit), then re-summarises only when needed for LinkedIn (2 800), Instagram (2 200) and X (250 chars). This reduces AI and image credit consumption compared to separate slots.

> ℹ️ The `PowerLaw` slot at hour 14 does not require AI providers — its DAG (`AcquireCryptoValue → BuildPowerLawPost → FanOutSend`) computes a deterministic post from crypto price data and never calls `ITextToTextProvider` or `ITextToImageProvider`.

Workflows themselves are declared in the `Workflows` configuration section as node DAGs (e.g. `Workflows__Bitcoin__Nodes__N__Type` = `FetchRss` → `AiText` → `AiImage` → `FanOutSend`). `OrchestratorFactory` receives `ISlotProfileProvider` via constructor injection and calls `GetProfiles()` at resolution time — making the whole schedule a swappable, config-driven dependency rather than embedded logic.

### Dry-Run Testing (Local)

To run the full pipeline locally without publishing to any social platform, add a dry-run slot using the dry-run senders — **no code changes required**:

```json
// local.settings.json
{
  "Values": {
    "Schedule__2__Hour": "9",
    "Schedule__2__Workflow": "PowerLaw",
    "Schedule__2__Senders__0": "DryRunMaxLength",
    "Schedule__2__Senders__1": "DryRunShortLength",
    "ForceHour": "9"
  }
}
```

| Key | Value | Effect |
|-----|-------|--------|
| `Schedule__2__…` | dry-run slot | Registers an ordinary `Schedule` entry whose senders are the dry-run variants of `SenderPlatform` |
| `ForceHour` | `9` | Overrides the UTC clock (development only) so the dry-run slot is selected regardless of wall-clock time |

`DryRunMaxLength` (unlimited length) and `DryRunShortLength` (250 chars) are `SenderPlatform` values backed by `DryRunSender` implementations: they run the full orchestration pipeline — RSS fetch, AI summarisation, tag replacement, image generation — but **never publish to any social platform**, logging the post content instead.

> ⚠️ `ForceHour` is honoured only in the `Development` environment. In production the dry-run senders must never appear in the `Schedule__N__Senders__M` lists.

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
| **Sender Plugins** (`ISender`) | Implement `ISender`, register in DI keyed by a new `SenderPlatform` enum value, list the platform name in a schedule slot's `Senders` (`Schedule__N__Senders__M`) | Platform-specific code is fully isolated behind a single interface, so adding a new social network has zero impact on workflows or scheduling |
| **Workflow Nodes** (`IWorkflowNode`) | Implement `IWorkflowNode`, register as a keyed transient in `AddWorkflows()`, reference the node `Type` in the `Workflows__*` section as a DAG step with `NextNodeIds` | The DAG engine decouples content logic from scheduling; new content strategies are configured workflows, not new orchestrator classes |
| **AI Providers** (`ITextToTextProvider` / `ITextToImageProvider`) | Implement the relevant capability interface(s), register as keyed services in `AddXPosterAiProviders()`, add an `AiProvider` enum value, assign the provider name in an `AiText` / `AiImage` node | Providers expose only the capabilities they support; `null` resolution is the canonical signal for "capability not available" — no switch expressions or factory classes to modify |
| **Feed Sources** (`FetchRss` node) | Provide the RSS URLs as the `Urls` node parameter or author a new node that supplies feed content | Feed URLs are a per-workflow concern; sourcing them from a database or remote config requires only a new/updated node — no changes to `FeedService` or the engine |
| **Tag Replacement Providers** (`ITagReplacementProvider`) | Implement `ITagReplacementProvider`, register as `Singleton` in `Program.cs` replacing `ConfigurationTagReplacementProvider` | The hashtag map is externalised from node code; changing, adding, or removing replacements requires only a configuration update — no redeployment |
| **Scheduling profiles** (`ISlotProfileProvider`) | Implement `ISlotProfileProvider` and register it in `Program.cs` (default: `ConfigurationSlotProfileProvider`) | The schedule is a swappable dependency injected into `OrchestratorFactory` — operators alter the slot list via the `Schedule__N` configuration section without touching factory or node code |

> 📖 For step-by-step implementation guides, code contracts, design constraints, and worked examples for each extension point, see **[docs/extending-xposter.md](docs/extending-xposter.md)**.

---

## Testing

The test suite uses **xUnit + Moq** with a unit-first approach. Tests are organized to mirror the `src/` folder structure and target ≥ 80% line coverage on every CI run.

```
tests/
├── XFunctionTests.cs, XPosterContainerPollingFunctionTests.cs   # function entry points
├── Contracts/        # AiProviderExtensions, enum contracts
├── Helpers/          # shared HTTP mock helpers and image fixtures for resilience tests
├── Orchestrators/    # WorkflowOrchestrator, OrchestratorFactory, BaseOrchestrator, NoOrchestrator
├── Integration/      # Polly resilience pipelines — not run in CI
├── Models/           # domain model invariants, options validators
├── Providers/        # ConfigurationSlotProfileProvider, ConfigurationTagReplacementProvider, time providers
├── SenderPlugins/    # per-platform subfolders: X, Linkedin, Instagram, Facebook; DryRunSender variants
├── Services/         # AI services (OpenAi, AzureFoundry, DeepSeek, FalAiImageService, Perplexity, AiServiceHelper), FeedService, CryptoService…
└── Workflows/        # Engine, Nodes, Configuration, Services, Utilities, Models
```

### Running Tests

```bash
# All tests
dotnet test

# With coverage
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
```

> 📖 Full test structure (per-file listing), naming conventions, mocking patterns, coverage exclusions, and checklist for adding new tests: **[tests/README.md](tests/README.md)**.

---

## Monitoring

XPoster uses **Azure Application Insights** for full-stack observability: telemetry collection, structured logging via `ILogger<T>`, dependency tracking, and alerting.

Application Insights is activated automatically when the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable is present — no additional SDK code is required beyond the two registration calls already in `Program.cs`.

Key monitoring capabilities at a glance:
- **Execution tracking**: every `XPosterFunction` invocation appears as a `request` in Application Insights
- **Dependency tracing**: outbound HTTP calls to AI providers, social media APIs, and `cryptoprices.cc` are captured as `dependencies`
- **Structured logging**: all `ILogger<T>` calls flow to the `traces` table with full custom dimensions
- **Fan-out observability**: per-sender publish outcomes and partial failures are logged independently by `BaseOrchestrator.PostAsync` with structured `Sender` and `Result` fields
- **Alerting**: recommended rules cover consecutive errors, high latency, token budget, function downtime, and fan-out partial failures

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
- [x] Retry & resilience for external HTTP calls 
- [x] Tag replacement externalization — `TagReplacementOptions` hashtag map, no redeployment
- [x] Workflow DAG orchestration (ADR-006) — legacy `FeedOrchestrator`/`PowerLawOrchestrator` superseded by config-driven `Workflows__*`
- [x] Config-driven scheduling (`Schedule__N` / `Workflows__*`, `ConfigurationSlotProfileProvider`) — ADR-006 
- [x] Multi-platform fan-out: single slot publishes to multiple platforms in parallel, AI generated once 
- [x] Instagram publishing
- [x] Facebook publishing
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
- [Perplexity](https://www.perplexity.ai/) - Sonar text generation
- [LinqToTwitter](https://github.com/JoeMayo/LinqToTwitter) - Twitter API wrapper
- [SkiaSharp](https://github.com/mono/skiasharp) - Cross-platform 2D graphics API for .NET
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

[&#x1F3E0; Homepage](https://xposter.artcava.net/) • 
[&#x1F4D6; Documentation](docs/index.md) • 
[&#x1F41B; Report Bug](https://github.com/artcava/XPoster/issues) • 
[&#x1F4A1; Request Feature](https://github.com/artcava/XPoster/issues)

</div>
