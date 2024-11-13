using System.Reflection;
using FluentValidation;
using Marten;
using Marten.Events.Projections;
using RedditPoC.Application.Users.Projections;
using Weasel.Core;

namespace RedditPoC.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => { options.SupportNonNullableReferenceTypes(); });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddVersioning();
        services.ConfigureMartenDb(builder);
        return services;
    }

    private static IServiceCollection ConfigureMartenDb(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("MartenDb") ??
                               throw new ApplicationException("MartenDb connection string is not configured");
        services.AddMarten(options =>
        {
            options.Connection(connectionString);
            options.UseSystemTextJsonForSerialization();
            if (builder.Environment.IsDevelopment()) options.AutoCreateSchemaObjects = AutoCreate.All;
            options.Projections.Add<UserProjection>(ProjectionLifecycle.Inline);
        });
        return services;
    }
}