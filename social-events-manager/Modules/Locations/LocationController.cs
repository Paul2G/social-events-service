using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;

namespace social_events_manager.Modules.Locations;

[ApiController]
[Route("api/locations")]
[Authorize]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _locationService.GetAllAsync();

        return Ok(locations);
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var location = await _locationService.GetByIdAsync(id);

        if (location == null)
            return NotFound("Location not found");

        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto locationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var location = await _locationService.CreateAsync(locationDto);

        return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
    }

    [HttpPut]
    [Route("{id:long}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateLocationDto locationDto
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var location = await _locationService.UpdateAsync(id, locationDto);

        if (location == null)
            return NotFound("Location was not found");

        return Ok(location);
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var location = await _locationService.DeleteAsync(id);

        if (location == null)
            return NotFound("Location not found");

        return NoContent();
    }
}
