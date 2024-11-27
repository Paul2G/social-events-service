using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Locations.DTOs;
using web_api_learning.Modules.Locations.Interfaces;

namespace web_api_learning.Modules.Locations;

[Route("api/locations")]
public class LocationController(ILocationRepository locationRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await locationRepository.GetAllAsync();
        var locationsDto = locations.Select(l => l.ToLocationDto());

        return Ok(locationsDto);
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var location = await locationRepository.GetByIdAsync(id);

        if (location == null) return NotFound("Location not found");

        return Ok(location.ToLocationDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto locationDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var locationModel = await locationRepository.CreateAsync(locationDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = locationModel.Id },
            locationModel.ToLocationDto()
        );
    }

    [HttpPut]
    [Route("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateLocationDto locationDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var locationModel = await locationRepository.UpdateAsync(id, locationDto);

        if (locationModel == null) return NotFound("Location was not found");

        return Ok(locationModel.ToLocationDto());
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var locationModel = await locationRepository.DeleteAsync(id);

        if (locationModel == null) return NotFound("Location not found");

        return NoContent();
    }
}