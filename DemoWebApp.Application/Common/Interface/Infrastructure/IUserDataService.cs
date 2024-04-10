using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Application.Common.Interface.Infrastructure
{
    public interface IUserDataService
    {
        public Task<List<UserEntity>> GetUserByUserId(string userId);
        public Task<bool> UpdateUserByUserId(UserEntity user, string userId);
    }
}
