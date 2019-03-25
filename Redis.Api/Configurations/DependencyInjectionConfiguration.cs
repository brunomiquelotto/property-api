using Microsoft.Extensions.DependencyInjection;
using Redis.Api.Cache;
using Redis.Infra.CrossCutting.IoC;

namespace Redis.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<JsonCache>();
            NativeDotNetInjector.Inject(services);
        }
    }
}
