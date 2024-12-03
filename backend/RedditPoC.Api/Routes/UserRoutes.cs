using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedditPoC.Api.Interfaces;
using RedditPoC.Application.Common;
using RedditPoC.Application.Users;
using RedditPoC.Application.Users.Commands;
using RedditPoC.Application.Users.Projections;
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
            })
            .Produces<Result>();

        #endregion
        
        #region Queries

        group.MapGet("", async ([FromServices] IMediator mediator, [FromQuery] string email) =>
            {
                var result = await mediator.Send(new GetUserByEmail.Query(email));
                return Results.Ok(result);
            })
            .Produces<Result<User?>>();
        
        #endregion
        
        return builder;
    }
}