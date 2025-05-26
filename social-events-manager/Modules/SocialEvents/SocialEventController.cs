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
    ISocialEventService socialEventService,
    UserManager<AppUser> userManager
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var socialEvents = await socialEventService.GetAllAsync();
        return Ok(socialEvents);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var socialEvent = await socialEventService.GetByIdAsync(id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var socialEvent = await socialEventService.CreateAsync(socialEventDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEvent.Id }
        );
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateSocialEventDto socialEventDto
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var socialEvent = await socialEventService.UpdateAsync(id, socialEventDto);
        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var socialEventModel = await socialEventService.DeleteAsync(id);
        if (socialEventModel == null)
            return NotFound();

        return NoContent();
    }
}
