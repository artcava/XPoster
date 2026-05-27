---
name: azure-functions-timer-trigger
description: 'Use when implementing or reviewing timer schedule behavior in XPoster: NCRONTAB, timezone handling, startup behavior, past-due handling, and schedule reliability.'
---

# Azure Functions Timer Trigger For XPoster

Use this skill for schedule-driven behavior and timer-trigger correctness.

## Scope

- NCRONTAB schedule expressions
- schedule app settings usage
- timezone behavior and operational implications
- past-due invocation handling
- startup-trigger safety

## Rules

- Keep schedule values externalized in app settings.
- Treat timer invocations as schedule-driven orchestration, not ad-hoc execution.
- Avoid run-on-startup behavior unless explicitly requested.
- Preserve clear logs for start/end, selected path, and failure reasons.

## Reliability Guidance

- Ensure schedule changes are reflected in GeneratorFactory tests.
- Validate behavior for unmapped time slots.
- Handle missed or delayed invocations defensively.

## Validation Checklist

- Cron expression and timezone assumptions are explicit.
- Schedule changes include test updates.
- Function behavior is deterministic for each time slot.
