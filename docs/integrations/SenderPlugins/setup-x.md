# Twitter / X Setup

> **TODO**: This page is a placeholder. Full setup documentation is pending.

## Overview

XPoster publishes posts to Twitter / X using the API v2 with OAuth 1.0a authentication.

## Required Configuration

| App Setting | Description |
|---|---|
| `XApiKey` | Twitter/X API Key (Consumer Key) |
| `XApiKeySecret` | Twitter/X API Key Secret (Consumer Secret) |
| `XAccessToken` | OAuth 1.0a Access Token |
| `XAccessTokenSecret` | OAuth 1.0a Access Token Secret |

## Steps

1. Go to the [Twitter Developer Portal](https://developer.twitter.com/en/portal/dashboard).
2. Create a project and an app with **Read and Write** permissions.
3. Generate OAuth 1.0a **Access Token** and **Access Token Secret** under the app's *Keys and Tokens* section.
4. Copy all four values into your Azure Functions app settings (or `local.settings.json` for local development).

## Notes

- Ensure the app has **Read and Write** permissions; Read-only apps cannot post.
- Free tier API access may have posting limits; review your Twitter developer plan.
