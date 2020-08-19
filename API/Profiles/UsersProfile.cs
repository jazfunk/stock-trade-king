using AutoMapper;
using Core.Entities;
using API.Models;

namespace API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadModel>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<User, UserUpdateModel>();
        }
    }
}
