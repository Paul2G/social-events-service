using Microsoft.EntityFrameworkCore;
using wep_api_learning.Models;

namespace wep_api_learning.Data;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions): base( dbContextOptions)
    {
    }
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}