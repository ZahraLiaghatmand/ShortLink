using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application
{
    public static class ConfigServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILinkServices, LinkServices>();
            return services;
        }
    }
}
