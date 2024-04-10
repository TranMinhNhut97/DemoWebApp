using DemoWebApp.Application.Common.Interface.Infrastructure;
using DemoWebApp.Infrastructure.Persistence;
using DemoWebApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<CoffeeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
            #endregion
            
            #region Register Data Service

            services.AddTransient<IUserDataService, UserDataService>();
            #endregion
            return services;
        }
    }
}
