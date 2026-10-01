# Data Model: RSS Feed Reader

## Core Entities

### FeedSource

Represents a single subscribed RSS or Atom source.

| Field | Type | Description |
|------|------|-------------|
| id | string | Unique identifier for the feed |
| title | string | Display name of the source |
| url | string | Original feed URL |
| siteUrl | string | Optional homepage or site URL |
| lastFetchedAt | datetime | Last successful refresh time |
| status | enum | active, error, removed |

### FeedItem

Represents an individual article or post pulled from a feed.

| Field | Type | Description |
|------|------|-------------|
| id | string | Unique identifier of the item |
| feedId | string | Source feed that owns the item |
| title | string | Article title |
| link | string | Canonical article URL |
| summary | string | Short description or excerpt |
| publishedAt | datetime | Original publication timestamp |
| isRead | boolean | Tracking for unread vs. read state |
| guid | string | Stable unique key from the source feed |

### UserReadingState

Tracks personal reading preferences and view state.

| Field | Type | Description |
|------|------|-------------|
| userId | string | Local user profile or storage key |
| readItems | string[] | IDs of items marked as read |
| hiddenFeeds | string[] | Feeds hidden from the active list |
| unreadOnly | boolean | Filter mode for unread content |

## Relationships

- One FeedSource can have many FeedItem records.
- FeedItem belongs to exactly one FeedSource.
- UserReadingState is a cross-cutting preference model that interacts with item visibility and unread tracking.
- FeedSource status may change from active to error when a refresh fails.

## Validation Rules

- Feed URL must be syntactically valid and resolvable.
- Feed item title and link are required for display and navigation.
- Duplicate feed URLs should be prevented during creation.
- Duplicate item GUIDs should be ignored on refresh to avoid redundant entries.
