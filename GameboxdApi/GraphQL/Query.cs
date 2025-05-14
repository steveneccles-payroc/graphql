using GameboxdApi.GraphQL.Types;
using GameboxdApi.Models;
using GameboxdApi.Repositories;

namespace GameboxdApi.GraphQL;

public class Query
{
    public IQueryable<Game> GetGames([Service] GameRepository gameRepo, string search = null) =>
        gameRepo.GetGames(search);

    public Game GetGame([Service] GameRepository gameRepo, string id) => gameRepo.GetGameById(id);
}
