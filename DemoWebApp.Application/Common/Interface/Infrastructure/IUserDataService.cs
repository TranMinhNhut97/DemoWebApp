using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Infrastructure.Common.Interface.Infrastructure
{
    public interface IUserDataService
    {
        public Task<UserEntity> GetUserByUserId(string userId);
        public Task<bool> UpdateUserByUserId(UserEntity user, string userId);
    }
}
