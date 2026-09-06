# OpenAI — Setup Guide

This guide explains how to obtain OpenAI API credentials and configure XPoster to use `OpenAiService` as the AI text and image provider (`ITextToTextProvider` + `ITextToImageProvider`, keyed by `AiProvider.OpenAi`).

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
| `OpenAI__TextModelName` | The chat model name (default `gpt-4.1-nano`) |
| `OpenAI__ImageModelName` | The image model name (default `gpt-image-1.5`) |

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "OpenAI__ApiKey": "<your-openai-api-key>",
    "OpenAI__Endpoint": "https://api.openai.com/v1/",
    "OpenAI__TextModelName": "gpt-4.1-nano",
    "OpenAI__ImageModelName": "gpt-image-1.5"
  }
}
```

These settings configure **connectivity and models only**. There is no global `AiProvider`
switch — each AI node selects its own provider: point an `AiText` node at OpenAI with
`Workflows__<key>__Nodes__N__Parameters__Provider: "OpenAi"` (the default when omitted), and
an `AiImage` node the same way. Prompt templates, temperature, and token budgets live in
`PromptSteps__<StepId>__*`, referenced by the nodes' `StepId`. See `src/local.settings.json.example`
for the full list.

## 6. Store Secrets Safely

For production environments:

- Store `OpenAI__ApiKey` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. Troubleshooting

### 401 Unauthorized

- Check that `OpenAI__ApiKey` matches the key in your OpenAI dashboard.
- Ensure the key has not been revoked or rotated.

### 404 Model Not Found

- Verify the model name in `OpenAI__TextModelName` or `OpenAI__ImageModelName` is correct and available on your account tier.
- Check [platform.openai.com/docs/models](https://platform.openai.com/docs/models) for availability.

### 429 Too Many Requests / Rate Limit

- You have exceeded your rate limit or monthly quota.
- Review usage at **Settings → Usage** and consider upgrading your tier or adding credits.

### 400 Bad Request

- Verify the endpoint URL format: no trailing slash.
- Ensure the request payload matches the model's expected parameters (e.g. `dall-e-3` does not support all `gpt-image-1.5` parameters).

### Empty or Low-Quality Output

- Verify that the `PromptSteps__<StepId>` entry referenced by the `AiText` node defines a `SystemPromptTemplate` containing `{MaxChars}` and a `UserPromptTemplate` containing the input label (`InputTextLabel`, default `{Text}`).
- For image prompts, check the step used by the `AiImage` node.
- Consider using a larger model for better output quality.
