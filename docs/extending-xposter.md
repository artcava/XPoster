# Extending XPoster

XPoster is designed around four extension points: **Senders** (platform plugins), **Orchestrators** (content strategies), **AI Providers** (model integrations), and **Tag Replacement Providers** (hashtag mapping sources). Each maps to a dedicated abstraction and can be implemented without modifying any existing component.

> For the architectural rationale behind each extension point, see [architecture.md §5](architecture.md#5-extension-points).

---

## Adding a New Sender (Platform)

A sender is a class that implements `ISender` and knows how to publish a `Post` to a specific social network. It owns all platform-specific concerns: authentication, payload serialisation, rate-limit handling, and error mapping.

Sender credentials are loaded from Azure Key Vault at application startup via the Key Vault Configuration Provider and injected through `IOptions<TCredentials>` — no Key Vault calls occur at publish time.

### Step 1 — Define the Credentials class

Create a plain credentials DTO and its validator in `src/Credentials/`:

```csharp
// src/Credentials/TikTokCredentials.cs
namespace XPoster.Credentials;

public class TikTokCredentials
{
    public const string SectionName = "TikTokCredentials";

    public string TikTokAccessToken { get; init; } = string.Empty;
    public string TikTokClientKey   { get; init; } = string.Empty;
}
```

```csharp
// src/Credentials/TikTokCredentialsValidator.cs
using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

public class TikTokCredentialsValidator : IValidateOptions<TikTokCredentials>
{
    public ValidateOptionsResult Validate(string? name, TikTokCredentials options)
    {
        if (string.IsNullOrWhiteSpace(options.TikTokAccessToken))
            return ValidateOptionsResult.Fail("TikTokCredentials:TikTokAccessToken is required.");
        if (string.IsNullOrWhiteSpace(options.TikTokClientKey))
            return ValidateOptionsResult.Fail("TikTokCredentials:TikTokClientKey is required.");
        return ValidateOptionsResult.Success;
    }
}
```

```csharp
// src/Credentials/TikTokCredentialsExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

public static class TikTokCredentialsExtensions
{
    public static IServiceCollection AddTikTokCredentials(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<TikTokCredentials>(configuration.GetSection(TikTokCredentials.SectionName));
        services.AddSingleton<IValidateOptions<TikTokCredentials>, TikTokCredentialsValidator>();
        return services;
    }
}
```

> The Key Vault Configuration Provider maps secret names to `IConfiguration` keys using the Azure SDK default convention: a secret named `TikTokCredentialsTikTokAccessToken` is available as `TikTokCredentials:TikTokAccessToken`. `SectionName` is the prefix that ties secret names to the credentials DTO. This mirrors the convention used by `XCredentials`, `LinkedInCredentials`, and `IgCredentials`.

### Step 2 — Implement ISender

```csharp
// src/SenderPlugins/TikTokSender.cs
using Microsoft.Extensions.Options;
using XPoster.Credentials;

public class TikTokSender : ISender
{
    private readonly TikTokCredentials _credentials;
    private readonly ILogger<TikTokSender> _logger;

    public TikTokSender(IOptions<TikTokCredentials> credentials, ILogger<TikTokSender> logger)
    {
        _credentials = credentials.Value;
        _logger = logger;
    }

    public int MessageMaxLength => 150;

    public async Task<bool> SendAsync(Post post)
    {
        if (post is null)
        {
            _logger.LogWarning("[TikTokSender] Received null post — skipping.");
            return false;
        }

        // Use _credentials.TikTokAccessToken and _credentials.TikTokClientKey here.
        // Return false (do not throw) on non-fatal platform errors.
        return true;
    }
}
```

> `MessageMaxLength` must reflect the platform's actual character limit. Orchestrators use this value to truncate content before calling `SendAsync`.

### Step 3 — Register in DI

```csharp
// src/Program.cs
builder.Services.AddTikTokCredentials(builder.Configuration); // binds IOptions + startup validation
builder.Services.AddTransient<TikTokSender>();
```

> Call only the extension method — never raw `Configure<T>(configuration.GetSection("..."))` literals for sender credentials in `Program.cs`.

### Step 4 — Add the secrets to Key Vault

Add one secret per credentials property, using the `{SectionName}{PropertyName}` naming convention:

```bash
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentialsTikTokAccessToken --value "<value>"
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentialsTikTokClientKey   --value "<value>"
```

For local development only, set them in `src/local.settings.json` using the double-underscore separator:

```json
"TikTokCredentials__TikTokAccessToken": "<local-dev-value>",
"TikTokCredentials__TikTokClientKey":   "<local-dev-value>"
```

> Do not add social-platform credentials to `src/local.settings.json.example`. Use Key Vault for all non-local environments.

### Step 5 — Add SenderPlatform Enum Value

Add a single value to `SenderPlatform` representing the new platform. Each value maps to exactly one sender class, independent of which orchestrator produces the content:

```csharp
// src/Contracts/Enums.cs
public enum SenderPlatform
{
    // existing values ...
    TikTok,
}
```

> `SenderPlatform` represents **where** to publish. It is orthogonal to the orchestrator type (what content strategy to use), so a single `TikTok` value covers all orchestrators that target TikTok. This is the key difference from the legacy `MessageSender` enum, which conflated platform identity with content strategy.

### Step 6 — Wire in OrchestratorFactory

`OrchestratorFactory.Resolve()` resolves the concrete sender through a **switch expression** that maps each `SenderPlatform` value to the class retrieved from the DI container. Because `SenderPlatform` is platform-only, there is **one arm per platform** — independent of how many orchestrators target that platform. Add one arm to the existing switch expression inside `Resolve()`:

```csharp
// src/Orchestrators/OrchestratorFactory.cs — sender switch expression
ISender? sender = profile.SenderPlatform switch
{
    // existing arms ...
    SenderPlatform.TikTok => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    _ => null
};
```

> One enum value, one switch arm, one sender class. Adding a new orchestrator that posts to TikTok (e.g. `TrendingOrchestrator`) requires **no change** to this switch — only a new `ScheduledOrchestrationProfile` entry referencing `SenderPlatform.TikTok`.

### Step 7 — Add a ScheduledOrchestrationProfile entry

The production schedule is owned by `DefaultSlotProfileProvider` (`src/Orchestrators/DefaultSlotProfileProvider.cs`). Add the new profile to its `GetProfiles()` return list, specifying the UTC hour, sender platform, orchestrator type, and (optionally) the AI provider for that slot:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(20, SenderPlatform.TikTok, typeof(FeedOrchestrator), AiProvider.OpenAi),
];
```

> `OrchestratorFactory` no longer owns a static profile list — it receives `ISlotProfileProvider` via constructor injection and calls `GetProfiles()` at resolution time. Only `DefaultSlotProfileProvider` needs to change when adding a production slot.

**Validation**: Write a unit test for the new sender using a mock `Post` to verify serialisation and error-return behaviour before integration.

---

## Adding a New Orchestrator (Content Strategy)

An orchestrator inherits from `BaseOrchestrator` and overrides `OrchestrateAsync()` to produce a `Post`. It must also implement the `SupportedPlatforms` property to declare which `SenderPlatform` values it is compatible with. Dependencies — sender, AI capability providers, and any data services — are received via constructor injection; `OrchestratorFactory` resolves them automatically through reflection.

### Step 1 — Extend BaseOrchestrator

```csharp
// src/Orchestrators/QuoteOrchestrator.cs
public class QuoteOrchestrator : BaseOrchestrator
{
    public QuoteOrchestrator(
        ISender sender,
        ILogger<QuoteOrchestrator> logger,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider)
        : base(sender, logger, textProvider, imageProvider) { }

    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        [SenderPlatform.X, SenderPlatform.LinkedIn, SenderPlatform.DryRun];

