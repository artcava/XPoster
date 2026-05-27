---
name: csharp-async
description: 'Use when implementing or reviewing async C# code in XPoster: Task-based APIs, cancellation, timeout handling, and sync-over-async avoidance in Azure Functions isolated workflows.'
---

# C# Async Best Practices For XPoster

Use this skill when implementing or reviewing asynchronous code in XPoster.

## Naming And Signatures

- Use the Async suffix for asynchronous methods.
- Return Task or Task<T> for asynchronous APIs.
- Avoid async void except event handlers.

## Azure Functions Isolated Context

- Keep async end-to-end across function orchestration, generators, services, and sender plugins.
- Avoid sync-over-async patterns (.Result, .Wait(), GetAwaiter().GetResult()).
- Treat cancellation as first-class at I/O boundaries when possible.

## Cancellation And Timeouts

- Accept and propagate CancellationToken where signatures allow.
- Use cancellation-aware APIs (for example Task.Delay with token).
- Prefer explicit timeout and cancellation composition over fire-and-forget behavior.

## Error Handling

- Do not swallow async exceptions.
- Log actionable context for operational failures.
- Rethrow or propagate failures when they must surface to runtime monitoring.

## Concurrency Patterns

- Use Task.WhenAll only for independent work with acceptable fan-out.
- Use Task.WhenAny for first-result and timeout workflows where justified.
- Avoid unbounded parallelism for outbound API calls.

## Performance And Reliability

- Avoid unnecessary async wrappers that only forward tasks.
- Consider ValueTask only when there is measured benefit.
- Keep memory allocations moderate on hot paths.

## Review Checklist

- No blocking calls in async flow.
- No lost tasks (all Task-returning calls are awaited or intentionally tracked).
- Cancellation tokens are propagated where feasible.
- Failure logs include enough context to diagnose schedule/generator/sender path.
