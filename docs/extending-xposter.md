# Extending XPoster

XPoster is designed around three extension points: **Senders** (platform plugins), **Orchestrators** (content strategies), **AI Providers** (model integrations). Each maps to a dedicated abstraction and can be implemented without modifying any existing component.

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
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.TikTokAccessToken))
            failures.Add($"{nameof(TikTokCredentials.TikTokAccessToken)} is required.");

        if (string.IsNullOrWhiteSpace(options.TikTokClientKey))
            failures.Add($"{nameof(TikTokCredentials.TikTokClientKey)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
```

```csharp
// src/Credentials/CredentialsExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

public static class CredentialsExtensions
{
    public static IServiceCollection AddCredentials(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ... other Platform credentials

        services
            .AddOptions<TikTokCredentials>()
            .Bind(configuration.GetSection(TikTokCredentials.SectionName));

        services.AddSingleton<IValidateOptions<TikTokCredentials>, TikTokCredentialsValidator>();

        services.AddSingleton<ICredentialsStartupValidator, CredentialsStartupValidator>();

        return services;
    }
}
```

> The Key Vault Configuration Provider maps secret names to `IConfiguration` keys using the Azure SDK default convention: a secret named `TikTokCredentialsTikTokAccessToken` is available as `TikTokCredentials--TikTokAccessToken`. `SectionName` is the prefix that ties secret names to the credentials DTO. This mirrors the convention used by `XCredentials`, `LinkedInCredentials`, and `IntagramCredentials`.

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
        ArgumentNullException.ThrowIfNull(credentials);
        ArgumentNullException.ThrowIfNull(logger);
        
        _credentials = credentials.Value;
        _logger = logger;
    }

    public SenderPlatform Platform => SenderPlatform.TikTok;

    public int MessageMaxLenght => 150;

    public async Task<bool> SendAsync(Post post, CancellationToken ct = default)
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

> `MessageMaxLenght` must reflect the platform's actual character limit. `FeedOrchestrator` uses this value as the target length for AI summarisation; an incorrect value leads to content that is too long or wastes character budget.

### Step 3 — Register in DI

```csharp
// src/Program.cs
builder.Services.AddTransient<TikTokSender>();
```

### Step 4 — Add the secrets to Key Vault

Add one secret per credentials property, using the `{SectionName}--{PropertyName}` naming convention:

```bash
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentials--TikTokAccessToken --value "<value>"
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentials--TikTokClientKey   --value "<value>"
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

> `SenderPlatform` represents **where** to publish. It is orthogonal to the orchestrator type (what content strategy to use), so a single `TikTok` value covers all orchestrators that target TikTok.

### Step 6 — Wire in OrchestratorFactory

`OrchestratorFactory.Resolve()` resolves the concrete sender list through a private `ResolveSender` helper that maps each `SenderPlatform` value to the class retrieved from the DI container. Add one arm to the switch expression inside `ResolveSender()`:

```csharp
// src/Orchestrators/OrchestratorFactory.cs — ResolveSender helper
private ISender? ResolveSender(SenderPlatform platform) => platform switch
{
    // existing arms ...
    SenderPlatform.TikTok => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    _ => null
};
```

The `Resolve()` method iterates `profile.SenderPlatforms`, calls `ResolveSender()` for each entry, and passes the resulting `IReadOnlyList<ISender>` to the orchestrator constructor. One enum value maps to one switch arm and one sender class — independent of how many senders are configured per slot.

> Adding a new orchestrator that posts to TikTok (e.g. `TrendingOrchestrator`) requires **no change** to this switch — only a new `ScheduledOrchestrationProfile` entry referencing `SenderPlatform.TikTok`.

### Step 7 — Add a ScheduledOrchestrationProfile entry

The production schedule is owned by `DefaultSlotProfileProvider` (`src/Orchestrators/DefaultSlotProfileProvider.cs`). Add the new profile to its `GetProfiles()` return list, specifying the UTC hour, sender platform list, orchestrator type, and (optionally) the AI providers for that slot:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(
        hour: 20,
        senderPlatforms: new[] { SenderPlatform.TikTok },
        orchestratorType: typeof(FeedOrchestrator),
        textProvider: AiProvider.OpenAi,
        imageProvider: AiProvider.OpenAi),
];
```

To publish to multiple platforms in the same slot, list all target senders. Each `*Orchestrator` reorder in **descending `MessageMaxLength` order** (widest first).

```csharp
new ScheduledOrchestrationProfile(
    hour: 20,
    senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.TikTok },  // LinkedIn wider (2 800) → first
    orchestratorType: typeof(FeedOrchestrator),
    textProvider: AiProvider.OpenAi,
    imageProvider: AiProvider.OpenAi),
