using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Mappers;
using web_api_learning.Modules.SocialEvents.Interfaces;

namespace web_api_learning.Modules.Attendees.Controllers;

[Route("api/attendees")]
public class AttendeeController : ControllerBase
{
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly ISocialEventRepository _socialEventRepository;

    public AttendeeController(IAttendeeRepository attendeeAttendeeRepository,
        ISocialEventRepository socialEventRepository)
    {
        _attendeeRepository = attendeeAttendeeRepository;
        _socialEventRepository = socialEventRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attendees = await _attendeeRepository.GetAllAsync();
        var attendeesDto = attendees.Select(s => s.ToAttendeeDto());
        return Ok(attendeesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var attendee = await _attendeeRepository.GetByIdAsync(id);

        if (attendee == null)
            return NotFound();

        return Ok(attendee.ToAttendeeDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendeeDto attendeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await _socialEventRepository.ExitsAsync(attendeeDto.SocialEventId))
            return BadRequest("Social event doesn't exists");

        var attendeeModel = attendeeDto.ToAttendeeFromCreateDto();

        await _attendeeRepository.CreateAsync(attendeeModel);

        return CreatedAtAction(nameof(GetById), new { id = attendeeModel.Id }, attendeeModel.ToAttendeeDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateAttendeeDto attendeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var attendeeModel = await _attendeeRepository.UpdateAsync(id, attendeeDto);

        if (attendeeModel == null) return NotFound("Attendee not found");

        return Ok(attendeeModel.ToAttendeeDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var attendeeModel = await _attendeeRepository.DeleteAsync(id);

        if (attendeeModel == null) return NotFound("Attendee not found");

        return NoContent();
    }
}