using Framework.Application.Models.Auth;

namespace Framework.Application.Contracts.Auth;

public interface IAuthJwtService
{
    Task<AuthTokenResponse> AuthenticateAsync(AuthLoginRequest request);
}
