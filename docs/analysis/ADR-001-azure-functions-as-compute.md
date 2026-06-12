# ADR-001 — Azure Functions as Compute

| Field | Detail |
|---|---|
| **Date** | 2025-Q1 |
| **Status** | Accepted |

> Back to [Architecture](../architecture.md#4-architecture-decision-records-adrs)

---

## Context

XPoster needs to execute a publishing workflow several times per day. The workload is bursty (seconds of CPU, then idle for hours) and has no persistent in-process state requirements.

## Decision

Use **Azure Functions v4 (Consumption Plan)** with a Timer Trigger.

## Rationale

- Zero infrastructure management; scaling and availability are platform-managed.
- Cost model aligns with usage: the function executes ~8–10 times/day, well within the free tier.
- Native integration with Azure Application Insights, Key Vault, and Managed Identity.
- `.NET 8 isolated worker` model provides full control over the host process (custom middleware, DI, etc.).

## Alternatives Considered

- **Containerised service (AKS/ACI)**: Rejected — always-on cost is unjustified for a periodic workload; adds Kubernetes or container orchestration overhead.
- **Azure Logic Apps**: Rejected — insufficient support for custom C# logic and AI SDK integration; low debuggability.
- **Azure Container Apps (scheduled jobs)**: Viable future option if cold-start latency becomes a constraint, but premature at current scale.

## Consequences

Cold starts are possible on the Consumption Plan. Acceptable because the timer trigger fires on a fixed schedule and a delay of 1–2 seconds is not user-facing.
