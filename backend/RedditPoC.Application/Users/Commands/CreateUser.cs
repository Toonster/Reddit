using FluentValidation;
using Marten;
using MediatR;
using RedditPoC.Application.Common;
using RedditPoC.Domain.Users.Entities;
using RedditPoC.Domain.Users.Events;

namespace RedditPoC.Application.Users.Commands;

public static class CreateUser
{
    public sealed record Command(Guid Id, string Username, string Email, string Password)
        : IRequest<Result>;

    internal sealed class Handler(IDocumentStore documentStore, IValidator<Command> validator)
        : IRequestHandler<Command, Result>
    {
        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Error(validationResult.Errors.Select(err => new Error(err.PropertyName, err.ErrorMessage)));

            await using var session = documentStore.LightweightSession();
            var timestamp = DateTime.UtcNow;
            var userCreated = new UserCreated
            {
                UserId = request.Id,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                CreatedOn = timestamp
            };

            session.Events.StartStream<User>(userCreated.UserId, userCreated);
            await session.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

    internal sealed class CreateUserValidator : AbstractValidator<Command>
    {
        public CreateUserValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Id cannot be empty");
            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty");
            RuleFor(command => command.Email)
                .EmailAddress()
                .WithMessage("Invalid email address");
            RuleFor(command => command.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty");
        }
    }
}