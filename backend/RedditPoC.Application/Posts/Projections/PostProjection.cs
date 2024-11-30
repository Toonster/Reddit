using Marten.Events.Projections;
using RedditPoC.Domain.Posts.Events;
using RedditPoC.Domain.Users.Entities;

namespace RedditPoC.Application.Posts.Projections;

public sealed record Post(Guid Id, string Title, string Content, DateTime Created, Guid UserId, string Username);

public sealed class PostProjection : EventProjection
{
    public PostProjection()
    {
        ProjectAsync<PostCreated>(async (created, operations) =>
        {
            var user = await operations.LoadAsync<User>(created.UserId);
            operations.Store(new Post(created.PostId, created.Title, created.Content, created.Timestamp, user!.Id,
                user.Username));
        });
    }

    public static Post Apply(PostTitleEdited @event, Post post)
    {
        return post with { Title = @event.Title };
    }

    public static Post Apply(PostContentEdited @event, Post post)
    {
        return post with { Content = @event.Content };
    }
}