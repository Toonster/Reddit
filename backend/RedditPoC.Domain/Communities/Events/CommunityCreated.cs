using RedditPoC.Domain.Communities.Enums;
using RedditPoC.Domain.Events;

namespace RedditPoC.Domain.Communities.Events;

public sealed record CommunityCreated : Event
{
    public required Guid CommunityId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required bool IsMature { get; init; }
    public required CommunityVisiblity Visibility { get; init; }
    public override Guid StreamId => CommunityId;
}