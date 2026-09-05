# Perplexity AI — Setup Guide

XPoster supports Perplexity as an AI provider for text summarisation and image
prompt generation via the [Sonar Chat Completions API](https://docs.perplexity.ai/reference/post_chat_completions).

> **Provider capabilities:** Text only (`ITextToTextProvider`)  
> **`AiProvider` enum value:** `Perplexity`

> ⚠️ **Image generation is not supported.** Assign `Provider: Perplexity` only on
> `AiText` nodes (`Workflows__<key>__Nodes__N__Parameters__Provider`); an `AiImage` node pointing
> at it throws `InvalidOperationException`. If image generation is required, use `OpenAi`,
> `AzureFoundry`, or pair `Perplexity` (text) with `FalAi` (image) on separate nodes.

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

Set `Perplexity__TextModelName` to the model identifier you want to use.

---

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "Perplexity__ApiKey": "<your-perplexity-api-key>",
    "Perplexity__Endpoint": "https://api.perplexity.ai",
    "Perplexity__TextModelName": "sonar"
  }
}
```

These settings configure **connectivity and models only**. There is no global `AiProvider`
switch — the provider is chosen per AI node via `Workflows__<key>__Nodes__N__Parameters__Provider:
"Perplexity"` (assign it on `AiText` nodes only). Prompt templates, temperature, and token budgets
live in `PromptSteps__<StepId>__*`, referenced by the nodes' `StepId`. See
`src/local.settings.json.example` for the full list.

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

Run a dry-run locally to confirm the provider is wired up correctly. Point an `AiText` node at
Perplexity (e.g. `Workflows__Bitcoin__Nodes__1__Parameters__Provider: "Perplexity"`), then:

```bash
cd src && func start
```

When a dry-run slot is selected, the dry-run probe and the post output appear in the logs
(no `Image` is expected on a text-only workflow):

```
[DryRun] Configuration probe succeeded ('XApiKey' is present, length=…)
[DryRun] Post content (… chars): "…" | Image: False
```

Nothing is published anywhere.

---

## 8. Troubleshooting

| Symptom | Likely cause | Fix |
|---|---|---|
| `401 Unauthorized` | Invalid or missing API key | Verify `Perplexity__ApiKey` is set correctly |
| `402 Payment Required` | Insufficient credits | Add credits at perplexity.ai/settings/api |
| `404 Not Found` | Wrong endpoint or model name | Check `Perplexity__Endpoint` and `Perplexity__TextModelName` |
| Summary always empty | `choices` array empty or API error | Check structured logs for `[Perplexity]` warning entries |
| Posts published without image | Expected — Perplexity is `ITextToTextProvider` only | Use `OpenAi`, `AzureFoundry`, or `FalAi` if images are required |