    public override async Task<Post>? OrchestrateAsync()
    {
        // Return null (do not throw) when no content can be produced.
        // XFunction will skip posting gracefully.
        if (_textProvider is null) return null;

        var quote = await _textProvider.GetSummaryAsync("Generate a motivational tech quote.", 100);
        if (string.IsNullOrWhiteSpace(quote)) return null;

        byte[]? image = null;
        if (_imageProvider is not null)
            image = await _imageProvider.GenerateImageAsync(quote);

        return new Post { Content = quote, Image = image };
    }
}
```

> **`SupportedPlatforms` invariant**: always include `SenderPlatform.DryRun` so the orchestrator can be exercised locally without live API calls. Declare only the platforms the orchestrator has been validated against — omitting a platform is a deliberate signal that the content format may not be compatible.

> **`OrchestrateAsync` invariant**: must return `null` — not throw — when content cannot be produced. `XFunction` treats a `null` return as a graceful skip; an exception is treated as a pipeline failure.

> **Null capability providers**: `ITextToTextProvider?` and `ITextToImageProvider?` are injected as nullable. When a slot references a text-only provider (e.g. `AiProvider.DeepSeek`), `imageProvider` will be `null` — check before use and degrade gracefully (text-only post). When a slot references an image-only provider (e.g. `AiProvider.FalAi`), `textProvider` will be `null` — return `null` early if the orchestrator cannot produce content without text generation.

### Step 2 — Add a ScheduledOrchestrationProfile entry

Reference the new orchestrator type and the target `SenderPlatform` in `DefaultSlotProfileProvider.GetProfiles()`. `CreateOrchestratorInstance` in `OrchestratorFactory` resolves constructor parameters automatically via reflection:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(10, SenderPlatform.X, typeof(QuoteOrchestrator), AiProvider.Perplexity),
];
```

