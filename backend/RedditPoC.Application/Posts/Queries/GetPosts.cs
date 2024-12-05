using Marten;
using Marten.Linq;
using Marten.Pagination;
using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Application.Posts.Projections;

namespace RedditPoC.Application.Posts.Queries;

public static class GetPosts
{
    public record Query(int PageIndex, int PageSize, string? Community) : IRequest<Result<IPagedList<Post>>>;

    internal class Handler(IQuerySession session) : IRequestHandler<Query, Result<IPagedList<Post>>>
    {
        public async Task<Result<IPagedList<Post>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var (pageIndex, pageSize, community) = request;

            var query = session.Query<Post>();
            if (!string.IsNullOrWhiteSpace(community))
                query = (IMartenQueryable<Post>)query.Where(x => x.Community == community);

            var posts = await query
                .OrderByDescending(p => p.Created)
                .ToPagedListAsync(pageIndex, pageSize, cancellationToken);

            return Result<IPagedList<Post>>.Success(posts);
        }
    }
}