namespace GameboxdApi.Models;

public class Game
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string CoverImage { get; set; } = default!;
    public List<string> Platforms { get; set; } = default!;
    public short Year { get; set; } = default!;

    public List<GameReview> Reviews { get; set; } = new();
}