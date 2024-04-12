using AutoMapper;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Application.Common.Interface.Identity;
using DemoWebApp.Application.Common.Sercurity;
using DemoWebApp.Domain.Entities.Mssql;
using DemoWebApp.Infrastructure.Common.Interface.Infrastructure;
using System.Text;
using DemoWebApp.Application.Common.Constant;

namespace DemoWebApp.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly IUserDataService _userDataService;
        public IdentityService(IUserDataService userDataService,
                               IMapper mapper) 
        {
            _userDataService = userDataService;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUserByUserId(string userId)
        {
            UserEntity userEntity = await _userDataService.GetUserByUserId(userId);
            if (userEntity == null) return null;
            
            UserModel userModel = _mapper.Map<UserModel>(userEntity);
            return userModel;
        }

        public async Task<bool> IsAuthorization(string userId, string password)
        {
            UserEntity user = await _userDataService.GetUserByUserId(userId);

            if (user == null) return false;

            byte[] passwordCipher = CryptedHelper.ConvertSecretValueToByte(password);
            var key = CryptedHelper.ConvertSecretValueToByte(Constants.AES_SECRET_KEY);
            var aesVI = CryptedHelper.ConvertSecretValueToByte(Constants.AES_SECRET_VI);

            var decryptpassword = CryptedHelper.DecryptPassWordAes(passwordCipher, key, aesVI);
            
            // verifing password
            if (password == null) return false;
            if (!password.Equals(decryptpassword)) return false;

            return true;
        }
    }
}
