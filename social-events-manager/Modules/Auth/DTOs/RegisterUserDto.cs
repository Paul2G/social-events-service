using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Auth.DTOs;

public class RegisterUserDto
{
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255, MinimumLength = 1)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(255, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
