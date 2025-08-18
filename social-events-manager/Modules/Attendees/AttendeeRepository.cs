using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees;

public class AttendeeRepository(ApplicationDbContext applicationDbContext) : IAttendeeRepository
{
    public async Task<List<Attendee>> FindUserAttendees(string userId)
    {
        return await applicationDbContext.Attendees.Where(a => a.AppUserId == userId).ToListAsync();
    }

    public async Task<List<Attendee>> FindUserAttendeesPaginated(
        string userId,
        int limit,
        int offset
    )
    {
        return await applicationDbContext
            .Attendees.Where(a => a.AppUserId == userId)
            .Include(a => a.SocialEvent)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Attendee?> FindUserAttendeeById(string userId, long id)
    {
        return await applicationDbContext
            .Attendees.Include(a => a.SocialEvent)
            .FirstOrDefaultAsync(s => s.Id == id && s.AppUserId == userId);
    }

    public async Task<Attendee> SaveUserAttendee(string userId, Attendee attendee)
    {
        attendee.AppUserId = userId;

        var createdAttendee = await applicationDbContext.Attendees.AddAsync(attendee);
        await applicationDbContext.SaveChangesAsync();

        return createdAttendee.Entity;
    }

    public async Task<Attendee?> UpdateUserAttendee(string userId, Attendee attendee)
    {
        var existingAttendee = await applicationDbContext.Attendees.FirstOrDefaultAsync(s =>
            s.Id == attendee.Id && s.AppUserId == userId
        );

        if (existingAttendee == null)
            return null;

        applicationDbContext.Entry(existingAttendee).CurrentValues.SetValues(attendee);
        existingAttendee.AppUserId = userId;

        await applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public async Task<Attendee?> DeleteUserAttendee(string userId, long id)
    {
        var existingAttendee = await applicationDbContext.Attendees.FirstOrDefaultAsync(a =>
            a.Id == id && a.AppUserId == userId
        );

        if (existingAttendee == null)
            return null;

        applicationDbContext.Attendees.Remove(existingAttendee);
        await applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public Task<bool> ExistsUserAttendee(string userId, long id)
    {
        return applicationDbContext.Attendees.AnyAsync(a => id == a.Id && a.AppUserId == userId);
    }

    public Task<int> CountUserAttendees(string userId)
    {
        return applicationDbContext.Attendees.CountAsync(a => a.AppUserId == userId);
    }
}