No other change to `OrchestratorFactory` is required. The factory receives the updated profile list via `ISlotProfileProvider` at runtime without any code modification.

---

## Adding a New AI Provider

The AI layer uses two capability interfaces — `ITextToTextProvider` and `ITextToImageProvider` — registered as **keyed services** in the DI container, keyed by `AiProvider` enum value. `OrchestratorFactory` resolves both capabilities independently via `IServiceProvider.GetKeyedService<T>(profile.AiProvider)`. There is no factory class or switch expression to modify — adding a new provider requires only implementing the relevant interface(s) and adding the keyed DI registrations.

### Capability model

A provider can implement one or both capability interfaces:

| Provider type | Implements | Keyed registrations to add |
|---|---|---|
| Text + Image | `ITextToTextProvider` and `ITextToImageProvider` | Both interfaces under the same key |
| Text only | `ITextToTextProvider` | `ITextToTextProvider` only; `GetKeyedService<ITextToImageProvider>` returns `null` |
| Image only | `ITextToImageProvider` | `ITextToImageProvider` only; `GetKeyedService<ITextToTextProvider>` returns `null` |

`null` resolution is **intentional**: orchestrators check for null providers and degrade gracefully. Misconfiguring a text-only provider for an image-generating slot surfaces explicitly inside `FeedOrchestrator` at the point of use, not silently.

### Step 1 — Add the Enum Value

Append a new value to `AiProvider`. Assign an explicit integer to avoid accidental renumbering of existing values, and add a `[Description]` attribute if the display label differs from the enum name:

```csharp
// src/Contracts/AiProvider.cs
public enum AiProvider
{
    None         = 0,
    OpenAi       = 1,
    Perplexity   = 2,
    AzureFoundry = 3,
    DeepSeek     = 4,
    FalAi        = 5,
    [Description("Anthropic")]
    Anthropic    = 6,  // new
}
```

