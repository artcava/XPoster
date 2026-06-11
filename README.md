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
- [Contributing](#contributing)
- [License](#license)

> 📐 For a deep-dive into architectural decisions, design patterns, ADRs, and extension contracts, see [docs/architecture.md](docs/architecture.md).

---

## Features

### 🤖 Content Generation
- **AI-Powered Summarization**: Intelligent RSS feed summaries via a configurable AI model of your choice
- **Image Generation**: Automatic contextual image creation using any supported image generation model
- **Smart Hashtags**: Automatic keyword conversion to optimized hashtags
- **Multi-Strategy**: Support for different content generation algorithms
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

> 📐 For the full architectural rationale, ADRs, design patterns, and Mermaid data-flow diagram, see **[docs/architecture.md](docs/architecture.md)**.

### High-Level Overview

```
┌────────────────────────────┐
│   Azure Timer Trigger      │
│   (configurable schedule)  │
└───────────┬────────────────┘
            │
            ▼
┌────────────────────────────┐
│   Generator Factory        │ ◄─── Strategy Pattern
│   (Time-based Selector)    │
└───────────┬────────────────┘
            │
    ┌───────┴────────┬──────────────┐
    ▼                ▼              ▼
┌──────────┐   ┌──────────┐   ┌──────────┐
│   Feed   │   │ PowerLaw │   │    No    │
│Generator │   │Generator │   │Generator │
└─────┬────┘   └─────┬────┘   └──────────┘
      │              │
      └──────┬───────┘
             │
             ▼
    ┌────────────────┐
    │   Services     │
    ├────────────────┤
    │ • HybridAiSvc  │ ◄─── Composite AI Provider
    │ • Feed Service │ ◄─── RSS Parser
    │ • Crypto Svc   │ ◄─── CryptoPrices HTTP client
    └────────┬───────┘
             │
             ▼
    ┌────────────────┐
    │ Sender Plugins │
    ├────────────────┤
    │ • XSender      │ ◄─── Twitter/X API
    │ • InSender     │ ◄─── LinkedIn API
    │ • IgSender     │ ◄─── Instagram API
    └────────────────┘
```

### Core Components

#### 1. **XFunction** (Entry Point)
Timer-triggered Azure Function that orchestrates the entire publishing workflow.

**Cron Expression**: Configurable via environment variable (default: `0 5 * * * *`)

#### 2. **GeneratorFactory** (Factory + Strategy Pattern)
Dynamically selects the appropriate generator based on current time.

| Time | Platform | Strategy | Status |
|------|----------|----------|--------|
| 06:00 | LinkedIn | Feed Summary | ✅ Active |
| 08:00 | Twitter/X | Feed Summary | ✅ Active |
| 10:00 | Instagram | Feed Summary | ⚠️ Disabled — pending Instagram production readiness |
| 14:00 | LinkedIn | Power Law | ✅ Active |
| 16:00 | Twitter/X | Power Law | ✅ Active |
| 18:00 | Instagram | Power Law | ⚠️ Disabled — pending Instagram production readiness |

#### 3. **Generators** (Content Strategy)
- **FeedGenerator**: Analyzes RSS feeds, generates AI summaries, creates images
- **PowerLawGenerator**: Generates posts based on the Bitcoin Power Law model (`value = 10⁻¹⁷ × days^5.83`), comparing the fair-value estimate with the live BTC price
- **NoGenerator**: Placeholder for time slots without publishing

#### 4. **Services Layer**

##### General Services
- **FeedService**: RSS parser with caching and intelligent filtering
- **CryptoService**: Thin HTTP client that polls `cryptoprices.cc` to retrieve the current market price for a given cryptocurrency symbol

##### AI Provider Services

All AI provider services implement the `IAiService` interface, which defines three operations: `GetSummaryAsync`, `GetImagePromptAsync`, and `GenerateImageAsync`. The concrete implementation injected at runtime is determined by the `AiProvider` value on the active `ScheduledGenerationProfile`.

| Service | Text model | Image model | Notes |
|---------|------------|-------------|-------|
| **OpenAiService** | Any OpenAI-compatible chat-completion model (e.g. `gpt-4.1-nano`, `gpt-4o-mini`) | Any OpenAI-compatible image-generation model (e.g. `gpt-image-1`, `dall-e-3`) | Default provider; endpoint and deployment name are read from `AZURE_OPENAI_ENDPOINT` / `AZURE_OPENAI_DEPLOYMENT_NAME` |
| **AzureFoundryService** | Azure AI Foundry chat-completion deployment | Azure AI Foundry image-generation deployment | Drop-in alternative to `OpenAiService` for teams already on the Azure AI Foundry hub |
| **DeepSeekService** | DeepSeek chat-completion API | — (text only) | Cost-effective option for high-volume text generation; used by `HybridAiService` for summaries and image prompts |
| **FalAiImageService** | — (image only) | FLUX.2 Turbo via [fal.ai](https://fal.ai) | Specialized image-generation service; used by `HybridAiService` to produce images |
| **HybridAiService** | Delegates to `DeepSeekService` | Delegates to `FalAiImageService` | Composite service — see deep-dive below |

###### HybridAiService — Deep Dive

`HybridAiService` is a **composite implementation** of `IAiService` that combines two specialized providers under a single interface, routing each operation to the backend best suited for it:

```
                  ┌─────────────────────────┐
                  │     HybridAiService     │
                  │    (implements IAiService)│
                  └────────────┬────────────┘
                               │
           ┌───────────────────┴───────────────────┐
           │                                       │
           ▼                                       ▼
  ┌─────────────────┐                   ┌──────────────────────┐
  │  DeepSeekService│                   │  FalAiImageService   │
  │  (text/summary) │                   │  (FLUX.2 Turbo image)│
  └─────────────────┘                   └──────────────────────┘
  GetSummaryAsync()                     GenerateImageAsync()
  GetImagePromptAsync()
```

**Routing logic:**

| `IAiService` method | Delegated to | Rationale |
|---|---|---|
| `GetSummaryAsync` | `DeepSeekService` | DeepSeek offers a strong cost/quality ratio for text summarization tasks |
| `GetImagePromptAsync` | `DeepSeekService` | Prompt crafting is a text task — consistent use of the same text model avoids style drift |
| `GenerateImageAsync` | `FalAiImageService` | FLUX.2 Turbo on fal.ai delivers high-quality images faster and cheaper than OpenAI image models for this workload |

**Why use HybridAiService?**  
Mixing providers at the service level lets the system optimise each step of the content pipeline independently — low-cost, high-throughput text generation with DeepSeek, and fast, high-quality image generation with FLUX.2 — without exposing that complexity to the generators, which only see the `IAiService` contract.

**Configuration keys required:**
```
DEEPSEEK_API_KEY       # DeepSeek API key
DEEPSEEK_MODEL         # e.g. deepseek-chat
FALAI_API_KEY          # fal.ai API key
```

#### 5. **Sender Plugins** (Platform Abstraction)
- **XSender**: Twitter/X via LinqToTwitter
- **InSender**: LinkedIn via HTTP API
- **IgSender**: Instagram via Graph API (in development)

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

The AI layer is built on **Microsoft.Extensions.AI**, the provider-agnostic abstraction for .NET AI services. Each AI provider is registered as a keyed `IAiService` in the DI container and resolved at runtime by `AiServiceFactory` based on the `AiProvider` enum value set on each `ScheduledGenerationProfile`.

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
| `DeepSeekWithFal` | `HybridAiService` | DeepSeek API | fal.ai — FLUX.2 Turbo |

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

### Utilities

| Package | Version | Role |
|---------|---------|------|
| `Microsoft.Extensions.Http` | 9.0.10 | `IHttpClientFactory` — typed/named HTTP clients |
| `System.Text.Json` | 10.0.8 | JSON serialization / deserialization |
| `Microsoft.AspNetCore.App` (framework ref) | 8.0 | ASP.NET Core primitives used by the Functions host |

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
| **Azure AI Foundry** | [azure.microsoft.com/ai-foundry](https://azure.microsoft.com/en-us/products/ai-foundry/) | Text + Image | [docs/setup-azure-foundry.md](docs/setup-azure-foundry.md) |
| **OpenAI** | [platform.openai.com](https://platform.openai.com/) | Text + Image | [docs/setup-openai.md](docs/setup-openai.md) |
| **DeepSeek** | [platform.deepseek.com](https://platform.deepseek.com/) | Text only | [docs/setup-deepseek.md](docs/setup-deepseek.md) |
| **fal.ai** | [fal.ai](https://fal.ai/) | Image only | [docs/setup-falai.md](docs/setup-falai.md) |

> ℹ️ **DeepSeek** and **fal.ai** are used together as the `HybridAiService` — DeepSeek handles text generation and fal.ai handles image generation. See the [Architecture](#architecture) section for details.
>
> ⚠️ Setup guides marked as `docs/setup-*.md` are either available or in progress. See the [Roadmap](#roadmap) for the current documentation status.

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

**For local development**, copy the template and fill in your credentials:

```bash
cp src/local.settings.json.example src/local.settings.json
```

The example file documents every key inline. The variables are grouped into four areas:

| Group | Keys |
|---|---|
| **Scheduling** | `CronSchedule`, `AzureWebJobsStorage`, `FUNCTIONS_WORKER_RUNTIME` |
| **Twitter/X** | `X_API_KEY`, `X_API_SECRET`, `X_ACCESS_TOKEN`, `X_ACCESS_TOKEN_SECRET` |
| **LinkedIn** | `LINKEDIN_ACCESS_TOKEN`, `LINKEDIN_ORGANIZATION_ID` |
| **Instagram** | `INSTAGRAM_ACCESS_TOKEN`, `INSTAGRAM_BUSINESS_ACCOUNT_ID` |
| **AI Provider** | Varies by provider — see [Getting Started → Supported AI Providers](#supported-ai-providers) |

**For Azure**, add the same variables as Application Settings (**Azure Portal → Function App → Configuration**). For production environments, [Azure Managed Identity](https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview) is recommended over API keys.

> 📖 Full reference with types, defaults, allowed values, and instructions on where to obtain each credential: **[docs/configuration.md](docs/configuration.md)**.

---

## Deployment

Three deployment methods are supported. **GitHub Actions (Option 1) is recommended for production** — the repository ships with a ready-to-use workflow at `.github/workflows/master_xposterfunction.yml`.

| Option | Best for |
|---|---|
| **1. GitHub Actions** | Production — automated CI/CD on every push to `master` |
| **2. Azure CLI** | Scripted / IaC provisioning, staging environments |
| **3. Visual Studio** | One-off deploys during early development |

### Quick Start: GitHub Actions

1. Create a **Function App** in Azure Portal (Runtime: `.NET 8 Isolated`, Plan: Consumption)
2. Download the **Publish Profile** (Function App → Overview → *Get publish profile*)
3. Add it as a GitHub secret named `AZURE_FUNCTIONAPP_PUBLISH_PROFILE`
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
//local.settings.json
{
  "Values": {
    "CronSchedule": "0 5 * * * *"
  }
}
```

```bash
//Azure CLI
az functionapp config appsettings set
--name xposterfunction
--resource-group XPosterRG
--settings "CronSchedule=0 5 * * * *"
```

### Cron Expression Examples

| Schedule | Cron Expression | Description |
|----------|-----------------|-------------|
| **Default** | `0 5 */2 * * *` | Every 2 hours at :05 |
| **Hourly** | `0 0 * * * *` | Every hour on the hour |
| **Every 4 hours** | `0 0 */4 * * *` | Every 4 hours |
| **Business Hours** | `0 0 9,12,15,18 * * 1-5` | 9, 12, 15, 18 (Mon-Fri) |
| **Morning/Evening** | `0 0 8,20 * * *` | At 8:00 and 20:00 |
| **Daily** | `0 0 9 * * *` | Every day at 9:00 |
| **Quick Test** | `*/30 * * * * *` | Every 30 seconds (dev only) |

### Time-based Strategy (GeneratorFactory)

Modify `GeneratorFactory.cs` to customize which generator to use at each hour:

```csharp
private static readonly List<ScheduledGenerationProfile> slotProfiles = new()
{
    new ScheduledGenerationProfile(6, MessageSender.InSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
    new ScheduledGenerationProfile(8, MessageSender.XSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
    new ScheduledGenerationProfile(14, MessageSender.InPowerLaw, typeof(PowerLawGenerator)),
    new ScheduledGenerationProfile(16, MessageSender.XPowerLaw, typeof(PowerLawGenerator)),
};
```
---

### Best Practices

✅ **Testing**: Use frequent schedules in development (`*/5 * * * * *` = every 5 secs)
✅ **Production**: More conservative schedules to avoid rate limiting
✅ **Multi-environment**: Different schedules for Dev/Staging/Prod
✅ **Monitoring**: Check logs to confirm correct execution

---

## Extensibility

XPoster is designed with explicit extension points that allow new capabilities to be added without modifying core logic. The table below lists what is extensible, and why each point was designed that way.

| Extension point | How to extend | Rationale |
|---|---|---|
| **Sender Plugins** (`ISender`) | Implement `ISender`, register in DI, add an enum value to `MessageSender`, configure a `ScheduledGenerationProfile` | Platform-specific code is fully isolated behind a single interface, so adding a new social network has zero impact on generators or scheduling |
| **Content Generators** (`BaseGenerator`) | Subclass `BaseGenerator`, override `GenerateAsync()`, register in `GeneratorFactory` | The Strategy pattern in `GeneratorFactory` decouples content logic from scheduling, making it safe to introduce new content strategies independently |
| **AI Providers** (`IAiService`) | Implement `IAiService`, register as a keyed service in DI, add an `AiProvider` enum value | All generators depend only on `IAiService`, so swapping or adding a provider requires no changes outside the service layer and `Program.cs` |
| **Scheduling profiles** (`ScheduledGenerationProfile`) | Add or modify entries in `GeneratorFactory.slotProfiles` | Time slots are data, not code — operators can reconfigure the publishing schedule without touching business logic |

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
│   └── BaseGeneratorTests.cs
├── Implementation/
│   ├── AiServiceFactoryTests.cs
│   ├── FeedGeneratorTests.cs
│   ├── GeneratorFactoryTests.cs
│   ├── NoGeneratorTests.cs
│   └── PowerLawGeneratorTests.cs
├── Models/
│   ├── AzureFoundryOptionsValidatorTests.cs
│   ├── ModelsTests.cs
│   ├── OpenAiOptionsValidatorTests.cs
│   ├── PostMissingBranchTests.cs
│   └── RSSFeedMissingBranchTests.cs
├── SenderPlugins/
│   ├── IgSenderTests.cs
│   ├── InSenderMissingBranchTests.cs
│   ├── InSenderSendAsyncTests.cs
│   ├── InSenderTests.cs
│   ├── XSenderMissingBranchTests.cs
│   ├── XSenderSendAsyncTests.cs
│   └── XSenderTests.cs
└── Services/
    ├── AzureFoundryServiceTests.cs
    ├── CryptoServiceTests.cs
    ├── FeedServiceTests.cs
    ├── OpenAiServiceTests.cs
    └── TimeProviderTests.cs
```

| Folder | What is covered |
|---|---|
| *(root)* | `XFunction` entry point — happy path and missing-branch edge cases |
| `Abstraction/` | `BaseGenerator` abstract class contracts |
| `Implementation/` | `FeedGenerator`, `PowerLawGenerator`, `NoGenerator`, `GeneratorFactory`, and `AiServiceFactory` resolution logic |
| `Models/` | Domain model invariants, `Post` and `RSSFeed` missing-branch cases, OpenAI and Azure Foundry options validators |
| `SenderPlugins/` | `XSender` and `InSender` (happy path, `SendAsync`, missing-branch); `IgSender` (in-development coverage) |
| `Services/` | `OpenAiService`, `AzureFoundryService`, `CryptoService`, `FeedService`, and `TimeProvider` unit tests |

### Running Tests

```bash
# All tests
dotnet test

# Specific tests
dotnet test --filter "FullyQualifiedName~FeedGenerator"

# With coverage
dotnet test --collect:"XPlat Code Coverage"
```

> 📖 Full testing strategy, mocking patterns, and coverage goals: [tests/README.md](tests/README.md).

### Mocking External Services

```csharp
[Fact]
public async Task FeedGenerator_ShouldGenerateSummary()
{
    // Arrange
    var mockAiService = new Mock<IAiService>();
    mockAiService
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
        .ReturnsAsync("Test summary");
    
    var generator = new FeedGenerator(
        mockSender.Object,
        mockLogger.Object,
        mockFeedService.Object,
        mockAiService.Object
    );

    // Act
    var result = await generator.GenerateAsync();

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
- [ ] AI addition: Azure AI Foundry (alternative to OpenAI)
- [ ] LinkedIn auto-update authorization token ⚠️
- [ ] Enhanced error handling
- [ ] Comprehensive testing (80%+ coverage)

> ⚠️ LinkedIn token refresh is scoped to organization accounts only (`IN_ORG_ID`). Personal member accounts require manual renewal every 60 days.

### 🎨 Phase 3: Admin Dashboard (TBD)
- [ ] Web based UI
- [ ] Real-time analytics
- [ ] Manual post scheduling
- [ ] Content calendar
- [ ] Performance metrics
- [ ] Mobile app (MAUI)

### 🌍 Phase 4: Expansion (TBD)
- [ ] Instagram publishing (complete setup)
- [ ] Threads (Meta) integration
- [ ] Mastodon support
- [ ] BlueSky protocol
- [ ] YouTube Shorts
- [ ] Podcast automation

---

## Contributing

Contributions, issues, and feature requests are welcome!

### How to Contribute

1. **Fork** the project
2. **Create** your feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

### Guidelines

- Follow C# (.NET) coding conventions
- Add unit tests for new features
- Update documentation
- Keep commits atomic and descriptive
- Respect existing design patterns

### Coding Standards

```csharp
// ✅ Good
public async Task<Post> GenerateAsync()
{
    var summary = await _aiService.GetSummaryAsync(content, maxLength);
    if (string.IsNullOrWhiteSpace(summary))
    {
        _logger.LogWarning("Empty summary generated");
        return null;
    }
    return new Post { Content = summary };
}

// ❌ Avoid
public async Task<Post> GenerateAsync() {
    var summary = await _aiService.GetSummaryAsync(content, maxLength);
    if (summary == null || summary == "") return null;
    return new Post { Content = summary };
}
```

---

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

```
MIT License

Copyright (c) 2025 Marco Cavallo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
```


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
