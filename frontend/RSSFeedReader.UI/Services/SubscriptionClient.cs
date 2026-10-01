using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI.Services;

public class SubscriptionClient(HttpClient httpClient)
{
    public async Task<IReadOnlyList<FeedSubscription>> GetSubscriptionsAsync()
    {
        var result = await httpClient.GetFromJsonAsync<List<FeedSubscription>>("api/subscriptions");
        return result ?? [];
    }

    public async Task<FeedSubscription> AddSubscriptionAsync(string url)
    {
        var response = await httpClient.PostAsJsonAsync("api/subscriptions", new { url });
        response.EnsureSuccessStatusCode();

        var subscription = await response.Content.ReadFromJsonAsync<FeedSubscription>();
        return subscription ?? throw new InvalidOperationException("The API did not return a subscription payload.");
    }
}
