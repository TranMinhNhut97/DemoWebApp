using DemoWebApp.Application.Common.Interface.Application;
using DemoWebApp.Application.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            #region Register service

            service.AddTransient<IUserService, UserService>();
            #endregion

            return service;
        }
    }
}
