using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using social_events_manager.Modules.Attendees.Models;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.Locations.Models;
using social_events_manager.Modules.SocialEvents.Models;

namespace social_events_manager.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions)
    : IdentityDbContext<AppUser>(dbContextOptions)
{
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Attendee>()
            .HasMany(a => a.SocialEvents)
            .WithMany(se => se.Attendees)
            .UsingEntity<Dictionary<string, object>>(
                "AttendeeSocialEvent",
                j =>
                    j.HasOne<SocialEvent>()
                        .WithMany()
                        .HasForeignKey("SocialEventsId")
                        .OnDelete(DeleteBehavior.Cascade), // or NoAction
                j =>
                    j.HasOne<Attendee>()
                        .WithMany()
                        .HasForeignKey("AttendeesId")
                        .OnDelete(DeleteBehavior.Cascade) // choose only one to cascade
            );
    }
}
