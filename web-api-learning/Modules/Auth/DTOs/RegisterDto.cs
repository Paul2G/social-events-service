using System.ComponentModel.DataAnnotations;

namespace web_api_learning.Modules.DTOs;

public class RegisterDto
{
    [Required] public string? Username { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] [MinLength(8)] public string? Password { get; set; }
}