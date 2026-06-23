# OpenAI — Setup Guide

This guide explains how to obtain OpenAI API credentials and configure XPoster to use `OpenAiService` as the `IAiService` provider.

> **Provider capabilities:** Text (`ITextToTextProvider`) + Image generation (`ITextToImageProvider`)  
> **`AiProvider` enum value:** `OpenAi`

---

## 1. Create an OpenAI Account and API Key

1. Sign up or log in at [platform.openai.com](https://platform.openai.com/).
2. Navigate to **API Keys** (top-right menu → Your profile → API keys).
3. Click **+ Create new secret key**, give it a name (e.g. `xposter`), and copy it immediately — it is shown only once.
4. Store the key in a password manager or Azure Key Vault.

> ⚠️ Keep your API key private. Never commit it to source control.

## 2. Enable Billing

OpenAI API access requires a funded account:

1. Go to **Settings → Billing** in the OpenAI dashboard.
2. Add a payment method and set a monthly usage limit to avoid unexpected charges.
3. Monitor token consumption from **Settings → Usage**.

## 3. Choose Models

XPoster requires two model types:

| Role | Recommended models | Notes |
|------|--------------------|-------|
| Text (chat completion) | `gpt-4.1-nano`, `gpt-4o-mini`, `gpt-4o` | Cost-efficient options recommended for high-volume summarization |
| Image generation | `gpt-image-1.5`, `dall-e-3` | `gpt-image-1.5` offers better instruction following; `dall-e-3` is widely available |

Model availability depends on your account tier. Check [platform.openai.com/docs/models](https://platform.openai.com/docs/models) for the current list.

## 4. Retrieve Required Parameters

| Parameter | Value |
|-----------|-------|
| `OpenAI__ApiKey` | The secret key created in step 1 |
| `OpenAI__ChatModel` | The chat model name (e.g. `gpt-4.1-nano`) |
| `OpenAI__ImageModel` | The image model name (e.g. `gpt-image-1.5`) |

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "AiProvider": "OpenAi",
    "OpenAI__ApiKey": "<your-openai-api-key>",
    "OpenAI__ChatEndpoint": "https://api.openai.com/v1/chat/completions",
    "OpenAI__ChatModel": "gpt-4.1-nano",
    "OpenAI__ImageEndpoint": "https://api.openai.com/v1/images/generations",
    "OpenAI__ImageModel": "gpt-image-1.5",
    "OpenAI__ImageSize": "1024x1024"
  }
}
```

All other settings (`SummaryTemperature`, prompt templates, etc.) have sensible defaults and can be omitted if the defaults suit your use case. See `src/local.settings.json.example` for the full list.

## 6. Store Secrets Safely

For production environments:

- Store `OpenAI__ApiKey` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. Troubleshooting

### 401 Unauthorized

- Check that `OpenAI__ApiKey` matches the key in your OpenAI dashboard.
- Ensure the key has not been revoked or rotated.

### 404 Model Not Found

- Verify the model name in `OpenAI__ChatModel` or `OpenAI__ImageModel` is correct and available on your account tier.
- Check [platform.openai.com/docs/models](https://platform.openai.com/docs/models) for availability.

### 429 Too Many Requests / Rate Limit

- You have exceeded your rate limit or monthly quota.
- Review usage at **Settings → Usage** and consider upgrading your tier or adding credits.

### 400 Bad Request

- Verify the endpoint URL format: no trailing slash.
- Ensure the request payload matches the model's expected parameters (e.g. `dall-e-3` does not support all `gpt-image-1.5` parameters).

### Empty or Low-Quality Output

- Verify that prompt templates include all required placeholders:
  - `OpenAI__SummarySystemPromptTemplate` must include `{MaxChars}`
  - `OpenAI__SummaryUserPromptTemplate` must include `{Text}`
  - `OpenAI__ImagePromptUserTemplate` must include `{Summary}`
- Consider using a larger model for better output quality.
