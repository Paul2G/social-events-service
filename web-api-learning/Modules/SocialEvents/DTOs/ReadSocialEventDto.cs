using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Locations.Models;

namespace web_api_learning.Modules.SocialEvents.DTOs;

public class ReadSocialEventDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Location? Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int AttendeesCount { get; set; }

    public List<ReadAttendeeDto> Attendees { get; set; } = new();
}