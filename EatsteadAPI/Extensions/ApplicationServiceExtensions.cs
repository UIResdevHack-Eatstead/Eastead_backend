using Eatstead.API.Extensions;
using Eatstead.Application.Commands;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using Valuegate.Infrastructure.Data;

namespace Valuegate.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {

            services.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterUserCommand).GetTypeInfo().Assembly));

            services.AddIdentityServices(_config);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });


            return services;
        }

        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
         int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new
            {
                currentPage,
                itemsPerPage,
                totalItems,
                totalPages
            };
            response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationHeader));

        }
    }
}
