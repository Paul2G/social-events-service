using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Auth.DTOs;

public class LoginUserDto
{
    [Required] public string? Username { get; set; }

    [Required] public string? Password { get; set; }
}