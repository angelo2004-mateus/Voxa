using Framework.Application.Contracts.Auth;
using Framework.Application.DependencyInjection;
using Framework.Domain.Services;
using Framework.Infrastructure.Auth;
using Framework.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Infrastructure.DependencyInjection;

public class DependencyInjectionFrameworkRegistrar : IDependencyInjectionFrameworkRegistrar
{
    public virtual void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthJwtSettings>(configuration.GetSection(AuthJwtSettings.SectionName));

        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IAuthJwtGenerator, AuthJwtGenerator>();
        services.AddScoped<IAuthJwtService, AuthJwtService>();
    }
}
