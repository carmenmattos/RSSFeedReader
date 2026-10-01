namespace RSSFeedReader.Api.Models;

public class FeedSubscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Url { get; set; } = string.Empty;
}
