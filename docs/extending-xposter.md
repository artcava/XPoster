# Extending XPoster

XPoster is designed around three extension points: **Senders** (platform plugins), **Orchestrators** (content strategies), and **AI Providers** (model integrations). Each maps to a dedicated abstraction and can be implemented without modifying any existing component.

> For the architectural rationale behind each extension point, see [architecture.md §5](architecture.md#5-extension-points).

---

## Adding a New Sender (Platform)

A sender is a class that implements `ISender` and knows how to publish a `Post` to a specific social network. It owns all platform-specific concerns: authentication, payload serialisation, rate-limit handling, and error mapping.

### Step 1 — Implement ISender

```csharp
// src/SenderPlugins/TikTokSender.cs
public class TikTokSender : ISender
{
    public int MessageMaxLength => 150;

    public async Task<bool> SendAsync(Post post)
    {
        // Call TikTok API here.
        // Return false (do not throw) on non-fatal platform errors.
        return true;
    }
}
```

> `MessageMaxLength` must reflect the platform's actual character limit. Orchestrators use this value to truncate content before calling `SendAsync`.

### Step 2 — Register in DI

```csharp
// src/Program.cs
builder.Services.AddTransient<TikTokSender>();
```

### Step 3 — Add Enum Value

```csharp
// src/Contracts/Enums.cs
public enum MessageSender
{
    // existing values...
    TikTokSummaryFeed,
    TikTokPowerLaw,
}
```

### Step 4 — Wire in OrchestratorFactory

`OrchestratorFactory.Resolve()` resolves the concrete sender through a **switch expression** that maps each `MessageSender` enum value to a specific class retrieved from the DI container. The result is cast to `ISender` because `GetService` returns `object?`; the factory then passes the interface reference to `CreateOrchestratorInstance`, keeping orchestrators fully decoupled from sender implementations.

Add two arms to the existing switch expression inside `Resolve()`:

```csharp
// src/Orchestrators/OrchestratorFactory.cs — sender switch expression
ISender? sender = profile.SenderType switch
{
    // existing arms ...
    MessageSender.TikTokSummaryFeed => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    MessageSender.TikTokPowerLaw    => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    _ => null
};
```

> Both `TikTokSummaryFeed` and `TikTokPowerLaw` resolve to the same `TikTokSender` class. The two enum values express *what is being posted* (content strategy + platform), not *how* — `TikTokSender` owns the how. This mirrors the existing pattern for `XSender` and `InSender`.

### Step 5 — Add a ScheduledOrchestrationProfile entry

The production schedule is owned by `DefaultSlotProfileProvider` (`src/Orchestrators/DefaultSlotProfileProvider.cs`), which implements `ISlotProfileProvider`. Add the new profile to its `GetProfiles()` return list, specifying the UTC hour, sender type, orchestrator type, and (optionally) the AI provider for that slot:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(20, MessageSender.TikTokSummaryFeed, typeof(FeedOrchestrator), AiProvider.OpenAi),
];
```

> `OrchestratorFactory` no longer owns a static profile list — it receives `ISlotProfileProvider` via constructor injection and calls `GetProfiles()` at resolution time. Only `DefaultSlotProfileProvider` needs to change when adding a production slot.

**Validation**: Write a unit test for the new sender using a mock `Post` to verify serialisation and error-return behaviour before integration.

---

## Adding a New Orchestrator (Content Strategy)

An orchestrator inherits from `BaseOrchestrator` and overrides `OrchestrateAsync()` to produce a `Post`. It receives its dependencies — sender, AI service, and any data services — via constructor injection; `OrchestratorFactory` resolves them automatically through reflection.

### Step 1 — Extend BaseOrchestrator

```csharp
// src/Orchestrators/QuoteOrchestrator.cs
public class QuoteOrchestrator : BaseOrchestrator
{
    public QuoteOrchestrator(ISender sender, ILogger<QuoteOrchestrator> logger, IAiService aiService)
        : base(sender, logger, aiService) { }

    public override async Task<Post>? OrchestrateAsync()
    {
        // Return null (do not throw) when no content can be produced.
        // XFunction will skip posting gracefully.
        var quote = await _aiService.GetCompletionAsync("Generate a motivational tech quote.", 100);
        if (string.IsNullOrWhiteSpace(quote)) return null;
        return new Post { Content = quote };
    }
}
```

> **Invariant**: `OrchestrateAsync()` must return `null` — not throw — when content cannot be produced. `XFunction` treats a `null` return as a graceful skip; an exception is treated as a pipeline failure.

### Step 2 — Add a ScheduledOrchestrationProfile entry

Reference the new orchestrator type in `DefaultSlotProfileProvider.GetProfiles()`. `CreateOrchestratorInstance` in `OrchestratorFactory` resolves constructor parameters automatically via reflection:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs
public IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles() =>
[
    // existing profiles ...
    new ScheduledOrchestrationProfile(10, MessageSender.XSummaryFeed, typeof(QuoteOrchestrator), AiProvider.Perplexity),
];
```

