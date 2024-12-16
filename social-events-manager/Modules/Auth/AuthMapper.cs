using social_events_manager.Modules.Auth.DTOs;
using social_events_manager.Modules.Auth.Models;

namespace social_events_manager.Modules.Auth;

public static class AuthMapper
{
    public static ReadUserDto ToReadUserDto(this AppUser appUser, string token)
    {
        return new ReadUserDto
        {
            Username = appUser.UserName,
            Email = appUser.Email,
            Token = token
        };
    }

    public static AppUser ToAppUser(this RegisterUserDto registerUserDto)
    {
        return new AppUser
        {
            UserName = registerUserDto.Username,
            Email = registerUserDto.Email
        };
    }
}