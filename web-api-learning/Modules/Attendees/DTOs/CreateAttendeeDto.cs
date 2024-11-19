namespace web_api_learning.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    public string Name { get; set; } = string.Empty;
    public long SocialEventId { get; set; }
}