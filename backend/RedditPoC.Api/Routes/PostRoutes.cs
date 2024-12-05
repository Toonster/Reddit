using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using RedditPoC.Api.Interfaces;
using RedditPoC.Application.Common;
using RedditPoC.Application.Posts.Projections;
using RedditPoC.Application.Posts.Queries;

namespace RedditPoC.Api.Routes;

public class PostRoutes : IEndpointBuilder
{
    public IEndpointRouteBuilder ConfigureEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("posts")
            .WithTags("Posts");

        #region Queries

        group.MapGet("",
                async ([FromServices] IMediator mediator, [FromQuery] string? community, [FromQuery] int? pageIndex = 1,
                    [FromQuery] int? pageSize = 25) =>
                {
                    var result =
                        await mediator.Send(new GetPosts.Query(pageIndex!.Value, pageSize!.Value, community));
                    return Results.Ok(result);
                })
            .Produces<Result<IReadOnlyList<Post>>>();

        group.MapGet("{id:int}", ([FromRoute] int id) => Results.Ok(id))
            .Produces<int>()
            .RequireAuthorization()
            .RequireScope("posts.read");

        return builder;

        #endregion
    }
}