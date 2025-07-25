using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using c_showcase.Models.Game;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<GameData> GameData { get; set; }
    public DbSet<Upgrade> Upgrades { get; set; }
    public DbSet<GameDataUpgrade> GameDataUpgrades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameDataUpgrade>()
            .HasKey(gdu => new { gdu.GameDataId, gdu.UpgradeId });

        modelBuilder.Entity<GameDataUpgrade>()
            .HasOne(gdu => gdu.GameData)
            .WithMany(gd => gd.GameDataUpgrades)
            .HasForeignKey(gdu => gdu.GameDataId);

        modelBuilder.Entity<GameDataUpgrade>()
            .HasOne(gdu => gdu.Upgrade)
            .WithMany(u => u.GameDataUpgrades)
            .HasForeignKey(gdu => gdu.UpgradeId);

        modelBuilder.Entity<Upgrade>().HasData(
            new Upgrade { Id = 1, Name = "Auto Clicker", Description = "+1 Orb/sec", BaseCost = 100 }, 
            new Upgrade { Id = 2, Name = "Small Harvester", Description = "+2 Orb/sec", BaseCost = 400 }
        );
    }
}