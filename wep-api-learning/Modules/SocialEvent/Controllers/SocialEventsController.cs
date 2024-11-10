using Microsoft.AspNetCore.Mvc;
using wep_api_learning.Modules.SocialEvent.DTOs;
using wep_api_learning.Modules.SocialEvent.Interfaces;
using wep_api_learning.Modules.SocialEvent.Mappers;

namespace wep_api_learning.Modules.SocialEvent.Controllers;

[Route("api/social-events")]
[ApiController]
public class SocialEventsController : ControllerBase
{
    private readonly ISocialEventRepository _repository;

    public SocialEventsController(ISocialEventRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var socialEvents = await _repository.GetAllAsync();
        var socialEventsDto = socialEvents.Select(s => s.ToSocialEventDto());

        return Ok(socialEventsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var socialEvent = await _repository.GetByIdAsync(id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSocialEventDto socialEventDto)
    {
        var socialEventModel = socialEventDto.ToSocialEventFromCreateDto();
        await _repository.CreateAsync(socialEventModel);

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEventModel.Id },
            socialEventModel.ToSocialEventDto()
        );
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateSocialEventDto socialEventDto
    )
    {
        var socialEventModel = await _repository.UpdateAsync(id, socialEventDto);

        if (socialEventModel == null)
            return NotFound();

        return Ok(socialEventModel.ToSocialEventDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var socialEventModel = await _repository.DeleteAsync(id);

        if (socialEventModel == null)
            return NotFound();

        return NoContent();
    }
}
