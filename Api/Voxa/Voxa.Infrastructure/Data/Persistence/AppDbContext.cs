using Framework.Infrastructure.EntityFramework.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Voxa.Domain.Organizations;
using Voxa.Domain.Users;

namespace Voxa.Infrastructure.Data.Persistence;

public class AppDbContext : BaseDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    // USERS
    public DbSet<User> User { get; set; }
    
    // ORGANIZATIONS
    public DbSet<Organization> Organization { get; set; }
    public DbSet<OrganizationMembership> Membership { get; set; }
}