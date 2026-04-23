using Framework.Application.Models.Auth;

namespace Framework.Application.Contracts.Auth;

public interface IAuthUserStore
{
    Task<AuthUser> FindByEmailAsync(string email);
}
