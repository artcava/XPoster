# XPoster — Documentation

Welcome to the XPoster documentation hub. Use the links below to navigate to each topic.

## Contents

| Document | Description |
|---|---|
| [Getting Started](getting-started.md) | Setup, prerequisites, first run |
| [Architecture](architecture.md) | Architectural decisions and design patterns |
| [Configuration Reference](configuration.md) | All environment variables with type, default, and description |
| [Deployment Guide](deployment.md) | Step-by-step Azure deployment |
| [Extending XPoster](extending-xposter.md) | Adding new senders and orchestrators |
| [Monitoring & Alerting](monitoring.md) | Application Insights setup and KQL queries |

## Architecture Decision Records

| Document | Status |
|---|---|
| [ADR-001 — Azure Functions as Compute](analysis/ADR-001-azure-functions-as-compute.md) | Accepted |
| [ADR-002 — Strategy Pattern for Content Generators](analysis/ADR-002-strategy-pattern-generators.md) | Accepted |
| [ADR-003 — Plugin Pattern for Senders](analysis/ADR-003-plugin-pattern-senders.md) | Accepted |
| [ADR-004 — Provider-Agnostic AI Integration](analysis/ADR-004-provider-agnostic-ai.md) | Accepted |
| [ADR-005 — Capability-based Extension Points](analysis/ADR-005-capability-based-extension-points.md) | Proposed |

## Analysis

| Document | Description |
|---|---|
| [LinkedIn Token Auto-Refresh](analysis/analysis-linkedin-token-auto-refresh.md) | Architecture analysis and implementation plan for automated LinkedIn OAuth token renewal |

## Integrations

| Document | Description |
|---|---|
| [Azure AI Foundry Setup](integrations/setup-azure-foundry.md) | Provisioning and configuration for Azure AI Foundry integration |
| [OpenAI Setup](integrations/setup-openai.md) | API key, model selection, and configuration for the OpenAI provider |
| [DeepSeek Setup](integrations/setup-deepseek.md) | API key and configuration for the DeepSeek text provider (used in HybridAiService) |
| [fal.ai Setup](integrations/setup-falai.md) | API key and configuration for the fal.ai image provider (used in HybridAiService) |
| [Agent Graph](agent-graph.md) | Auto-generated code-graph for AI-assisted development: what it is, output formats, CI pipeline, and usage guide |

## Quick Links

- [README](../README.md) — Project overview
- [CONTRIBUTING.md](../CONTRIBUTING.md) — Contribution guidelines
- [tests/README.md](../tests/README.md) — Testing strategy