No other change to `OrchestratorFactory` is required. The factory receives the updated profile list via `ISlotProfileProvider` at runtime without any code modification.

---

## Adding a New AI Provider

The AI layer is abstracted behind `IAiService`. `AiServiceFactory` resolves implementations using the .NET **keyed services** mechanism: each `IAiService` is registered against its `AiProvider` enum value as the key, and `AiServiceFactory.GetByProvider()` calls `GetKeyedService<IAiService>(provider)` to retrieve it. There is no switch inside the factory — adding a new provider requires only registering the implementation under the correct key and declaring that key as supported.

### Step 1 — Add the Enum Value

Append a new value to `AiProvider`. Assign an explicit integer to avoid accidental renumbering of existing values:

```csharp
// src/Contracts/AiProvider.cs
public enum AiProvider
{
    None         = 0,
    OpenAi       = 1,
    Perplexity   = 2,
    AzureFoundry = 3,
    Anthropic    = 4,  // new
}
```

### Step 2 — Implement IAiService

```csharp
// src/Services/Ai/AnthropicAiService.cs
public class AnthropicAiService : IAiService
{
    // Model names, SDK dependencies, and API keys are internal to this class.
    public async Task<string> GetCompletionAsync(string prompt, int maxTokens)
    {
        // Call Anthropic Messages API
    }

    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        // Anthropic does not offer a native image model;
        // delegate to a compatible image provider or throw NotSupportedException.
    }
}
```

### Step 3 — Register as a Keyed Service and Declare as Supported

`AiServiceFactory` resolves providers via `GetKeyedService<IAiService>(provider)`, so the implementation must be registered as a **keyed transient** against its `AiProvider` enum value — not as a plain `AddTransient`. A plain registration would be invisible to the factory.

```csharp
// src/Program.cs
builder.Services.AddKeyedTransient<IAiService, AnthropicAiService>(AiProvider.Anthropic);
builder.Services.AddAnthropicOptions(builder.Configuration);  // see Step 4
```

Then add the new value to the `_supportedProviders` set in `AiServiceFactory`. This guard is what `GetByProvider` checks before attempting resolution; without it the factory throws `ArgumentException` even if the service is correctly registered:

```csharp
// src/Orchestrators/AiServiceFactory.cs
private static readonly HashSet<AiProvider> _supportedProviders =
[
    AiProvider.OpenAi,
    AiProvider.AzureFoundry,
    AiProvider.Anthropic,  // new
];
```

No further change to `AiServiceFactory` is needed. The new provider is immediately available for assignment in any `ScheduledOrchestrationProfile` and via the global `AiProvider` configuration key.

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

## Adding a New Service (Data Source)

For new external data integrations (e.g., a news API, a stock ticker, a weather feed), define an interface in `src/Contracts/` and implement it in `src/Services/`. Inject the new service into the orchestrator that needs it — `CreateOrchestratorInstance` will resolve it automatically.

```csharp
// src/Contracts/INewsService.cs
public interface INewsService
{
    Task<IEnumerable<string>> GetHeadlinesAsync(int count);
}

// src/Services/NewsService.cs
public class NewsService : INewsService
{
    public async Task<IEnumerable<string>> GetHeadlinesAsync(int count)
    {
        // Call a news API
    }
}
```

Register in `Program.cs`:

```csharp
builder.Services.AddTransient<INewsService, NewsService>();
```

---

## Design Constraints

All extensions must respect the following invariants to integrate correctly with the pipeline:

- **Senders must be stateless.** Do not cache authentication tokens in instance fields; use the DI-injected configuration or a token-provider service. The DI container manages lifetime.
- **`SendAsync` must return `false`, not throw, on non-fatal platform errors.** Throwing from a sender propagates the exception to `XFunction` and prevents App Insights from recording a clean skip.
- **`MessageMaxLength` must be accurate.** Orchestrators rely on this value to truncate content before calling `SendAsync`. An incorrect value causes silent data loss at the platform layer.
- **`OrchestrateAsync` must return `null`, not throw, when no content can be produced.** `XFunction` treats a `null` return as a graceful skip; an exception is treated as a pipeline failure.
- **Orchestrators must be idempotent where possible.** Avoid side effects beyond returning a `Post`. In particular, do not call `ISender.SendAsync` from inside an orchestrator — that responsibility belongs to `XFunction`.
- **All external HTTP calls must go through `IHttpClientFactory`.** This ensures connection pooling, retry policies, and timeout configuration are applied consistently.
- **Every new AI provider must include an `*OptionsExtensions.cs` file** in its `src/Models/<ProviderName>/` folder, declaring `SectionName` and the `Add*Options(IServiceCollection, IConfiguration)` extension method. `Program.cs` must use only the extension method — never raw `Configure<T>` + `GetSection("...")` literals for AI provider options.
- See [architecture.md](architecture.md) for full ADRs and design pattern rationale.
