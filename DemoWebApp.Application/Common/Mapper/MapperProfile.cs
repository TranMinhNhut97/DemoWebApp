using AutoMapper;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Application.Common.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserModel>();
        }
    }
}
