using Marten;
using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Application.Users.Models;
using RedditPoC.Domain.Users.Entities;

namespace RedditPoC.Application.Users.Queries;

public static class GetUserById
{
    public sealed record Query(Guid Id) : IRequest<Result<UserDto?>>;

    internal sealed class Handler(IDocumentStore store) : IRequestHandler<Query, Result<UserDto?>>
    {
        public async Task<Result<UserDto?>> Handle(Query request, CancellationToken cancellationToken)
        {
            await using var session = store.LightweightSession();
            var user = await session.Events.AggregateStreamAsync<User>(request.Id, token: cancellationToken);
            
            return Result<UserDto?>.Success(user is not null ? UserDto.FromUser(user) : null);
        }
    }
}