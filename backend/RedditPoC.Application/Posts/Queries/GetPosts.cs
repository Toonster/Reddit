using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Application.Posts.Projections;

namespace RedditPoC.Application.Posts.Queries;

public static class GetPosts
{
    public record Query(int PageIndex, int PageSize) : IRequest<Result<List<PostProjection>>>;

    internal class Handler : IRequestHandler<Query, Result<List<PostProjection>>>
    {
        public Task<Result<List<PostProjection>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var (pageIndex, pageSize) = request;
            return Task.FromResult(Result<List<PostProjection>>.Success([]));
        }
    }
}