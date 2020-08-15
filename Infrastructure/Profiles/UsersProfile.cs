using AutoMapper;
using Core.Entities;
using Infrastructure.Models;

namespace Infrastructure.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadModel>();
        }
    }
}
