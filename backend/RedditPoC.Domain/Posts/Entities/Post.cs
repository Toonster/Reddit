using RedditPoC.Domain.Events;
using RedditPoC.Domain.Posts.Events;

namespace RedditPoC.Domain.Posts.Entities;

public sealed class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    private void Apply(PostCreated @event)
    {
        Id = @event.PostId;
        Title = @event.Title;
        Content = @event.Content;
    }

    private void Apply(TitleEdited @event)
    {
        Title = @event.Title;
    }

    private void Apply(ContentEdited @event)
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
            case TitleEdited titleEdited:
                Apply(titleEdited);
                break;
            case ContentEdited contentEdited:
                Apply(contentEdited);
                break;
        }
    }
}