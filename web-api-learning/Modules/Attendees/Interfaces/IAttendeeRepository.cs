using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> GetAllAsync();
    Task<Attendee?> GetByIdAsync();
    Task<Attendee> CreateAsync();
    Task<Attendee?> UpdateAsync();
    Task<Attendee?> DeleteAsync();
}