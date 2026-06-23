# fal.ai — Setup Guide

This guide explains how to obtain fal.ai API credentials and configure XPoster to use `FalAiImageService` as the image generation provider.

> **Provider capabilities:** Image generation only (FLUX.2 Turbo)  
> **`AiProvider` enum value:** `FalAi`

---

## 1. Create a fal.ai Account

1. Sign up or log in at [fal.ai](https://fal.ai/).
2. Navigate to **Dashboard → API Keys**.
3. Click **Add key**, give it a name (e.g. `xposter`), and copy the key immediately — it is shown only once.
4. Store the key in a password manager or Azure Key Vault.

> ⚠️ Keep your API key private. Never commit it to source control.

## 2. Enable Billing

fal.ai uses pay-per-inference pricing:

1. Go to **Dashboard → Billing**.
2. Add a payment method and load credits.
3. Monitor consumption from the **Usage** section of the dashboard.

## 3. Model Used by XPoster

XPoster uses the **FLUX.2 Turbo** model via fal.ai for all image generation tasks. This model is hardcoded in `FalAiImageService` — no model selection is required in configuration.

| Model | Endpoint (internal) | Notes |
|-------|---------------------|-------|
| FLUX.2 Turbo | `fal-ai/flux/turbo` | Fast, high-quality image generation; optimized for social media content |

## 4. Retrieve Required Parameters

| Parameter | Value |
|-----------|-------|
| `ApiKey` | The API key created in step 1 |

No endpoint URL configuration is needed — `FalAiImageService` uses the fal.ai SDK which resolves the endpoint automatically.

## 5. Configure XPoster

```json
{
  "Values": {
    "AiProvider": "FalAi",
    "FALAI_API_KEY": "<your-falai-api-key>"
  }
}
```

## 6. Store Secrets Safely

For production environments:

- Store `FALAI_API_KEY` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. How fal.ai Fits in the AI Layer

`FalAiImageService` handles `GenerateImageAsync` exclusively:

| Operation | Routed to | Rationale |
|-----------|-----------|----------|
| `GetSummaryAsync` | ❌ Not supported | fal.ai is image-only |
| `GetImagePromptAsync` | ❌ Not supported | fal.ai is image-only |
| `GenerateImageAsync` | `FalAiImageService` | FLUX.2 Turbo delivers fast, high-quality images for social media content |

## 8. Troubleshooting

### 401 Unauthorized

- Check that `FALAI_API_KEY` is valid and not revoked.
- Regenerate the key from the fal.ai dashboard if needed.

### 402 Payment Required / Insufficient Credits

- Top up your fal.ai account balance from **Dashboard → Billing**.

### 422 Unprocessable Entity

- The image prompt may contain content that violates fal.ai's content policy.
- Review the prompt in the Application Insights logs.
- Adjust `ImagePromptUserTemplate` to produce safer prompts if needed.

### Slow or Timed-Out Generation

- FLUX.2 Turbo is optimized for speed, but generation time varies with load.
- Check the [fal.ai status page](https://status.fal.ai/) for ongoing incidents.
- Consider increasing the timeout configured for the fal.ai HTTP client in `Program.cs`.

### Low Image Quality

- Review the image prompt logged in Application Insights — the prompt is the main driver of quality.
- Ensure `ImagePromptUserTemplate` includes `{Summary}` and produces descriptive, specific prompts.
