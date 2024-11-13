using RedditPoC.Api.Interfaces;

namespace RedditPoC.Api.Routes;

public class PostRoutes : IEndpointBuilder
{
    public IEndpointRouteBuilder ConfigureEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("posts")
            .WithTags("Posts");

        #region Queries

        group.MapGet("", () => Results.Ok());

        return builder;

        #endregion
    }
}