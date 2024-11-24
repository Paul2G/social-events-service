using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Locations.Interfaces;

namespace web_api_learning.Modules.Locations.Controllers;

[Route("api/locations")]
public class LocationController(ILocationRepository locationRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await locationRepository.GetAllAsync();

        return Ok(locations);
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var location = await locationRepository.GetByIdAsync(id);

        if (location == null) return NotFound("Location not found");

        return Ok(location);
    }
}