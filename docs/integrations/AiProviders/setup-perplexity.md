# Perplexity AI — Setup Guide

XPoster supports Perplexity as an AI provider for text summarisation and image
prompt generation via the [Sonar Chat Completions API](https://docs.perplexity.ai/reference/post_chat_completions).

> ⚠️ **Image generation is not supported.** When `AiProvider = Perplexity`,
> `GenerateImageAsync` always returns an empty byte array and logs a `Warning`.
> Posts will be published **without an attached image**.

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

Copy the Perplexity block from `src/local.settings.json.example` into your
`src/local.settings.json` and fill in the required values:

```jsonc
// ══ AI — Perplexity (AiProvider = "Perplexity") ════════════════════════
"AiProvider":                              "Perplexity",
"Perplexity__ApiKey":                      "<your-perplexity-api-key>",
"Perplexity__Endpoint":                    "https://api.perplexity.ai",
"Perplexity__DeploymentName":              "sonar",
"Perplexity__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
"Perplexity__SummaryUserPromptTemplate":   "Summarize this text in a few sentences. text: {Text}",
"Perplexity__ImagePromptSystemTemplate":   "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content and avoids text, signs, or words in the image.",
"Perplexity__ImagePromptUserTemplate":     "Generate an image prompt based on this summary: {Summary}",
"Perplexity__SummaryTemperature":          "0.5",
"Perplexity__SummaryMaxTokensPerChar":     "5",
"Perplexity__SummarySafetyMarginChars":    "50",
"Perplexity__ImagePromptMaxTokens":        "60",
"Perplexity__ImagePromptTemperature":      "0.7"
```

All settings except `Perplexity__ApiKey` have sensible defaults and can be
omitted if the default values suit your use case.

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
[PerplexityService] does not support image generation. Returning empty byte array.
[DryRunSender] Image attached: False
[DryRunSender] Dry run complete — no post published.
```

---

## 8. Image Generation Behaviour

`PerplexityService.GenerateImageAsync` always returns `Array.Empty<byte>()` and
emits a structured `Warning` log:

```
{Service} does not support image generation. Returning empty byte array.
```

The orchestrator interprets an empty byte array as "no image" and publishes the
post as text-only. This is intentional and not an error condition.

If image generation is required, switch to `OpenAi`, `AzureFoundry`, or
`FalAi` instead.

---

## 9. Troubleshooting

| Symptom | Likely cause | Fix |
|---|---|---|
| `401 Unauthorized` | Invalid or missing API key | Verify `Perplexity__ApiKey` is set correctly |
| `402 Payment Required` | Insufficient credits | Add credits at perplexity.ai/settings/api |
| `404 Not Found` | Wrong endpoint or model name | Check `Perplexity__Endpoint` and `Perplexity__DeploymentName` |
| Summary always empty | `choices` array empty or API error | Check structured logs for `[Perplexity]` warning entries |
| Posts published without image | Expected — Perplexity does not support image generation | Use a different provider if images are required |
