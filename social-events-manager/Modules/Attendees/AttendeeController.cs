using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Modules.Attendees.DTOs;
using social_events_manager.Modules.Attendees.Interfaces;

namespace social_events_manager.Modules.Attendees;

[ApiController]
[Route("api/attendees")]
[Authorize]
public class AttendeeController(IAttendeeService attendeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attendees = await attendeeService.GetAllAsync();

        return Ok(attendees);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var attendee = await attendeeService.GetByIdAsync(id);

        return Ok(attendee);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendeeDto attendeeDto)
    {
        var attendee = await attendeeService.CreateAsync(attendeeDto);

        return CreatedAtAction(nameof(GetById), new { id = attendee.Id }, attendee);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateAttendeeDto attendeeDto
    )
    {
        var attendee = await attendeeService.UpdateAsync(id, attendeeDto);

        return Ok(attendee);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await attendeeService.DeleteAsync(id);

        return NoContent();
    }
}
