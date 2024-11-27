using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees;

public class AttendeeRepository(ApplicationDbContext context) : IAttendeeRepository
{
    public async Task<List<Attendee>> GetAllAsync()
    {
        return await context.Attendees.Include(a => a.SocialEvent).ToListAsync();
    }

    public async Task<Attendee?> GetByIdAsync(long id)
    {
        return await context
            .Attendees.Include(a => a.SocialEvent)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Attendee> CreateAsync(Attendee attendeeModel)
    {
        await context.Attendees.AddAsync(attendeeModel);
        await context.SaveChangesAsync();
        return attendeeModel;
    }

    public async Task<Attendee?> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        var attendeeModel = await context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null)
            return null;

        attendeeModel.ParseFromUpdateAttendeeDto(attendeeDto);
        await context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<Attendee?> DeleteAsync(long id)
    {
        var attendeeModel = await context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null)
            return null;

        context.Attendees.Remove(attendeeModel);
        await context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<bool> ExistsAsync(long id)
    {
        return await context.Attendees.AnyAsync(a => id == a.Id);
    }
}