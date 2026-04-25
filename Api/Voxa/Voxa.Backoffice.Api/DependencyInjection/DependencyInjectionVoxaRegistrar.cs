using Framework.Application.Contracts.Auth;
using Framework.Application.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Voxa.Application.Services;
using Voxa.Backoffice.Api.ExceptionHandlers;
using Voxa.Domain.Users;
using Voxa.Infrastructure.Auth;
using Voxa.Infrastructure.Data.Persistence;
using Voxa.Infrastructure.Data.Repositories;

namespace Voxa.Backoffice.Api.DependencyInjection;

public class DependencyInjectionVoxaRegistrar : IDependencyInjectionFrameworkRegistrar
{
    public virtual void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UserAppService>();
        services.AddScoped<IAuthUserStore, UserAuthStore>();

        services.AddExceptionHandler<ExceptionHandlerUserEmailAlreadyInUse>();
        services.AddProblemDetails();
    }
}
