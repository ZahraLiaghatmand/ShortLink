using Microsoft.Extensions.DependencyInjection;

namespace ShortLink.Application
{
    public static class ConfigServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
            return services;
        }
    }
}
