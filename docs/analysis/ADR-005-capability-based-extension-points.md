# ADR-005 — Capability-based Extension Points for Senders, Generators and AI Providers

| Field | Detail |
|---|---|
| **Date** | 2026-Q2 |
| **Status** | Proposed |

> Back to [Architecture](../architecture.md#4-architecture-decision-records-adrs)

---

## Context

XPoster has three independent extension axes — Platform Senders, Content Generators, and AI Providers — but the current design couples them in two ways that limit independent extensibility.

**Problem 1 — `MessageSender` enum couples Sender identity to Generator identity**

`MessageSender` today encodes not just *which platform to send to* but implicitly *which generator produced the content*. If a new Generator is introduced (e.g. a `VideoFeedGenerator`), a new enum value must be added for every existing Sender (e.g. `XVideo`, `InVideo`, `IgVideo`). The cartesian product grows with O(generators × senders) instead of O(generators) + O(senders).

**Problem 2 — `HybridAiService` couples AI capability dispatch to a fixed provider list**

`HybridAiService` currently decides at runtime whether to call OpenAI (text + image) or DeepSeek/Foundry (text only) via internal branching. Adding a new provider or a new modality (text-to-video, text-to-audio) requires modifying `HybridAiService` itself, violating the Open/Closed Principle. Furthermore, users cannot independently choose a text provider and an image provider; the coupling is implicit.

## Decision

### 1. Separate Generator identity from Sender identity

Introduce a `SenderPlatform` enum (or string key) that identifies only the target platform (`X`, `LinkedIn`, `Instagram`). Each `IGenerator` declares which platforms it targets via a `IReadOnlyList<SenderPlatform> SupportedPlatforms` property. `GeneratorFactory` matches Generators to platforms, not to a combined Generator+Sender key.

**Before:**
```csharp
public enum MessageSender { XFeed, InFeed, IgFeed, XPowerLaw, InPowerLaw, ... }
```

**After:**
```csharp
public enum SenderPlatform { X, LinkedIn, Instagram }

public interface IGenerator
{
    IReadOnlyList<SenderPlatform> SupportedPlatforms { get; }
    Task<Post> GenerateAsync(RSSFeed feed);
}
```

### 2. Introduce capability-based AI provider contracts

Replace `HybridAiService` with a set of capability interfaces resolved from DI. Consumers declare which capability they need; the DI container resolves the configured implementation.

```csharp
public interface ITextToTextProvider
{
    Task<string> CompleteAsync(string prompt, CancellationToken ct = default);
}

public interface ITextToImageProvider
{
    Task<byte[]> GenerateImageAsync(string prompt, CancellationToken ct = default);
}

// Future-proof, no code change required in existing code when added:
public interface ITextToVideoProvider { ... }
public interface ITextToAudioProvider { ... }
```

Concrete services (`OpenAiService`, `DeepSeekService`, `AzureFoundryService`, `FalAiImageService`) implement only the interfaces matching their actual capabilities. Configuration drives which implementation is registered for each capability:

```csharp
// Program.cs — example
builder.Services.AddScoped<ITextToTextProvider, DeepSeekService>();
builder.Services.AddScoped<ITextToImageProvider, FalAiImageService>();
```

## Rationale

The two problems share a root cause: the current model uses a single opaque identifier (`MessageSender`, `HybridAiService`) to encode multiple orthogonal concepts simultaneously. This is a classic violation of the Single Responsibility Principle at the type-system level — correcting it at the abstraction layer, rather than patching individual classes, is the only approach that scales linearly with future extension.

For Problem 1, the `SenderPlatform` split restores the invariant that was implicit in ADR-003: a sender knows only how to publish to a platform, not what content strategy produced the post.

For Problem 2, the capability-interface model aligns with the direction already taken in ADR-004: capability gaps are now explicit at compile time and runtime branching in `HybridAiService` is eliminated.

## Alternatives Considered

| Alternative | Reason rejected |
|---|---|
| Keep `HybridAiService` and add new providers via switch | Violates OCP; grows unboundedly with each new provider |
| Use a Strategy dictionary keyed by provider name string | Loses compile-time safety; discovery is implicit |
| Semantic Kernel / Microsoft.Extensions.AI abstraction layer | Introduces a large dependency for a relatively small problem; can be reconsidered in later stages |

## Consequences

**Positive:**
- Adding a new Generator does not require touching the `MessageSender`/`SenderPlatform` enum.
- Adding a new AI Provider requires only implementing the relevant capability interface(s) and registering it in `Program.cs`.
- Users can freely mix providers per capability (e.g. DeepSeek for text, Fal.ai for image) via configuration alone.
- Future modalities (text-to-video, text-to-audio) are a new interface + one registration line — zero changes to existing code.
- `HybridAiService` is eliminated, removing an internal branch that is currently a maintenance burden.

**Negative / Trade-offs:**
- Requires a breaking refactor of `GeneratorFactory`, `AiServiceFactory`, and `HybridAiService`.
- `Program.cs` DI registration becomes more verbose; a helper extension method (`AddXPosterAiProviders`) is recommended to keep it readable.
- Existing tests for `GeneratorFactory` and `AiServiceFactory` must be rewritten.
