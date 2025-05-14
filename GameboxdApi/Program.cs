using GameboxdApi.GraphQL;
using GameboxdApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<GameRepository>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();