using Asp.Versioning;
using RedditPoC.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Custom",
        policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyHeader(); });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers()
    .WithOpenApi();
app.UseCors("Custom");

var versionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(builder.Configuration.GetValue<int>("Api:Version:Major"),
        builder.Configuration.GetValue<int>("Api:Version:Minor")))
    .ReportApiVersions()
    .Build();

var group = app
    .MapGroup("api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(versionSet)
    .DisableAntiforgery()
    .ConfigureEndpoints();

app.Run();