> Also update `DefaultSlotProfileProvider` if the new provider should be active for a production slot. Any slot profile that previously referenced `AiProvider.DeepSeekWithFal` must be migrated to `AiProvider.DeepSeek` (text) or `AiProvider.FalAi` (image) as appropriate — `DeepSeekWithFal` has been removed.

### Step 2 — Implement the Capability Interface(s)

**Text + Image provider** (e.g. Anthropic supports both):

```csharp
// src/Services/Ai/AnthropicService.cs
public class AnthropicService : ITextToTextProvider, ITextToImageProvider
{
    public async Task<string> GetSummaryAsync(string text, int maxLength, CancellationToken ct = default)
    {
        // Call Anthropic Messages API for summarisation
    }

    public async Task<string> GetImagePromptAsync(string text, CancellationToken ct = default)
    {
        // Call Anthropic Messages API for prompt generation
    }

    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken ct = default)
    {
        // Call Anthropic image generation API
    }
}
```

**Text-only provider** (e.g. a provider that has no image model):

```csharp
// src/Services/Ai/MyTextOnlyService.cs
public class MyTextOnlyService : ITextToTextProvider
{
    public async Task<string> GetSummaryAsync(string text, int maxLength, CancellationToken ct = default) { ... }
    public async Task<string> GetImagePromptAsync(string text, CancellationToken ct = default) { ... }
    // No GenerateImageAsync — ITextToImageProvider is not implemented.
    // Slots using this provider will receive null for imageProvider — intentional.
}
```

**Image-only provider** (e.g. a specialised diffusion model):

```csharp
// src/Services/Ai/MyImageOnlyService.cs
public class MyImageOnlyService : ITextToImageProvider
{
    public async Task<byte[]> GenerateImageAsync(string prompt, CancellationToken ct = default) { ... }
    // No text methods — ITextToTextProvider is not implemented.
    // Slots using this provider will receive null for textProvider — intentional.
}
```

### Step 3 — Register as Keyed Services

Add the keyed registrations to `AddXPosterAiProviders()` in `Program.cs`. Register only the interfaces the service actually implements:

```csharp
// src/Program.cs — inside AddXPosterAiProviders()

// Text + Image provider
builder.Services.AddKeyedTransient<ITextToTextProvider,  AnthropicService>(AiProvider.Anthropic);
builder.Services.AddKeyedTransient<ITextToImageProvider, AnthropicService>(AiProvider.Anthropic);

// Text-only provider
builder.Services.AddKeyedTransient<ITextToTextProvider, MyTextOnlyService>(AiProvider.MyTextOnly);
// No ITextToImageProvider registration — GetKeyedService returns null for this key

// Image-only provider
builder.Services.AddKeyedTransient<ITextToImageProvider, MyImageOnlyService>(AiProvider.MyImageOnly);
// No ITextToTextProvider registration — GetKeyedService returns null for this key
```

No switch expression, no factory class, and no `_supportedProviders` set to maintain. The keyed DI registration is the single source of truth for capability availability.

### Step 4 — Add an `*OptionsExtensions.cs` file

Every AI provider **must** ship an `*OptionsExtensions.cs` file alongside its `*Options.cs` and `*OptionsValidator.cs` in `src/Models/<ProviderName>/`. This file is the single source of truth for the configuration section key and encapsulates both the binding and the startup-validation registration in one method call.

```
src/Models/
  Anthropic/
    AnthropicOptions.cs
    AnthropicOptionsValidator.cs
    AnthropicOptionsExtensions.cs   ← required
```

The file must follow this exact shape:

```csharp
// src/Models/Anthropic/AnthropicOptionsExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="AnthropicOptions"/> binding and validation.
/// </summary>
public static class AnthropicOptionsExtensions
{
    /// <summary>App-settings section name: <c>Anthropic</c>.</summary>
    public const string SectionName = "Anthropic";

    /// <summary>
    /// Binds the <c>Anthropic</c> configuration section to <see cref="AnthropicOptions"/>
    /// and registers <see cref="AnthropicOptionsValidator"/> for startup validation.
    /// </summary>
    public static IServiceCollection AddAnthropicOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AnthropicOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<AnthropicOptions>, AnthropicOptionsValidator>();
        return services;
    }
}
```

