using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Auth.DTOs;

public class LoginUserDto
{
    [Required]
    [StringLength(255)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(255, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
