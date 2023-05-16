using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class EmployeeDbContext: DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
    {
        
    }
    
    //Dbsets are properties of Dbcontext
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }
/*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I can use this method to do fluent API way to do any schema changes just like Data Annotations
        modelBuilder.Entity<Candidate>(ConfigureCandidate);
    }

    private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
    {
        // establish the rules for candidate table
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
    }
    */
}