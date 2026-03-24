# Getting Started

This guide walks you through cloning, configuring, and running XPoster locally for the first time.

## Prerequisites

| Tool | Version | Link |
|---|---|---|
| .NET SDK | 8.0+ | [Download](https://dotnet.microsoft.com/download/dotnet/8.0) |
| Azure Functions Core Tools | v4 | [Install](https://docs.microsoft.com/azure/azure-functions/functions-run-local) |
| Visual Studio / VS Code | Latest | — |
| Azure Account | Active subscription | [Sign up](https://azure.microsoft.com/free/) |
| Azure OpenAI Service | GPT-4 + DALL-E 3 deployments | [Docs](https://learn.microsoft.com/azure/cognitive-services/openai/) |

## 1. Clone the Repository

```bash
git clone https://github.com/artcava/XPoster.git
cd XPoster
```

## 2. Restore Dependencies

```bash
dotnet restore
```

## 3. Configure Local Settings

A template with all required keys is versioned at `src/local.settings.json.example`.

```bash
cp src/local.settings.json.example src/local.settings.json
```

Open `src/local.settings.json` and fill in your credentials.
See [Configuration Reference](configuration.md) for the full list of variables.

> ⚠️ `local.settings.json` is listed in `.gitignore` and will **never** be committed.

## 4. Build

```bash
dotnet build
```

## 5. Run Tests

```bash
dotnet test
```

For coverage reports:

```bash
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report"
```

## 6. Start Locally

```bash
cd src
func start
```

The function starts and listens according to the `CronSchedule` variable.
For quick local testing use `*/30 * * * * *` (every 30 seconds) in `local.settings.json`.

## Troubleshooting

| Symptom | Likely Cause | Fix |
|---|---|---|
| `Missing value for 'AzureWebJobsStorage'` | Storage emulator not running | Start Azurite or set `UseDevelopmentStorage=true` |
| `401 Unauthorized` on Twitter | Expired or wrong tokens | Regenerate tokens on [developer.twitter.com](https://developer.twitter.com) |
| `OpenAI endpoint not found` | Wrong endpoint URL | Verify `AZURE_OPENAI_ENDPOINT` in Azure Portal |
| Tests fail locally but pass on CI | Missing env vars in test runner | Add vars to your shell or use `dotnet user-secrets` |
