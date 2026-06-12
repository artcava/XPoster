# ADR-004 — Provider-Agnostic AI Integration

| Field | Detail |
|---|---|
| **Date** | 2026-Q1 |
| **Status** | Accepted |

> Back to [Architecture](../architecture.md#4-architecture-decision-records-adrs)

---

## Context

Content generation requires a large language model for summarisation and an image model for visuals. The initial implementation was coupled to a specific OpenAI model pair; as the number of supported providers and models grew, hardcoding became a maintenance liability.

## Decision

Introduce `IAiServiceFactory` as an abstract factory that resolves `IAiService` implementations by `AiProvider` enum value (`OpenAi`, `Perplexity`, `AzureFoundry`, `DeepSeekWithFal`). The active provider per time slot is declared in `ScheduledGenerationProfile.AiProvider` and can be overridden globally via the `AiProvider` configuration key. Concrete model names are an internal concern of each `IAiService` implementation.

## Rationale

- `IAiService` abstraction means the underlying provider and model can be swapped without touching generators or the factory scheduling logic.
- Per-slot provider assignment (e.g. different providers at different hours) is expressed declaratively in the profile list.
- Global override via config enables A/B testing between providers without code deployments.

## Alternatives Considered

- **Single hardcoded `AiService` (OpenAI only)**: Used in v1.x; rejected as the provider landscape expanded.
- **Hugging Face / open-source models**: Remains a valid future option via a new `IAiService` implementation; the current architecture supports it without changes.

## Consequences

Each `IAiService` implementation manages its own SDK dependencies and model configuration. Adding a new provider requires a new class, a DI registration, and an `AiProvider` enum value — no changes to `GeneratorFactory` or any generator.
