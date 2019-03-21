using Microsoft.Extensions.DependencyInjection;
using Redis.Infra.CrossCutting.IoC;

namespace Redis.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            NativeDotNetInjector.Inject(services);
        }
    }
}
