using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Modules.Auth.Extensions;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;

namespace social_events_manager.Modules.SocialEvents;

[ApiController]
[Route("api/social-events")]
[Authorize]
public class SocialEventController(
    ISocialEventRepository socialEventRepository,
    UserManager<AppUser> userManager
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEvents = await socialEventRepository.GetAllAsync();
        var socialEventsDto = socialEvents.Select(s => s.ToSocialEventDto());

        return Ok(socialEventsDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEvent = await socialEventRepository.GetByIdAsync(id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var socialEventModel = await socialEventRepository.CreateAsync(socialEventDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEventModel.Id },
            socialEventModel.ToSocialEventDto()
        );
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateSocialEventDto socialEventDto
    )
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var socialEventModel = await socialEventRepository.UpdateAsync(id, socialEventDto);
        if (socialEventModel == null)
            return NotFound();

        return Ok(socialEventModel.ToSocialEventDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var socialEventModel = await socialEventRepository.DeleteAsync(id);
        if (socialEventModel == null)
            return NotFound();

        return NoContent();
    }
}
