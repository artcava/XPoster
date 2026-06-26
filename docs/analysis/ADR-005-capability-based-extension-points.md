# ADR-005 — Capability-based Extension Points for Senders, Orchestrators and AI Providers

| Field | Detail |
|---|---|
| **Date** | 2026-Q2 |
| **Status** | Accepted |
| **Linked issues** | #134 #210 #211 |

> Back to [Architecture](../architecture.md#4-architecture-decision-records-adrs)

---

## Context

XPoster has three independent extension axes — Platform Senders, Content Orchestrators, and AI Providers — but the current design couples them in two ways that limit independent extensibility.

**Problem 1 — `MessageSender` enum couples Sender identity to Orchestrator identity**

`MessageSender` today encodes not just *which platform to send to* but implicitly *which orchestrator produced the content*. If a new Orchestrator is introduced (e.g. a `VideoFeedOrchestrator`), a new enum value must be added for every existing Sender (e.g. `XVideo`, `InVideo`, `IgVideo`). The cartesian product grows with O(orchestrators × senders) instead of O(orchestrators) + O(senders).

**Problem 2 — `HybridAiService` couples AI capability dispatch to a fixed provider list**

`HybridAiService` currently decides at runtime whether to call OpenAI (text + image) or DeepSeek/Foundry (text only) via internal branching. Adding a new provider or a new modality (text-to-video, text-to-audio) requires modifying `HybridAiService` itself, violating the Open/Closed Principle. Furthermore, users cannot independently choose a text provider and an image provider; the coupling is implicit.

---

## Decision

### 1. Separate Orchestrator identity from Sender identity

Introduce a `SenderPlatform` enum that identifies only the target platform (`X`, `LinkedIn`, `Instagram`). Each `IOrchestrator` declares which platforms it targets via a `IReadOnlyList<SenderPlatform> SupportedPlatforms` property. `OrchestratorFactory` matches Orchestrators to platforms via a switch on `SenderPlatform` — independent of which Orchestrator type produced the content.

**Before:**
```csharp
public enum MessageSender { XSummaryFeed, InSummaryFeed, XPowerLaw, InPowerLaw, ... }
```

**After:**
```csharp
public enum SenderPlatform { X, LinkedIn, Instagram, DryRun }

public interface IOrchestrator
{
    IReadOnlyList<SenderPlatform> SupportedPlatforms { get; }
    Task<Post> OrchestrateAsync(RSSFeed feed);
}
```

`OrchestratorFactory` sender switch becomes O(senders) and never changes when new Orchestrators are added:
```csharp
ISender? sender = profile.SenderPlatform switch
{
    SenderPlatform.X         => _serviceProvider.GetService<XSender>(),
    SenderPlatform.LinkedIn  => _serviceProvider.GetService<InSender>(),
    SenderPlatform.Instagram => _serviceProvider.GetService<IgSender>(),
    SenderPlatform.DryRun    => _serviceProvider.GetService<DryRunSender>(),
    _ => null
};
```

### 2. Introduce capability-based AI provider contracts

Replace `HybridAiService` with two capability interfaces resolved from DI. Consumers declare which capability they need; the DI container resolves the configured implementation.

```csharp
public interface ITextToTextProvider
{
    Task<string> GetSummaryAsync(string text, int maxLength, CancellationToken ct = default);
    Task<string> GetImagePromptAsync(string text, CancellationToken ct = default);
}

public interface ITextToImageProvider
{
    Task<byte[]> GenerateImageAsync(string prompt, CancellationToken ct = default);
}

// Future-proof — zero changes to existing code when added:
public interface ITextToVideoProvider { ... }
public interface ITextToAudioProvider { ... }
```

Concrete services implement only the interfaces matching their actual capabilities:

| Service | `ITextToTextProvider` | `ITextToImageProvider` | Note |
|---|---|---|---|
| `OpenAiService` | ✅ | ✅ | Fully implemented |
| `AzureFoundryService` | ✅ | ✅ | `GenerateImageAsync` calls `/images/generations` — fully implemented |
| `DeepSeekService` | ✅ | ❌ | Text only |
| `PerplexityService` | ✅ | ❌ | `GenerateImageAsync` removed — previously returned `byte[0]` silently; misconfiguration now fails at startup |
| `FalAiImageService` | ❌ | ✅ | Image only |

#### Per-slot provider selection — two independent fields

Each `AiProvider` value identifies **exactly one concrete service**. Because text and image generation can come from different providers (e.g. DeepSeek for text, Fal for images), `ScheduledOrchestrationProfile` exposes two independent fields instead of one:

```csharp
public class ScheduledOrchestrationProfile
{
    public SenderPlatform SenderPlatform { get; init; }
    public AiProvider     TextAiProvider  { get; init; }  // replaces AiProvider
    public AiProvider     ImageAiProvider { get; init; }
    // ...
}
```

`AiProvider` is extended with `FalAi`:

```csharp
public enum AiProvider
{
    None,
    OpenAi,
    AzureFoundry,
    DeepSeek,   // renamed from DeepSeekWithFal
    Perplexity,
    FalAi       // new — image-only provider
}
```

Registration in `Program.cs` via `AddXPosterAiProviders()`:

```csharp
// Text providers
builder.Services.AddKeyedTransient<ITextToTextProvider, OpenAiService>(AiProvider.OpenAi);
builder.Services.AddKeyedTransient<ITextToTextProvider, AzureFoundryService>(AiProvider.AzureFoundry);
builder.Services.AddKeyedTransient<ITextToTextProvider, DeepSeekService>(AiProvider.DeepSeek);
builder.Services.AddKeyedTransient<ITextToTextProvider, PerplexityService>(AiProvider.Perplexity);

// Image providers
builder.Services.AddKeyedTransient<ITextToImageProvider, OpenAiService>(AiProvider.OpenAi);
builder.Services.AddKeyedTransient<ITextToImageProvider, AzureFoundryService>(AiProvider.AzureFoundry);
builder.Services.AddKeyedTransient<ITextToImageProvider, FalAiImageService>(AiProvider.FalAi);
```

Each key maps to exactly one concrete class per interface. `OrchestratorFactory` resolves the two capabilities independently:

```csharp
var textProvider  = _serviceProvider.GetRequiredKeyedService<ITextToTextProvider>(profile.TextAiProvider);
var imageProvider = _serviceProvider.GetRequiredKeyedService<ITextToImageProvider>(profile.ImageAiProvider);
```

A slot that previously used `AiProvider.DeepSeekWithFal` now declares:

```csharp
TextAiProvider  = AiProvider.DeepSeek,
ImageAiProvider = AiProvider.FalAi
```

#### Removal of `AiServiceFactory`

`AiServiceFactory` and `IAiServiceFactory` are removed. `OrchestratorFactory` resolves the two capability interfaces directly — no intermediary factory is needed. The keyed DI container is the factory.

#### Removal of `HybridAiService`

`HybridAiService` is removed. The combination text via `DeepSeekService` + image via `FalAiImageService` is now expressed as two independent profile fields pointing to two independent keyed registrations. No new "hybrid" wrapper class is ever needed for future provider combinations.

---

## Rationale

The two problems share a root cause: the current model uses a single opaque identifier (`MessageSender`, `HybridAiService`) to encode multiple orthogonal concepts simultaneously. This is a classic violation of the Single Responsibility Principle at the type-system level — correcting it at the abstraction layer, rather than patching individual classes, is the only approach that scales linearly with future extension.

For Problem 1, the `SenderPlatform` split restores the invariant that was implicit in ADR-003: a sender knows only how to publish to a platform, not what content strategy produced the post.

For Problem 2, the capability-interface model aligns with the direction already taken in ADR-004: capability gaps are now explicit at compile time and runtime branching in `HybridAiService` is eliminated. The two-field profile design (`TextAiProvider` + `ImageAiProvider`) ensures each `AiProvider` value identifies exactly one service, preserving clear semantics and independent per-slot flexibility.

---

## Alternatives Considered

| Alternative | Reason rejected |
|---|---|
| Keep `HybridAiService` and add new providers via switch | Violates OCP; grows unboundedly with each new provider |
| Use a Strategy dictionary keyed by provider name string | Loses compile-time safety; discovery is implicit |
| Global (non-keyed) DI registration per capability | Destroys per-slot flexibility — all slots would use the same provider pair |
| Single `AiProvider` field with `FalAiImageService` under `DeepSeek` key | `AiProvider` would identify a pairing rather than a single provider; semantically wrong |
| Semantic Kernel / Microsoft.Extensions.AI abstraction layer | Introduces a large dependency for a relatively small problem; can be reconsidered in later stages |

---

## Implementation Notes

### Files to create

| File | Content |
|---|---|
| `src/Contracts/ITextToTextProvider.cs` | `GetSummaryAsync` + `GetImagePromptAsync` |
| `src/Contracts/ITextToImageProvider.cs` | `GenerateImageAsync` |

### Files to modify

| File | Change |
|---|---|
| `src/Contracts/AiProvider.cs` | Rename `DeepSeekWithFal` → `DeepSeek`; add `FalAi` |
| `src/Contracts/Enums.cs` | Add `SenderPlatform`; remove `MessageSender` |
| `src/Abstraction/ScheduledOrchestrationProfile.cs` | Replace `MessageSender` with `SenderPlatform`; replace `AiProvider` with `TextAiProvider` + `ImageAiProvider` |
| `src/Contracts/IOrchestrator.cs` | Add `SupportedPlatforms` property |
| `src/Abstraction/BaseOrchestrator.cs` | Implement `SupportedPlatforms` |
| `src/Orchestrators/OrchestratorFactory.cs` | `SenderPlatform` switch; independent keyed resolution of `TextAiProvider` and `ImageAiProvider`; remove `IAiServiceFactory` |
| `src/Orchestrators/DefaultSlotProfileProvider.cs` | Use `SenderPlatform`; replace `AiProvider.DeepSeekWithFal` with `TextAiProvider = DeepSeek, ImageAiProvider = FalAi` |
| `src/Orchestrators/DryRunSlotProfileProvider.cs` | Use `SenderPlatform.DryRun` |
| `src/Orchestrators/FeedOrchestrator.cs` | Replace `IAiService` with `ITextToTextProvider` + `ITextToImageProvider`; implement `SupportedPlatforms` |
| `src/Orchestrators/PowerLawOrchestrator.cs` | Implement `SupportedPlatforms` |
| `src/Orchestrators/NoOrchestrator.cs` | Implement `SupportedPlatforms` (empty list) |
| `src/Services/Ai/OpenAiService.cs` | Implement `ITextToTextProvider` + `ITextToImageProvider`; remove `IAiService` |
| `src/Services/Ai/AzureFoundryService.cs` | Implement `ITextToTextProvider` + `ITextToImageProvider`; remove `IAiService` |
| `src/Services/Ai/DeepSeekService.cs` | Implement `ITextToTextProvider` only; remove `IAiService` |
| `src/Services/Ai/PerplexityService.cs` | Implement `ITextToTextProvider` only; remove `IAiService` and `GenerateImageAsync` |
| `src/Services/Ai/FalAiImageService.cs` | Implement `ITextToImageProvider` only; remove `IAiService` |
| `src/Program.cs` | Replace keyed `IAiService` registrations with `AddXPosterAiProviders()`; use `AiProvider.DeepSeek` + `AiProvider.FalAi` |

### Files to remove

| File | Reason |
|---|---|
| `src/Services/Ai/HybridAiService.cs` | Replaced by two independent keyed registrations |
| `src/Contracts/IAiService.cs` | Replaced by `ITextToTextProvider` + `ITextToImageProvider` |
| `src/Orchestrators/AiServiceFactory.cs` | Replaced by direct keyed resolution in `OrchestratorFactory` |
| `src/Contracts/IAiServiceFactory.cs` | No longer needed |

### Tests

| File | Change |
|---|---|
| `tests/Services/HybridAiServiceTests.cs` | **Delete** |
| `tests/Orchestrators/AiServiceFactoryTests.cs` | **Delete** |
| `tests/Orchestrators/OrchestratorFactoryTests.cs` | Rewrite for `SenderPlatform` switch; independent resolution of `TextAiProvider` + `ImageAiProvider` |
| `tests/Orchestrators/FeedOrchestratorTests.cs` | Replace `IAiService` mock with `ITextToTextProvider` + `ITextToImageProvider` mocks; update profile construction |
| `tests/Services/PerplexityServiceTests.cs` | Remove `GenerateImageAsync` tests; add `ITextToTextProvider` contract tests |
| `tests/Services/DeepSeekServiceTests.cs` | Rename `GenerateImageAsync_ExceptionMessage_MentionsHybridAiService` → `GenerateImageAsync_AlwaysThrows_NotSupportedException` |
| `tests/Contracts/AiProviderExtensionsTests.cs` | Replace `AiProvider.DeepSeekWithFal` → `AiProvider.DeepSeek`; add `AiProvider.FalAi` case |
| NEW `tests/Integration/DiWiringTests.cs` | Verify keyed resolution for all `AiProvider` values per interface; verify `Perplexity` has no `ITextToImageProvider` registration; verify `FalAi` has no `ITextToTextProvider` registration |

---

## Consequences

**Positive:**
- Adding a new Orchestrator does not require touching `SenderPlatform` or `OrchestratorFactory` sender switch.
- Adding a new AI Provider requires only implementing the relevant capability interface(s) and adding keyed registrations in `AddXPosterAiProviders()`.
- Each `AiProvider` enum value identifies exactly one concrete service — no implicit pairings encoded in enum names.
- Text and image providers can be mixed freely per slot: any `ITextToTextProvider` + any `ITextToImageProvider` combination is expressed as two independent profile fields.
- Per-slot flexibility is fully preserved: `TextAiProvider` and `ImageAiProvider` are independent per slot.
- Future modalities (text-to-video, text-to-audio) are a new interface + keyed registration — zero changes to existing code.
- `HybridAiService` is eliminated, removing an internal branch that is currently a maintenance burden.
- `PerplexityService` silent failure (`GenerateImageAsync` returning `byte[0]`) is eliminated — misconfiguration fails explicitly at startup.

**Negative / Trade-offs:**
- Requires a breaking refactor of `OrchestratorFactory`, `AiServiceFactory`, `HybridAiService`, and all AI service classes.
- `AiProvider.DeepSeekWithFal` is a breaking rename — any configuration file or app setting referencing this value must be updated to `DeepSeek`.
- `ScheduledOrchestrationProfile` gains a second AI provider field (`ImageAiProvider`) — a minor breaking change to profile construction.
- `Program.cs` DI registration becomes more verbose; `AddXPosterAiProviders()` helper extension method keeps it readable.
- Existing tests for `OrchestratorFactory` and `AiServiceFactory` must be rewritten.
