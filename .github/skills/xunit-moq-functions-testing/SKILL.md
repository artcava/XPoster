---
name: xunit-moq-functions-testing
description: 'Use when writing or reviewing tests in XPoster: xUnit + Moq conventions for function orchestration, schedule mapping, sender behavior, and service edge cases.'
---

# xUnit + Moq Testing For XPoster

Use this skill for all test strategy and test code in XPoster.

## Stack

- Test framework: xUnit
- Mocking: Moq

## Priorities

- XFunction orchestration success/failure paths
- GeneratorFactory schedule mapping
- generator generation/post behavior under success/failure
- sender plugin behavior and failure semantics
- service-level edge cases for external API responses

## Style Rules

- Follow Arrange / Act / Assert.
- Keep tests focused and deterministic.
- Prefer behavior assertions over implementation details.
- Avoid broad integration setup when unit tests are sufficient.

## Coverage Checklist

- Happy path
- Error path
- Null/invalid output handling
- Unmapped or disabled schedule behavior
