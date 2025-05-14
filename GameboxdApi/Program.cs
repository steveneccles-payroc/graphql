using GameboxdApi.GraphQL;
using GameboxdApi.GraphQL.Types;
using GameboxdApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<GameRepository>()
    .AddGraphQLServer()
    .AddType<GameType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();

app.Run();