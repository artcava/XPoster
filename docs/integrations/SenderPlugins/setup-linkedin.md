# LinkedIn Setup

> **TODO**: This page is a placeholder. Full setup documentation is pending.

## Overview

XPoster publishes posts to LinkedIn using the Marketing API with OAuth 2.0 authentication. LinkedIn access tokens expire after **60 days** and must be rotated regularly.

## Required Configuration

| App Setting | Description |
|---|---|
| `LinkedInAccessToken` | OAuth 2.0 access token |
| `LinkedInAuthorId` | LinkedIn person URN (e.g. `urn:li:person:XXXXXXXX`) |

## Steps

1. Go to the [LinkedIn Developer Portal](https://www.linkedin.com/developers/) and create an app.
2. Request the `w_member_social` permission scope.
3. Complete the OAuth 2.0 authorization flow to obtain an access token.
4. Copy the access token and your person URN into your Azure Functions app settings.

## Token Rotation

LinkedIn OAuth 2.0 access tokens expire after **60 days**. You must manually refresh them before expiry to avoid publishing failures. Consider setting a calendar reminder to rotate the token every ~50 days.
