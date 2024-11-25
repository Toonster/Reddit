using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using RedditPoC.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Custom",
        policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyHeader(); });
});


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddMicrosoftIdentityWebApi(options =>
        {
            builder.Configuration.Bind("AzureAdB2C", options);

            options.TokenValidationParameters.NameClaimType = "name";
        },
        options => { builder.Configuration.Bind("AzureAdB2C", options); });

var app = builder.Build();


app.UseCors("Custom");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

var versionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(builder.Configuration.GetValue<int>("Api:Version:Major"),
        builder.Configuration.GetValue<int>("Api:Version:Minor")))
    .ReportApiVersions()
    .Build();

app
    .MapGroup("api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(versionSet)
    .DisableAntiforgery()
    .WithOpenApi()
    .ConfigureEndpoints();

app.Run();