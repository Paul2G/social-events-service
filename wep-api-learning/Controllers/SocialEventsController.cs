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

        Console.Write(socialEventModel);

        _context.SocialEvents.Add(socialEventModel);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetById),
            new { id = socialEventModel.Id },
            socialEventModel.ToSocialEventDto()
        );
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] UpdateSocialEventRequestDto socialEventDto
    )
    {
        var socialEventModel = _context.SocialEvents.FirstOrDefault(x => x.Id == id);

        if (socialEventModel == null)
        {
            return NotFound();
        }

        socialEventModel.Name = socialEventDto.Name;
        socialEventModel.Description = socialEventDto.Description;
        socialEventModel.Location = socialEventDto.Location;
        socialEventModel.StartTime = socialEventDto.StartTime;
        socialEventModel.EndTime = socialEventDto.EndTime;

        _context.SaveChanges();

        return Ok(socialEventModel.ToSocialEventDto());
    }
}
