using web_api_learning.Modules.Auth.DTOs;
using web_api_learning.Modules.Auth.Models;

namespace web_api_learning.Modules.Auth;

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

    public static AppUser ToAppUser(this RegisterDto registerDto)
    {
        return new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };
    }
}