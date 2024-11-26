using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Mappers;
using web_api_learning.Modules.SocialEvents.Interfaces;

namespace web_api_learning.Modules.Attendees.Controllers;

[Route("api/attendees")]
public class AttendeeController(
    IAttendeeRepository attendeeRepository,
    ISocialEventRepository socialEventRepository)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var attendees = await attendeeRepository.GetAllAsync();
        var attendeesDto = attendees.Select(s => s.ToAttendeeDto());
        return Ok(attendeesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var attendee = await attendeeRepository.GetByIdAsync(id);

        if (attendee == null)
            return NotFound();

        return Ok(attendee.ToAttendeeDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendeeDto attendeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await socialEventRepository.ExitsAsync(attendeeDto.SocialEventId))
            return BadRequest("Social event doesn't exists");

        var attendeeModel = attendeeDto.ToAttendeeFromCreateDto();

        await attendeeRepository.CreateAsync(attendeeModel);

        return CreatedAtAction(nameof(GetById), new { id = attendeeModel.Id }, attendeeModel.ToAttendeeDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateAttendeeDto attendeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var attendeeModel = await attendeeRepository.UpdateAsync(id, attendeeDto);

        if (attendeeModel == null) return NotFound("Attendee not found");

        return Ok(attendeeModel.ToAttendeeDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var attendeeModel = await attendeeRepository.DeleteAsync(id);

        if (attendeeModel == null) return NotFound("Attendee not found");

        return NoContent();
    }
}