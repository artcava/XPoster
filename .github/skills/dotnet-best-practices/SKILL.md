---
name: dotnet-best-practices
description: 'Ensure .NET/C# code meets best practices for the solution/project.'
---

# .NET/C# Best Practices For XPoster

Use this skill when reviewing or improving C# code in XPoster.

XPoster is an Azure Functions v4 app using the .NET isolated worker model on .NET 8. Favor guidance that preserves timer-trigger orchestration, current abstractions, and plugin boundaries.

## Project Alignment Rules

- Keep function entrypoints thin and orchestration-focused.
- Preserve the current Strategy + Factory + Plugin model.
- Keep business logic in generators, services, and sender plugins.
- Do not introduce unrelated architectural patterns unless explicitly requested.

## Runtime And Framework

- Target .NET 8 conventions and Azure Functions isolated worker patterns.
- Keep nullable reference handling intentional.
- Prefer async APIs for all I/O paths.
- Add CancellationToken at new I/O boundaries when signatures allow.

## Dependency Injection And Composition

- Register dependencies centrally in Program startup composition.
- Reuse existing abstraction contracts before adding new interfaces.
- Keep service lifetimes consistent with current usage and runtime behavior.

## External HTTP And Resilience

- Use HttpClientFactory-based patterns for outbound calls.
- Handle transient failures (429, 5xx, timeout) with sensible retry/backoff behavior.
- Respect server retry hints where available.
- Never hardcode secrets or tokens.

## Logging And Observability

- Use structured logs with meaningful context fields.
- Log events that help diagnose generator selection, publish outcome, and failures.
- Avoid logging sensitive data or full raw payloads containing secrets.

## Testing Standards

- Use the repository test stack: xUnit + Moq.
- Follow Arrange / Act / Assert with focused, deterministic tests.
- Prioritize tests for:
	- XFunction orchestration success and failure paths
	- GeneratorFactory schedule mapping
	- sender success/failure semantics
	- service edge cases for external API responses

## Documentation Sync

- When behavior changes affect scheduling, configuration, plugin contracts, or runtime flow, update relevant docs in the same change set.

## Quality Guardrails

- Prefer small, reviewable diffs.
- Avoid broad refactors unless explicitly requested.
- Keep naming and folder conventions consistent with the repository.
