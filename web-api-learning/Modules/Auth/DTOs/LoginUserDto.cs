using System.ComponentModel.DataAnnotations;

namespace web_api_learning.Modules.Auth.DTOs;

public class LoginUserDto
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}