# Quickstart: RSS Feed Reader

## Prerequisites

- Node.js 18 or newer
- npm or pnpm
- A local browser to preview the app

## Setup

1. Initialize the project with Vite and React.
2. Install dependencies for routing, state management, and feed parsing.
3. Create the feed service, article state store, and UI shell.

## Run the app

```bash
npm install
npm run dev
```

## Typical workflow

1. Enter a valid RSS or Atom URL in the add-feed form.
2. Confirm that the app loads recent articles from that source.
3. Refresh the feed to check for new posts.
4. Open an article or external link to read the full content.
5. Mark items as read and filter unread entries as needed.

## Validation

- Confirm one feed loads correctly and the article list updates.
- Check that invalid URLs show a clear error message.
- Verify that feed refresh preserves existing entries on failure.
- Confirm that removing a feed stops it from appearing in the active list.
