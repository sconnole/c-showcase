using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [EmailAddress]
    public required string Email { get; set; } = "";

    [DataType(DataType.Password)]
    public required string Password { get; set; } = "";

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; } = "";
}
