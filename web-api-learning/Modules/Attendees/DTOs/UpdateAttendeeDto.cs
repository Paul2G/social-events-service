using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.DTOs;

public class UpdateAttendeeDto
{
    public string Name { get; set; }
    public Attendee.AttendanceStatus Status { get; set; }
}