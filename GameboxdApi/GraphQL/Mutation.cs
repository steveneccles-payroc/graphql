using GameboxdApi.Models;
using GameboxdApi.Repositories;
using HotChocolate.Subscriptions;

namespace GameboxdApi.GraphQL;

public class Mutation
{
    public Game AddGame(
        string title,
        string coverImage,
        List<string> platforms,
        short year,
        [Service] GameRepository repo)
    {
        var game = new Game
        {
            Title = title,
            CoverImage = coverImage,
            Platforms = platforms,
            Year = year,
        };

        return repo.AddGame(game);
    }
    
    public async Task<Game>? AddOrUpdateReview(
        string gameId,
        string username,
        double rating,
        string review,
        [Service] GameRepository repo, [Service] ITopicEventSender sender)
    {
        var game = repo.AddOrUpdateReview(gameId, username, rating, review);
        await sender.SendAsync(nameof(Subscription.OnReviewAdded), new GameReview {Review = review, Rating = rating, Username = username});
        return game;
    }
}