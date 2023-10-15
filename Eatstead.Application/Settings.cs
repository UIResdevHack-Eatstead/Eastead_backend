using Eatstead.Application.Services.Abstractions;
using Eatstead.Application.Services.Implementations;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Application.Services.Abstractions;
using Valuegate.Infrastructure.Repositories;

namespace Valuegate.Application
{
    public static class Settings
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ICafeteriaService, CafeteriaService>();

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<UnitOfWork>();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
