using FluentValidation;
using Marten;
using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Domain.Posts.Entities;
using RedditPoC.Domain.Posts.Events;

namespace RedditPoC.Application.Posts.Commands;

public static class CreatePost
{
    public sealed record Command(Guid Id, string Title, string Content, Guid UserId) : IRequest<Result>;

    internal sealed class Handler(IDocumentStore store, IValidator<Command> validator)
        : IRequestHandler<Command, Result>
    {
        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Error(
                    validationResult.Errors.Select(err => new Error(err.PropertyName, err.ErrorMessage)));
            
            var postId = Guid.NewGuid();
            var @event = new PostCreated
            {
                PostId = postId,
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content
            };
            await using var session = store.LightweightSession();
            session.Events.StartStream<Post>(postId, @event);
            
            await session.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }

    internal sealed class CreatePostValidator : AbstractValidator<Command>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required");
        }
    }
}