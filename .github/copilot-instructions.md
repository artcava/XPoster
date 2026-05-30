# Copilot Instructions For XPoster

## Objective
Generate code changes that preserve XPoster architecture, runtime behavior, and operational reliability for an Azure Functions timer-triggered app.

## Project Type And Runtime
- This repository is an Azure Functions app using .NET isolated worker.
- Treat this project as serverless orchestration.
- Keep guidance aligned with .NET 8 and Azure Functions v4 unless explicitly requested otherwise.

## Architecture Rules
- Keep function entrypoints thin: orchestration belongs in function classes, business logic belongs in generators/services/senders.
- Preserve current Strategy + Factory + Plugin model.
- Prefer extending existing abstractions over adding parallel patterns.

## Function Execution Rules
- Respect timer-trigger behavior and schedule-driven execution model.
- Keep schedule configuration externalized via app settings.
- Avoid startup-triggered execution behavior in production-oriented changes unless explicitly required.
- Maintain clear failure semantics: log actionable context, avoid silent failures, preserve expected runtime observability

## Dependency Injection And Composition
- Register dependencies centrally in Program startup composition.
- Reuse existing abstraction contracts and concrete registrations when extending behavior.
- Keep service lifetimes intentional and consistent with current app design.
- Avoid introducing service registrations that are unused or duplicate existing responsibilities

## External API And HTTP Rules
- Use HttpClientFactory-based patterns for outbound HTTP integrations
- For transient failures (429/5xx/timeouts), favor resilient handling and respect server retry hints when available.
- Keep authentication and secrets in configuration/app settings and never hardcode secrets.
- Avoid logging sensitive tokens, keys, or full raw payloads that may contain secrets.

## Logging And Monitoring
- Use structured logs with meaningful context fields.
- Keep Application Insights/telemetry compatibility intact.
- Ensure logs are useful for diagnosing schedule, generator selection, publish outcome, and error paths.
- Prefer clear operational signals over verbose noise.

## Sender Plugin Conventions
- Platform-specific publishing logic belongs in sender plugins implementing shared sender contracts.
- Preserve sender boundary: generators produce content, senders publish content.
- Keep sender-specific constraints (message length, payload shape, API requirements) encapsulated in the sender layer.

## Generator And Factory Conventions
- Generator selection logic remains centralized in factory mapping.
- Any scheduling or slot behavior change should be reflected in corresponding tests.
- Keep generators focused on content production flow, not infrastructure wiring concerns.

## .NET And C# Conventions
- Keep nullable reference types enabled and address nullability intentionally.
- Prefer async APIs for I/O.
- Use CancellationToken on new I/O boundaries when feasible and consistent with existing signatures.
- Follow existing naming and folder conventions in the repository.

## Tests
- Add or update tests for every behavior change.
- Use xUnit + Moq patterns already present in the repository.
- Prefer focused Arrange/Act/Assert tests.
- Prioritize tests for:
  - function orchestration success/failure paths
  - generator selection and schedule mapping
  - sender behavior under success and failure conditions
  - service-level edge cases for external API responses

## Documentation Sync
- When changing runtime behavior, scheduling, plugin contracts, or configuration expectations, update repository docs in the same PR.

## Output Style
- Propose minimal, reviewable diffs.
- Avoid broad refactors unless explicitly requested.
- State assumptions clearly when requirements are ambiguous.

## Preferred Reference Sources
- Microsoft Learn: Azure Functions .NET isolated worker guide.
- Microsoft Learn: Azure Functions timer trigger reference.
- Microsoft Learn: Azure Functions monitoring and telemetry guidance.
- Microsoft Learn: HttpClientFactory and .NET outbound HTTP best practices.
- Official Azure Functions .NET worker samples for implementation patterns.
