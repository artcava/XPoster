# Architecture

This document explains the architectural decisions, component responsibilities, and extension contracts of **XPoster** — an AI-powered social media automation platform built on Azure Functions.

> See also: [README.md](README.md) for setup, configuration, and deployment instructions.

---

## Table of Contents

1. [System Overview](#1-system-overview)
2. [Component Responsibilities](#2-component-responsibilities)
3. [Design Patterns Used](#3-design-patterns-used)
4. [Architecture Decision Records (ADRs)](#4-architecture-decision-records-adrs)
5. [Extension Points](#5-extension-points)
6. [Data Flow Diagram](#6-data-flow-diagram)

---

## 1. System Overview

XPoster is a **serverless, event-driven pipeline** that runs on a timer, selects a content strategy based on the current time, generates a social media post (optionally using AI), and publishes it to one or more platforms via pluggable sender components.

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
    │ • AI Service   │ ◄─── OpenAI Integration
    │ • Feed Service │ ◄─── RSS Parser
    │ • Crypto Svc   │ ◄─── Security Utils
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

**System boundaries:**
- **Inbound**: Azure Timer Trigger (no external HTTP surface in production)
- **Outbound**: OpenAI API, Twitter/X API, LinkedIn API, Instagram Graph API, RSS feeds
- **Observability**: Azure Application Insights

---

## 2. Component Responsibilities

### XFunction — Entry Point

`XFunction` is the Azure Functions timer-triggered entry point. Its sole responsibility is to **orchestrate the pipeline**: resolve the correct generator via the factory, call `GenerateAsync()`, and forward the resulting `Post` to the target sender. It owns no business logic and depends exclusively on injected abstractions, keeping the trigger layer thin and testable.

### GeneratorFactory — Strategy Selector

`GeneratorFactory` maps the current hour of day to a `(IGenerator, ISender)` pair using a statically declared `Dictionary<int, MessageSender>`. This component is the **single point of variation** for scheduling: changing what gets posted at any hour means editing one line in this dictionary. The factory enforces the invariant that every hour slot resolves to a valid, non-null generator (defaulting to `NoGenerator` for unscheduled slots).

### Generators — Content Strategies

Each generator implements `IGenerator` and encapsulates a specific **content production algorithm**:

- **FeedGenerator**: fetches RSS entries via `FeedService`, calls `AiService` to produce a gpt-4.1-nano summary, and requests a gpt-image-1.5 image. It is stateless and side-effect-free until it hands off the `Post`.
- **PowerLawGenerator**: constructs posts based on statistical/mathematical content (Bitcoin Power Law model). It consumes `CryptoService` for price data and `AiService` for narrative framing.
- **NoGenerator**: a null-object implementation that returns `null` immediately, allowing the factory to represent "no posting" without null-checks in the orchestrator.

### Services Layer — Shared Infrastructure

Services are registered as singletons or transients in the DI container and are consumed by generators:

- **AiService**: thin wrapper over the OpenAI API; isolates all prompt engineering and model-specific parameters behind a stable interface (`IAiService`).
- **FeedService**: RSS parser with in-memory caching and deduplication; exposes a clean `IEnumerable<FeedItem>` contract.
- **CryptoService**: utility layer for cryptocurrency data retrieval and token handling; used for security-sensitive operations and market data queries.

### Sender Plugins — Platform Abstraction

Each sender implements `ISender`, which exposes `Task<bool> SendAsync(Post post)` and `int MessageMaxLength`. Senders are **exclusively responsible for platform-specific serialisation and API communication**; they receive a fully-formed `Post` and return a success/failure signal. This contract guarantees that generators never reference platform SDKs directly.

---

## 3. Design Patterns Used

### Strategy Pattern — Content Generators

**What**: `IGenerator` defines the algorithm interface; `FeedGenerator`, `PowerLawGenerator`, and `NoGenerator` are concrete strategies. `XFunction` programs to the interface, not the implementation.

**Why**: Content generation algorithms change independently of the publishing pipeline. New generation strategies (e.g. a `QuoteGenerator` or `TrendingTopicGenerator`) can be introduced without touching the orchestrator or any other generator. The alternative — a large `switch` block inside `XFunction` — would violate the Open/Closed Principle and make unit testing expensive.

**Trade-off**: The pattern adds one interface and one class per strategy. For the expected number of strategies (< 10), this overhead is negligible compared to the isolation gained.

### Factory Pattern — Time-based Generator Selection

**What**: `GeneratorFactory` centralises the construction and selection of `(IGenerator, ISender)` pairs. It reads the current UTC hour and returns the pre-configured pair, resolving concrete types from the DI container.

**Why**: Centralising selection logic in one class avoids scattering time-aware conditionals across the codebase. It also allows the scheduling table to be unit-tested in isolation and makes it trivial to mock the factory in orchestrator tests. A pure DI-only approach (e.g. named registrations) would require framework-specific workarounds and coupling to the DI container API.

**Trade-off**: The current implementation uses a compile-time dictionary, so schedule changes require a code deployment. A future improvement would be externalising the schedule to Azure App Configuration, but this adds operational complexity not yet warranted.

### Plugin Pattern — Sender Architecture

**What**: Platform senders implement a common `ISender` interface and are registered in the DI container as concrete types. `GeneratorFactory` injects the appropriate sender into each generator at construction time.

**Why**: The plugin approach means **adding a new platform requires zero changes to existing code** — only a new class, a DI registration, a new enum value, and a factory case. This directly supports the Roadmap's expansion goals (Threads, Mastodon, BlueSky, etc.). Embedding platform logic in generators would create a fan-out of changes every time a new platform is added.

**Extensibility contract**: Any sender must:
1. Implement `ISender`
2. Honour `MessageMaxLength` so generators can truncate content correctly
3. Return `false` (not throw) on non-fatal platform errors, allowing the orchestrator to continue

---

## 4. Architecture Decision Records (ADRs)

### ADR-001 — Azure Functions as Compute

| Field | Detail |
|---|---|
| **Date** | 2025-Q1 |
| **Status** | Accepted |

**Context**: XPoster needs to execute a publishing workflow several times per day. The workload is bursty (seconds of CPU, then idle for hours) and has no persistent in-process state requirements.

**Decision**: Use **Azure Functions v4 (Consumption Plan)** with a Timer Trigger.

**Rationale**:
- Zero infrastructure management; scaling and availability are platform-managed.
- Cost model aligns with usage: the function executes ~8–10 times/day, well within the free tier.
- Native integration with Azure Application Insights, Key Vault, and Managed Identity.
- `.NET 8 isolated worker` model provides full control over the host process (custom middleware, DI, etc.).

**Alternatives considered**:
- **Containerised service (AKS/ACI)**: Rejected — always-on cost is unjustified for a periodic workload; adds Kubernetes or container orchestration overhead.
- **Azure Logic Apps**: Rejected — insufficient support for custom C# logic and AI SDK integration; low debuggability.
- **Azure Container Apps (scheduled jobs)**: Viable future option if cold-start latency becomes a constraint, but premature at current scale.

**Consequences**: Cold starts are possible on the Consumption Plan. Acceptable because the timer trigger fires on a fixed schedule and a delay of 1–2 seconds is not user-facing.

---

### ADR-002 — Strategy Pattern for Content Generators

| Field | Detail |
|---|---|
| **Date** | 2025-Q1 |
| **Status** | Accepted |

**Context**: The system must support multiple, independently evolving content-generation algorithms (RSS summary, Power Law model, future strategies). The orchestrator must remain stable as new algorithms are added.

**Decision**: Model each content algorithm as a class implementing `IGenerator`, selected at runtime by `GeneratorFactory`.

**Rationale**: See [Design Patterns — Strategy Pattern](#strategy-pattern--content-generators) above. Key driver: every new generator must be testable in isolation, without standing up Azure infrastructure.

**Alternatives considered**:
- **Inline conditionals in `XFunction`**: Rejected — violates SRP and OCP; every new strategy modifies the orchestrator.
- **Azure Durable Functions fan-out**: Rejected — adds orchestration complexity not needed for sequential, single-platform execution.

**Consequences**: Each generator owns its own dependencies (AI service, feed service, etc.), which are injected. This means generator tests are pure unit tests with mocks.

---

### ADR-003 — Plugin Pattern for Senders

| Field | Detail |
|---|---|
| **Date** | 2025-Q1 |
| **Status** | Accepted |

**Context**: The system targets multiple social platforms with different APIs, rate limits, authentication schemes, and content formats. New platforms must be addable without modifying existing code.

**Decision**: Define `ISender` as the platform abstraction contract; implement one class per platform; register each in the DI container.

**Rationale**: The Roadmap explicitly targets 5+ additional platforms (Threads, Mastodon, BlueSky, YouTube Shorts, TikTok). A plugin model ensures this expansion is low-risk and reviewable in isolation.

**Alternatives considered**:
- **Single `SenderService` with platform enum**: Rejected — grows unboundedly and mixes platform-specific logic in one class.
- **External webhook/queue per platform**: Viable architectural direction for a distributed system, but over-engineered for the current single-process, low-volume deployment.

**Consequences**: Each sender is independently deployable in tests. The `MessageMaxLength` contract must be respected; violations cause silent truncation bugs at the platform layer.

---

### ADR-004 — OpenAI Integration via Direct API

| Field | Detail |
|---|---|
| **Date** | 2026-Q1 |
| **Status** | Accepted |

**Context**: Content generation requires a large language model for summarisation and an image model for visuals.

<<<<<<< develop
**Decision**: Use **Azure OpenAI Service** (gpt-4.1-nano for text, gpt-image-1.5 for images) accessed through the official Azure SDK, abstracted behind `IAiService`.
=======
**Decision**: Use **OpenAI direct API** (`api.openai.com`) accessed via `HttpClient` + `OPENAI_API_KEY`, abstracted behind `IAiService`.
>>>>>>> master

**Rationale**:
- **Models**: `gpt-4.1-nano` for summarisation/prompting, `gpt-image-1.5` for image generation.
- Migrated from Azure OpenAI (DALL-E 3) in v1.2.0 due to `response_format` parameter incompatibility.
- `IAiService` abstraction means the underlying provider (Azure OpenAI, Anthropic, local model) can be swapped without touching generators.
- Azure OpenAI migration is a future option.

**Alternatives considered**:
- **Azure OpenAI Service**: Rejected in v1.2.0 — `response_format` parameter incompatibility with DALL-E 3.
- **Hugging Face / open-source models**: Rejected — self-hosting adds infrastructure burden; quality gap for summarisation tasks at current scale.

**Consequences**: OpenAI API quotas and rate limits must be managed. Token usage should be monitored via Application Insights (see KQL queries in README).

---

## 5. Extension Points

### Adding a New Platform Sender

Follow these four steps; no existing file requires modification beyond step 3 and 4:

**Step 1 — Implement `ISender`**

```csharp
// src/SenderPlugins/ThreadsSender.cs
public class ThreadsSender : ISender
{
    public int MessageMaxLength => 500;

    public async Task<bool> SendAsync(Post post)
    {
        // Threads API implementation
        return true;
    }
}
```

**Step 2 — Register in DI**

```csharp
// src/Program.cs
builder.Services.AddTransient<ThreadsSender>();
```

**Step 3 — Add Enum Value**

```csharp
// src/Abstraction/Enums.cs
public enum MessageSender
{
    // ...
    ThreadsSummaryFeed,
    ThreadsPowerLaw,
}
```

**Step 4 — Register in Factory**

```csharp
// src/Implementation/GeneratorFactory.cs
case MessageSender.ThreadsSummaryFeed:
    return GetInstance<FeedGenerator>(
        _serviceProvider.GetService(typeof(ThreadsSender)) as ISender
    );
```

**Validation**: Add a time slot in the `sendParameters` dictionary and write a unit test for the new sender using a mock `Post`.

---

### Adding a New Generator

**Step 1 — Extend `BaseGenerator`**

```csharp
// src/Implementation/TrendingTopicGenerator.cs
public class TrendingTopicGenerator : BaseGenerator
{
    public TrendingTopicGenerator(ISender sender, ILogger logger, IAiService aiService)
        : base(sender, logger) { _aiService = aiService; }

    public override async Task<Post>? GenerateAsync()
    {
        var topic = await _aiService.GetTrendingTopicAsync();
        return new Post { Content = topic };
    }
}
```

**Step 2 — Register and wire in Factory** — same pattern as sender steps 2–4 above.

**Invariant**: `GenerateAsync()` must return `null` (not throw) when no content can be produced, so the orchestrator can skip posting gracefully.

---

## 6. Data Flow Diagram

The following sequence diagram covers the end-to-end execution from Timer Trigger to post publication.

```mermaid
sequenceDiagram
    participant Timer as Azure Timer Trigger
    participant Fn as XFunction
    participant Factory as GeneratorFactory
    participant Gen as IGenerator<br/>(Feed / PowerLaw)
    participant AI as AiService<br/>(OpenAI)
    participant Feed as FeedService<br/>(RSS)
    participant Sender as ISender<br/>(X / LinkedIn / Instagram)
    participant Platform as Social Platform API

    Timer->>Fn: Trigger (cron schedule)
    Fn->>Factory: GetGenerator(currentHour)
    Factory-->>Fn: IGenerator + ISender resolved

    Fn->>Gen: GenerateAsync()

    alt FeedGenerator
        Gen->>Feed: GetLatestItemAsync()
        Feed-->>Gen: FeedItem (title, url, content)
        Gen->>AI: GetSummaryAsync(content, maxLength)
        AI-->>Gen: summary text
        Gen->>AI: GenerateImageAsync(title)
        AI-->>Gen: image URL
    else PowerLawGenerator
        Gen->>AI: GetPowerLawNarrativeAsync(priceData)
        AI-->>Gen: narrative text
    end

    Gen-->>Fn: Post { Content, ImageUrl }

    alt Post is null (NoGenerator or empty result)
        Fn->>Fn: Log skip, exit
    else Post is valid
        Fn->>Sender: SendAsync(post)
        Sender->>Platform: HTTP API call
        Platform-->>Sender: 200 OK / error
        Sender-->>Fn: true / false
        Fn->>Fn: Log result to App Insights
    end
```

---

*Document maintained by [@artcava](https://github.com/artcava) — open an issue to propose changes.*
