# Changelog

All notable changes to XPoster will be documented in this file.

Format based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Unreleased]

### Added
- Dynamic GitHub Actions build status badge in README ([#35](https://github.com/artcava/XPoster/issues/35))
- This CHANGELOG.md file ([#36](https://github.com/artcava/XPoster/issues/36))

### Removed
- `PR_BODY.md` from repository root — redundant with `.github/PULL_REQUEST_TEMPLATE.md`

---

## [0.1.2] - 2026-03-24

### Added
- `docs/` folder with full versioned documentation: `index.md`, `getting-started.md`, `configuration.md`, `deployment.md`, `extending-xposter.md`, `monitoring.md` (closes [#30](https://github.com/artcava/XPoster/issues/30))
- `tests/README.md` with testing strategy, conventions, and coverage goals (closes [#31](https://github.com/artcava/XPoster/issues/31))
- `CONTRIBUTING.md` updated with secrets handling guidance and good-first-issue section (closes [#32](https://github.com/artcava/XPoster/issues/32))
- GitHub issue/PR templates: `bug_report.md`, `feature_request.md`, `documentation.md`, `PULL_REQUEST_TEMPLATE.md`
- `src/local.settings.json.example` template with all required keys and inline documentation (closes [#29](https://github.com/artcava/XPoster/issues/29))
- `docs/architecture.md` with ADRs, design pattern rationale, and Mermaid data-flow diagram (closes [#28](https://github.com/artcava/XPoster/issues/28))
- XML documentation comments across all C# source files (`Abstraction/`, `Models/`, `Implementation/`, `Services/`, `SenderPlugins/`) with `GenerateDocumentationFile` enabled in `.csproj` (closes [#27](https://github.com/artcava/XPoster/issues/27))

### Changed
- README Table of Contents updated to reference `docs/architecture.md`
- README footer: empty wiki link replaced with `docs/index.md`

---

## [0.1.1] - 2026-03-18

### Changed
- Image generation migrated from DALL-E 3 (Azure OpenAI SDK) to `gpt-image-1` via OpenAI Direct API using `HttpClient` + `System.Text.Json` (closes [#24](https://github.com/artcava/XPoster/issues/24), [#25](https://github.com/artcava/XPoster/issues/25))
- Removed unsupported `response_format` parameter from image generation request body (fixes [#26](https://github.com/artcava/XPoster/issues/26))
- Switched model from `gpt-image-1-mini` to `gpt-image-1` (not available on direct OpenAI API)
- Added GitHub Actions `issues: write` and `pull-requests: write` permissions to issue-management workflow

---

## [0.1.0] - 2025-11-30

### Fixed
- Image generation failure no longer blocks message posting — graceful degradation implemented in `FeedGenerator` and `BaseGenerator` ([#22](https://github.com/artcava/XPoster/issues/22))
- Fixed extra semicolon causing compilation error in `BaseGenerator`

### Changed
- `BaseGenerator.PostAsync` changed from blocking (return false) to warning (log and continue) when image is null
- CI/CD workflow updated to run `dotnet test` before deployment

### Tests
- Updated `FeedGeneratorTests` to reflect new graceful image failure behavior

---

<!-- Links -->
[Unreleased]: https://github.com/artcava/XPoster/compare/v0.1.2...HEAD
[0.1.2]: https://github.com/artcava/XPoster/compare/v0.1.1...v0.1.2
[0.1.1]: https://github.com/artcava/XPoster/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/artcava/XPoster/releases/tag/v0.1.0
