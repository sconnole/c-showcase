using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using c_showcase.Models.Game;
using Microsoft.EntityFrameworkCore;

public class GameController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public GameController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [Authorize]
    public async Task<ActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var gameData = _context.GameData.Include(g => g.GameDataUpgrades)
                    .ThenInclude(gdu => gdu.Upgrade)
                    .FirstOrDefault(g => g.UserId == user.Id);

        if (gameData == null)
        {
            gameData = new GameData
            {
                UserId = user.Id,
                Resources = 0,
                LastUpdated = DateTime.UtcNow,
                GameDataUpgrades = new List<GameDataUpgrade>()
            };


            _context.GameData.Add(gameData);
            await _context.SaveChangesAsync();
        }
        
        var availableUpgrades = await _context.Upgrades.ToListAsync();
        var viewModel = new GameViewModel
        {
            GameData = gameData,
            AvailableUpgrades = availableUpgrades
        };

        return View(viewModel);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Save([FromBody] ClickUpdate update)
    {
        var user = await _userManager.GetUserAsync(User);
        var gameData = _context.GameData.FirstOrDefault(g => g.UserId == user.Id);

        if (gameData == null)
        {
            return NotFound();
        }

        gameData.Resources += update.Clicks;
        await _context.SaveChangesAsync();

        return Json(new { resources = gameData.Resources }); 
    }

    // upgrade
}