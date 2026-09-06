# Twitter / X Setup

> **TODO**: This page is a placeholder. Full setup documentation is pending.

## Overview

XPoster publishes posts to Twitter / X using the API v2 with OAuth 1.0a authentication.

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

## Notes

- Ensure the app has **Read and Write** permissions; Read-only apps cannot post.
- Free tier API access may have posting limits; review your Twitter developer plan.
