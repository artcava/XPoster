---
name: httpclient-resilience-dotnet
description: 'Use when implementing outbound HTTP calls in XPoster: HttpClientFactory usage, timeout/retry behavior, transient fault handling, and safe logging patterns.'
---

# HttpClient Resilience For XPoster

Use this skill for outbound HTTP integrations in services and sender plugins.

## Core Rules

- Prefer HttpClientFactory-based usage patterns.
- Set explicit timeouts and honor cancellation tokens where possible.
- Handle 429, 5xx, and network failures with sensible retry/backoff.
- Respect server-provided retry hints.

## Safety And Logging

- Do not log secrets or full sensitive payloads.
- Log enough context for troubleshooting (endpoint category, status code, path outcome).
- Keep retry behavior visible but not noisy.

## Performance

- Avoid per-call client construction anti-patterns.
- Avoid unbounded parallel outbound fan-out.

## Validation Checklist

- Failure behavior is deterministic and testable.
- Cancellation and timeout paths are covered.
- Logs provide actionable failure diagnostics.
