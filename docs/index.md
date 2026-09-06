# XPoster Documentation

Welcome to the XPoster documentation. Use the links below to navigate to the relevant section.

---

## Getting Started

- [Getting Started](getting-started.md) — prerequisites, first run, local setup
- [Configuration Reference](configuration.md) — all environment variables and app settings
- [Deployment](deployment.md) — Azure Functions deployment guide

---

## Architecture & Extension

- [Architecture](architecture.md) — component map, data flow, design decisions
- [Extending XPoster](extending-xposter.md) — adding workflows, senders, and AI providers

---

## Orchestration & Scheduling

- [Workflow-Based Orchestration (ADR-006)](analysis/ADR-006-workflow-based-orchestration-architecture.md) — the workflow DAG model, node catalogue, and config-driven scheduling
- [Capability-Based Extension Points (ADR-005)](analysis/ADR-005-capability-based-extension-points.md) — AI capability interfaces and keyed DI
- [Testing Strategy](../tests/README.md) — testing philosophy, mocking patterns, and coverage goals

> The full ADR list is maintained in the [architecture document](architecture.md#4-architecture-decision-records-adrs).

---

## Integrations

Setup guides for each external service XPoster integrates with.

| Integration | Guide | Notes |
|---|---|---|
| Twitter / X | [setup-x.md](integrations/SenderPlugins/setup-x.md) | OAuth 1.0a, API v2 |
| LinkedIn | [setup-linkedin.md](integrations/SenderPlugins/setup-linkedin.md) | OAuth 2.0, 60-day token rotation |
| Instagram | [setup-instagram.md](integrations/SenderPlugins/setup-instagram.md) | OAuth 2.0, Graph API management |
| Facebook | [setup-facebook.md](integrations/SenderPlugins/setup-facebook.md) | OAuth 2.0, Graph API management |
| fal.ai | [setup-falai.md](integrations/AiProviders/setup-falai.md) | Image-only provider; text generation not supported |
| Perplexity | [setup-perplexity.md](integrations/AiProviders/setup-perplexity.md) | Text-only provider; image generation not supported |
| Open AI | [setup-openai.md](integrations/AiProviders/setup-openai.md) | AI provider for summarisation + image generation |
| Azure AI Foundry | [setup-azure-foundry.md](integrations/AiProviders/setup-azure-foundry.md) | AI provider for summarisation + image generation |
| DeepSeek | [setup-deepseek.md](integrations/AiProviders/setup-deepseek.md) | Text-only provider; image generation not supported |
| graphify-ci | [graphify-ci.md](integrations/graphify-ci.md) | CI integration documentation |

---

## AI Provider Capabilities

Each AI **node** names its provider via `Workflows__<key>__Nodes__N__Parameters__Provider`. Providers are keyed by `AiProvider` and expose only the capability interfaces they implement:

| Provider | `AiProvider` value | Text (`AiText` nodes) | Image (`AiImage` nodes) |
|---|---|---|---|
| OpenAI | `OpenAi` | ✅ | ✅ |
| Azure AI Foundry | `AzureFoundry` | ✅ | ✅ |
| DeepSeek | `DeepSeek` | ✅ | ❌ (node throws) |
| Perplexity | `Perplexity` | ✅ | ❌ (node throws) |
| fal.ai | `FalAi` | ❌ (node throws) | ✅ |

A single workflow can mix providers per node (e.g. DeepSeek for the summary `AiText`, fal.ai for the `AiImage`).

---

## Observability

- [Monitoring](monitoring.md) — Application Insights, structured logs, alerts
