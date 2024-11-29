using System.ComponentModel.DataAnnotations;

namespace web_api_learning.Modules.Attendees.DTOs;

public class CreateAttendeeDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be 6 characters length")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; }

    [Required] public long SocialEventId { get; set; }
}