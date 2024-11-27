using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.SocialEvents.DTOs;
using web_api_learning.Modules.SocialEvents.Interfaces;

namespace web_api_learning.Modules.SocialEvents;

[Route("api/social-events")]
[ApiController]
public class SocialEventController(ISocialEventRepository socialEventRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var socialEvents = await socialEventRepository.GetAllAsync();
        var socialEventsDto = socialEvents.Select(s => s.ToSocialEventDto());

        return Ok(socialEventsDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var socialEvent = await socialEventRepository.GetByIdAsync(id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

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
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var socialEventModel = await socialEventRepository.UpdateAsync(id, socialEventDto);
        if (socialEventModel == null) return NotFound();

        return Ok(socialEventModel.ToSocialEventDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var socialEventModel = await socialEventRepository.DeleteAsync(id);
        if (socialEventModel == null) return NotFound();

        return NoContent();
    }
}