using DemoWebApp.Application.Common.Constant;
using DemoWebApp.Application.Common.Interface.Identity;
using DemoWebApp.Infrastructure.Common.Interface.Infrastructure;
using DemoWebApp.Infrastructure.Identity;
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
                options.UseSqlServer(configuration.GetConnectionString(Constants.CONECTIONSTRING_SQLSERVER));
            });
            #endregion
            
            #region Registerer Data Service

            services.AddTransient<IUserDataService, UserDataService>();
            services.AddTransient<IIdentityService, IdentityService>();
            #endregion

            return services;
        }
    }
}
