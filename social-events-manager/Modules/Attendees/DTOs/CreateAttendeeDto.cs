using System.ComponentModel.DataAnnotations;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public string Status { get; set; } = Attendee.AttendanceStatus.Pending.ToString();

    [Required]
    public long SocialEventId { get; set; }
}
