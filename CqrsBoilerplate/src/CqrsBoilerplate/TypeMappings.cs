using AutoMapper;
using CqrsBoilerplate.Entities.Users;
using CqrsBoilerplate.Models.Dto;

namespace CqrsBoilerplate
{
    public static class TypeMappings
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserDto, User>();

            cfg.CreateMap<UserInfo, UserInfoDto>();
            cfg.CreateMap<UserDto, User>();
        }
    }
}
