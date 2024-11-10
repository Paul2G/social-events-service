using Microsoft.EntityFrameworkCore;
using wep_api_learning.Modules.Attendees.Models;
using wep_api_learning.Modules.SocialEvents.Models;

namespace wep_api_learning.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }

    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}
