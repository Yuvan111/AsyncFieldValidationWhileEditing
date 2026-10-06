using System.ComponentModel.DataAnnotations;

namespace ServerApp.Components.Models;

public sealed class SignUpModel
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Use only letters, numbers, and underscores.")]
    [UsernameAvailable]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [EmailAvailable]
    public string Email { get; set; } = string.Empty;
}
