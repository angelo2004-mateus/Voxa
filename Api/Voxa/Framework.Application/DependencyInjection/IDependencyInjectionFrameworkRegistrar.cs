using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application.DependencyInjection;

public interface IDependencyInjectionFrameworkRegistrar
{
    void Register(IServiceCollection services, IConfiguration configuration);
}
