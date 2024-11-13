using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Users.Events;

public sealed record PasswordUpdated : Event
{
    public required Guid UserId { get; init; }
    public required string Password { get; init; }
    public override Guid StreamId => UserId;
}