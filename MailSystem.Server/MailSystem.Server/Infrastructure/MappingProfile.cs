using AutoMapper;
using MailSystem.Contracts.Authentication;
using MailSystem.Contracts.Couriers;
using MailSystem.Contracts.Users;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;

namespace MailSystem.Server.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapEntities();
            MapContracts();
        }

        private void MapEntities()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            
            CreateMap<Courier, CourierEntity>().ReverseMap();
            CreateMap<CourierPassword, CourierPasswordEntity>().ReverseMap();
            CreateMap<UserPassword, UserPasswordEntity>().ReverseMap();
        }

        private void MapContracts()
        {
            CreateMap<User, UserContract>().ReverseMap();
            CreateMap<User, CreateUserContract>().ReverseMap();
            CreateMap<User, UpdateUserContract>().ReverseMap();
            CreateMap<User, UserRegisterContract>().ReverseMap();
            
            CreateMap<Courier, CourierEntity>().ReverseMap();
            CreateMap<Courier, CourierContract>().ReverseMap();
            CreateMap<Courier, CreateCourierContract>().ReverseMap();
            CreateMap<Courier, UpdateCourierContract>().ReverseMap();
            CreateMap<Courier, CourierRegisterContract>().ReverseMap();
        }
    }
}
