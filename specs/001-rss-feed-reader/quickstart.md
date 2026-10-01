# Quickstart: MVP RSS Feed Reader

## Prerequisites

- .NET SDK 8.0 or newer
- An IDE such as Visual Studio or VS Code
- A local browser to test the Blazor UI

## Project setup

1. Create the API project:

```bash
dotnet new webapi -n RSSFeedReader.Api -f net8.0
```

2. Create the frontend project:

```bash
dotnet new blazorwasm -n RSSFeedReader.UI -f net8.0
```

3. Add a minimal model for subscriptions and keep the data in memory only for the MVP.
4. Configure the API to expose an endpoint for adding and listing subscriptions.
5. Configure the Blazor app to call the API and render the subscription list.

## Run the app

Start the backend:

```bash
cd backend/RSSFeedReader.Api
dotnet run
```

Start the frontend:

```bash
cd frontend/RSSFeedReader.UI
dotnet run
```

## Typical workflow

1. Open the Blazor page in the browser.
2. Enter a subscription URL in the form.
3. Submit the form to add the feed URL to the list.
4. Confirm the UI updates immediately and displays the added subscription.
5. Repeat with additional URLs to verify the list continues to show all entries.

## Validation

- Confirm the API accepts new subscription requests and returns the current list.
- Confirm the UI updates immediately after submitting a URL.
- Verify that the app remains in-memory only and does not depend on a database or persistence layer.
- Confirm the application remains focused on the MVP: add subscriptions and list them, without feed fetching or parsing.
