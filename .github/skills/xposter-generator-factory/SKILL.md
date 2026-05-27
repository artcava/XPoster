---
name: xposter-generator-factory
description: 'Use when changing generator selection logic in XPoster: schedule mapping, generator ownership boundaries, and safe extension of GeneratorFactory behavior.'
---

# XPoster Generator Factory Conventions

Use this skill when changing GeneratorFactory or generator selection behavior.

## Core Principles

- GeneratorFactory is the central selector for schedule-based behavior.
- Generators are responsible for content production, not platform publishing.
- Sender plugins own platform-specific publish behavior.

## Change Rules

- Keep slot-to-generator mapping centralized.
- Keep behavior explicit for unmapped slots.
- Avoid scattering schedule logic across multiple classes.
- Extend existing abstractions before introducing new selector layers.

## Test Expectations

- Add or update tests for each modified slot behavior.
- Cover success and no-op paths.
- Cover failure propagation from generation/post flow where relevant.

## Review Checklist

- Factory remains single source of truth for selection.
- Generator responsibilities remain cohesive.
- Changes are minimal and reviewable.
