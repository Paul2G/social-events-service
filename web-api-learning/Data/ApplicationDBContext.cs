using Microsoft.EntityFrameworkCore;
using web_api_learning.Modules.Attendees.Models;
using web_api_learning.Modules.Locations.Models;
using web_api_learning.Modules.SocialEvents.Models;

namespace web_api_learning.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Location> Locations { get; set; }
}