using AutoMapper;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Application.Common.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserModel>();
        }
    }
}
