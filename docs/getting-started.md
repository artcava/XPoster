# Getting Started

This guide walks you through running XPoster locally for the first time.

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Azure Functions Core Tools v4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite) (local Azure Storage emulator)
- An Azure subscription with a Key Vault instance
- `az login` authenticated Azure CLI session
- An API key for at least one AI provider:
  - **OpenAI** — `OpenAI__ApiKey` (default provider)
  - **Azure AI Foundry** — `AzureFoundry__Endpoint` + `AzureFoundry__ApiKey`
  - **DeepSeek + fal.ai** — `DeepSeek__ApiKey` + `FalAi__ApiKey`
  - **Perplexity** — `Perplexity__ApiKey` (text-only; no image generation)

---

## First Run (Dry Run — no social credentials needed)

The fastest way to verify the full pipeline locally is with `DryRunSender`, which runs all orchestration steps but never publishes to any social platform.

1. Clone the repository and restore dependencies:
   ```bash
   git clone https://github.com/artcava/XPoster.git
   cd XPoster
   dotnet restore
   ```

2. Copy the settings template:
   ```bash
   cp src/local.settings.json.example src/local.settings.json
   ```

3. Fill in `src/local.settings.json`:
   - `KEYVAULT_URI` — your Key Vault URI
   - `OpenAI__ApiKey` — your OpenAI key (or swap `AiProvider` to another provider)
   - `FeedOptions__Urls__0` — any RSS/Atom feed URL
   - Set `EnableDryRunSlot` to `"true"` and `ForceHour` to `"9"`

4. Start Azurite:
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

5. Start the function:
   ```bash
   cd src && func start
   ```

6. Watch the logs for `[DryRunSender] Dry run complete — no post published.`

See [Configuration Reference](configuration.md#dryrunsender--local-testing) for the full dry-run `local.settings.json` snippet.

---

## Running Tests

```bash
dotnet test
```

To collect code coverage:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

---

## Next Steps

- [Configuration Reference](configuration.md) — full list of all settings
- [Architecture](architecture.md) — understand the component model
- [Extending XPoster](extending-xposter.md) — add a new sender or AI provider
