# Twitter / X Setup

## Overview

XPoster publishes posts to Twitter / X using the API v2 (`POST /2/tweets`) with OAuth 1.0a authentication, and uploads images through the v1.1 chunked media-upload flow (INIT → APPEND → FINALIZE). Requests are signed by the first-party `XOAuth1Signer` (RFC 5849 HMAC-SHA1) and routed through the resilient named `"X"` client with the standard Polly pipeline. Media chunks are posted as `media` parts in a `multipart/form-data` body (required by the APPEND command), and the `media_type` sent to INIT is detected from the actual image bytes (JPEG, PNG, GIF, WebP) rather than hardcoded.

## Required Configuration

Credentials are bound to `XCredentials` (`XPoster.Credentials`) via `IOptions<XCredentials>` and loaded from Azure Key Vault at startup. Use the double-dash secret naming convention so each secret maps to the matching configuration key:

| Key Vault secret name | Configuration key | Description |
|---|---|---|
| `XCredentials--XApiKey` | `XCredentials:XApiKey` | Twitter/X API Key (Consumer Key) |
| `XCredentials--XApiSecret` | `XCredentials:XApiSecret` | Twitter/X API Key Secret (Consumer Secret) |
| `XCredentials--XAccessToken` | `XCredentials:XAccessToken` | User Access Token (OAuth 1.0a) |
| `XCredentials--XAccessTokenSecret` | `XCredentials:XAccessTokenSecret` | User Access Token Secret (OAuth 1.0a) |

## Steps

1. Go to the [Twitter Developer Portal](https://developer.twitter.com/en/portal/dashboard).
2. Create a project and an app with **Read and Write** permissions.
3. Generate OAuth 1.0a **Access Token** and **Access Token Secret** under the app's *Keys and Tokens* section.
4. Store the four values in Azure Key Vault using the secret names above (or in `local.settings.json` with double-underscore keys, e.g. `XCredentials__XApiKey`, for local development).

## Usage & Credits (Pay-per-Use)

The X API moved to a **pay-per-use credit model**. Check your plan and balances on the **Usage & Billing / Credits** page of the [X Developer Portal](https://developer.twitter.com/en/portal/dashboard) and keep credits topped up ahead of scheduled posts. Posting a tweet consumes a small number of credits; each request is metered.

## Notes

- Ensure the app has **Read and Write** permissions; Read-only apps cannot post.
- If publishing fails with `402 Payment Required` (`usage_cap_exceeded`), the developer account has exhausted its credits — add credits in the Developer Portal and wait for the next scheduled run.
- Failure logs include the HTTP status and the parsed X error body (title, detail, label), so credit/limit issues are diagnosable from Application Insights alone.
- If an attached image's format cannot be detected, `XSender` logs a warning and falls back to a text-only tweet instead of failing the run.
