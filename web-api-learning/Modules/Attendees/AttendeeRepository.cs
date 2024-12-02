using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Models;
using web_api_learning.Modules.Auth.Models;

namespace web_api_learning.Modules.Attendees;

public class AttendeeRepository(ApplicationDbContext context) : IAttendeeRepository
{
    public async Task<List<Attendee>> GetAllAsync(AppUser appUser)
    {
        return await context.Attendees.Where(s => s.AppUserId == appUser.Id).ToListAsync();
    }

    public async Task<Attendee?> GetByIdAsync(AppUser appUser, long id)
    {
        return await context.Attendees
            .Where(a => a.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Attendee> CreateAsync(AppUser appUser, CreateAttendeeDto attendeeDto)
    {
        var attendeeModel = attendeeDto.ToAttendee(appUser.Id);

        await context.Attendees.AddAsync(attendeeModel);
        await context.SaveChangesAsync();
        return attendeeModel;
    }

    public async Task<Attendee?> UpdateAsync(AppUser appUser, long id, UpdateAttendeeDto attendeeDto)
    {
        var attendeeModel = await context.Attendees
            .Where(a => a.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null)
            return null;

        attendeeModel.ParseFromUpdateAttendeeDto(attendeeDto);
        await context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<Attendee?> DeleteAsync(AppUser appUser, long id)
    {
        var attendeeModel = await context.Attendees
            .Where(a => a.AppUserId == appUser.Id)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null)
            return null;

        context.Attendees.Remove(attendeeModel);
        await context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<bool> ExistsAsync(AppUser appUser, long id)
    {
        return await context.Attendees.Where(a => a.AppUserId == appUser.Id).AnyAsync(a => id == a.Id);
    }
}