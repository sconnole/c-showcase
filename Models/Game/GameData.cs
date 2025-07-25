namespace c_showcase.Models.Game;

public class GameData
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public long Resources { get; set; } = 0;
    public int ResourcesPerClick { get; set; } = 1;
    public int ResourcesPerSecond { get; set; } = 0;

    public List<GameDataUpgrade> GameDataUpgrades { get; set; } = new();

    public void ClickResource()
    {
        Resources += ResourcesPerClick;
    }
}