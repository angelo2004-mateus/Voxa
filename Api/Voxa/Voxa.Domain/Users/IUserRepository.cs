using Framework.Domain.Repositories;

namespace Voxa.Domain.Users;

public interface IUserRepository : IRepository<User, Guid, UserGetParams>
{
    Task<bool> ExistsByEmailAsync(string email);
}
