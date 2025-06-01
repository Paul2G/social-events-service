using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    [Required]
    [MinLength(1, ErrorMessage = "Name have to be 1 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;
}
