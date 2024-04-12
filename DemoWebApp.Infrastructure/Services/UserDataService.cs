using DemoWebApp.Infrastructure.Persistence;
using DemoWebApp.Domain.Entities.Mssql;
using DemoWebApp.Infrastructure.Common.Interface.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Infrastructure.Services
{
    public class UserDataService : IUserDataService
    {
        private CoffeeDbContext _dbContext;

        public UserDataService(CoffeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateUserByUserId(UserEntity userEntity, string userId)
        {
            _dbContext.Attach(userEntity);
            _dbContext.Entry(userEntity).Property(x=> x.UserName).IsModified = true;
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserEntity> GetUserByUserId(string userId)
        {
            return await _dbContext.Users.AsNoTracking()
                                         .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
