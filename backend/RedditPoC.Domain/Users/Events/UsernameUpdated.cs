using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Users.Events;

public sealed record UsernameUpdated : Event
{
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public override Guid StreamId => UserId;
}