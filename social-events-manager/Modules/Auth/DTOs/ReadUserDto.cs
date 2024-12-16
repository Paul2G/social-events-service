namespace social_events_manager.Modules.Auth.DTOs;

public class ReadUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}