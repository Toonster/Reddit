using Asp.Versioning;

namespace RedditPoC.Api.Extensions;

public static class ApiVersionExtensions
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(configuration.GetValue<int>("Api:Version:Major"),
                    configuration.GetValue<int>("Api:Version:Minor"));
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }
}