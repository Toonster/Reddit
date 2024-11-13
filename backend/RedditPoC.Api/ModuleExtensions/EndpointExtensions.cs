using System.Reflection;
using RedditPoC.Api.Interfaces;

namespace RedditPoC.Api.ModuleExtensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder ConfigureEndpoints(this IEndpointRouteBuilder app)
    {
        var endpointDefinitions = Assembly.GetExecutingAssembly()
            .ExportedTypes
            .Where(t => typeof(IEndpointBuilder).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IEndpointBuilder>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.ConfigureEndpoints(app);
        }

        return app;
    }
}