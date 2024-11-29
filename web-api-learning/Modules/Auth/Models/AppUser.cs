using Microsoft.AspNetCore.Identity;
using web_api_learning.Modules.Attendees.Models;
using web_api_learning.Modules.Locations.Models;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Modules.Auth.Models;

public class AppUser : IdentityUser
{
    public List<SocialEvent> SocialEvents { get; set; } = [];
    public List<Location> Locations { get; set; } = [];
    public List<Attendee> Attendees { get; set; } = [];
}