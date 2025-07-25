public class DashboardViewModel
{
    public required string Email { get; set; }
    public required string WelcomeMessage { get; set; }
    public required Dictionary<string, string> Stats { get; set; }
}