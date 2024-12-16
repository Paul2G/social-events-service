using Microsoft.AspNetCore.Identity;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Locations.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Modules.Auth.Models;

public class AppUser : IdentityUser
{
    public List<SocialEvent> SocialEvents { get; set; } = [];
    public List<Location> Locations { get; set; } = [];
    public List<Attendee> Attendees { get; set; } = [];
}