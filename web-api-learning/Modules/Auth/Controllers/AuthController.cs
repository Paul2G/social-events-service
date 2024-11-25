using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Auth.Interfaces;
using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.DTOs;

namespace web_api_learning.Modules.Auth.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(UserManager<AppUser> userManager, ITokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(appUser, "User");

                return roleResult.Succeeded
                    ? Ok(new NewUserDto
                    {
                        UserName = appUser.UserName,
                        Email = appUser.Email,
                        Token = tokenService.CreateToken(appUser)
                    })
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