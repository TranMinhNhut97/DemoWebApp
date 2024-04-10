using AutoMapper;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Application.Common.Interface.Application;
using DemoWebApp.Application.Common.Interface.Infrastructure;
using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Application.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserDataService _userDataService;
        private readonly IMapper _mapper;

        public UserService(IUserDataService userDataService,
                           IMapper mapper)
        {
            _userDataService = userDataService;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetUsersByUserId(string userId)
        {
            List<UserEntity> userEntities = await _userDataService.GetUserByUserId(userId);
            List<UserModel> users = _mapper.Map<List<UserModel>>(userEntities);
            return users;
        }
    }
}
