using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be 6 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;

    [Required] public long SocialEventId { get; set; }
}