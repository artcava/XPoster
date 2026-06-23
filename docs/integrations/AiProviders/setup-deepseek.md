# DeepSeek — Setup Guide

This guide explains how to obtain DeepSeek API credentials and configure XPoster to use `DeepSeekService` as the text provider.

> **Provider capabilities:** Text only (chat completion)  
> **`AiProvider` enum value:** `DeepSeek`

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
| `Endpoint` | `https://api.deepseek.com/v1` |
| `ApiKey` | The API key created in step 1 |
| `Model` | e.g. `deepseek-chat` |

## 5. Configure XPoster

```json
{
  "Values": {
    "AiProvider": "DeepSeek",
    "DEEPSEEK_API_KEY": "<your-deepseek-api-key>",
    "DEEPSEEK_MODEL": "deepseek-chat"
  }
}
```

## 6. Store Secrets Safely

For production environments:

- Store `DEEPSEEK_API_KEY` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. Troubleshooting

### 401 Unauthorized

- Check that `DEEPSEEK_API_KEY` is valid and not revoked.
- Ensure there are sufficient credits in your DeepSeek account.

### 404 Model Not Found

- Verify that `DEEPSEEK_MODEL` is a valid model identifier (e.g. `deepseek-chat`).
- Check the [DeepSeek model list](https://platform.deepseek.com/api-docs) for supported names.

### 429 Too Many Requests

- You have exceeded your rate limit or run out of credits.
- Top up your account balance in the DeepSeek dashboard.

### Empty or Truncated Output

- Verify that prompt templates include all required placeholders:
  - `SummarySystemPromptTemplate` must include `{MaxChars}`
  - `SummaryUserPromptTemplate` must include `{Text}`
  - `ImagePromptUserTemplate` must include `{Summary}`
- Check `DEEPSEEK_MODEL` is not set to a reasoning model (`deepseek-reasoner`) when low latency is needed — reasoning models are slower and more expensive.
