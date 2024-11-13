using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedditPoC.Api.Interfaces;
using RedditPoC.Application.Users;
using RedditPoC.Application.Users.Commands;
using RedditPoC.Application.Users.Queries;

namespace RedditPoC.Api.Routes;

public class UserRoutes : IEndpointBuilder
{
    public IEndpointRouteBuilder ConfigureEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("users")
            .WithTags("Users");

        #region Commands

        group.MapPost("", async ([FromServices] IMediator mediator, [FromBody] CreateUser.Command command) =>
        {
            var result = await mediator.Send(command);
            result.Match(() => Results.Ok(), errors => Results.BadRequest(new { errors }));
        });

        #endregion
        
        #region Queries

        group.MapGet("{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id) =>
        {
            var result = await mediator.Send(new GetUserById.Query(id));
            return Results.Ok(result);
        });
        
        #endregion
        
        return builder;
    }
}