using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InterviewDbContext : DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options)
    {
        
    }
    public DbSet<Interview> Interview { get; set; }
    public DbSet<Interviewer> Interviewer { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewStatusLookUps { get; set; }
}