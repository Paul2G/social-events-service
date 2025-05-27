using Microsoft.EntityFrameworkCore;
using social_events_manager.Data;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Attendees.Models;

namespace social_events_manager.Modules.Attendees;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AttendeeRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Attendee>> FindUserAttendees(string userId)
    {
        return await _applicationDbContext
            .Attendees.Where(a => a.AppUserId == userId)
            .ToListAsync();
    }

    public async Task<Attendee?> FindUserAttendeeById(string userId, long id)
    {
        return await _applicationDbContext.Attendees.FirstOrDefaultAsync(s =>
            s.Id == id && s.AppUserId == userId
        );
    }

    public async Task<Attendee> SaveUserAttendee(string userId, Attendee attendee)
    {
        attendee.AppUserId = userId;

        var createdAttendee = await _applicationDbContext.Attendees.AddAsync(attendee);
        await _applicationDbContext.SaveChangesAsync();

        return createdAttendee.Entity;
    }

    public async Task<Attendee?> UpdateUserAttendee(string userId, Attendee attendee)
    {
        var existingAttendee = await _applicationDbContext.Attendees.FirstOrDefaultAsync(s =>
            s.Id == attendee.Id && s.AppUserId == userId
        );

        // TODO: Make this more robust, maybe throw an exception or return a specific error
        if (existingAttendee == null)
            return null;

        _applicationDbContext.Entry(existingAttendee).CurrentValues.SetValues(attendee);
        await _applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public async Task<Attendee?> DeleteUserAttendee(string userId, long id)
    {
        var existingAttendee = await _applicationDbContext.Attendees.FirstOrDefaultAsync(a =>
            a.Id == id && a.AppUserId == userId
        );

        // TODO: Make this more robust, maybe throw an exception or return a specific error
        if (existingAttendee == null)
            return null;

        _applicationDbContext.Attendees.Remove(existingAttendee);
        await _applicationDbContext.SaveChangesAsync();

        return existingAttendee;
    }

    public Task<bool> ExistsUserAttendee(string userId, long id)
    {
        return _applicationDbContext.Attendees.AnyAsync(a => id == a.Id && a.AppUserId == userId);
    }
}
