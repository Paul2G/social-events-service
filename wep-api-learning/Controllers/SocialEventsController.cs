using Microsoft.AspNetCore.Mvc;
using wep_api_learning.Data;
using wep_api_learning.Dtos.SocialEvent;
using wep_api_learning.Mappers;

namespace wep_api_learning.Controllers;

[Route("api/social-events")]
[ApiController]
public class SocialEventsController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public SocialEventsController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var socialEvents = _context.SocialEvents.ToList().Select(s => s.ToSocialEventDto());

        return Ok(socialEvents);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] long id)
    {
        var socialEvent = _context.SocialEvents.Find(id);

        if (socialEvent == null)
            return NotFound();

        return Ok(socialEvent);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateSocialEventRequestDto socialEventDto)
    {
        var socialEventModel = socialEventDto.ToSocialEventFromCreateDto();

        _context.SocialEvents.Add(socialEventModel);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEventModel.Id },
            socialEventModel.ToSocialEventDto()
        );
    }
}
