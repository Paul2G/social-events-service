using System.ComponentModel.DataAnnotations;

namespace social_events_manager.Modules.SocialEvents.DTOs;

public class CreateSocialEventDto
{
    [Required]
    [MinLength(6, ErrorMessage = "Name have to be at least 6 characters long")]
    [MaxLength(255, ErrorMessage = "Name cannot be over 255 characters")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255, ErrorMessage = "Description cannot be over 255 characters")]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    public long? LocationId { get; set; }

    public int[] AttendeesIds { get; set; } = [];
}
