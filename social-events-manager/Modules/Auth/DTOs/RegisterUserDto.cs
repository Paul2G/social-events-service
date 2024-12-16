using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Auth.DTOs;

public class RegisterUserDto
{
    [Required] public string? Username { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    [Required] [MinLength(8)] public string? Password { get; set; }
}