Key rules for this file:

- `SectionName` lives on the **extension class**, not on `AnthropicOptions`. The Options DTO must remain a pure data model with no infrastructure concerns.
- The method encapsulates **both** `Configure<T>` and `AddSingleton<IValidateOptions<T>>`. Never register them separately in `Program.cs`.
- `Program.cs` must call only `builder.Services.AddAnthropicOptions(builder.Configuration)` — never raw `Configure<T>(configuration.GetSection("..."))` literals for AI providers.
- Add the corresponding `appsettings.json` / `local.settings.json` section using `SectionName` as the key.

> This pattern mirrors `HttpClientExtensions.AddHttpClients()` already present in the codebase and is consistent with the approach used by ASP.NET Core, the Azure SDK, and `Microsoft.Extensions` libraries throughout the .NET ecosystem.

---

## Adding a New Tag Replacement Provider

The tag replacement provider resolves the word-to-hashtag map consumed by `FeedOrchestrator` at Step 3 of its pipeline. The default implementation, `ConfigurationTagReplacementProvider`, reads the map from `TagReplacementOptions:Replacements` in app settings. If you need to source replacements from a different store — a database, a remote API, Azure App Configuration, or Key Vault — implement `ITagReplacementProvider` and swap the registration in `Program.cs`.

### Contract

```csharp
// src/Contracts/ITagReplacementProvider.cs
public interface ITagReplacementProvider
{
    IReadOnlyDictionary<string, string> GetReplacements();
}
```

`GetReplacements()` must:
- Return an `IReadOnlyDictionary<string, string>` mapping plain words (keys) to their hashtag replacements (values).
- Return an **empty dictionary** — never `null` — when no replacements are configured. `FeedOrchestrator` treats an empty map as a valid no-op.
- Be **synchronous and cheap**. `FeedOrchestrator` calls it twice per execution (once for feed keyword filtering, once for post-summary replacement). Load data at construction time or cache it; do not make blocking HTTP calls inside `GetReplacements()`.

### Step 1 — Implement ITagReplacementProvider

```csharp
// src/Orchestrators/DatabaseTagReplacementProvider.cs
using XPoster.Contracts;

namespace XPoster.Orchestrators;

/// <summary>
/// Loads word-to-hashtag replacements from a remote database, refreshed at startup.
/// </summary>
public class DatabaseTagReplacementProvider : ITagReplacementProvider
{
    private readonly IReadOnlyDictionary<string, string> _replacements;

    public DatabaseTagReplacementProvider(IMyDatabaseClient db)
    {
        // Load once at construction; FeedOrchestrator calls GetReplacements() synchronously.
        var rows = db.FetchReplacements();
        _replacements = rows.ToDictionary(
            r => r.Word,
            r => r.Hashtag,
            StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlyDictionary<string, string> GetReplacements() => _replacements;
}
```

> Use `StringComparer.OrdinalIgnoreCase` on the dictionary to honour the case-insensitive matching contract. `FeedOrchestrator.ReplaceEveryFirstOccurrenceOf()` performs its own case-insensitive scan, but a case-insensitive dictionary prevents duplicate keys with different casing from causing silent overrides.

### Step 2 — Register in DI

Replace the existing `ConfigurationTagReplacementProvider` registration in `Program.cs` with your implementation. The registration must remain `Singleton` — `FeedOrchestrator` is resolved per-trigger and expects the provider to be cheap to call.

```csharp
// src/Program.cs
// Remove or comment out:
// builder.Services.AddSingleton<ITagReplacementProvider, ConfigurationTagReplacementProvider>();

// Add your implementation:
builder.Services.AddSingleton<ITagReplacementProvider, DatabaseTagReplacementProvider>();
```

