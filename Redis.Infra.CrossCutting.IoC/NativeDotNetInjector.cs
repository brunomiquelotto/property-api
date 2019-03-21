using Microsoft.Extensions.DependencyInjection;
using Redis.Infra.Data.Context;
using Redis.Infra.Data.Repositories;

namespace Redis.Infra.CrossCutting.IoC
{
    public static class NativeDotNetInjector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped<PropertyRepository>();
        }
    }
}
