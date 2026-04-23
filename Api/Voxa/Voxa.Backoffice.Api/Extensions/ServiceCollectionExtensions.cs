using System.Text;
using Framework.Application.Contracts.Auth;
using Framework.Application.DependencyInjection;
using Framework.AspNetCore.Auth;
using Framework.Infrastructure.Auth;
using Framework.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Voxa.Backoffice.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFramework(
        this IServiceCollection services,
        IDependencyInjectionFrameworkRegistrar appRegistrar,
        IConfiguration configuration)
    {
        new DependencyInjectionFrameworkRegistrar().Register(services, configuration);
        appRegistrar.Register(services, configuration);

        var jwtSettings = configuration.GetSection(AuthJwtSettings.SectionName).Get<AuthJwtSettings>()!;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer           = true,
                    ValidateAudience         = true,
                    ValidateLifetime         = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = jwtSettings.Issuer,
                    ValidAudience            = jwtSettings.Audience,
                    IssuerSigningKey         = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecretKey!)),
                    RoleClaimType            = "role"
                };
            });

        services.AddAuthorization();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentTenant, AuthCurrentTenant>();

        return services;
    }
}
