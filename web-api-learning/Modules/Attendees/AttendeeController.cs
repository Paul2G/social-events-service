using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Auth.Extensions;
using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.SocialEvents.Interfaces;

namespace web_api_learning.Modules.Attendees;

[ApiController]
[Route("api/attendees")]
[Authorize]
public class AttendeeController(
    IAttendeeRepository attendeeRepository,
    ISocialEventRepository socialEventRepository,
    UserManager<AppUser> userManager)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var attendees = await attendeeRepository.GetAllAsync(appUser);
        var attendeesDto = attendees.Select(s => s.ToAttendeeDto());
        return Ok(attendeesDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var attendee = await attendeeRepository.GetByIdAsync(appUser, id);

        if (attendee == null) return NotFound();

        return Ok(attendee.ToAttendeeDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendeeDto attendeeDto)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await socialEventRepository.ExitsAsync(appUser, attendeeDto.SocialEventId))
            return BadRequest("Social event doesn't exists");

        var attendeeModel = await attendeeRepository.CreateAsync(appUser, attendeeDto);

        return CreatedAtAction(nameof(GetById), new { id = attendeeModel.Id }, attendeeModel.ToAttendeeDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateAttendeeDto attendeeDto)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var attendeeModel = await attendeeRepository.UpdateAsync(appUser, id, attendeeDto);
        if (attendeeModel == null) return NotFound("Attendee not found");

        return Ok(attendeeModel.ToAttendeeDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var attendeeModel = await attendeeRepository.DeleteAsync(appUser, id);
        if (attendeeModel == null) return NotFound("Attendee not found");

        return NoContent();
    }
}