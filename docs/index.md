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
| fal.ai | [setup-fal.md](integrations/setup-fal.md) | Image generation for `DeepSeekWithFal` provider |
| Perplexity | [setup-perplexity.md](integrations/setup-perplexity.md) | Text-only provider; image generation not supported |

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
