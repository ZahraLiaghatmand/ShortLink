using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.Common.Interfaces;

namespace ShortLink.Infrastructure.Persistence
{
    public static class ConfigServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
