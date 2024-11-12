using FluentValidation;
using MediatR;

namespace RedditPoC.Application.Posts;

public static class GetPosts
{
    public record Query() : IRequest;

    internal class Handler : IRequestHandler<Query>
    {
        public Task Handle(Query request, CancellationToken cancellationToken)
        {
            Console.WriteLine("GetPosts");
            return Task.CompletedTask;
        }
    }

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
        }
    }
}