using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Middlewares;
using social_events_manager.Modules.Locations.DTOs;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.Shared.DTOs;

namespace social_events_manager.Modules.Locations;

[ApiController]
[Route("api/locations")]
[Authorize]
[ModelStateValidationFilter]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQueryDto paginationQuery)
    {
        if (paginationQuery.Page.HasValue)
        {
            var locations = await locationService.GetAllPaginatedAsync(paginationQuery);
            return Ok(locations);
        }
        else
        {
            var locations = await locationService.GetAllAsync();
            return Ok(locations);
        }
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var location = await locationService.GetByIdAsync(id);

        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto locationDto)
    {
        var location = await locationService.CreateAsync(locationDto);

        return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
    }

    [HttpPut]
    [Route("{id:long}")]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromBody] UpdateLocationDto locationDto
    )
    {
        var location = await locationService.UpdateAsync(id, locationDto);

        return Ok(location);
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await locationService.DeleteAsync(id);

        return NoContent();
    }
}
