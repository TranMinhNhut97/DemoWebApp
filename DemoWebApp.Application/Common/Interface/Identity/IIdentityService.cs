using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Application.Common.Interface.Identity
{
    public interface IIdentityService
    {
        public Task<UserModel> GetUserByUserId(string userId);

        public Task<bool> IsAuthorization(string userId, string password);
    }
}
