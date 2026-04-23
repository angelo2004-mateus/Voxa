using Framework.Application.Contracts.Auth;
using Framework.Application.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Voxa.Infrastructure.Data.Persistence;

namespace Voxa.Infrastructure.Auth;

public class UserAuthStore : IAuthUserStore
{
    private readonly AppDbContext _context;

    public UserAuthStore(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<AuthUser> FindByEmailAsync(string email)
    {
        var user = await _context.User
            .Include(u => u.Memberships)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user is null)
            return null;

        var memberships = user.Memberships?
            .Select(m => new AuthTenantMembership
            {
                TenantId = m.OrganizationId,
                TenantRole = m.Role.ToString()
            })
            .ToList();

        return new AuthUser
        {
            Id = user.Id,
            Email = user.Email,
            PasswordHash = user.Password,
            Role = user.Role.ToString(),
            Memberships = memberships
        };
    }
}
