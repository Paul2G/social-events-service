using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees;

public class AttendeeRepository(ApplicationDbContext applicationDbContext) : IAttendeeRepository
{
    public async Task<List<Attendee>> FindAttendees()
    {
        return await applicationDbContext.Attendees.ToListAsync();
    }

    public async Task<List<Attendee>> FindAttendeesPaginated(int limit, int offset)
    {
        return await applicationDbContext
            .Attendees.Include(a => a.SocialEvent)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Attendee?> FindAttendeeById(long id)
    {
        return await applicationDbContext
            .Attendees.Include(a => a.SocialEvent)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Attendee> SaveAttendee(Attendee attendee)
    {
        var createdAttendee = await applicationDbContext.Attendees.AddAsync(attendee);
        await applicationDbContext.SaveChangesAsync();

        return createdAttendee.Entity;
    }

    public async Task<Attendee?> UpdateAttendee(Attendee attendee)
    {
        var existingAttendee = await applicationDbContext.Attendees.FirstOrDefaultAsync(s =>
            s.Id == attendee.Id
        );

        if (existingAttendee == null)
            return null;

        attendee.AppUserId = existingAttendee.AppUserId;
        applicationDbContext.Entry(existingAttendee).CurrentValues.SetValues(attendee);

        await applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public async Task<Attendee?> DeleteAttendee(long id)
    {
        var existingAttendee = await applicationDbContext.Attendees.FirstOrDefaultAsync(a =>
            a.Id == id
        );

        if (existingAttendee == null)
            return null;

        applicationDbContext.Attendees.Remove(existingAttendee);
        await applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public Task<bool> ExistsAttendee(long id)
    {
        return applicationDbContext.Attendees.AnyAsync(a => id == a.Id);
    }

    public Task<int> CountAttendees()
    {
        return applicationDbContext.Attendees.CountAsync();
    }
}
