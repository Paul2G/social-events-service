using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_learning.Modules.Auth.DTOs;
using web_api_learning.Modules.Auth.Interfaces;
using web_api_learning.Modules.Auth.Models;

namespace web_api_learning.Modules.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    SignInManager<AppUser> signInManager
) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await userManager.Users.FirstOrDefaultAsync(u =>
            u.NormalizedUserName == loginDto.Username.ToUpper()
        );

        if (user == null)
            return Unauthorized("Invalid credentials");

        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded)
            return Unauthorized("Invalid credentials");

        return Ok(user.ToReadUserDto(tokenService.CreateToken(user)));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = registerDto.ToAppUser();

            var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

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