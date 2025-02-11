using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.Common.Interfaces;
using System.Reflection;

namespace ShortLink.Application
{
    public static class ConfigServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddTransient<IShortCodeGenerator, ShortCodeGenerator>();

            return services;
        }
    }
}
