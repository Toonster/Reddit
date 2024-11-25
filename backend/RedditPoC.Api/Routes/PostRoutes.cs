using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using RedditPoC.Api.Interfaces;

namespace RedditPoC.Api.Routes;

public class PostRoutes : IEndpointBuilder
{
    public IEndpointRouteBuilder ConfigureEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("posts")
            .WithTags("Posts");

        #region Queries

        group.MapGet("", () => Results.Ok())
            .Produces<int>();

        group.MapGet("{id:int}", ([FromRoute] int id) => Results.Ok(id))
            .Produces<int>()
            .RequireAuthorization()
            .RequireScope(["posts.read"]);

        return builder;

        #endregion
    }
}