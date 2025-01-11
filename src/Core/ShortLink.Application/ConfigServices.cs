using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShortLink.Application
{
    public static class ConfigServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
