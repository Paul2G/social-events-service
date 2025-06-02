using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_events_manager.Middlewares;
using social_events_manager.Modules.Auth.DTOs;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Auth.Models;

namespace social_events_manager.Modules.Auth;

[Route("auth")]
[ApiController]
[ModelStateValidationFilter]
public class AuthController(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    SignInManager<AppUser> signInManager
) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u =>
            u.NormalizedUserName == loginUserDto.Username.ToUpper()
        );

        if (user == null)
            return Unauthorized("Invalid credentials");

        var result = await signInManager.CheckPasswordSignInAsync(
            user,
            loginUserDto.Password,
            false
        );

        if (!result.Succeeded)
            return Unauthorized("Invalid credentials");

        return Ok(user.ToReadUserDto(tokenService.CreateToken(user)));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        try
        {
            var appUser = registerUserDto.ToAppUser();

            var createdUser = await userManager.CreateAsync(appUser, registerUserDto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(appUser, "User");

                return roleResult.Succeeded
                    ? Ok(appUser.ToReadUserDto(tokenService.CreateToken(appUser)))
                    : StatusCode(500, roleResult.Errors);
            }

            return StatusCode(500, createdUser.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}