```

**Validation**: Write a unit test for the new sender using a mock `Post` to verify serialisation and error-return behaviour before integration.

---

## Adding a New Orchestrator (Content Strategy)

An orchestrator inherits from `BaseOrchestrator` and overrides `OrchestrateAsync()` to produce one `Post` per configured sender. It must also implement the `SupportedPlatforms` property to declare which `SenderPlatform` values it is compatible with. Dependencies — sender list, AI capability providers, and any data services — are received via constructor injection; `OrchestratorFactory` resolves them automatically through reflection.

### Step 1 — Extend BaseOrchestrator

The constructor now receives `IReadOnlyList<ISender>` instead of a single `ISender`. `OrchestrateAsync()` returns `IReadOnlyDictionary<SenderPlatform, Post?>` — one entry per configured sender, keyed by platform. A `null` value for a given key signals that content generation failed for that sender.

```csharp
// src/Orchestrators/QuoteOrchestrator.cs
public class QuoteOrchestrator : BaseOrchestrator
{
    public QuoteOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<QuoteOrchestrator> logger,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider)
        : base(senders, logger) { }

    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        [SenderPlatform.X, SenderPlatform.LinkedIn, SenderPlatform.DryRun];

    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(
        CancellationToken ct = default)
    {
        if (_textProvider is null)
        {
            SendIt = false;
            return new Dictionary<SenderPlatform, Post?>();
        }

        // Build the PromptRequest value object — the orchestrator owns prompt intent.
        var request = new PromptRequest
        {
            InputText           = "Generate a motivational tech quote.",
            SystemPromptTemplate = "<your system prompt template>",
            UserPromptTemplate   = "<your user prompt template>",
            MaxOutputLength      = _senders.Max(s => s.MessageMaxLenght),
        };

        var quote = await _textProvider.GenerateTextAsync(request, ct);

        if (string.IsNullOrWhiteSpace(quote))
        {
            SendIt = false;
            return new Dictionary<SenderPlatform, Post?>();
        }

        byte[]? image = null;
        if (_imageProvider is not null)
        {
            var imageRequest = new ImagePromptRequest
            {
                InputText            = quote,
                SystemPromptTemplate = "<your image system prompt>",
                UserPromptTemplate   = "<your image user prompt>",
            };
            image = await _imageProvider.GenerateImageAsync(imageRequest, ct);
        }

        // Broadcast strategy: same post to every configured sender
        var post = new Post { Content = quote, Image = image };
        SendIt = true;
        return _senders.ToDictionary(s => s.Platform, _ => (Post?)post);
    }
}
```

#### Prompt value objects

All prompt data is transported via **value objects** constructed by the orchestrator and passed to the provider interfaces:

| Type | Used by | Purpose |
|---|---|---|
| `PromptRequest` | `ITextToTextProvider.GenerateTextAsync` | Carries input text, system/user prompt templates, temperature, max output length, max token budget, and optional input text label |
| `ImagePromptRequest` | `ITextToImageProvider.GenerateImageAsync` | Extends `PromptRequest` with `ImageQuantity` and `ImageSize` for image generation parameters |

The orchestrator is responsible for constructing these objects; the provider is responsible only for executing them. This ensures that **prompt intent stays in the orchestration layer** and never leaks into provider implementations.

`PromptStepOptions` (from `FeedPromptOptions` configuration) maps to `PromptRequest`/`ImagePromptRequest` at runtime: for the `Summary` role, `MaxOutputLength` is resolved from `ISender.MessageMaxLenght` rather than from configuration — all other fields are read directly from the corresponding `PromptStepOptions` entry.

The `PromptRole` enum identifies each step in the orchestration flow:

| Value | Step |
|---|---|
| `Summary` | Generates the primary text summary from raw feed content |
| `ImagePromptDerivation` | Derives the image-generation prompt from the summary text |
| `ImageGeneration` | Generates the image from the derived prompt |

#### Broadcast vs. per-sender content adaptation

Choose the strategy that fits the orchestrator's purpose:

| Strategy | When to use | Example |
|---|---|---|
| **Broadcast** | Same content works on every target platform | `PowerLawOrchestrator` — deterministic text, no AI, broadcast identical `Post` to all senders |
| **Per-sender adaptation** | Content must be re-summarised to fit each platform's character limit | `FeedOrchestrator` — AI base summary at primary sender's limit, AI re-summarise for each secondary sender |

For a **per-sender adaptation** pattern, iterate `senders` and call `_textProvider.GenerateTextAsync` independently per sender with a new `PromptRequest` whose `MaxOutputLength` is set to `sender.MessageMaxLenght`. See `FeedOrchestrator.OrchestrateAsync()` for the canonical implementation.

> **`OrchestrateAsync` invariant**: return an **empty dictionary** with `SendIt = false` — not throw — when content cannot be produced. `XFunction` treats an empty result as a graceful skip; an exception is treated as a pipeline failure.

> **`SupportedPlatforms` invariant**: always include `SenderPlatform.DryRun` so the orchestrator can be exercised locally without live API calls. Declare only the platforms the orchestrator has been validated against.

> **Null capability providers**: `ITextToTextProvider?` and `ITextToImageProvider?` are injected as nullable. When a slot references a text-only provider (e.g. `AiProvider.DeepSeek`), `imageProvider` will be `null` — check before use and degrade gracefully (text-only post). When a slot references an image-only provider (e.g. `AiProvider.FalAi`), `textProvider` will be `null` — return an empty dictionary early if the orchestrator cannot produce content without text generation.

### Step 2 — Add a ScheduledOrchestrationProfile entry

Reference the new orchestrator type and the target `SenderPlatforms` list in `DefaultSlotProfileProvider.GetProfiles()`. `CreateOrchestratorInstance` in `OrchestratorFactory` resolves constructor parameters automatically via reflection:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(
        hour: 10,
        senderPlatforms: new[] { SenderPlatform.X },
        orchestratorType: typeof(QuoteOrchestrator),
        textProvider: AiProvider.Perplexity),
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

### Step 2 — Implement the Capability Interface(s)

Provider methods receive typed value objects (`PromptRequest` / `ImagePromptRequest`) constructed by the orchestrator. Providers must not impose any prompt-shaping logic; they must execute the request as supplied.

**Text + Image provider** (e.g. Anthropic supports both):

```csharp
// src/Services/Ai/AnthropicService.cs
public class AnthropicService : ITextToTextProvider, ITextToImageProvider
{
    public async Task<string> GenerateTextAsync(PromptRequest request, CancellationToken cancellationToken = default)
    {
        // Use request.SystemPromptTemplate, request.UserPromptTemplate,
        // request.InputText, request.Temperature, request.MaxOutputLength, etc.
        // Call Anthropic Messages API for text generation.
        return generatedText;
    }

