using System.Reflection;
using Asp.Versioning;
using FluentValidation;
using RedditPoC.Api.ModuleExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.SupportNonNullableReferenceTypes(); });
builder.Services.AddVersioning();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Custom",
            policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyHeader();
            });
    });
}

app.UseHttpsRedirection();
app.MapControllers()
    .WithOpenApi();
app.UseCors("Custom");
app.UseExceptionHandler();

var versionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(builder.Configuration.GetValue<int>("Api:Version:Major"),
        builder.Configuration.GetValue<int>("Api:Version:Minor")))
    .ReportApiVersions()
    .Build();

var group = app.MapGroup("api/v{apiVersion:apiVersion}").WithApiVersionSet(versionSet);

app.Run();