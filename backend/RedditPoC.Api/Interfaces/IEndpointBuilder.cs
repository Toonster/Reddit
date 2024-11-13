namespace RedditPoC.Api.Interfaces;

public interface IEndpointBuilder
{
    IEndpointRouteBuilder ConfigureEndpoints(IEndpointRouteBuilder builder);
}