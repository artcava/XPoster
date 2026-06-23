# Perplexity AI — Setup Guide

XPoster supports Perplexity as an AI provider for text summarisation and image
prompt generation via the [Sonar Chat Completions API](https://docs.perplexity.ai/reference/post_chat_completions).

> **Provider capabilities:** Text only (`ITextToTextProvider`)  
> **`AiProvider` enum value:** `Perplexity`

> ⚠️ **Image generation is not supported.** When `AiProvider = Perplexity`, no
> `ITextToImageProvider` is resolved and posts will be published **without an attached image**.
> If image generation is required, switch to `OpenAi`, `AzureFoundry`, or `FalAi`.

---

## 1. Create a Perplexity Account

Sign up at [perplexity.ai](https://www.perplexity.ai) if you do not already
have an account.

---

## 2. Generate an API Key

1. Open [perplexity.ai/settings/api](https://www.perplexity.ai/settings/api).
2. Click **Generate** under *API Keys*.
3. Copy the key — it will not be shown again.

---

## 3. Add Billing Credits

Perplexity API is pay-per-use. Add credits from the same settings page before
making API calls, otherwise requests return `402 Payment Required`.

---

## 4. Choose a Model

The default model is `sonar`. Available options at the time of writing:

| Model | Context window | Notes |
|---|---|---|
| `sonar` | 127 k | Recommended default |
| `sonar-pro` | 200 k | Higher quality, higher cost |
| `sonar-reasoning` | 127 k | Chain-of-thought, slower |

Set `Perplexity__DeploymentName` to the model identifier you want to use.

---

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "AiProvider": "Perplexity",
    "Perplexity__ApiKey": "<your-perplexity-api-key>",
    "Perplexity__Endpoint": "https://api.perplexity.ai",
    "Perplexity__DeploymentName": "sonar"
  }
}
```

All other settings (`SummaryTemperature`, prompt templates, etc.) have sensible defaults and can be omitted if the defaults suit your use case. See `src/local.settings.json.example` for the full list.

---

## 6. Store the API Key Securely in Production

**Never commit `Perplexity__ApiKey` to source control.**

In Azure, add it as an Application Setting directly in the Function App or
store it in Key Vault and reference it via a Key Vault reference:

```
@Microsoft.KeyVault(SecretUri=https://<vault>.vault.azure.net/secrets/PerplexityApiKey/)
```

---

## 7. Verify the Integration

Run a dry-run locally to confirm the provider is wired up correctly:

```bash
# local.settings.json must have AiProvider = "Perplexity" and Perplexity__ApiKey set
cd src && func start
```

Expected log output on success:

```
[PerplexityService] Summary generated (312 chars)
[PerplexityService] Image prompt generated
[DryRunSender] Image attached: False
[DryRunSender] Dry run complete — no post published.
```

> ℹ️ `Image attached: False` is expected — Perplexity implements `ITextToTextProvider` only
> and is not registered as an `ITextToImageProvider`. The orchestrator publishes text-only posts.

---

## 8. Troubleshooting

| Symptom | Likely cause | Fix |
|---|---|---|
| `401 Unauthorized` | Invalid or missing API key | Verify `Perplexity__ApiKey` is set correctly |
| `402 Payment Required` | Insufficient credits | Add credits at perplexity.ai/settings/api |
| `404 Not Found` | Wrong endpoint or model name | Check `Perplexity__Endpoint` and `Perplexity__DeploymentName` |
| Summary always empty | `choices` array empty or API error | Check structured logs for `[Perplexity]` warning entries |
| Posts published without image | Expected — Perplexity is `ITextToTextProvider` only | Use `OpenAi`, `AzureFoundry`, or `FalAi` if images are required |
