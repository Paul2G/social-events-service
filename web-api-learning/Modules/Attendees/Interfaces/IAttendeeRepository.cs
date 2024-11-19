using web_api_learning.Modules.Attendees.Models;

namespace web_api_learning.Modules.Attendees.Interfaces;

public interface IAttendeeRepository
{
    Task<List<Attendee>> GetAllAsync();
    Task<Attendee?> GetByIdAsync(long id);
    Task<Attendee> CreateAsync(Attendee attendeeModel);
    Task<Attendee?> UpdateAsync();
    Task<Attendee?> DeleteAsync();
}