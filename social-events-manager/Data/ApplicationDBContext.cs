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

        // SocialEvent → Location
        modelBuilder
            .Entity<SocialEvent>()
            .HasOne(se => se.Location)
            .WithMany(l => l.SocialEvents)
            .HasForeignKey(se => se.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        // SocialEvent → AppUser
        modelBuilder
            .Entity<SocialEvent>()
            .HasOne(se => se.AppUser)
            .WithMany(u => u.SocialEvents)
            .HasForeignKey(se => se.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Attendee → SocialEvent
        modelBuilder
            .Entity<Attendee>()
            .HasOne(a => a.SocialEvent)
            .WithMany(se => se.Attendees)
            .HasForeignKey(a => a.SocialEventId)
            .OnDelete(DeleteBehavior.Restrict);

        // Attendee → AppUser
        modelBuilder
            .Entity<Attendee>()
            .HasOne(a => a.AppUser)
            .WithMany(u => u.Attendees)
            .HasForeignKey(a => a.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Location → AppUser
        modelBuilder
            .Entity<Location>()
            .HasOne(l => l.AppUser)
            .WithMany(u => u.Locations)
            .HasForeignKey(l => l.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
