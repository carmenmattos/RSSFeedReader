# Research: MVP RSS Feed Reader

## Decision 1: Technology stack

**Decision**: Use ASP.NET Core Web API for the backend and Blazor WebAssembly for the frontend.

**Rationale**: This matches the project’s required .NET-first architecture and keeps the solution simple, cross-platform, and ready for incremental growth. It also aligns with the stakeholder guidance that the product may evolve toward richer features later without requiring a rewrite.

**Trade-offs**: The stack is more opinionated than a JavaScript-only client, but it is consistent with the project requirement to use C# and .NET throughout the implementation.

## Decision 2: Storage model for the MVP

**Decision**: Keep subscriptions in memory within the backend for the current session only.

**Rationale**: The project scope explicitly defines the MVP as a local proof-of-concept and does not require persistence or database support. In-memory storage keeps the implementation minimal and directly supports the demo requirement.

**Trade-offs**: Data will not survive application restarts, but that is acceptable for the approved MVP and avoids introducing unnecessary infrastructure.

## Decision 3: Scope boundaries

**Decision**: Do not include feed fetching, parsing, validation, item display, or persistence in the MVP.

**Rationale**: The stakeholder documents require the simplest feasible functionality: adding a URL and showing it in a list. Any broader feed-reader behavior is explicitly deferred to the Extended-MVP or post-MVP phase.

**Trade-offs**: This limits the first version, but it keeps the project focused, fast to build, and easy to validate against the required success criteria.

## Decision 4: Local verification strategy

**Decision**: Validate the app through .NET build and run commands plus browser checks for the add/list flow.

**Rationale**: The project is a local demo and does not need a separate client-side toolchain. End-to-end verification can be done by starting the API and Blazor app, submitting subscription URLs, and checking the UI list updates.

**Trade-offs**: This approach is intentionally lightweight, but it intentionally excludes feed-content features that are outside the MVP scope.
