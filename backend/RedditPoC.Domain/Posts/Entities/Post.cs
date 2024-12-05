using RedditPoC.Domain.Events;
using RedditPoC.Domain.Posts.Events;
using RedditPoC.Domain.Users.Entities;

namespace RedditPoC.Domain.Posts.Entities;

public sealed class Post
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CommunityId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public User Author { get; private set; } = default!;
    
    public Post() { }

    private void Apply(PostCreated @event)
    {
        Id = @event.PostId;
        UserId = @event.UserId;
        CommunityId = @event.CommunityId;
        Title = @event.Title;
        Content = @event.Content;
    }

    private void Apply(PostTitleEdited @event)
    {
        Title = @event.Title;
    }

    private void Apply(PostContentEdited @event)
    {
        Content = @event.Content;
    }

    public void Apply(Event @event)
    {
        switch (@event)
        {
            case PostCreated postCreated:
                Apply(postCreated);
                break;
            case PostTitleEdited titleEdited:
                Apply(titleEdited);
                break;
            case PostContentEdited contentEdited:
                Apply(contentEdited);
                break;
        }
    }
}