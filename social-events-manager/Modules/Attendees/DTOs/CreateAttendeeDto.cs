using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
}
