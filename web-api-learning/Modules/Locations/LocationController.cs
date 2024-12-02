using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api_learning.Modules.Auth.Extensions;
using web_api_learning.Modules.Auth.Models;
using web_api_learning.Modules.Locations.DTOs;
using web_api_learning.Modules.Locations.Interfaces;

namespace web_api_learning.Modules.Locations;

[ApiController]
[Route("api/locations")]
[Authorize]
public class LocationController(ILocationRepository locationRepository, UserManager<AppUser> userManager)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var locations = await locationRepository.GetAllAsync(appUser);
        var locationsDto = locations.Select(l => l.ToLocationDto());

        return Ok(locationsDto);
    }

    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var location = await locationRepository.GetByIdAsync(appUser, id);

        if (location == null) return NotFound("Location not found");

        return Ok(location.ToLocationDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto locationDto)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var locationModel = await locationRepository.CreateAsync(appUser, locationDto);

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
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var locationModel = await locationRepository.UpdateAsync(appUser, id, locationDto);
        if (locationModel == null) return NotFound("Location was not found");

        return Ok(locationModel.ToLocationDto());
    }

    [HttpDelete]
    [Route("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var locationModel = await locationRepository.DeleteAsync(appUser, id);

        if (locationModel == null) return NotFound("Location not found");

        return NoContent();
    }
}