No other change is required. `FeedOrchestrator` depends only on `ITagReplacementProvider` — it is unaware of the concrete implementation.

### Step 3 — Remove the `TagReplacementOptions` configuration keys (optional)

If your new provider does not use `TagReplacementOptions`, you can remove the `TagReplacementOptions__Replacements__*` keys from `local.settings.json` and Azure App Settings. The `ConfigurationTagReplacementProvider` binding will no longer be active.

> If you keep the configuration keys but switch to a different provider, the bound `TagReplacementOptions` values are simply ignored — no error is raised.

---

## Design Constraints

All extensions must respect the following invariants to integrate correctly with the pipeline:

- **Senders must be stateless.** Do not cache authentication tokens in instance fields; inject them via `IOptions<TCredentials>` (bound at startup from Key Vault via the Configuration Provider). The DI container manages lifetime.
- **`SendAsync` must return `false`, not throw, on non-fatal platform errors.** Throwing from a sender propagates the exception to `XFunction` and prevents App Insights from recording a clean skip.
- **`MessageMaxLength` must be accurate.** Orchestrators rely on this value to truncate content before calling `SendAsync`. An incorrect value causes silent data loss at the platform layer.
- **`OrchestrateAsync` must return `null`, not throw, when no content can be produced.** `XFunction` treats a `null` return as a graceful skip; an exception is treated as a pipeline failure.
- **Orchestrators must implement `SupportedPlatforms`.** The property must include every `SenderPlatform` value the orchestrator has been validated against, and always include `SenderPlatform.DryRun`. `NoOrchestrator` is the only valid exception (empty list).
- **Orchestrators must be idempotent where possible.** Avoid side effects beyond returning a `Post`. In particular, do not call `ISender.SendAsync` from inside an orchestrator — that responsibility belongs to `XFunction`.
- **Orchestrators must handle null capability providers explicitly.** `ITextToTextProvider?` and `ITextToImageProvider?` are injected as nullable. Check before use and degrade gracefully: return a text-only post when `imageProvider` is null, return `null` early when `textProvider` is null and text generation is required.
- **AI provider services must implement only the capability interfaces they actually support.** Do not implement `ITextToImageProvider` on a text-only provider as a no-op or a `NotSupportedException` stub — leave the interface unimplemented and omit the keyed DI registration. The `null`-resolution contract is the canonical signal for “capability not available”.
- **Keyed AI provider registrations live exclusively in `AddXPosterAiProviders()`.** Never add `AddKeyedTransient<ITextToTextProvider, ...>` or `AddKeyedTransient<ITextToImageProvider, ...>` calls outside that method.
- **All external HTTP calls must go through `IHttpClientFactory`.** This ensures connection pooling, Polly resilience pipelines (retry, circuit breaker, attempt timeout), and consistent timeout configuration across the entire codebase. All services — including `FeedService` (named client `"Feed"`, registered in `HttpClientExtensions`) — conform to this constraint. Creating `new HttpClient()` inline is prohibited.
- **Every new sender must include a `*CredentialsExtensions.cs` file** in `src/Credentials/`, declaring `SectionName` on the credentials DTO and the `Add*Credentials(IServiceCollection, IConfiguration)` extension method. `Program.cs` must use only the extension method — never raw `Configure<T>` + `GetSection("...")` literals for sender credentials.
- **Every new AI provider must include an `*OptionsExtensions.cs` file** in its `src/Models/<ProviderName>/` folder, declaring `SectionName` and the `Add*Options(IServiceCollection, IConfiguration)` extension method. `Program.cs` must use only the extension method — never raw `Configure<T>` + `GetSection("...")` literals for AI provider options.
- **`ITagReplacementProvider` must return an empty dictionary — never `null`.** `FeedOrchestrator` iterates the result directly without a null-guard; returning `null` causes a `NullReferenceException` at runtime.
- See [architecture.md](architecture.md) for full ADRs and design pattern rationale.
