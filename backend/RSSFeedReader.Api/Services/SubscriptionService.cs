using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionService
{
    private readonly List<FeedSubscription> _subscriptions = [];

    public IReadOnlyCollection<FeedSubscription> GetAll() => _subscriptions.AsReadOnly();

    public FeedSubscription Add(string url)
    {
        var normalizedUrl = url?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(normalizedUrl))
        {
            throw new ArgumentException("A feed URL is required.", nameof(url));
        }

        var subscription = new FeedSubscription
        {
            Url = normalizedUrl
        };

        _subscriptions.Add(subscription);
        return subscription;
    }
}
