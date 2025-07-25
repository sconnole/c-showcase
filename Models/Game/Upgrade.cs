namespace c_showcase.Models.Game;
public class Upgrade
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int BaseCost { get; set; }
    public int ResourcesPerSecond { get; set; }

    public List<GameDataUpgrade> GameDataUpgrades { get; set; } = new();
}
