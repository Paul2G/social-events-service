using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.Locations.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
{
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Config many-to-many relationship
        builder.Entity<SocialEvent>()
            .HasMany(e => e.Attendees)
            .WithMany(e => e.SocialEvents);

        // Seeding roles
        var roles = new List<IdentityRole>
        {
            new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new()
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}