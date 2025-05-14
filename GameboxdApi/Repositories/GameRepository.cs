using GameboxdApi.Models;
using System.Collections.Concurrent;

namespace GameboxdApi.Repositories;

public class GameRepository
{
    private readonly ConcurrentDictionary<string, Game> _games = new();

    public GameRepository()
    {
        // Seed initial games
        AddGame(new Game
        {
            Id = Guid.NewGuid().ToString(),
            Title = "The Legend of Zelda: Tears of the Kingdom",
            CoverImage = "https://images.nintendolife.com/880243a8baed2/switch-tloz-totk-artwork-01.900x.jpg",
            Platforms = ["Nintendo Switch"],
            Year = 2024,
            Reviews = new List<GameReview>()
        });

        AddGame(new Game
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Clair Obscur: Expedition 33",
            CoverImage = "https://www.rpgfan.com/wp-content/uploads/2024/06/Clair-Obscur-Expedition-33-Cover-Art-Digital.webp",
            Platforms = ["PlayStation 5", "XBox Series", "PC"],
            Year = 2025,
            Reviews = new List<GameReview>()
        });
    }

    public IQueryable<Game> GetGames(string? search = null)
    {
        var allGames = _games.Values.AsEnumerable();

        return string.IsNullOrWhiteSpace(search)
            ? allGames.AsQueryable()
            : allGames.Where(g =>
                g.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).AsQueryable();
    }

    public Game? GetGameById(string id) => _games.GetValueOrDefault(id);

    public Game AddGame(Game game)
    {
        game.Id ??= Guid.NewGuid().ToString();
        _games[game.Id] = game;
        return game;
    }

    public bool UpdateGame(Game game)
    {
        if (!_games.ContainsKey(game.Id)) return false;
        _games[game.Id] = game;
        return true;
    }

    public bool DeleteGame(string id)
    {
        return _games.TryRemove(id, out _);
    }
    
    public Game? AddOrUpdateReview(string gameId, string username, double rating, string review)
    {
        if (!_games.TryGetValue(gameId, out var game)) return null;

        var existing = game.Reviews.FirstOrDefault(r => r.Username == username);
        if (existing != null)
        {
            existing.Rating = rating;
            existing.Review = review;
        }
        else
        {
            game.Reviews.Add(new GameReview
            {
                Username = username,
                Rating = rating,
                Review = review
            });
        }

        return game;
    }

}