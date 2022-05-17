using AutoMapper;
using MailSystem.Contracts.Users;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;

namespace MailSystem.Server.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<User, UserContract>().ReverseMap();
            CreateMap<User, CreateUserContract>().ReverseMap();
            CreateMap<User, UpdateUserContract>().ReverseMap();
        }
    }
}