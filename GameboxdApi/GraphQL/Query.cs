using GameboxdApi.Models;
using GameboxdApi.Repositories;

namespace GameboxdApi.GraphQL;

public class Query
{
    public IQueryable<Game> GetGames([Service] GameRepository gameRepo, string search = null) =>
        gameRepo.GetGames(search);
}
