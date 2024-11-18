using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Mappers;

namespace web_api_learning.Modules.Attendees.Controllers;

[Route("api/attendees")]
public class AttendeeController : ControllerBase
{
    private readonly IAttendeeRepository _repository;

    public AttendeeController(IAttendeeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attendees = await _repository.GetAllAsync();
        var attendeesDto = attendees.Select(s => s.ToAttendeeDto());
        return Ok(attendeesDto);
    }
}