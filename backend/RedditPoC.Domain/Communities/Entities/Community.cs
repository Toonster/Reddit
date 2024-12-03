using RedditPoC.Domain.Communities.Enums;
using RedditPoC.Domain.Communities.Events;

namespace RedditPoC.Domain.Communities.Entities;

public sealed class Community
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsMature { get; private set; }
    public CommunityVisiblity Visiblity { get; private set; }

    public Community()
    {
    }

    private void Create(CommunityCreated @event)
    {
        Id = @event.CommunityId;
        Name = @event.Name;
        Description = @event.Description;
        IsMature = @event.IsMature;
        Visiblity = @event.Visibility;
    }
}