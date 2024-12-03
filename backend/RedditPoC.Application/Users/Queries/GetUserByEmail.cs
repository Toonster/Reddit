using Marten;
using MediatR;
using RedditPoC.Application.Common;
using User = RedditPoC.Application.Users.Projections.User;

namespace RedditPoC.Application.Users.Queries;

public static class GetUserByEmail
{
    public sealed record Query(string Email) : IRequest<Result<User?>>;

    internal sealed class Handler(IDocumentStore store) : IRequestHandler<Query, Result<User?>>
    {
        public async Task<Result<User?>> Handle(Query request, CancellationToken cancellationToken)
        {
            await using var session = store.LightweightSession();
            var user = await session.Query<User>().Where(u => u.Email == request.Email)
                .FirstOrDefaultAsync(cancellationToken);

            return Result<User?>.Success(user);
        }
    }
}