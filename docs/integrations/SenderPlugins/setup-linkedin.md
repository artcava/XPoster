# LinkedIn Setup

> **TODO**: This page is a placeholder. Full setup documentation is pending.

## Overview

XPoster publishes posts to LinkedIn using the Marketing API with OAuth 2.0 authentication. LinkedIn access tokens expire after **60 days** and must be rotated regularly.

## Required Configuration

Credentials are bound to `LinkedInCredentials` (`XPoster.Credentials`) via `IOptions<LinkedInCredentials>` and loaded from Azure Key Vault at startup. Use the double-dash secret naming convention so each secret maps to the matching configuration key:

| Key Vault secret name | Configuration key | Description |
|---|---|---|
| `LinkedInCredentials--LinkedInAccessToken` | `LinkedInCredentials:LinkedInAccessToken` | OAuth 2.0 access token (mandatory) |
| `LinkedInCredentials--LinkedInOrgId` | `LinkedInCredentials:LinkedInOrgId` | LinkedIn organization ID (used for org posts; takes precedence over the owner code) |
| `LinkedInCredentials--LinkedInOwnerCode` | `LinkedInCredentials:LinkedInOwnerCode` | LinkedIn numeric person ID (used when the org ID is not set) |

## Steps

1. Go to the [LinkedIn Developer Portal](https://www.linkedin.com/developers/) and create an app.
2. Request the `w_member_social` permission scope.
3. Complete the OAuth 2.0 authorization flow to obtain an access token.
4. Store the access token and your org/person ID in Azure Key Vault using the secret names above (or in `local.settings.json` with double-underscore keys, e.g. `LinkedInCredentials__LinkedInAccessToken`, for local development).

## Token Rotation

LinkedIn OAuth 2.0 access tokens expire after **60 days**. You must manually refresh them before expiry to avoid publishing failures. Consider setting a calendar reminder to rotate the token every ~50 days.
