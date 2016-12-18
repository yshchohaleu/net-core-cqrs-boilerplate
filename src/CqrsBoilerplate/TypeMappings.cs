using AutoMapper;
using CqrsBoilerplate.Entities.Users;
using CqrsBoilerplate.Models.Dto;

namespace CqrsBoilerplate
{
    public static class TypeMappings
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            ConfigureQueriesDto(cfg);
            ConfigureCommandsDto(cfg);
        }

        public static void ConfigureQueriesDto(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserDto, User>();

            cfg.CreateMap<UserInfo, UserInfoDto>();
            cfg.CreateMap<UserDto, User>();
        }

        private static void ConfigureCommandsDto(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserCreateDto, User>();
            cfg.CreateMap<UserInfoCreateDto, UserInfo>();
        }
    }
}
