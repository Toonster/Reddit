namespace RedditPoC.Api.Routes;

public static class PostRoutes
{
    public static void MapPostRoutes(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("posts")
            .WithTags("Posts");

        #region Queries

        group.MapGet("", () => Results.Ok());

        
        #endregion
    }
}