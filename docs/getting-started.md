# Getting Started

This guide walks you through running XPoster locally for the first time.

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Azure Functions Core Tools v4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite) (local Azure Storage emulator)
- An Azure subscription with a Key Vault instance; `az login` authenticated Azure CLI session
- An API key for at least one AI provider (only if you exercise an AI workflow such as `Bitcoin`):
  - **OpenAI** — `OpenAI__ApiKey` (default provider for the `AiText` / `AiImage` nodes)
  - **Azure AI Foundry** — `AzureFoundry__Endpoint` + `AzureFoundry__ApiKey`
  - **DeepSeek + fal.ai** — `DeepSeek__ApiKey` + `FalAi__ApiKey`
  - **Perplexity** — `Perplexity__ApiKey` (text-only; no image generation)

Each AI node names its own provider via `Workflows__<key>__Nodes__N__Parameters__Provider` — there is no global AI provider selection.

---

## First Run (Dry Run — nothing is published)

The fastest way to verify the pipeline end to end is with a **dry-run slot**: a normal `Schedule__*` entry whose senders are the dry-run platforms (`DryRunMaxLength`, `DryRunShortLength`). The full workflow — feed fetch, AI text/image generation, fan-out — runs as in production, but `DryRunSender` **logs the post instead of publishing**.

> ⚠️ **Two startup requirements apply even for a dry-run.**
> 1. `KEYVAULT_URI` is mandatory (`Program.cs` fails fast if unset — `AddAzureKeyVault` is the Configuration Provider that delivers every credential).
> 2. `ICredentialsStartupValidator.Validate()` runs at startup and validates **all four** platform credentials sections (X, LinkedIn, Instagram, Facebook). Your Key Vault must therefore contain those secrets — they are validated but **never used** when the dry-run senders are selected, and nothing is published. This mirrors production: a misconfigured platform fails fast instead of failing at publish time.

### Setup steps

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
   - `KEYVAULT_URI` — your Key Vault URI (the vault must be reachable with `az login`; `DefaultAzureCredential` handles auth)
   - `XApiKey` — a **top-level** key with any non-empty value; this is the dry-run probe signal (distinct from `XCredentials--XApiKey`)
   - Keep **all** platform credential sections present in the vault so the startup validator passes — they are not called during a dry-run
   - `OpenAI__ApiKey` — only if you also dry-run the `Bitcoin` workflow (its `AiText` nodes resolve `Provider: OpenAi`); the `PowerLaw` workflow is AI-free
   - Provide the list of RSS feed URLs in the workflow definition you schedule (`Workflows__<Workflow>__Nodes__0__Parameters__Urls`) — there is no `FeedOptions__Urls` setting
   - Unlock the dry-run slot: uncomment `Schedule__2` (hour 9, `PowerLaw`, with `DryRunMaxLength` + `DryRunShortLength` senders); `ForceHour` is already set to `"9"` in the template so that slot is selected at startup

4. Start Azurite:
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

5. Start the function:
   ```bash
   cd src && func start
   ```

6. Watch the logs for the dry-run probe and the post output:
   ```
   [DryRun] Configuration probe succeeded ('XApiKey' is present, length=…)
   [DryRun] Post content (… chars): "Value of #BTC for the #powerlaw today would be: …
   …" | Image: False
   ```

   Nothing has been published anywhere.

See [Configuration Reference — DryRunSender](configuration.md#dryrunsender--local-testing) for the full dry-run `local.settings.json` snippet and the fan-out semantics of the two dry-run senders.

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
- [Extending XPoster](extending-xposter.md) — add a new sender, workflow, or AI provider