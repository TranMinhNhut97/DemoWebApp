using DemoWebApp.Application.Common.Interface.Application;
using DemoWebApp.Application.Common.Interface.Identity;
using DemoWebApp.Application.Common.Mapping;
using DemoWebApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MapperProfile));

            #region Register service
            service.AddTransient<IUserService, UserService>();
            #endregion

            return service;
        }
    }
}
