using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Posts.Events;

public sealed record ContentEdited : Event
{
    public required Guid PostId { get; init; }
    public required string Content { get; init; }
    public override Guid StreamId => PostId;
}