    public async Task<byte[]> GenerateImageAsync(ImagePromptRequest request, CancellationToken cancellationToken = default)
    {
        // Use request.SystemPromptTemplate, request.UserPromptTemplate,
        // request.InputText, request.ImageQuantity, request.ImageSize, etc.
        // Call Anthropic image generation API.
        return imageBytes;
    }
}
```

**Text-only provider** (e.g. a provider that has no image model):

```csharp
// src/Services/Ai/MyTextOnlyService.cs
public class MyTextOnlyService : ITextToTextProvider
{
    public async Task<string> GenerateTextAsync(PromptRequest request, CancellationToken cancellationToken = default)
    {
        // Execute the text-to-text step using request fields.
    }
    // No GenerateImageAsync — ITextToImageProvider is not implemented.
    // Slots using this provider will receive null for imageProvider — intentional.
}
```

**Image-only provider** (e.g. a specialised diffusion model):

```csharp
// src/Services/Ai/MyImageOnlyService.cs
public class MyImageOnlyService : ITextToImageProvider
{
    public async Task<byte[]> GenerateImageAsync(ImagePromptRequest request, CancellationToken cancellationToken = default)
    {
        // Execute the image generation step using request fields.
    }
    // No GenerateTextAsync — ITextToTextProvider is not implemented.
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

## Design Constraints

All extensions must respect the following invariants to integrate correctly with the pipeline:

- **Senders must be stateless.** Do not cache authentication tokens in instance fields; inject them via `IOptions<TCredentials>` (bound at startup from Key Vault via the Configuration Provider). The DI container manages lifetime.
- **`SendAsync` must return `false`, not throw, on non-fatal platform errors.** Throwing from a sender propagates the exception to `XFunction` and prevents App Insights from recording a clean skip.
- **`MessageMaxLenght` must be accurate.** `FeedOrchestrator` relies on this value to size AI summarisation calls. An incorrect value causes content that is either silently truncated at the platform layer or wastes character budget on secondary re-summarisation.
- **`OrchestrateAsync` must return an empty dictionary with `SendIt = false`, not throw, when no content can be produced.** `XFunction` treats an empty result as a graceful skip; an exception is treated as a pipeline failure.
- **`OrchestrateAsync` returns one entry per configured sender.** The dictionary key is `SenderPlatform`; a `null` value signals content generation failure for that specific sender. `BaseOrchestrator.PostAsync` skips null entries with a warning log and returns `false` for the overall slot.
- **Orchestrators must implement `SupportedPlatforms`.** The property must include every `SenderPlatform` value the orchestrator has been validated against, and always include `SenderPlatform.DryRun`. `NoOrchestrator` is the only valid exception (empty list).
- **Orchestrators must be idempotent where possible.** Avoid side effects beyond returning a dictionary of posts. In particular, do not call `ISender.SendAsync` from inside an orchestrator — that responsibility belongs to `BaseOrchestrator.PostAsync`, which dispatches all senders in parallel via `Task.WhenAll`.
- **Orchestrators must handle null capability providers explicitly.** `ITextToTextProvider?` and `ITextToImageProvider?` are injected as nullable. Check before use and degrade gracefully: return a text-only post when `imageProvider` is null, return an empty dictionary early when `textProvider` is null and text generation is required.
- **Orchestrators own prompt intent.** Construct `PromptRequest` and `ImagePromptRequest` value objects in the orchestrator and pass them to the provider interfaces. Do not embed raw prompt strings or generation parameters inside provider implementations.
- **AI provider services must implement only the capability interfaces they actually support.** Do not implement `ITextToImageProvider` on a text-only provider as a no-op or a `NotSupportedException` stub — leave the interface unimplemented and omit the keyed DI registration. The `null`-resolution contract is the canonical signal for "capability not available".
- **Keyed AI provider registrations live exclusively in `AddXPosterAiProviders()`.** Never add `AddKeyedTransient<ITextToTextProvider, ...>` or `AddKeyedTransient<ITextToImageProvider, ...>` calls outside that method.
- **All external HTTP calls must go through `IHttpClientFactory`.** This ensures connection pooling, Polly resilience pipelines (retry, circuit breaker, attempt timeout), and consistent timeout configuration across the entire codebase. Creating `new HttpClient()` inline is prohibited.
- **Every new sender must include a `*CredentialsExtensions.cs` file** in `src/Credentials/`, declaring `SectionName` on the credentials DTO and the `Add*Credentials(IServiceCollection, IConfiguration)` extension method. `Program.cs` must use only the extension method — never raw `Configure<T>` + `GetSection("...")` literals for sender credentials.
- **Every new AI provider must include an `*OptionsExtensions.cs` file** in its `src/Models/<ProviderName>/` folder, declaring `SectionName` and the `Add*Options(IServiceCollection, IConfiguration)` extension method. `Program.cs` must use only the extension method — never raw `Configure<T>` + `GetSection("...")` literals for AI provider options.
- See [architecture.md](architecture.md) for full ADRs and design pattern rationale.
