using System.ComponentModel.DataAnnotations;

namespace WASMApp.Client.Models;

public sealed class SignUpModel
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Use only letters, numbers, and underscores.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
