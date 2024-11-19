using Microsoft.EntityFrameworkCore;
using web_api_learning.Data;
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

    public Task<Attendee> CreateAsync() 
    {
        throw new NotImplementedException();
    }

    public Task<Attendee?> UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Attendee?> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}