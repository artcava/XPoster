---
name: appinsights-functions-observability
description: 'Use when improving observability in XPoster: Application Insights-compatible structured logging, category clarity, and diagnostics for schedule/generator/sender execution paths.'
---

# Functions Observability For XPoster

Use this skill for logging, telemetry, and diagnostics guidance.

## Objectives

- Keep logs actionable for runtime troubleshooting.
- Preserve compatibility with current Application Insights integration.
- Improve diagnostic clarity for schedule-driven orchestration.

## Logging Rules

- Use structured logs with meaningful fields.
- Log lifecycle points relevant to operations:
  - function start/end
  - selected generator and sender
  - generation success/failure
  - publish success/failure
- Avoid noisy logs and sensitive payload data.

## Diagnostic Guidance

- Ensure failures include enough context to identify the failing stage.
- Keep exception logging consistent and clear.
- Maintain useful signal-to-noise ratio for production monitoring.

## Validation Checklist

- Logs support root-cause analysis without exposing secrets.
- Telemetry remains consistent after behavior changes.
