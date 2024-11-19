using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
using web_api_learning.Modules.Attendees.DTOs;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.Repositories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly ApplicationDbContext _context;

    public AttendeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Attendee>> GetAllAsync()
    {
        return await _context.Attendees.ToListAsync();
    }

    public async Task<Attendee?> GetByIdAsync(long id)
    {
        return await _context.Attendees.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Attendee> CreateAsync(Attendee attendeeModel)
    {
        await _context.Attendees.AddAsync(attendeeModel);
        await _context.SaveChangesAsync();
        return attendeeModel;
    }

    public async Task<Attendee?> UpdateAsync(long id, UpdateAttendeeDto attendeeDto)
    {
        var attendeeModel = await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null) return null;

        attendeeModel.Name = attendeeDto.Name;
        attendeeModel.Status = attendeeDto.Status;

        await _context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<Attendee?> DeleteAsync(long id)
    {
        var attendeeModel = await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendeeModel == null) return null;

        _context.Attendees.Remove(attendeeModel);
        await _context.SaveChangesAsync();

        return attendeeModel;
    }

    public async Task<bool> ExistsAsync(long id)
    {
        return await _context.Attendees.AnyAsync(a => id == a.Id);
    }
}