using GameboxdApi.Models;
using GameboxdApi.Repositories;

namespace GameboxdApi.GraphQL;

public class Mutation
{
    public Game AddGame(
        string title,
        string coverImage,
        List<string> platforms,
        [Service] GameRepository repo)
    {
        var game = new Game
        {
            Title = title,
            CoverImage = coverImage,
            Platforms = platforms
        };

        return repo.AddGame(game);
    }
    
    public Game? AddOrUpdateReview(
        string gameId,
        string username,
        double rating,
        string review,
        [Service] GameRepository repo)
    {
        return repo.AddOrUpdateReview(gameId, username, rating, review);
    }
}