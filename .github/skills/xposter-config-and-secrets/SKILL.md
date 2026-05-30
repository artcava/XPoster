---
name: xposter-config-and-secrets
description: 'Use when changing configuration or credentials in XPoster: app settings boundaries, local.settings handling, secret hygiene, and deployment-safe configuration changes.'
---

# XPoster Configuration And Secrets

Use this skill for configuration and credential handling changes.

## Principles

- Keep secrets out of source code.
- Keep runtime configuration externalized.
- Keep local developer configuration separate from committed templates.

## Rules

- Use app settings for runtime values.
- Keep local.settings for local execution only.
- Update local.settings.json.example and docs when config contracts change.
- Never log raw tokens, keys, or sensitive credential values.

## Change Safety

- Validate required settings are documented.
- Keep defaults explicit where safe.
- Avoid behavior that depends on hidden implicit configuration.

## Validation Checklist

- New settings are documented.
- Secret-bearing values are never hardcoded.
- Runtime and local configuration behavior is predictable.
