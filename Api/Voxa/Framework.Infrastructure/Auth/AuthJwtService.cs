using Framework.Application.Contracts.Auth;
using Framework.Application.Models.Auth;
using Framework.Domain.Services;
using Microsoft.Extensions.Options;

namespace Framework.Infrastructure.Auth;

public class AuthJwtService : IAuthJwtService
{
    private readonly IAuthUserStore _userStore;
    private readonly IPasswordService _passwordService;
    private readonly IAuthJwtGenerator _jwtGenerator;
    private readonly AuthJwtSettings _settings;

    public AuthJwtService(
        IAuthUserStore userStore,
        IPasswordService passwordService,
        IAuthJwtGenerator jwtGenerator,
        IOptions<AuthJwtSettings> settings)
    {
        _userStore = userStore;
        _passwordService = passwordService;
        _jwtGenerator = jwtGenerator;
        _settings = settings.Value;
    }

    public virtual async Task<AuthTokenResponse> AuthenticateAsync(AuthLoginRequest request)
    {
        var user = await _userStore.FindByEmailAsync(request.Email);
        if (user is null)
            return null;

        if (!_passwordService.Verify(request.Password, user.PasswordHash))
            return null;

        var claims = new Dictionary<string, string>
        {
            ["sub"]   = user.Id.ToString(),
            ["email"] = user.Email,
            ["role"]  = user.Role
        };

        if (request.OrganizationId.HasValue)
        {
            var membership = user.Memberships?
                .FirstOrDefault(m => m.TenantId == request.OrganizationId.Value);

            if (membership is not null)
            {
                claims["tenant_id"]   = membership.TenantId.ToString();
                claims["tenant_role"] = membership.TenantRole;
            }
        }

        var expiration = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes);
        var token = _jwtGenerator.Generate(claims);

        return new AuthTokenResponse { Token = token, Expiration = expiration };
    }
}
