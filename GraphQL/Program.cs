using Application.Interfaces;
using Application.UseCases;
using GraphQL.grpcServices;
using GraphQL.Query;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

});


var connectionString = builder.Configuration.GetConnectionString("MongoDB");
var connectionDBName = builder.Configuration.GetConnectionString("MongoDBName");

var finalConnection = connectionString;

if (Environment.GetEnvironmentVariable("MONGODB_URL") != null)
{
    finalConnection = Environment.GetEnvironmentVariable("MONGODB_URL");
}


builder.Services.AddDbContext<MediaDbContext>(options =>
{
    options.UseMongoDB(finalConnection, connectionDBName);
    options.EnableThreadSafetyChecks();
}, ServiceLifetime.Singleton);




builder.Services.AddScoped<IMediaClientWrapper, MediaClientWrapper>(options =>
{
var configuration = options.GetRequiredService<IConfiguration>();
var address = configuration["MediaServiceAddress"];
if (Environment.GetEnvironmentVariable("MediaServiceAddress") != null)
{
    address = Environment.GetEnvironmentVariable("MediaServiceAddress");
}
    Console.WriteLine(address);
    return new MediaClientWrapper(address);
});

builder.Services.AddGraphQLServer().AddQueryType<Query>();


builder.Services.AddScoped<ICreateCountryService, CreateCountryService>();
builder.Services.AddScoped<ICreateCountryCommand, CreateCountryCommand>();

builder.Services.AddScoped<ICreateGenreService, CreateGenreService>();
builder.Services.AddScoped<ICreateGenreCommand, CreateGenreCommand>();

builder.Services.AddScoped<ICreateMediaService, CreateMediaService>();
builder.Services.AddScoped<ICreateMediaCommand, CreateMediaCommand>();

builder.Services.AddScoped<IGetMediasByTitleService, GetMediasByTitleService>();
builder.Services.AddScoped<IGetMediasByTitleQuery, GetMediasByTitleQuery>();

builder.Services.AddScoped<IGetMediaByImdbIdService, GetMediaByImdbIdService>();
builder.Services.AddScoped<IGetMediaByImdbIdQuery, GetMediaByImdbIdQuery>();

builder.Services.AddScoped<IUpdateMediaService, UpdateMediaService>();
builder.Services.AddScoped<IUpdateMediaCommand, UpdateMediaCommand>();

var app = builder.Build();

app.UseCors();
app.MapGraphQL();

app.Run();
