using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.API.Data;

public class AuthenticationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>,IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    
}