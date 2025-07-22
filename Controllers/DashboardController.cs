using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class DashboardController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public DashboardController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        var model = new DashboardViewModel
        {
            Email = user?.Email ?? "Unknown",
            WelcomeMessage = "Welcome to your dashboard!",
            Stats = new Dictionary<string, string>
            {
                { "Games Played", "12" },
                { "High Score", "9001" },
                { "Rank", "Elite Player" }
            }
        };

        return View(model);
    }
}
