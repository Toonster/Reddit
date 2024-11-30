using Marten;
using Marten.Events;
using Marten.Events.Aggregation;
using Marten.Events.Projections;
using RedditPoC.Domain.Posts.Events;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Application.Posts.Projections;

public sealed record Post(Guid Id, string Title, string Content, DateTime Created, Guid UserId);

public sealed class PostProjection : MultiStreamProjection<Post, Guid>
{
    public PostProjection()
    {
        Identity<UserCreated>(x => x.UserId);
        Identity<PostCreated>(x => x.UserId);
    }

    public static Post Create(PostCreated @event)
    {
        return new Post(@event.PostId, @event.Title, @event.Content, @event.Timestamp, @event.UserId);
    }

    public static Post Apply(PostTitleEdited @event, Post post)
    {
        return post with { Title = @event.Title };
    }

    public static Post Apply(PostContentEdited @event, Post post)
    {
        return post with { Title = @event.Content };
    }
}

public sealed class PostProjectionHandler : IProjection
{
    public void Apply(IDocumentOperations operations, IReadOnlyList<StreamAction> streams)
    {
        throw new NotImplementedException();
    }

    public Task ApplyAsync(IDocumentOperations operations, IReadOnlyList<StreamAction> streams, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}