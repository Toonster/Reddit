using FluentValidation;
using Marten;
using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Domain.Communities.Entities;
using RedditPoC.Domain.Communities.Enums;
using RedditPoC.Domain.Communities.Events;
using RedditPoC.Domain.Users.Entities;

namespace RedditPoC.Application.Communities.Commands;

public static class CreateCommunity
{
    public sealed record Command(
        Guid Id,
        Guid UserId,
        string Name,
        string Description,
        CommunityVisiblity Visibility,
        bool IsMature) : IRequest<Result>;

    internal sealed class Handler(IDocumentSession session, IValidator<Command> validator)
        : IRequestHandler<Command, Result>
    {
        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Error(validationResult.Errors.Select(x => new Error(x.ErrorMessage, x.ErrorMessage)));

            var user = await session.Events.AggregateStreamAsync<User>(request.UserId, token: cancellationToken);
            if (user is null) return Result.Error([new Error("UserId", "User does not exist.")]);

            var @event = new CommunityCreated
            {
                CommunityId = request.Id,
                Name = request.Name,
                Description = request.Description,
                AdminId = user.Id,
                Visibility = request.Visibility,
                IsMature = request.IsMature
            };
            session.Events.StartStream<Community>(request.Id, @event);
            await session.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

    internal sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User is required");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");
            RuleFor(x => x.Visibility)
                .NotEmpty()
                .WithMessage("Visibility is required");
            RuleFor(x => x.IsMature)
                .NotEmpty()
                .WithMessage("Is mature is required");
        }
    }
}