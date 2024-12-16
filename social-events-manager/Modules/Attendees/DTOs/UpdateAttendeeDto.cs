using System.ComponentModel.DataAnnotations;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees.DTOs;

public class UpdateAttendeeDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be 6 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;

    [Required] public Attendee.AttendanceStatus Status { get; set; }
}