using Framework.Infrastructure.EntityFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Voxa.Domain.Users;
using Voxa.Infrastructure.Data.Persistence;

namespace Voxa.Infrastructure.Data.Repositories;

public class UserRepository : Repository<User, Guid, UserGetParams>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<IList<User>> GetAllAsync(UserGetParams? parameters = null)
    {
        var query = DbSet.AsQueryable();

        if (parameters?.Name is not null)
            query = query.Where(x => x.Name.Contains(parameters.Name));

        if (parameters?.Email is not null)
            query = query.Where(x => x.Email.Contains(parameters.Email));

        return await query.ToListAsync();
    }
}