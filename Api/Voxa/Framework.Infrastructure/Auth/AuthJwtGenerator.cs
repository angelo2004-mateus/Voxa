using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Framework.Application.Contracts.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Framework.Infrastructure.Auth;

public class AuthJwtGenerator : IAuthJwtGenerator
{
    private readonly AuthJwtSettings _settings;

    public AuthJwtGenerator(IOptions<AuthJwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public virtual string Generate(Dictionary<string, string> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claimsList = claims.Select(c => new Claim(c.Key, c.Value)).ToList();

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claimsList,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
