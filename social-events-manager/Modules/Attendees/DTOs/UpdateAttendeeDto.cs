using System.ComponentModel.DataAnnotations;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees.DTOs;

public class UpdateAttendeeDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public long SocialEventId { get; set; }
}
