# Changelog

All notable changes to XPoster will be documented in this file.

Format based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Unreleased]

### Fixed
- **`PowerLawOrchestrator` — duplicate `Post.Firm` footer in published posts** ([#202](https://github.com/artcava/XPoster/issues/202)): `Post.Firm` was appended both inside `OrchestrateAsync()` and again by every sender plugin (`XSender`, `InSender`, `IgSender`), causing the firm footer to appear twice in all posts from slots `InPowerLaw` (hour 14) and `XPowerLaw` (hour 16). Removed `Post.Firm` from the orchestrator content string; the sender layer remains the single, authoritative place for appending the footer.

### Tests
- **`PowerLawOrchestratorTests`** ([#202](https://github.com/artcava/XPoster/issues/202)): `Assert.Contains("#XPoster #AI", ...)` replaced with `Assert.DoesNotContain(Post.Firm, ...)` to verify the orchestrator no longer embeds the firm footer in `post.Content`; `using XPoster.Models` added to reference `Post.Firm` directly instead of a magic string.

### Added
- **Azure Key Vault Configuration Provider** ([#195](https://github.com/artcava/XPoster/issues/195)): `AddAzureKeyVault` registered in `Program.cs` via an explicit `((IConfigurationBuilder)builder.Configuration)` cast (required because `FunctionsApplicationBuilder.Configuration` is a `ConfigurationManager` that implements `IConfigurationBuilder` but does not expose extension methods without the cast). Secrets are merged into `IConfiguration` at application startup using `DefaultAzureCredential`; no Key Vault calls occur at post-publish time.
- **`Azure.Extensions.AspNetCore.Configuration.Secrets` v1.4.0** added to `XPoster.csproj` ([#195](https://github.com/artcava/XPoster/issues/195)).
- **Typed sender credentials via `IOptions<T>`** ([#195](https://github.com/artcava/XPoster/issues/195)): `XCredentials`, `LinkedInCredentials`, and `IgCredentials` DTOs introduced in `src/Credentials/`; each bound flat from `IConfiguration` via `BindConfiguration(string.Empty)` with `ValidateOnStart()`. Senders receive credentials through constructor-injected `IOptions<TCredentials>` — no runtime Key Vault calls.

### Changed
- **`XSender`, `InSender`, `IgSender`** ([#195](https://github.com/artcava/XPoster/issues/195)): constructor signature updated — `IKeyVaultService` dependency replaced by `IOptions<XCredentials>`, `IOptions<LinkedInCredentials>`, and `IOptions<IgCredentials>` respectively. Credential values read once from `options.Value` at construction time.
- **`DryRunSender`** ([#195](https://github.com/artcava/XPoster/issues/195)): Key Vault connectivity probe (`GetSecretAsync("XApiKey")`) removed; sender now has no infrastructure dependency and logs post content directly without any startup side-effect.
- **`Program.cs`** ([#195](https://github.com/artcava/XPoster/issues/195)): `KeyVaultService` / `IKeyVaultService` registrations replaced by `AddAzureKeyVault` Configuration Provider + `AddOptions<TCredentials>().BindConfiguration(string.Empty).ValidateOnStart()` blocks for all three sender credential types.

### Removed
- **`IKeyVaultService`** (`src/Contracts/IKeyVaultService.cs`) and **`KeyVaultService`** (`src/Services/KeyVaultService.cs`) ([#195](https://github.com/artcava/XPoster/issues/195)): runtime secret-fetch abstraction superseded by the startup-time Configuration Provider pattern. All consumer references removed from senders, DI composition, and tests.

### Tests
- **`DryRunSenderTests`** ([#195](https://github.com/artcava/XPoster/issues/195)): rewritten — `IKeyVaultService` mock removed; tests cover null-post guard and dry-run success path using no infrastructure dependencies.
- **`XSenderTests`, `InSenderTests`, `IgSenderTests`** ([#195](https://github.com/artcava/XPoster/issues/195)): updated to supply credentials via `Options.Create(new TCredentials { … })` in place of the removed `IKeyVaultService` mock.
- **`KeyVaultServiceTests`** removed ([#195](https://github.com/artcava/XPoster/issues/195)): test class deleted together with the removed service.

---

## [0.1.4] - 2026-06-19

### Added
- **Per-provider `*OptionsExtensions.cs` files** ([#189](https://github.com/artcava/XPoster/issues/189)): `OpenAiOptionsExtensions`, `AzureFoundryOptionsExtensions`, `DeepSeekOptionsExtensions`, `FalAiOptionsExtensions`, and `PerplexityOptionsExtensions` introduced in `src/Models/<Provider>/`. Each exposes a `SectionName` constant and an `Add*Options(IServiceCollection, IConfiguration)` extension method that encapsulates both the `Configure<T>` binding and the `IValidateOptions<T>` startup-validation registration. `Program.cs` updated to call these extension methods in place of the previous inline `Configure<T>` + `AddSingleton<IValidateOptions<T>>` pairs.
- **`PerplexityService`** ([#91](https://github.com/artcava/XPoster/issues/91)): new `IAiService` implementation that targets the Perplexity Sonar Chat Completions API (`api.perplexity.ai/chat/completions`). Supports `GetSummaryAsync` and `GetImagePromptAsync`; `GenerateImageAsync` always returns `Array.Empty<byte>()` and emits a structured `Warning` log — posts are published text-only when this provider is active.
- **`PerplexityOptions`** and **`PerplexityOptionsValidator`** ([#91](https://github.com/artcava/XPoster/issues/91)): configuration model bound from `Perplexity__*` app settings, with startup validation of required fields and prompt-placeholder format; mirrors the existing `DeepSeekOptions` / `DeepSeekOptionsValidator` pattern.
- **Named `HttpClient` registration `"Perplexity"`** in `HttpClientExtensions` ([#91](https://github.com/artcava/XPoster/issues/91)): resilient client registered via `AddResilientHttpClient` with the same timeout profile as other AI provider clients.
- **`AiProvider.Perplexity`** activated in `AiServiceFactory` and `Program.cs` DI composition ([#91](https://github.com/artcava/XPoster/issues/91)).
- **`local.settings.json.example`** updated with `Perplexity__Endpoint`, `Perplexity__ApiKey`, and `Perplexity__DeploymentName` entries ([#91](https://github.com/artcava/XPoster/issues/91)).
- **`docs/integrations/setup-perplexity.md`** ([#91](https://github.com/artcava/XPoster/issues/91)): new integration guide covering account setup, API key generation, billing, model selection, XPoster configuration, Key Vault secret storage, dry-run verification, image generation behaviour, and troubleshooting.
- **`IFeedUrlProvider` abstraction + `ConfigurationFeedUrlProvider`** ([#185](https://github.com/artcava/XPoster/issues/185)): introduces `IFeedUrlProvider` (returns `IReadOnlyList<string>`) and `ConfigurationFeedUrlProvider` bound from `FeedOptions__Urls__N` app settings; `FeedOrchestrator` now resolves feed URLs via the injected provider instead of a hardcoded list; `local.settings.json.example` updated with example `FeedOptions__Urls__0` / `FeedOptions__Urls__1` entries.

### Changed
- **`docs/extending-xposter.md`** ([#189](https://github.com/artcava/XPoster/issues/189)): *Adding a New AI Provider* section updated with a mandatory **Step 4** describing the `*OptionsExtensions.cs` file shape, placement, and key rules (`SectionName` on the extension class, not the DTO; both registrations encapsulated in a single method; no raw `Configure<T>` literals for AI providers in `Program.cs`). *Design Constraints* updated with the corresponding invariant.
- **Source folder restructure** ([#186](https://github.com/artcava/XPoster/issues/186)): purely structural reorganisation of `src/` and `tests/` — no behavioral changes, no new public API surface, no changes to DI registrations or scheduling logic.
  - `src/Abstraction/` split into `src/Abstraction/` (base classes and shared profile records: `BaseOrchestrator`, `ScheduledOrchestrationProfile`) and `src/Contracts/` (all interfaces, enums, and extension methods: `I*.cs`, `AiProvider`, `AiProviderExtensions`, `Enums`). Namespace `XPoster.Abstraction` → `XPoster.Contracts` for moved files; all consumer `using` directives updated.
  - `src/Implementation/` renamed to `src/Orchestrators/` (concrete orchestrators, `OrchestratorFactory`, `AiServiceFactory`, slot profile providers). Namespace `XPoster.Implementation` → `XPoster.Orchestrators`; all consumer `using` directives updated.
  - `src/Models/` reorganised with provider subfolders (`AzureFoundry/`, `DeepSeek/`, `FalAi/`, `OpenAi/`) for discoverability; namespace `XPoster.Models` unchanged across all files.
  - `src/Services/` reorganised with an `Ai/` subfolder for AI model integration services (`OpenAiService`, `AzureFoundryService`, `DeepSeekService`, `FalAiImageService`, `HybridAiService`, `AiServiceHelper`); namespace `XPoster.Services` unchanged.
  - `tests/Abstraction/` renamed to `tests/Contracts/`; `tests/Implementation/` renamed to `tests/Orchestrators/` to mirror source layout.
  - Documentation updated: `README.md`, `tests/README.md`, `docs/extending-xposter.md` aligned to new folder paths and namespace names.
- **`docs/architecture.md`** — `PerplexityService` added to the *AI Provider Services* section; supported provider count updated from 4 to 5 ([#91](https://github.com/artcava/XPoster/issues/91)).
- **`docs/configuration.md`** — `Perplexity__*` settings documented; `AiProvider` enum table updated with `Perplexity` entry ([#91](https://github.com/artcava/XPoster/issues/91)).

### Fixed
- **`AzureFoundryService.GenerateImageAsync` — image generation endpoint aligned to Azure AI Foundry `/openai/v1` format**: `GetImageGenerationEndpoint()` now builds `{Endpoint}/images/generations` without the `/openai/deployments/{name}/` path segment and without `api-version`; the `model = ImageDeploymentName` field is now included in the request body instead of being embedded in the URL.
- **`AzureFoundryService` — chat completions endpoint aligned to Azure AI Foundry `/openai/v1` format**: `GetChatCompletionsEndpoint()` now builds `{Endpoint}/chat/completions` without the `/openai/deployments/{name}/` path segment and without `api-version`; `BuildSummaryPayload()` and `BuildImagePromptPayload()` now include `model = DeploymentName` in the request body.
- **`AzureFoundryOptions` — removed `ApiVersion` property**: `ApiVersion` was not used by Foundry `/openai/v1` endpoints and was causing `400 Bad Request` errors; removed from `AzureFoundryOptions`, `local.settings.json.example`, and related documentation.
- **`AzureFoundryService.GenerateImageAsync` — removed unsupported `response_format` parameter**: the `response_format` field is not accepted by the Foundry image generation endpoint; removed from the request body to prevent `400 Bad Request` responses.

### Tests
- **`OptionsExtensionsTests`** ([#189](https://github.com/artcava/XPoster/issues/189)): new test class covering all five providers. Per provider: asserts `SectionName` holds the expected configuration key; asserts `Add*Options()` binds `T` from the correct section (using a valid minimal config that satisfies the validator); asserts `Add*Options()` registers `IValidateOptions<T>` with the correct concrete validator type.
- **`PerplexityServiceTests`** ([#91](https://github.com/artcava/XPoster/issues/91)): covers `GetSummaryAsync` success and failure paths (HTTP 200 with valid/empty/null `choices`, HTTP 4xx/5xx), `GetImagePromptAsync` success and failure paths, and `GenerateImageAsync` graceful-degradation path (always returns empty byte array and logs `Warning`).
- **`PerplexityOptionsValidatorTests`** ([#91](https://github.com/artcava/XPoster/issues/91)): validates required fields, prompt-placeholder presence, and the intentional no-op behaviour of `ImagePromptSystemTemplate` validation.
- **`AiServiceFactoryTests`** ([#91](https://github.com/artcava/XPoster/issues/91)): new test case asserting `GetByProvider(AiProvider.Perplexity)` resolves to `PerplexityService`.
- **`ConfigurationFeedUrlProviderTests`** ([#185](https://github.com/artcava/XPoster/issues/185)): covers configured-URL return, empty list when section absent, and `ArgumentNullException` on null options.
- **`FeedOrchestratorTests`** ([#185](https://github.com/artcava/XPoster/issues/185)): verifies `GetFeedUrls()` is called during `OrchestrateAsync()`; empty-URL-list returns `null` with `SendIt = false`; URLs from provider are forwarded to `IFeedService`.
- **`AzureFoundryServiceTests` — endpoint and payload coverage for image generation and chat completions**:
  - `E1`: verifies POST targets `/images/generations` without the `/openai/deployments/` path segment.
  - `E2`: verifies `model` is serialised in the image generation request body.
  - `C1`: verifies POST targets `/chat/completions` without the `/openai/deployments/` path segment.
  - `C2`: verifies `model` is present in the chat completions request body.
- **`AzureFoundryOptionsTests`** — added `DoesNotExpose_ApiVersionProperty` regression test to ensure `ApiVersion` is not reintroduced in the options model; follows the `DeepSeekOptions` test pattern.

---

## [0.1.3] - 2026-06-17

### Added
- **`DryRunSender`** (`src/SenderPlugins/DryRunSender.cs`) ([#174](https://github.com/artcava/XPoster/issues/174)): no-op `ISender` implementation for local end-to-end testing; probes Key Vault connectivity via `GetSecretAsync("XApiKey")` and logs the full post content (character count, text, image presence) without making any outbound social API call; `MessageMaxLenght` returns `int.MaxValue`; activated at hour 9 only when `EnableDryRunSlot = true` via `DryRunSlotProfileProvider` — must never be enabled in production.
- **`ISlotProfileProvider`** (`src/Abstraction/ISlotProfileProvider.cs`): interface exposing `GetProfiles()` returning `IReadOnlyList<ScheduledOrchestrationProfile>`; decouples schedule ownership from `OrchestratorFactory` and enables conditional DI composition of schedule profiles.
- **`DefaultSlotProfileProvider`** (`src/Implementation/DefaultSlotProfileProvider.cs`): production implementation of `ISlotProfileProvider`; owns the canonical four-slot schedule (UTC hours 6, 8, 14, 16); registered as `Singleton` in `Program.cs` by default.
- **`DryRunSlotProfileProvider`** (`src/Implementation/DryRunSlotProfileProvider.cs`): decorator around `ISlotProfileProvider` that appends the DryRun slot at hour 9 to the inner provider's profile list; registered in place of `DefaultSlotProfileProvider` only when `EnableDryRunSlot = true` in `local.settings.json`.
- **`coverlet.runsettings`** added at repo root ([#166](https://github.com/artcava/XPoster/issues/166)): excludes auto-generated Azure Functions isolated-worker classes from Coverlet coverage collection.
- **`Azure.Security.KeyVault.Secrets` v4.7.0** added to `XPoster.csproj` ([#113](https://github.com/artcava/XPoster/issues/113)).
- **`IKeyVaultService` abstraction** (`src/Abstraction/IKeyVaultService.cs`) ([#113](https://github.com/artcava/XPoster/issues/113)).
- **`KeyVaultService` implementation** (`src/Services/KeyVaultService.cs`) ([#113](https://github.com/artcava/XPoster/issues/113)).
- **`Microsoft.Extensions.Http.Resilience` package** added ([#133](https://github.com/artcava/XPoster/issues/133)).
- **Named `HttpClient` registrations in `Program.cs`** ([#133](https://github.com/artcava/XPoster/issues/133)).
- **`AiServiceHelper`** (`src/Services/AiServiceHelper.cs`) ([#158](https://github.com/artcava/XPoster/issues/158)).
- **Agent graph generation and persistence workflows** ([#141](https://github.com/artcava/XPoster/issues/141), [#149](https://github.com/artcava/XPoster/issues/149)).
- Dynamic GitHub Actions build status badge in README ([#35](https://github.com/artcava/XPoster/issues/35)).
- This CHANGELOG.md file ([#36](https://github.com/artcava/XPoster/issues/36)).

### Changed
- **`OrchestratorFactory` schedule decoupled via `ISlotProfileProvider`**: related documentation updated in `README.md`, `docs/architecture.md`, `docs/configuration.md`, `docs/extending-xposter.md`, and `docs/deployment.md`.
- **`COVERAGE_THRESHOLD` raised from `70` to `80`** in `.github/workflows/ci.yml` ([#166](https://github.com/artcava/XPoster/issues/166)).
- **`InSender`**, **`XSender`**, **`IgSender`** read credentials from Key Vault at runtime ([#113](https://github.com/artcava/XPoster/issues/113)).
- **`InSender`** and **`IgSender`** refactored to accept `IHttpClientFactory` ([#133](https://github.com/artcava/XPoster/issues/133)).
- **`OpenAiService`, `AzureFoundryService`, `DeepSeekService`** delegate HTTP-response parsing to `AiServiceHelper` ([#158](https://github.com/artcava/XPoster/issues/158)).
- `local.settings.json.example` updated: per-platform credential env vars removed; `KEYVAULT_URI` and `EnableDryRunSlot` added ([#113](https://github.com/artcava/XPoster/issues/113)).

### Fixed
- **`AzureFoundryService.GenerateImageAsync`** hardened ([#139](https://github.com/artcava/XPoster/issues/139), [#158](https://github.com/artcava/XPoster/issues/158)).
- **`OpenAiService.GenerateImageAsync`** hardened ([#139](https://github.com/artcava/XPoster/issues/139), [#158](https://github.com/artcava/XPoster/issues/158)).
- **`AiServiceHelper`** — `JsonException` on missing `choices` property ([#158](https://github.com/artcava/XPoster/issues/158)).
- **CI loop on `develop`** resolved ([#149](https://github.com/artcava/XPoster/issues/149)).

### Tests
- **`SlotProfileProviderTests`**, **`OrchestratorFactoryTests`** rewritten, **`DryRunSenderTests`**, **`IgSenderTests`**, **`KeyVaultServiceTests`**, **`Polly resilience pipeline integration tests`**, **`AiServiceHelperTests`**, **`OpenAiServiceTests`**, **`AzureFoundryServiceTests`** expanded — see full details in the Git history.

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
- **`IAiService` contract**: all three methods now accept an optional `CancellationToken` parameter ([#123](https://github.com/artcava/XPoster/issues/123))
- **`AiServiceFactory`** (`IAiServiceFactory`): resolves the correct `IAiService` implementation by `AiProvider` enum value at runtime ([#100](https://github.com/artcava/XPoster/issues/100))
- **`GeneratorFactory`** refactored to use `List<ScheduledGenerationProfile>` ([#100](https://github.com/artcava/XPoster/issues/100))
- `OpenAiOptions`: all OpenAI endpoints, model names and parameters externalised ([#88](https://github.com/artcava/XPoster/issues/88), [#89](https://github.com/artcava/XPoster/issues/89))
- `AiService` renamed to `OpenAiService` ([#87](https://github.com/artcava/XPoster/issues/87))
- `MessageSender.IgPowerLow` renamed to `IgPowerLaw` ([#108](https://github.com/artcava/XPoster/issues/108))
- GitHub Actions upgraded to Node.js 24 compatible versions ([#122](https://github.com/artcava/XPoster/issues/122), [#137](https://github.com/artcava/XPoster/issues/137))

### Fixed
- **Empty `choices[]` guard** across all three chat-based services ([#124](https://github.com/artcava/XPoster/issues/124))
- Azure Functions isolated deployment artifacts: corrected publish path ([#102](https://github.com/artcava/XPoster/issues/102))
- Keyed DI resolution for AI service in `Program.cs` ([#104](https://github.com/artcava/XPoster/issues/104))
- Removed unused `System.ServiceModel.Syndication` package dependency ([#85](https://github.com/artcava/XPoster/issues/85))

### Tests
- Empty-choices guard tests, `AiServiceFactoryTests`, `DeepSeekOptionsValidator`, `DeepSeekService`, `HybridAiService`, `CancellationToken` propagation tests ([#124](https://github.com/artcava/XPoster/issues/124), [#100](https://github.com/artcava/XPoster/issues/100), [#127](https://github.com/artcava/XPoster/issues/127), [#123](https://github.com/artcava/XPoster/issues/123))

---

## [0.1.1] - 2026-04-08

### Changed
- **Image generation migrated from DALL-E 3 to `gpt-image-1`**: replaced `AzureOpenAIClient` with `HttpClient` + `System.Text.Json` ([#24](https://github.com/artcava/XPoster/issues/24), [#25](https://github.com/artcava/XPoster/issues/25))
- OpenAI models updated to **`gpt-4.1-nano`** (text) and **`gpt-image-1.5`** (image) ([#68](https://github.com/artcava/XPoster/issues/68))
- `CONTRIBUTING.md`: explicit rule to always branch from `develop`; PR checklist updated ([#79](https://github.com/artcava/XPoster/issues/79))
- `README.md` and all docs aligned to actual environment variable names ([#70](https://github.com/artcava/XPoster/issues/70))
- Directory tree diagrams updated to match actual project structure ([#70](https://github.com/artcava/XPoster/issues/70), [#74](https://github.com/artcava/XPoster/issues/74))

### Fixed
- Removed unsupported `response_format` parameter from image generation request body ([#26](https://github.com/artcava/XPoster/issues/26))
- Added missing `issues: write` and `pull-requests: write` permissions to the `issue-management` workflow ([#83](https://github.com/artcava/XPoster/issues/83))

---

## [0.1.0] - 2026-03-30

### Added
- **Azure Key Vault + Managed Identity infrastructure**: Bicep IaC provisioning `xposter-kv` vault and system-assigned managed identity for Azure Functions ([#54](https://github.com/artcava/XPoster/issues/54))
- LinkedIn credentials migrated to **Azure Key Vault References** ([#55](https://github.com/artcava/XPoster/issues/55))
- GitHub Actions CI/CD pipeline (`ci.yml`) ([#45](https://github.com/artcava/XPoster/issues/45))
- LinkedIn access token expiry reminder workflow
- `CRON_EXPRESSION` externalised as environment variable
- `src/local.settings.json.example` ([#29](https://github.com/artcava/XPoster/issues/29))
- `docs/` folder ([#30](https://github.com/artcava/XPoster/issues/30))
- `docs/architecture.md` with ADRs and Mermaid data-flow diagram ([#28](https://github.com/artcava/XPoster/issues/28))
- `tests/README.md` ([#31](https://github.com/artcava/XPoster/issues/31))
- GitHub issue/PR templates ([#32](https://github.com/artcava/XPoster/issues/32))
- Versioning baseline `0.1.0` set in `XPoster.csproj` ([#49](https://github.com/artcava/XPoster/issues/49))

### Changed
- `README.md` translated to English ([#20](https://github.com/artcava/XPoster/issues/20))
- CI: `dotnet test` added as mandatory gate before deployment ([#22](https://github.com/artcava/XPoster/issues/22))
- CI coverage threshold raised to **70%** ([#22](https://github.com/artcava/XPoster/issues/22))

### Fixed
- **Nullable Reference Types**: resolved all `CS86xx` warnings ([#46](https://github.com/artcava/XPoster/issues/46))
- `BaseGenerator.PostAsync` and `FeedGenerator` graceful degradation on image generation failure ([#22](https://github.com/artcava/XPoster/issues/22))

### Tests
- Line coverage raised to **72.1%** ([#51](https://github.com/artcava/XPoster/issues/51), [#52](https://github.com/artcava/XPoster/issues/52), [#62](https://github.com/artcava/XPoster/issues/62))

---

<!-- Links -->
[Unreleased]: https://github.com/artcava/XPoster/compare/v0.1.4...HEAD
[0.1.4]: https://github.com/artcava/XPoster/compare/v0.1.3...v0.1.4
[0.1.3]: https://github.com/artcava/XPoster/compare/v0.1.2...v0.1.3
[0.1.2]: https://github.com/artcava/XPoster/compare/v0.1.1...v0.1.2
[0.1.1]: https://github.com/artcava/XPoster/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/artcava/XPoster/release
