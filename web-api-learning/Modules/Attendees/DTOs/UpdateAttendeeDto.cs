using System.ComponentModel.DataAnnotations;
using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.DTOs;

public class UpdateAttendeeDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be 6 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; }

    [Required] public Attendee.AttendanceStatus Status { get; set; }
}