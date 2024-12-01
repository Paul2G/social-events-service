using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Auth.Extensions;
using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Interfaces;

namespace web_api_learning.Modules.SocialEvents;

[Route("api/social-events")]
[ApiController]
public class SocialEventController(ISocialEventRepository socialEventRepository, UserManager<AppUser> userManager)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEvents = await socialEventRepository.GetAllAsync(appUser);
        var socialEventsDto = socialEvents.Select(s => s.ToSocialEventDto());

        return Ok(socialEventsDto);
    }

    [HttpGet]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEvent = await socialEventRepository.GetByIdAsync(appUser, id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var socialEventModel = await socialEventRepository.CreateAsync(appUser, socialEventDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEventModel.Id },
            socialEventModel.ToSocialEventDto()
        );
    }

    [HttpPut]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateSocialEventDto socialEventDto
    )
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var socialEventModel = await socialEventRepository.UpdateAsync(appUser, id, socialEventDto);
        if (socialEventModel == null) return NotFound();

        return Ok(socialEventModel.ToSocialEventDto());
    }

    [HttpDelete]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEventModel = await socialEventRepository.DeleteAsync(appUser, id);
        if (socialEventModel == null) return NotFound();

        return NoContent();
    }
}