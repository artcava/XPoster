---
name: azure-functions-isolated-worker
description: 'Use when working on Azure Functions .NET isolated worker in XPoster: Program setup, DI, bindings, worker configuration, and runtime-safe implementation patterns.'
---

# Azure Functions Isolated Worker For XPoster

Apply this skill for architecture and implementation decisions tied to the .NET isolated worker model.

## Scope

- Program startup composition
- Function class design and trigger boundaries
- Dependency injection in isolated worker
- Configuration boundaries between app code and host runtime
- Safe runtime behavior for timer-triggered workflows

## Rules

- Keep function classes thin and orchestration-focused.
- Keep business logic in generators, services, and sender plugins.
- Register dependencies in Program startup composition.
- Do not introduce HTTP/minimal API patterns unless explicitly required.
- Avoid framework changes that alter runtime model unless requested.

## Configuration Guidance

- Keep function host settings in host.json where appropriate.
- Keep app settings and secrets externalized.
- Avoid hardcoded runtime settings in code.

## Validation Checklist

- Function method remains clear and minimal.
- DI registration is intentional and used.
- New behavior is testable with existing xUnit + Moq stack.
- Logging remains useful for runtime diagnostics.
