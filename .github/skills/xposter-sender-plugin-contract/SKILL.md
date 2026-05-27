---
name: xposter-sender-plugin-contract
description: 'Use when implementing or reviewing sender plugins in XPoster: sender boundaries, platform constraints, publish semantics, and failure handling consistency.'
---

# XPoster Sender Plugin Contract

Apply this skill to sender plugin changes and platform publish integrations.

## Contract Principles

- Sender plugins encapsulate platform-specific API behavior.
- Generators should not contain platform API logic.
- Sender constraints (length, payload shape, API requirements) belong in sender layer.

## Implementation Rules

- Validate input content before publish calls.
- Keep authentication and tokens in configuration, never in code.
- Avoid logging secrets, tokens, or sensitive payloads.
- Return clear publish outcome semantics for caller flow.

## Failure Handling

- Handle transient HTTP/API failures predictably.
- Respect retry hints where available.
- Emit operationally useful logs on failure paths.

## Validation Checklist

- Sender boundary remains intact.
- Platform constraints are localized to sender.
- Tests cover sender success and failure outcomes.
