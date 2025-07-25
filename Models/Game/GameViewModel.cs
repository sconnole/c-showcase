namespace c_showcase.Models.Game;
public class GameViewModel
{
    public required GameData GameData { get; set; }
    public required List<Upgrade> AvailableUpgrades { get; set; }
}
