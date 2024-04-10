using DemoWebApp.Application.Common.Entities;

namespace DemoWebApp.Application.Common.Interface.Application
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetUsersByUserId(string userId);
    }
}
