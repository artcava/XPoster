# fal.ai — Setup Guide

This guide explains how to obtain fal.ai API credentials and configure XPoster to use `FalAiImageService` as the image generation provider.

> **Provider capabilities:** Image generation only (`ITextToImageProvider`)  
> **`AiProvider` enum value:** `FalAi`

> ℹ️ fal.ai does not support text generation. Assign `Provider: FalAi` only on `AiImage` nodes
> (`Workflows__<key>__Nodes__N__Parameters__Provider`); an `AiText` node pointing at it throws
> `InvalidOperationException`. Pair `FalAi` (image) with a text-capable provider on the
> workflow's `AiText` node (e.g. OpenAi or DeepSeek).

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

XPoster uses the **FLUX.1 Turbo** (`fal-ai/flux/schnell`) model via fal.ai for all image generation tasks. The model is configurable via `FalAi__ImageModelName`.

| Model | `FalAi__ImageModelName` | Notes |
|-------|-------------------------|-------|
| FLUX.1 Turbo | `fal-ai/flux/schnell` | Default — fast, high-quality, optimized for social media content |
| FLUX.1 Dev | `fal-ai/flux/dev` | Higher quality, slower and more expensive |

## 4. Retrieve Required Parameters

| Parameter | Value |
|-----------|-------|
| `FalAi__ApiKey` | The API key created in step 1 |
| `FalAi__ImageModelName` | Model identifier (default: `fal-ai/flux/schnell`) |

## 5. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "FalAi__ApiKey": "<your-falai-api-key>",
    "FalAi__ImageModelName": "fal-ai/flux/schnell",
    "FalAi__NumInferenceSteps": "4"
  }
}
```

These settings configure **connectivity and models only**. There is no global `AiProvider`
switch — the provider is chosen per AI node via `Workflows__<key>__Nodes__N__Parameters__Provider:
"FalAi"` (assign it on `AiImage` nodes only, as in the shipped `Bitcoin` workflow). Prompt
templates, image size, and token budgets live in `PromptSteps__<StepId>__*` (the step used by
the `AiImage` node carries its `ImageQuantity`/`ImageSize`). See `src/local.settings.json.example`
for the full list.

## 6. Store Secrets Safely

For production environments:

- Store `FalAi__ApiKey` in **Azure Key Vault** and reference it from Function App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 7. How fal.ai Fits in the AI Layer

`FalAiImageService` implements `ITextToImageProvider` exclusively:

| Capability | Interface | Routed to |
|------------|-----------|----------|
| Text generation (`AiText` nodes) | `ITextToTextProvider` | ❌ Not supported — `GetKeyedService<ITextToTextProvider>(FalAi)` is `null`; an `AiText` node throws |
| Image generation (`AiImage` nodes) | `ITextToImageProvider` | `FalAiImageService` — FLUX.1 Turbo |

## 8. Troubleshooting

### 401 Unauthorized

- Check that `FalAi__ApiKey` is valid and not revoked.
- Regenerate the key from the fal.ai dashboard if needed.

### 402 Payment Required / Insufficient Credits

- Top up your fal.ai account balance from **Dashboard → Billing**.

### 422 Unprocessable Entity

- The image prompt may contain content that violates fal.ai's content policy.
- Review the prompt in the Application Insights logs.
- Adjust the `PromptSteps` step used by the `AiText` node that derives the prompt to produce safer prompts if needed.

### Slow or Timed-Out Generation

- FLUX.1 Turbo is optimized for speed, but generation time varies with load.
- Check the [fal.ai status page](https://status.fal.ai/) for ongoing incidents.
- Consider increasing the timeout configured for the fal.ai HTTP client in `HttpClientExtensions.cs`.

### Low Image Quality

- Review the image prompt logged in Application Insights — the prompt is the main driver of quality.
- Ensure the `PromptSteps` step used by the `AiText` node that derives the image prompt produces descriptive, specific prompts.
