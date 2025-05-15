namespace GameboxdApi.Models;

public class GameReview
{
    public string Username { get; set; } = default!;
    public double Rating { get; set; }
    public string Review { get; set; } = default!;
    public bool Heart { get; set; }
}