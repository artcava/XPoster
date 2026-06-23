# DeepSeek — Setup Guide

This guide explains how to obtain DeepSeek API credentials and configure XPoster to use `DeepSeekService` as the text provider.

> **Provider capabilities:** Text only (`ITextToTextProvider`)  
> **`AiProvider` enum value:** `DeepSeek`

> ℹ️ DeepSeek does not support image generation. When `AiProvider = DeepSeek`, no
> `ITextToImageProvider` is resolved and posts are published **without an attached image**.
> If image generation is required, use `OpenAi`, `AzureFoundry`, or pair `DeepSeek` with
> `FalAi` by setting `AiProvider = FalAi` for the image slot.

---

## 1. Create a DeepSeek Platform Account

1. Sign up or log in at [platform.deepseek.com](https://platform.deepseek.com/).
2. Navigate to **API Keys** from the dashboard.
3. Click **Create API Key**, give it a descriptive name (e.g. `xposter`), and copy the key immediately — it is shown only once.
4. Store the key in a password manager or Azure Key Vault.

> ⚠️ Keep your API key private. Never commit it to source control.

## 2. Enable Billing

DeepSeek API access is pay-per-token:

1. Go to **Top Up** in the DeepSeek platform dashboard.
2. Add credits to your account.
3. Set spending alerts if available to avoid unexpected charges.
4. Monitor usage from the **Usage** section of the dashboard.

## 3. Choose a Model

DeepSeek provides text-only models. XPoster uses DeepSeek exclusively for chat completion (summaries and image prompt generation):

| Model | Notes |
|-------|-------|
| `deepseek-chat` | General-purpose, recommended for most workloads |
| `deepseek-reasoner` | Chain-of-thought reasoning model; higher cost, better for complex prompts |

For XPoster's summarization tasks, `deepseek-chat` offers the best cost/quality ratio.

## 4. Retrieve Required Parameters

| Parameter | Value |
|-----------|-------|
| `DeepSeek__Endpoint` | `https://api.deepseek.com` |
| `DeepSeek__ApiKey` | The API key created in step 1 |
| `DeepSeek__DeploymentName` | e.g. `deepseek-chat` |

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "AiProvider": "DeepSeek",
    "DeepSeek__Endpoint": "https://api.deepseek.com",
    "DeepSeek__ApiKey": "<your-deepseek-api-key>",
    "DeepSeek__DeploymentName": "deepseek-chat"
  }
}
```

All other settings (`SummaryTemperature`, prompt templates, etc.) have sensible defaults and can be omitted if the defaults suit your use case. See `src/local.settings.json.example` for the full list.

## 6. Store Secrets Safely

For production environments:

- Store `DeepSeek__ApiKey` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. Troubleshooting

### 401 Unauthorized

- Check that `DeepSeek__ApiKey` is valid and not revoked.
- Ensure there are sufficient credits in your DeepSeek account.

### 404 Model Not Found

- Verify that `DeepSeek__DeploymentName` is a valid model identifier (e.g. `deepseek-chat`).
- Check the [DeepSeek model list](https://platform.deepseek.com/api-docs) for supported names.

### 429 Too Many Requests

- You have exceeded your rate limit or run out of credits.
- Top up your account balance in the DeepSeek dashboard.

### Empty or Truncated Output

- Verify that prompt templates include all required placeholders:
  - `DeepSeek__SummarySystemPromptTemplate` must include `{MaxChars}`
  - `DeepSeek__SummaryUserPromptTemplate` must include `{Text}`
  - `DeepSeek__ImagePromptUserTemplate` must include `{Summary}`
- Check `DeepSeek__DeploymentName` is not set to a reasoning model (`deepseek-reasoner`) when low latency is needed — reasoning models are slower and more expensive.
