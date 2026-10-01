# Feed API Contract

## Overview

This document outlines the expected HTTP contract for a simple feed management API used by the RSS reader.

## Endpoints

### GET /api/feeds

Returns all currently tracked feed sources.

**Response**:

```json
[
  {
    "id": "feed-1",
    "title": "Example Feed",
    "url": "https://example.com/feed.xml",
    "status": "active",
    "lastFetchedAt": "2026-10-01T12:00:00Z"
  }
]
```

### POST /api/feeds

Adds a new feed source after validating the URL and the feed format.

**Request body**:

```json
{
  "url": "https://example.com/feed.xml"
}
```

**Success response**:

```json
{
  "id": "feed-1",
  "title": "Example Feed",
  "url": "https://example.com/feed.xml",
  "status": "active"
}
```

**Error response**:

```json
{
  "error": "The provided URL is not a valid RSS or Atom feed."
}
```

### POST /api/feeds/:id/refresh

Refreshes a specific feed and returns the latest item count results.

**Response**:

```json
{
  "feedId": "feed-1",
  "added": 3,
  "updated": 1,
  "failed": 0,
  "refreshedAt": "2026-10-01T12:05:00Z"
}
```

### DELETE /api/feeds/:id

Removes a feed and stops returning its articles.

**Response**:

```json
{
  "deleted": true,
  "feedId": "feed-1"
}
```

### GET /api/articles

Returns items from the active feed list with optional filters such as unread-only.

**Query parameters**:

- `feedId` (optional)
- `unreadOnly` (optional, boolean)

**Response**:

```json
[
  {
    "id": "item-1",
    "feedId": "feed-1",
    "title": "Newest Article",
    "summary": "A short summary of the article.",
    "link": "https://example.com/article",
    "publishedAt": "2026-10-01T11:59:00Z",
    "isRead": false
  }
]
```
