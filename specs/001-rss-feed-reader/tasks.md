# Tasks: RSS Feed Reader

**Input**: Design documents from `/specs/001-rss-feed-reader/`

**Prerequisites**: spec.md, plan.md, research.md, data-model.md, contracts/

## Phase 1: Setup (Shared Infrastructure)

- [ ] T001 Create Vite + React + TypeScript project scaffold in the repository root
- [ ] T002 Install feed parsing and validation dependencies for RSS/Atom content
- [ ] T003 [P] Configure linting, formatting, and test tooling for the web app
- [ ] T004 [P] Define the base app shell and global styling for the reader layout

## Phase 2: Foundational (Blocking Prerequisites)

- [ ] T005 Create the feed source model and article model with validation rules
- [ ] T006 Implement the local storage repository for persisted feeds and reading state
- [ ] T007 Build the feed parsing and normalization service for RSS and Atom inputs
- [ ] T008 Add refresh orchestration logic for fetching, deduplicating, and updating feed items
- [ ] T009 Add shared error handling for invalid URLs, unavailable feeds, and parsing failures

**Checkpoint**: Foundation ready - the feed reader can load and persist data before user-facing flows are built.

## Phase 3: User Story 1 - Add and browse a feed (Priority: P1) 🎯 MVP

**Goal**: Let a user add a feed and immediately view recent items.

**Independent Test**: A user can paste a valid feed URL and see the latest article list.

### Tests for User Story 1

- [ ] T010 [P] [US1] Contract test for feed creation and retrieval in tests/contract/feed-api.spec.ts
- [ ] T011 [P] [US1] Integration test for adding a valid source and rendering article items in tests/integration/feed-reader.spec.ts

### Implementation for User Story 1

- [ ] T012 [P] [US1] Build the Add Feed form component in src/components/AddFeedForm.tsx
- [ ] T013 [P] [US1] Create the FeedSource model in src/models/FeedSource.ts
- [ ] T014 [US1] Implement feed validation and add-feed service logic in src/services/feedParser.ts
- [ ] T015 [US1] Add the feed list view in src/components/FeedList.tsx
- [ ] T016 [US1] Add article list rendering for the latest entries in src/components/ArticleList.tsx
- [ ] T017 [US1] Connect the app shell to the feed and article state in src/app/App.tsx

**Checkpoint**: At this point, a user can add a valid feed and browse article content without the rest of the feature set.

## Phase 4: User Story 2 - Refresh and stay current (Priority: P1)

**Goal**: Keep the app updated as new content becomes available.

**Independent Test**: A user can refresh a feed and see newly published entries appear without losing previous items.

### Tests for User Story 2

- [ ] T018 [P] [US2] Unit test for deduplication and refresh result handling in tests/unit/feedParser.spec.ts
- [ ] T019 [P] [US2] Integration test for failed refresh states and preserved content in tests/integration/feed-reader.spec.ts

### Implementation for User Story 2

- [ ] T020 [P] [US2] Implement refresh service orchestration in src/services/refreshService.ts
- [ ] T021 [US2] Add deduplication logic for article IDs and GUID values
- [ ] T022 [US2] Show refresh status and error states in the feed list or article view
- [ ] T023 [US2] Add last-updated timestamps and refresh controls to the UI

**Checkpoint**: At this point, feed content stays fresh while preserving the user’s existing reading context.

## Phase 5: User Story 3 - Organize reading and manage feeds (Priority: P2)

**Goal**: Give users control over source management and reading flow.

**Independent Test**: A user can filter unread articles and remove an unsubscribed source without breaking the remaining feed list.

### Tests for User Story 3

- [ ] T024 [P] [US3] Unit test for unread filtering and source removal logic in tests/unit/storage.spec.ts
- [ ] T025 [P] [US3] Integration test for removing a feed and clearing its items from the active view

### Implementation for User Story 3

- [ ] T026 [P] [US3] Build the article detail view and reading state controls in src/components/ArticleDetail.tsx
- [ ] T027 [US3] Add unread/read toggling and filter behavior in the article state logic
- [ ] T028 [US3] Implement feed removal and cleanup logic in src/services/storage.ts
- [ ] T029 [US3] Add navigation and empty-state messaging for no items or failed feeds

**Checkpoint**: At this point, users can manage reading habits and maintain multiple feeds without clutter.

## Phase 6: Polish & Cross-Cutting Concerns

- [ ] T030 [P] Review responsive layout behavior across common browser widths
- [ ] T031 [P] Validate accessibility for buttons, list items, and article navigation
- [ ] T032 Improve empty states and loading indicators across the app
- [ ] T033 Run end-to-end validation against the quickstart workflow and core feed scenarios

## Dependencies & Execution Order

- Setup and foundation must complete before user story work begins.
- User Story 1 is the MVP and should be validated before adding Story 2 or Story 3.
- Story 2 depends on the refresh service created in the foundation layer.
- Story 3 depends on the article and storage model built in previous phases.

## Parallel Opportunities

- Linting configuration and base styling tasks can run in parallel.
- The Add Feed form, feed list, and article list components can be built in parallel once the core models are ready.
- Unit tests for parsing and storage can be developed alongside core service work to validate behavior early.
