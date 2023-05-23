using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.API.Data;

public class AuthenticationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole,
    IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(ConfigureUser);
        modelBuilder.Entity<Role>(ConfigureRole);
        modelBuilder.Entity<UserRole>(ConfigureUserRole);

        modelBuilder.Entity<IdentityUserClaim<Guid>>(uc => uc.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<Guid>>(uc => uc.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityUserToken<Guid>>(uc => uc.ToTable("UserTokens"));
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(uc => uc.ToTable("UserRoleClaims"));
    }

    private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
    }
    
    private void ConfigureRole(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r=> r.Id);
        builder.Property(r => r.Name).HasMaxLength(64);
        
        // each Role can have many entries in the UserRole joint table
        builder.HasMany(e => e.UsersForRole)
            .WithOne(e => e.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }
    
    private void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).HasMaxLength(128);
        builder.Property(u => u.LastName).HasMaxLength(128);

        builder.HasMany(e => e.RolesForUser)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();


    }
}