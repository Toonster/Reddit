using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Users.Events;

public sealed record UserCreated : Event
{
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required DateTime CreatedOn { get; init; }
    public override Guid StreamId => UserId;
}