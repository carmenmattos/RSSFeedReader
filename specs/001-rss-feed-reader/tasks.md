# Tasks: RSS Feed Reader

**Input**: Design documents from `/specs/001-rss-feed-reader/`

**Prerequisites**: plan.md (required), spec.md (required), quickstart.md, research.md, contracts/

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the .NET solution structure and shared project wiring for the MVP.

- [ ] T001 Create the solution and project folders for the ASP.NET Core API and Blazor UI in backend/ and frontend/
- [ ] T002 Initialize the API project with ASP.NET Core and .NET 8 dependencies in backend/RSSFeedReader.Api/Program.cs
- [ ] T003 Initialize the UI project with Blazor WebAssembly and .NET 8 dependencies in frontend/RSSFeedReader.UI/Program.cs
- [ ] T004 [P] Configure shared .NET build and launch settings for local development in backend/RSSFeedReader.Api/Properties/launchSettings.json and frontend/RSSFeedReader.UI/wwwroot/appsettings.json

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build the minimal backend and UI foundation that supports add/list subscription behavior without expanding scope.

- [ ] T005 Create the `FeedSubscription` model with the required URL field in backend/RSSFeedReader.Api/Models/FeedSubscription.cs
- [ ] T006 Implement the in-memory subscription service that stores the current session list in backend/RSSFeedReader.Api/Services/SubscriptionService.cs
- [ ] T007 Build the API controller skeleton for subscription requests in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T008 Add the Blazor API client used by the UI to call the backend in frontend/RSSFeedReader.UI/Services/SubscriptionClient.cs
- [ ] T009 [P] Define the empty state and page layout shell for the subscription screen in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor

**Checkpoint**: Foundation ready - the app can route requests and manage a session-scoped in-memory list before user story work begins.

---

## Phase 3: User Story 1 - Add a feed subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to enter a feed URL and see it appear in the subscription list immediately.

**Independent Test**: A user can enter a URL, submit the form, and confirm that the app adds the item to the list without additional setup.

### Implementation for User Story 1

- [ ] T010 [P] [US1] Create the subscription input form in frontend/RSSFeedReader.UI/Components/SubscriptionForm.razor
- [ ] T011 [US1] Add client-side form submission logic to call POST /api/subscriptions in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor
- [ ] T012 [US1] Implement POST /api/subscriptions in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T013 [US1] Add the service logic to append the submitted URL to the in-memory collection in backend/RSSFeedReader.Api/Services/SubscriptionService.cs
- [ ] T014 [US1] Return the created subscription payload with id and url values from the API response in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T015 [US1] Refresh the UI list after a successful submit and render the new subscription entry in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor

**Checkpoint**: At this point, User Story 1 is functional and independently testable as the MVP add-subscription flow.

---

## Phase 4: User Story 2 - View the subscription list (Priority: P2)

**Goal**: Show the current in-memory subscription list to the user in a simple, readable UI.

**Independent Test**: A user can load the page and confirm the list shows all entries added during the current session.

### Implementation for User Story 2

- [ ] T016 [P] [US2] Implement GET /api/subscriptions in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T017 [P] [US2] Add the client method to fetch all current subscriptions in frontend/RSSFeedReader.UI/Services/SubscriptionClient.cs
- [ ] T018 [US2] Render the list of subscription entries and empty state in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor
- [ ] T019 [US2] Ensure the page loads the active in-memory list on initial render and keeps it in sync after add operations in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor

**Checkpoint**: At this point, User Story 2 works independently and confirms the app reflects the current session data.

---

## Phase 5: Polish & Cross-Cutting Concerns

**Purpose**: Finalize the MVP quality bar and validate the user workflow using the project quickstart.

- [ ] T020 [P] Review the .NET solution structure to confirm the API and UI remain separated cleanly in backend/ and frontend/
- [ ] T021 [P] Validate there is no feed-fetching, feed-parsing, or persistence logic beyond the approved MVP scope in backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T022 Run the quickstart smoke test using dotnet build and dotnet run to verify the add/list workflow works end-to-end in the local browser
- [ ] T023 [P] Check the app for empty-state and basic UX polish in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor

---

## Dependencies & Execution Order

- Phase 1 must complete before Phase 2.
- Phase 2 is a blocking prerequisite for all user stories.
- User Story 1 (add subscription) is the MVP and should be completed before User Story 2 is considered complete.
- User Story 2 depends on the in-memory service and API contract already created in the foundation phase.
- Final polish runs only after both stories are working independently.

### Parallel Opportunities

- T004 can run in parallel with other setup tasks because it only configures local startup settings.
- T010 and T017 are parallelizable because they affect different files and serve distinct responsibilities.
- T020 and T021 are parallelizable because both are cross-cutting validation tasks performed after the MVP is functional.

---

## Implementation Strategy

### MVP First

1. Complete setup and foundation.
2. Implement Story 1: add a subscription.
3. Validate the API and UI flow in the browser.
4. Implement Story 2: view the current subscription list.
5. Stop and confirm the MVP scope is still limited to add/list without extra complexity.

### Incremental Delivery

1. Build the backend service and API contract.
2. Add the Blazor client and page shell.
3. Implement the add flow.
4. Implement the list flow.
5. Run smoke checks and finalize the proof-of-concept.
