using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Posts.Events;

public sealed record PostTitleEdited : Event
{
    public required Guid PostId { get; init; }
    public required string Title { get; init; }
    public override Guid StreamId => PostId;
}