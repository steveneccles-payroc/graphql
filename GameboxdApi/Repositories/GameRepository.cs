using GameboxdApi.Models;
using System.Collections.Concurrent;
using GameboxdApi.GraphQL.Types;

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
            Title = "Clair Obscur: Expedition 33",
            CoverImage = "https://www.rpgfan.com/wp-content/uploads/2024/06/Clair-Obscur-Expedition-33-Cover-Art-Digital.webp",
            Platforms = ["PlayStation 5", "XBox Series", "PC"],
            Year = 2025,
            Reviews = new List<GameReview>
            {
                new GameReview {Rating = 9.5, Review = "Game of the year!", Username = "Steven", Heart = true},
                new GameReview {Rating = 8.5, Review = "Didn't enjoy the QTEs", Username = "Fred", Heart = false},
            }
        });
        
        AddGame(new Game
        {
            Id = Guid.NewGuid().ToString(),
            Title = "The Legend of Zelda: Tears of the Kingdom",
            CoverImage = "https://i.redd.it/tjv3z5yjcreb1.jpg",
            Platforms = ["Nintendo Switch"],
            Year = 2023,
            Reviews = new List<GameReview>
            {
                new GameReview { Rating = 9.7, Review = "Incredible world and design!", Username = "LinkFan", Heart = true },
                new GameReview { Rating = 9.2, Review = "Loved every second!", Username = "ZeldaLover", Heart = true },
                new GameReview { Rating = 8.9, Review = "A bit too long but amazing.", Username = "HyruleDude", Heart = true },
                new GameReview { Rating = 9.5, Review = "Masterpiece.", Username = "GanonSlayer", Heart = true },
                new GameReview { Rating = 9.0, Review = "My favorite Switch game.", Username = "SwitchPro", Heart = true }
            }
        });

        AddGame(new Game
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Elden Ring",
            CoverImage = "https://storage.googleapis.com/pod_public/1300/216712.jpg",
            Platforms = ["PlayStation 5", "XBox Series", "PC"],
            Year = 2022,
            Reviews = new List<GameReview>
            {
                new GameReview { Rating = 9.6, Review = "Dark, brutal, beautiful.", Username = "TarnishedOne", Heart = true },
                new GameReview { Rating = 8.5, Review = "Not for the faint-hearted.", Username = "BossHunter", Heart = true },
                new GameReview { Rating = 9.8, Review = "True GOTY material.", Username = "RingBearer", Heart = true },
                new GameReview { Rating = 6.2, Review = "Too hard for me.", Username = "CasualGamer", Heart = false },
                new GameReview { Rating = 7.9, Review = "Love-hate relationship.", Username = "PainEnjoyer", Heart = true }
            }
        });
        
        AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "Cyberpunk 2077",
    CoverImage = "https://cdnb.artstation.com/p/assets/covers/images/033/037/923/large/artur-tarnowski-artur-tarnowski-coverart-thumbnail.jpg?1608208435",
    Platforms = [ "PlayStation 5", "XBox Series", "PC" ],
    Year = 2020,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 6.8, Review = "Buggy at launch but fun.", Username = "VRunner", Heart = false },
        new GameReview { Rating = 7.5, Review = "Night City is stunning.", Username = "Netrunner", Heart = true },
        new GameReview { Rating = 5.5, Review = "Underwhelming story.", Username = "DisappointedFan", Heart = false },
        new GameReview { Rating = 8.2, Review = "Improved with updates.", Username = "PatchLover", Heart = true },
        new GameReview { Rating = 6.0, Review = "Expected more.", Username = "JohnnySilver", Heart = false }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "God of War: Ragnarök",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/e/ee/God_of_War_Ragnar%C3%B6k_cover.jpg/250px-God_of_War_Ragnar%C3%B6k_cover.jpg",
    Platforms = ["PlayStation 5", "PlayStation 4" ],
    Year = 2022,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.3, Review = "Epic conclusion.", Username = "KratosMain", Heart = true },
        new GameReview { Rating = 9.1, Review = "So emotional!", Username = "DadOfBoy", Heart = true },
        new GameReview { Rating = 8.5, Review = "Combat is awesome.", Username = "HammerFan", Heart = true },
        new GameReview { Rating = 9.0, Review = "Loved the story.", Username = "FreyaFan", Heart = true },
        new GameReview { Rating = 7.0, Review = "Too linear.", Username = "OpenWorldOnly", Heart = false }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "Baldur’s Gate 3",
    CoverImage = "https://i.redd.it/m2lmw222h0ka1.png",
    Platforms = ["PC", "PlayStation 5"],
    Year = 2023,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.9, Review = "A masterpiece of RPGs.", Username = "LarianLover", Heart = true },
        new GameReview { Rating = 9.5, Review = "Perfect storytelling.", Username = "DiceRoller", Heart = true },
        new GameReview { Rating = 8.8, Review = "Too much reading.", Username = "QuickPlayer", Heart = false },
        new GameReview { Rating = 9.7, Review = "So much choice!", Username = "DMApproved", Heart = true },
        new GameReview { Rating = 8.2, Review = "Act 3 had bugs.", Username = "TesterGuy", Heart = true }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "Starfield",
    CoverImage = "https://images.ctfassets.net/rporu91m20dc/6zeNIhOtLaWMvaIR0NEgzO/873ad45ef8e01f6ce137a7db2d39c898/Starfield_JourneySpace_Wallpaper_2048x2732-01.jpg",
    Platforms = ["XBox Series", "PC"],
    Year = 2023,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 7.5, Review = "Space exploration is cool.", Username = "AstroNut", Heart = true },
        new GameReview { Rating = 6.9, Review = "Feels empty.", Username = "LonelyExplorer", Heart = false },
        new GameReview { Rating = 8.1, Review = "Lots of content!", Username = "SpaceFan", Heart = true },
        new GameReview { Rating = 6.2, Review = "Too much walking.", Username = "SlowWalker", Heart = false },
        new GameReview { Rating = 7.8, Review = "Solid RPG.", Username = "ModderDude", Heart = false }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "The Witcher 3: Wild Hunt",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/0/0c/Witcher_3_cover_art.jpg",
    Platforms = new List<string> { "PC", "PlayStation 4", "XBox 1", "Nintendo Switch" },
    Year = 2015,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.8, Review = "Masterpiece storytelling.", Username = "Alex", Heart = true },
        new GameReview { Rating = 9.5, Review = "Best RPG of the decade.", Username = "Jordan", Heart = true },
        new GameReview { Rating = 8.9, Review = "Loved the world design.", Username = "Sam", Heart = true },
        new GameReview { Rating = 9.2, Review = "Characters were excellent.", Username = "Riley", Heart = true },
        new GameReview { Rating = 9.6, Review = "Incredible depth and lore.", Username = "Casey", Heart = true },
        new GameReview { Rating = 9.0, Review = "Some minor bugs, but great.", Username = "Quinn", Heart = true },
        new GameReview { Rating = 8.5, Review = "Combat could be smoother.", Username = "Taylor", Heart = false }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "Red Dead Redemption 2",
    CoverImage = "https://assets.vg247.com/current//2018/05/red_dead_redemption_2_cover_art_1.jpg",
    Platforms = new List<string> { "PC", "PlayStation 4", "XBox 1" },
    Year = 2018,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.7, Review = "A stunning world to explore.", Username = "Morgan", Heart = true },
        new GameReview { Rating = 8.8, Review = "Story was amazing but slow.", Username = "Drew", Heart = true },
        new GameReview { Rating = 9.3, Review = "So much to do!", Username = "Jamie", Heart = true },
        new GameReview { Rating = 7.2, Review = "Too slow-paced for me.", Username = "Sam", Heart = false },
        new GameReview { Rating = 9.9, Review = "Emotional masterpiece.", Username = "Taylor", Heart = true },
        new GameReview { Rating = 9.1, Review = "Beautiful visuals.", Username = "Quinn", Heart = true },
        new GameReview { Rating = 6.8, Review = "Wanted more action.", Username = "Alex", Heart = false }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "Dark Souls III",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/b/bb/Dark_souls_3_cover_art.jpg",
    Platforms = new List<string> { "PC", "PlayStation 4", "XBox 1" },
    Year = 2016,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.4, Review = "Rewarding and brutal.", Username = "Riley", Heart = true },
        new GameReview { Rating = 8.7, Review = "Great boss design.", Username = "Fred", Heart = true },
        new GameReview { Rating = 6.9, Review = "Too hard for me.", Username = "Sam", Heart = false },
        new GameReview { Rating = 8.2, Review = "Loved the challenge.", Username = "Alex", Heart = true },
        new GameReview { Rating = 9.0, Review = "Atmosphere was chilling.", Username = "Taylor", Heart = true }
    }
});

AddGame(new Game
{
    Id = Guid.NewGuid().ToString(),
    Title = "The Legend of Zelda: Breath of the Wild",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
    Platforms = new List<string> { "Nintendo Switch", "Wii U" },
    Year = 2017,
    Reviews = new List<GameReview>
    {
        new GameReview { Rating = 9.9, Review = "Best open-world game ever.", Username = "Jamie", Heart = true },
        new GameReview { Rating = 9.4, Review = "Exploration was top-notch.", Username = "Drew", Heart = true },
        new GameReview { Rating = 8.8, Review = "Physics engine was amazing.", Username = "Morgan", Heart = true },
        new GameReview { Rating = 9.2, Review = "Incredible sense of freedom.", Username = "Casey", Heart = true },
        new GameReview { Rating = 7.5, Review = "Not a fan of weapon durability.", Username = "Sam", Heart = true },
        new GameReview { Rating = 9.6, Review = "Zelda at its peak.", Username = "Jordan", Heart = true },
        new GameReview { Rating = 8.0, Review = "Loved it, but had flaws.", Username = "Taylor", Heart = true },
        new GameReview { Rating = 9.0, Review = "Joy to play.", Username = "Alex", Heart = true }
    }
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