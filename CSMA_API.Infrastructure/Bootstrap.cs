using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSMA_API.Infrastructure
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalonDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(SalonDbContext).Assembly.FullName))
            );
            services.AddScoped<ISalonDbContext>(provider => provider.GetService<SalonDbContext>());

            return services;
        }
    }
}