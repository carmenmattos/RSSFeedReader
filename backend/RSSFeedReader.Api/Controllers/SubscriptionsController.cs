using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionService _subscriptionService;

    public SubscriptionsController(SubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FeedSubscription>> Get()
    {
        return Ok(_subscriptionService.GetAll());
    }

    [HttpPost]
    public ActionResult<FeedSubscription> Post([FromBody] CreateSubscriptionRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Url))
        {
            return BadRequest(new { error = "A feed URL is required." });
        }

        try
        {
            var subscription = _subscriptionService.Add(request.Url);
            return CreatedAtAction(nameof(Get), new { id = subscription.Id }, subscription);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    public record CreateSubscriptionRequest(string Url);
}
