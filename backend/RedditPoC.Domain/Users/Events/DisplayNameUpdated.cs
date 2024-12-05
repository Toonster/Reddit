using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Users.Events;

public sealed record DisplayNameUpdated : Event
{
    public required Guid UserId { get; init; }
    public required string DisplayName { get; init; }
    public override Guid StreamId => UserId;
}