using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InterviewDbContext : DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options)
    {
        
    }
}