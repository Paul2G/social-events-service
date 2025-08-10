using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Middlewares;
using social_events_manager.Modules.Shared.DTOs;
using social_events_manager.Modules.SocialEvents.DTOs;
using social_events_manager.Modules.SocialEvents.Interfaces;

namespace social_events_manager.Modules.SocialEvents;

[ApiController]
[Route("api/social-events")]
[Authorize]
[ModelStateValidationFilter]
public class SocialEventController(ISocialEventService socialEventService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQueryDto paginationQueryDto)
    {
        if (paginationQueryDto.Page.HasValue)
        {
            var paginatedSocialEvents = await socialEventService.GetAllPaginatedAsync(
                paginationQueryDto
            );
            return Ok(paginatedSocialEvents);
        }

        var socialEvents = await socialEventService.GetAllAsync();
        return Ok(socialEvents);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var socialEvent = await socialEventService.GetByIdAsync(id);

        return Ok(socialEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        var socialEvent = await socialEventService.CreateAsync(socialEventDto);

        return CreatedAtAction(nameof(GetById), new { id = socialEvent.Id }, socialEvent);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateSocialEventDto socialEventDto
    )
    {
        var socialEvent = await socialEventService.UpdateAsync(id, socialEventDto);

        return Ok(socialEvent);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await socialEventService.DeleteAsync(id);

        return NoContent();
    }
}
