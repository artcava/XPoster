# Changelog

All notable changes to XPoster will be documented in this file.

Format based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Unreleased]

### Changed
- **`AzureFoundryService.GenerateImageAsync` hardened** to match `FalAiImageService` as the reference implementation ([#139](https://github.com/artcava/XPoster/issues/139)):
  - Added 429 intercept before the success check, consistent with `GetSummaryAsync` and `GetImagePromptAsync` in the same class.
  - Wrapped `ReadFromJsonAsync<JsonElement>` in `try/catch (JsonException)` to handle malformed API responses without throwing.
  - Added `null`-check and `try/catch (FormatException)` around `Convert.FromBase64String` for the `b64_json` path.
  - Added origin validation for the `url` fallback: emits `LogWarning` with the full URL when the download origin does not match `_options.Endpoint`, enabling audit in Application Insights; download proceeds as defence-in-depth.
  - Wrapped `GetByteArrayAsync` in `try/catch (HttpRequestException)` on the `url` fallback path.
  - Added explicit `LogError` when the response data entry contains neither `b64_json` nor `url`.
- **`OpenAiService.GenerateImageAsync` hardened** ([#139](https://github.com/artcava/XPoster/issues/139)):
  - Added `string.IsNullOrWhiteSpace(prompt)` guard at method entry, consistent with `FalAiImageService`.
- **Prompt guard added to `AzureFoundryService.GenerateImageAsync`** ([#139](https://github.com/artcava/XPoster/issues/139)): rejects empty or whitespace-only prompts with `LogWarning` before any HTTP call, matching the pattern already in `FalAiImageService` and the newly updated `OpenAiService`.
- **Extracted `AiServiceHelper.ParseChatCompletionResponseAsync`** ([#158](https://github.com/artcava/XPoster/issues/158)): the five-step HTTP-response guard pipeline (429 intercept → non-2xx guard → JSON deserialisation → null/empty `choices` guard → content trim) was duplicated verbatim across `OpenAiService`, `AzureFoundryService`, and `DeepSeekService`; consolidated into a single `internal static` helper in `src/Services/AiServiceHelper.cs`; all three services updated to delegate to it. Log messages standardised to structured logging across all call sites.

### Fixed
- **`AiServiceHelper` — `JsonException` on missing `choices` property** ([#158](https://github.com/artcava/XPoster/issues/158)): `OpenAIResponse.choices` is declared `required`, causing `ReadFromJsonAsync<OpenAIResponse>` to throw `JsonRequiredPropertyMissingException` (a `JsonException` subtype) when the API returns `{}` or any body without `choices`; the deserialisation call is now wrapped in `try/catch (JsonException)` and returns `(false, string.Empty)` instead of propagating the exception.
- **`AzureFoundryService.GenerateImageAsync` — missing prompt guard** ([#158](https://github.com/artcava/XPoster/issues/158)): empty or whitespace-only prompts now return `Array.Empty<byte>()` immediately without making any HTTP call, consistent with `OpenAiService` and `FalAiImageService`.
- **`AzureFoundryService.GenerateImageAsync` — unhandled malformed JSON** ([#158](https://github.com/artcava/XPoster/issues/158)): `ReadFromJsonAsync<JsonElement>` now wrapped in `try/catch (JsonException)`; returns empty array on parse failure.
- **`OpenAiService.GenerateImageAsync` — missing prompt guard** ([#158](https://github.com/artcava/XPoster/issues/158)): same `string.IsNullOrWhiteSpace(prompt)` guard added, mirroring `AzureFoundryService`.
- **`OpenAiService.GenerateImageAsync` — unguarded `data` array access** ([#158](https://github.com/artcava/XPoster/issues/158)): `data[0]` access now preceded by `GetArrayLength() == 0` check; returns empty array instead of throwing `IndexOutOfRangeException`.
- **`OpenAiService.GenerateImageAsync` — null `b64_json` dereference** ([#158](https://github.com/artcava/XPoster/issues/158)): `b64Property.GetString()` null check added before `Convert.FromBase64String`; returns empty array instead of throwing `ArgumentNullException`.
- **`OpenAiService.GenerateImageAsync` — unhandled malformed JSON** ([#158](https://github.com/artcava/XPoster/issues/158)): `ReadFromJsonAsync<JsonElement>` now wrapped in `try/catch (JsonException)`; returns empty array on parse failure.

### Added
- Dynamic GitHub Actions build status badge in README ([#35](https://github.com/artcava/XPoster/issues/35))
- This CHANGELOG.md file ([#36](https://github.com/artcava/XPoster/issues/36))
- **Agent graph generation**: new `regenerate-agent-graph.yml` workflow runs as a PR check on every PR targeting `develop`; generates a `graphify-dotnet` knowledge graph (wiki, report, JSON) and uploads it as a downloadable Actions artifact for pre-merge review ([#141](https://github.com/artcava/XPoster/issues/141))
- **Agent graph persistence**: new `persist-agent-graph.yml` workflow runs on every push to `develop`; commits the regenerated graph directly to `develop` using `BOT_PAT` to bypass branch protection; uses `[skip ci]` and `paths-ignore` to prevent CI loops ([#141](https://github.com/artcava/XPoster/issues/141), [#149](https://github.com/artcava/XPoster/issues/149))
- `docs/agent-graph/NOTICE.md` auto-generated by both graph workflows to annotate node types (source code, documentation, infrastructure, generated) for LLM consumers ([#141](https://github.com/artcava/XPoster/issues/141))
- `BOT_PAT` repository secret: fine-grained Personal Access Token with `Contents: Read & Write` scope, required by `persist-agent-graph.yml` to push directly to the protected `develop` branch
- `docs/` folder reorganisation: analysis sub-folder reordered ([#143](https://github.com/artcava/XPoster/pull/143))
- `docs/agent-graph.md`: new unified guide explaining what the agent graph is, node types, output formats, CI workflow, and how to use it with AI coding assistants; merges and supersedes `docs/integrations/graphify-ci.md`

### Changed (continued)
- `regenerate-agent-graph.yml` trigger changed from `pull_request[closed]` (post-merge) to `pull_request[opened, synchronize, reopened]` (pre-merge PR check); removed `peter-evans/create-pull-request` step that was the root cause of the CI loop ([#149](https://github.com/artcava/XPoster/issues/149))
- `persist-agent-graph.yml` checkout step updated to use `BOT_PAT` token; `permissions.contents` downgraded to `read` (actual write delegated to the token) ([#149](https://github.com/artcava/XPoster/issues/149))
- `docs/index.md`: replaced `graphify-ci.md` row with `agent-graph.md` in the Integrations section
- `README.md`: added agent graph callout in the Architecture section

### Fixed (continued)
- **CI loop on `develop`**: merging the auto-generated `chore/regenerate-agent-graph` PR was re-triggering the same workflow indefinitely; resolved by splitting generation (PR check) and persistence (push trigger) into two separate workflows with explicit loop-prevention guards ([#149](https://github.com/artcava/XPoster/issues/149))
- `graphify-dotnet` install failure: tool requires .NET 10 SDK; `setup-dotnet` now pinned to `10.0.x`; install moved to `/tmp` to bypass `global.json` which pins the SDK to 8.0.x ([#144](https://github.com/artcava/XPoster/pull/144), [#145](https://github.com/artcava/XPoster/pull/145), [#146](https://github.com/artcava/XPoster/pull/146))
- `regenerate-agent-graph.yml` NOTICE.md: corrected Generated nodes description from "every merge to develop" to "every PR against develop (pre-merge preview)" to accurately reflect the workflow trigger

### Tests
- **`AiServiceHelperTests`**: new test class covering `ParseChatCompletionResponseAsync` in isolation — 429 guard returns `(false, empty)` and logs `Information`; non-2xx codes (`[Theory]` with 400, 500, 502, 503) return `(false, empty)`; `choices: null` and `choices: []` return `(false, empty)`; body `{}` (missing `required` property) returns `(false, empty)` via `JsonException` catch; happy path returns `(true, trimmed content)`; whitespace-only content returns `(true, empty)`; non-2xx logs provider name and status code; empty choices logs `Warning` with provider name ([#158](https://github.com/artcava/XPoster/issues/158))
- **`OpenAiServiceTests`**: added G2 (`WhenResponseBodyIsMalformedJson`), G3 (`WhenDataArrayIsEmpty`), G4 (`WhenB64JsonIsNull`), G7 (`WhenPromptIsEmpty`), G8 (`WhenPromptIsWhitespace`) — verify that `GenerateImageAsync` handles all degenerate API responses without throwing and returns empty array; G7/G8 additionally assert zero HTTP calls ([#158](https://github.com/artcava/XPoster/issues/158))
- **`AzureFoundryServiceTests`**: added G2 (`WhenResponseBodyIsMalformedJson`), G3 (`WhenDataArrayIsEmpty`), G4 (`WhenB64JsonIsNull`), G5 (`WhenB64JsonAbsentAndUrlPresent`), G6 (`WhenFallbackUrlIsFromDifferentOrigin_LogsWarning`), G7 (`WhenPromptIsEmpty`), G8 (`WhenPromptIsWhitespace`) for `GenerateImageAsync` ([#158](https://github.com/artcava/XPoster/issues/158))
- **`OpenAiServiceTests`**: added G7 (`WhenPromptIsEmpty`) and G8 (`WhenPromptIsWhitespace`) — verify that `GenerateImageAsync` returns an empty array and makes zero HTTP calls when the prompt is blank ([#139](https://github.com/artcava/XPoster/issues/139))
- **`AzureFoundryServiceTests`**: added G2–G8 for `GenerateImageAsync` — malformed JSON (G2), empty `data` array (G3), `b64_json: null` (G4), `url` fallback download (G5), cross-origin `url` fallback emits `LogWarning` (G6), empty prompt (G7), whitespace-only prompt (G8) ([#139](https://github.com/artcava/XPoster/issues/139))

---

## [0.1.2] - 2026-06-11

### Added
- **DeepSeek provider**: new `DeepSeekService` implementing `IAiService` for text generation (chat completions via DeepSeek API); `FalAiImageService` for image generation via fal.ai; `HybridAiService` combining both into a single `IAiService` delegate ([#127](https://github.com/artcava/XPoster/issues/127))
- **Azure Foundry provider**: new `AzureFoundryService` implementing `IAiService` with `AzureFoundryOptions`, DI registration and setup guide in `docs/setup-azure-foundry.md` ([#119](https://github.com/artcava/XPoster/issues/119), [#120](https://github.com/artcava/XPoster/issues/120))
- **LinkedIn organization page support** in `InSender`: new `ResolveAuthorUrn()` helper returns `urn:li:organization:{IN_ORG_ID}` when `IN_ORG_ID` is set, falling back to personal URN ([#71](https://github.com/artcava/XPoster/issues/71), [#96](https://github.com/artcava/XPoster/issues/96))
- `DeepSeekOptionsValidator`: startup validation for required fields and prompt placeholder format ([#127](https://github.com/artcava/XPoster/issues/127))
- Setup guides for all AI providers: `docs/setup-openai.md`, `docs/setup-deepseek.md`, `docs/setup-falai.md`, `docs/setup-azure-foundry.md`
- `global.json` pinning SDK to .NET 8.0.421 to resolve MSB4011 warnings
- `NuGet.Config` pinning package restore to nuget.org only ([#99](https://github.com/artcava/XPoster/issues/99))

### Changed
- **`IAiService` contract**: all three methods (`GetSummaryAsync`, `GetImagePromptAsync`, `GenerateImageAsync`) now accept an optional `CancellationToken` parameter; propagated through all implementations (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `HybridAiService`, `FalAiImageService`) and `FeedGenerator` ([#123](https://github.com/artcava/XPoster/issues/123))
- **`AiServiceFactory`** (`IAiServiceFactory`): resolves the correct `IAiService` implementation by `AiProvider` enum value at runtime; replaces direct DI registration of a single provider ([#100](https://github.com/artcava/XPoster/issues/100))
- **`GeneratorFactory`** refactored to use `List<ScheduledGenerationProfile>` (Hour, SenderType, GeneratorType, AiProvider?) instead of `Dictionary<int, MessageSender>`; AI service and sender resolved independently via `AiServiceFactory` ([#100](https://github.com/artcava/XPoster/issues/100))
- `OpenAiOptions`: all OpenAI endpoints, model names and parameters externalised from `OpenAiService` into a configuration class; bound from `OpenAI__*` double-underscore env vars; prompt templates also externalised with startup placeholder validation ([#88](https://github.com/artcava/XPoster/issues/88), [#89](https://github.com/artcava/XPoster/issues/89))
- `AiService` renamed to `OpenAiService`; DI registration and test file updated accordingly ([#87](https://github.com/artcava/XPoster/issues/87))
- `MessageSender.IgPowerLow` enum value renamed to `IgPowerLaw` (typo fix); factory switch case updated ([#108](https://github.com/artcava/XPoster/issues/108))
- GitHub Actions upgraded to Node.js 24 compatible versions: `actions/checkout` v5, `actions/setup-dotnet` v5, `actions/upload-artifact` v6, `softprops/action-gh-release` v3, `azure/login` v3, `Azure/functions-action` v1.5.6 ([#122](https://github.com/artcava/XPoster/issues/122), [#137](https://github.com/artcava/XPoster/issues/137))

### Fixed
- **Empty `choices[]` guard**: `GetSummaryAsync` and `GetImagePromptAsync` in all three chat-based services (`OpenAiService`, `DeepSeekService`, `AzureFoundryService`) now return `string.Empty` instead of throwing `IndexOutOfRangeException` when the API returns `"choices": []` (content-policy refusals, partial API errors) ([#124](https://github.com/artcava/XPoster/issues/124))
- Azure Functions isolated deployment artifacts: corrected publish path for `ci.yml` deploy step ([#102](https://github.com/artcava/XPoster/issues/102))
- Keyed DI resolution for AI service in `Program.cs` ([#104](https://github.com/artcava/XPoster/issues/104))
- Removed unused `System.ServiceModel.Syndication` package dependency ([#85](https://github.com/artcava/XPoster/issues/85))

### Tests
- Empty-choices guard tests for `DeepSeekService`, `OpenAiService`, and `AzureFoundryService` ([#124](https://github.com/artcava/XPoster/issues/124))
- `AiServiceFactoryTests`, missing `FeedGenerator` null-safety cases, `GeneratorFactory` factory interaction tests ([#100](https://github.com/artcava/XPoster/issues/100))
- `DeepSeekOptionsValidator`, `DeepSeekOptions`, `DeepSeekService` and `HybridAiService` tests ([#127](https://github.com/artcava/XPoster/issues/127))
- `CancellationToken` propagation tests updated across all `IAiService` mock setups ([#123](https://github.com/artcava/XPoster/issues/123))

---

## [0.1.1] - 2026-04-08

### Changed
- **Image generation migrated from DALL-E 3 to `gpt-image-1`**: replaced `AzureOpenAIClient` (Azure OpenAI SDK) with `HttpClient` + `System.Text.Json` calling the OpenAI Direct API; removed `Azure.AI.OpenAI` and `OpenAI.Images` package dependencies ([#24](https://github.com/artcava/XPoster/issues/24), [#25](https://github.com/artcava/XPoster/issues/25))
- OpenAI models updated to **`gpt-4.1-nano`** (text) and **`gpt-image-1.5`** (image) ([#68](https://github.com/artcava/XPoster/issues/68))
- `CONTRIBUTING.md`: explicit rule to always branch from `develop`; PR checklist updated ([#79](https://github.com/artcava/XPoster/issues/79))
- `README.md` and all docs aligned to actual environment variable names: `IN_*`, `IG_*`, `OPENAI_*` ([#70](https://github.com/artcava/XPoster/issues/70))
- Directory tree diagrams in `README.md` and `tests/README.md` updated to match actual project structure ([#74](https://github.com/artcava/XPoster/issues/74))

### Fixed
- Removed unsupported `response_format` parameter from image generation request body (`gpt-image-1` always returns `b64_json` by default); switched model from `gpt-image-1-mini` (unavailable on direct OpenAI API) to `gpt-image-1` ([#26](https://github.com/artcava/XPoster/issues/26))
- Added missing `issues: write` and `pull-requests: write` permissions to the `issue-management` workflow ([#83](https://github.com/artcava/XPoster/issues/83))

---

## [0.1.0] - 2026-03-30

### Added
- **Azure Key Vault + Managed Identity infrastructure**: Bicep IaC provisioning `xposter-kv` vault and system-assigned managed identity for Azure Functions ([#54](https://github.com/artcava/XPoster/issues/54))
- LinkedIn credentials (`LINKEDIN_ACCESS_TOKEN`, `LINKEDIN_CLIENT_ID`, `LINKEDIN_CLIENT_SECRET`) migrated to **Azure Key Vault References**; `KEYVAULT_URI` App Setting added; resolved transparently at Azure Functions startup — no code changes required ([#55](https://github.com/artcava/XPoster/issues/55))
- GitHub Actions CI/CD pipeline (`ci.yml`): build, test-gate, and deployment to Azure Functions; auto-delete merged feature branches ([#45](https://github.com/artcava/XPoster/issues/45))
- LinkedIn access token expiry reminder workflow (automated GitHub issue before token expiry)
- `CRON_EXPRESSION` externalised as environment variable (previously hardcoded)
- `src/local.settings.json.example` with all required keys, placeholder values and inline comments grouped by service (X, LinkedIn, Instagram, Azure OpenAI) ([#29](https://github.com/artcava/XPoster/issues/29))
- `docs/` folder: `index.md`, `getting-started.md`, `configuration.md`, `deployment.md`, `extending-xposter.md`, `monitoring.md` ([#30](https://github.com/artcava/XPoster/issues/30))
- `docs/architecture.md` with ADRs (001–004), design pattern rationale and Mermaid data-flow diagram ([#28](https://github.com/artcava/XPoster/issues/28))
- `tests/README.md` with testing strategy, conventions and coverage goals ([#31](https://github.com/artcava/XPoster/issues/31))
- GitHub issue/PR templates: `bug_report.md`, `feature_request.md`, `documentation.md`, `PULL_REQUEST_TEMPLATE.md` ([#32](https://github.com/artcava/XPoster/issues/32))
- Versioning baseline `0.1.0` set in `XPoster.csproj` ([#49](https://github.com/artcava/XPoster/issues/49))

### Changed
- `README.md` translated to English ([#20](https://github.com/artcava/XPoster/issues/20))
- CI: `dotnet test` added as mandatory gate before deployment ([#22](https://github.com/artcava/XPoster/issues/22))
- CI coverage threshold raised progressively: 0% → 50% → **70%** (actual line coverage reached: 72.1%) ([#62](https://github.com/artcava/XPoster/issues/62))

### Fixed
- **Nullable Reference Types**: resolved all `CS86xx` warnings across `src/` and `tests/` (`CS8602`, `CS8609`, `CS8620`, `CS8625`, `xUnit2013`) ([#46](https://github.com/artcava/XPoster/issues/46))
- `BaseGenerator.PostAsync`: changed from blocking (`return false`) to graceful degradation (log warning + continue) when image generation fails and `ProduceImage` is `true` ([#22](https://github.com/artcava/XPoster/issues/22))
- `FeedGenerator`: added `try-catch` around `GenerateImageAsync`; post is published without image on failure instead of being suppressed ([#22](https://github.com/artcava/XPoster/issues/22))
- Extra semicolon in `BaseGenerator` causing compilation error ([#22](https://github.com/artcava/XPoster/issues/22))
- `RSSFeed` required members (`Title`, `Content`, `Link`) aligned in tests to match actual record definition ([#62](https://github.com/artcava/XPoster/issues/62))
- `CS9007` raw string interpolation in `AiServiceTests` replaced with standard string concatenation ([#62](https://github.com/artcava/XPoster/issues/62))

### Tests
- Line coverage raised from 0% to **72.1%** with new test suites: `AiServiceTests`, `InSenderGeneratePayLoadTests`, `IgSenderMissingBranchTests`, `XSenderMissingBranchTests`, `ModelsMissingTests`, `BaseGeneratorTests`, `NoGeneratorTests`, `IgSenderTests`, `XFunction` missing branch tests ([#51](https://github.com/artcava/XPoster/issues/51), [#52](https://github.com/artcava/XPoster/issues/52), [#62](https://github.com/artcava/XPoster/issues/62))

---

<!-- Links -->
[Unreleased]: https://github.com/artcava/XPoster/compare/v0.1.2...HEAD
[0.1.2]: https://github.com/artcava/XPoster/compare/v0.1.1...v0.1.2
[0.1.1]: https://github.com/artcava/XPoster/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/artcava/XPoster/releases/tag/v0.1.0
