using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Users.Events;

public sealed record PasswordUpdated : Event
{
    public required Guid UserId { get; init; }
    public required string OldPassword { get; init; }
    public required string NewPassword { get; init; }
    public override Guid StreamId => UserId;
}