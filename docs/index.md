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
- [Extending XPoster](extending-xposter.md) — adding senders, orchestrators, AI providers, feed URL providers

---

## Integrations

Setup guides for each external service XPoster integrates with.

| Integration | Guide | Notes |
|---|---|---|
| Twitter / X | [setup-x.md](integrations/setup-x.md) | OAuth 1.0a, API v2 |
| LinkedIn | [setup-linkedin.md](integrations/setup-linkedin.md) | OAuth 2.0, 60-day token rotation |
| Instagram | [setup-instagram.md](integrations/setup-instagram.md) | Not yet active — see [#72](https://github.com/artcava/XPoster/issues/72) |
| fal.ai | [setup-falai.md](integrations/setup-falai.md) | Image generation for `DeepSeekWithFal` provider |
| Perplexity | [setup-perplexity.md](integrations/setup-perplexity.md) | Text-only provider; image generation not supported |
| Azure AI Foundry | [setup-azure-foundry.md](integrations/setup-azure-foundry.md) | AI provider for summarisation + image generation |
| DeepSeek | [setup-deepseek.md](integrations/setup-deepseek.md) | Used in `DeepSeekWithFal` provider |
| graphify-ci | [graphify-ci.md](integrations/graphify-ci.md) | CI integration documentation |

---

## AI Provider Capabilities

| Provider | `AiProvider` value | Summarisation | Image Prompt | Image Generation |
|---|---|---|---|---|
| OpenAI | `OpenAi` | ✅ | ✅ | ✅ |
| Azure AI Foundry | `AzureFoundry` | ✅ | ✅ | ✅ |
| DeepSeek + fal.ai | `DeepSeekWithFal` | ✅ | ✅ | ✅ |
| Perplexity | `Perplexity` | ✅ | ✅ | ❌ |

---

## Observability

- [Monitoring](monitoring.md) — Application Insights, structured logs, alerts
