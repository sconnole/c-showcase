namespace c_showcase.Models.Game;
public class GameDataUpgrade
{
    public int GameDataId { get; set; }
    public GameData GameData { get; set; } = default!;

    public int UpgradeId { get; set; }
    public Upgrade Upgrade { get; set; } = default!;

    public int Quantity { get; set; }
}
