using GameboxdApi.GraphQL;
using GameboxdApi.GraphQL.Types;
using GameboxdApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<GameRepository>()
    .AddGraphQLServer()
    .AddType<GameType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();